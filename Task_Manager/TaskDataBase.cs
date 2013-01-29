//Copyright (C) 2013 <copyright holders>
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this 
//software and associated documentation files (the "Software"), to deal in the Software without 
//restriction, including without limitation the rights to use, copy, modify, merge, publish, 
//distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom 
//the Software is furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all copies or 
//substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
//PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR 
//ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
//SOFTWARE.

//Author: Alex Rodrigues

namespace Task_Manager
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// The database of tasks.
    /// </summary>
    public class TaskDataBase
    {
        /// <summary>
        /// The list of existing tasks.
        /// </summary>
        private static List<Task> taskList;
        /// <summary>
        /// The list of filters that can be applied to the tasks.
        /// </summary>
        private static List<string> filters;
        /// <summary>
        /// True iff their are scheduled reminders left.
        /// </summary>
        private bool remindersLeft = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskDataBase"/> class.
        /// </summary>
        /// <param name="filterList">The filter list.</param>
        /// <param name="tags">The tags.</param>
        public TaskDataBase(CheckedListBox filterList, string[] tags)
        {
            filters = new List<string>();
            SetDefaultFilters(filterList, tags);
            taskList = new List<Task>();
        }

        /// <summary>
        /// Sets the default filters.
        /// </summary>
        /// <param name="filterList">The filter list.</param>
        /// <param name="tags">The tags.</param>
        private void SetDefaultFilters(CheckedListBox filterList, string[] tags)
        {
            bool[] defaultChecks = new bool[9];
            defaultChecks[0] = true;
            AddFilters(filterList, tags, defaultChecks);
        }
        /// <summary>
        /// Determines whether any tasks [has reminders left].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has reminders left]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasRemindersLeft()
        {
            return remindersLeft;
        }
        /// <summary>
        /// Adds the filters to the filter list.
        /// </summary>
        /// <param name="filterList">The filter list.</param>
        /// <param name="tags">The tags.</param>
        /// <param name="checkedStates">The list of checked states for the tags.</param>
        private void AddFilters(CheckedListBox filterList, string[] tags, bool[] checkedStates)
        {
            int ct = 0;
            while (ct < tags.Length)
            {
                _addFilter(filterList, tags[ct], checkedStates[ct]);
                ++ct;
            }
        }

        private void _addFilter(CheckedListBox filterList, string tag, bool check)
        {
            filters.Add(tag);
            filterList.Items.Add(tag, check);
        }

        /// <summary>
        /// Return the number of existing tasks.
        /// </summary>
        /// <returns>The number of existing tasks.</returns>
        public int NumberofTasks()
        {
            return taskList.Count;
        }

        /// <summary>
        /// Determines whether their are no tasks.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if their are no tasks; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEmpty()
        {
            return taskList.Count == 0;
        }

        /// <summary>
        /// Adds the task to the list of tasks.
        /// </summary>
        /// <param name="task">The task.</param>
        public void AddTask(Task task)
        {
            taskList.Add(task);
        }

        /// <summary>
        /// Determines whether the task list [contains] [the specified task].
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>
        ///   <c>true</c> if the task list [contains] [the specified task]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Task task)
        {
            foreach (Task otherTask in taskList)
            {
                if (otherTask.date.ToShortDateString() == task.date.ToShortDateString()
                    && otherTask.tag == task.tag
                    && otherTask.task == task.task)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Inserts the task the task into the task list in order of date.
        /// </summary>
        /// <param name="task">The task.</param>
        public void InsertTask(Task task)
        {
            int i = 0;
            while (i < taskList.Count)
            {
                if (task.date.Ticks < taskList[i].date.Ticks)
                {
                    taskList.Insert(i, task);
                    return;
                }

                i += 1;
            }
            this.AddTask(task);
        }

        /// <summary>
        /// Updates the task list.
        /// </summary>
        /// <param name="viewAbleList">The view able list of tasks.</param>
        /// <param name="filterList">The list of filters.</param>
        /// <param name="draw">if set to <c>true</c> [draw].</param>
        public void UpdateTaskList(ListView viewAbleList, CheckedListBox filterList, bool draw = true)
        {
            filterList.Enabled = false;
            viewAbleList.Items.Clear();
            int i = 0;
            int listIndex = 0;
            while (i < taskList.Count)
            {
                if (AcceptTask(filterList.CheckedItems, taskList[i]) & draw)
                {
                    taskList[i].Add(viewAbleList, listIndex);
                    listIndex += 1;
                }

                if (!filters.Contains(taskList[i].tag))
                {
                    filters.Insert(MainForm.filters.Length - 3, taskList[i].tag);
                    filterList.Items.Insert(MainForm.filters.Length - 3, taskList[i].tag);
                }

                ++i;
            }
            filterList.Enabled = true;
        }

        /// <summary>
        /// Returns true if the task passes the current filters selected.
        /// </summary>
        /// <param name="activeFilters">The active filters.</param>
        /// <param name="task">The task.</param>
        /// <returns>True iff the task passes the current filters selected.</returns>
        private bool AcceptTask(CheckedListBox.CheckedItemCollection activeFilters, Task task)
        {
            if (activeFilters.Contains("All") || activeFilters.Contains(task.tag))
            {
                return true;
            }
            else if (activeFilters.Contains("Today") && task.date.Date == System.DateTime.Today)
            {
                return true;
            }
            else if (activeFilters.Contains("Next 3 Days")
                && (task.date.Date <= System.DateTime.Today.AddDays(3))
                && task.date.Date >= System.DateTime.Today)
            {
                return true;
            }
            else if (activeFilters.Contains("Next 5 Days")
                && (task.date.Date <= System.DateTime.Today.AddDays(5))
                && task.date.Date >= System.DateTime.Today)
            {
                return true;
            }
            else if (activeFilters.Contains("Current Month") && task.date.Month == System.DateTime.Today.Month)
            {
                return true;
            }

            else if (activeFilters.Contains("Current Week"))
            {
                int offset = GetDayOfTheWeekOffset();
                if (task.date.Date >= System.DateTime.Today.AddDays(-offset).Date
                    && task.date.Date <= System.DateTime.Today.AddDays(6 - offset).Date)
                {
                    return true;
                }
            }
            else if (activeFilters.Contains("Next Week"))
            {
                int offset = GetDayOfTheWeekOffset();
                if (task.date.Date >= System.DateTime.Today.AddDays(-offset + 7).Date
                    && task.date.Date <= System.DateTime.Today.AddDays(6 - offset + 7).Date)
                {
                    return true;
                }
            }
            else if (activeFilters.Contains("Completed") && task.completed)
            {
                if (activeFilters.Count == 1)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else if (activeFilters.Contains("Not Completed") && !task.completed)
            {
                return true;
            }
            else if (activeFilters.Contains("Over Due") && !task.completed && task.date.Date < System.DateTime.Today.Date)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the day of the week offset.
        /// </summary>
        /// <returns>The offset</returns>
        private int GetDayOfTheWeekOffset()
        {
            int offset;
            if (System.DateTime.Today.DayOfWeek == System.DayOfWeek.Sunday)
            {
                offset = 0;
            }
            else if (System.DateTime.Today.DayOfWeek == System.DayOfWeek.Monday)
            {
                offset = 1;
            }
            else if (System.DateTime.Today.DayOfWeek == System.DayOfWeek.Tuesday)
            {
                offset = 2;
            }
            else if (System.DateTime.Today.DayOfWeek == System.DayOfWeek.Wednesday)
            {
                offset = 3;
            }
            else if (System.DateTime.Today.DayOfWeek == System.DayOfWeek.Thursday)
            {
                offset = 4;
            }
            else if (System.DateTime.Today.DayOfWeek == System.DayOfWeek.Friday)
            {
                offset = 5;
            }
            else
            {
                offset = 6;
            }
            return offset;
        }

        /// <summary>
        /// Searches the tasks by a GUI item in the viewable task list.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public Task SearchTasksByItem(ListViewItem item)
        {
            Task matchingTask = null;
            foreach (Task t in taskList)
            {
                if (t.date.ToShortDateString() == item.SubItems[0].Text
                    && t.tag == item.SubItems[1].Text
                    && t.task == item.SubItems[2].Text)
                {
                    matchingTask = t;
                    break;
                }
            }
            return matchingTask;
        }

        /// <summary>
        /// Searches the tasks by the current selected task in the GUI.
        /// </summary>
        /// <param name="viewAbleList">The view able list.</param>
        /// <returns></returns>
        public Task SearchTasksBySelectedItem(ListView viewAbleList)
        {
            return this.SearchTasksByItem(viewAbleList.SelectedItems[0]);
        }

        /// <summary>
        /// Deletes the selected tasks.
        /// </summary>
        /// <param name="viewAbleList">The view able list.</param>
        /// <param name="filterList">The filter list.</param>
        /// <param name="tags">The tags.</param>
        public void DeleteSelectedTasks(ListView viewAbleList, CheckedListBox filterList, string[] tags)
        {
            List<string> preservedFilterChecks = GetFiltersSelected(filterList);
            filterList.Items.Clear();
            filters.Clear();
            SetDefaultFilters(filterList, tags);

            int i = 0;
            while (i < taskList.Count)
            {
                int j = 0;
                while (j < viewAbleList.SelectedItems.Count)
                {
                    if (taskList[i].date.ToShortDateString() == viewAbleList.SelectedItems[j].SubItems[0].Text
                         && taskList[i].tag == viewAbleList.SelectedItems[j].SubItems[1].Text
                         && taskList[i].task == viewAbleList.SelectedItems[j].SubItems[2].Text)
                    {
                        taskList.RemoveAt(i);
                        i -= 1;
                        break;
                    }
                    ++j;
                }
                ++i;
            }
            UpdateTaskList(viewAbleList, filterList, false);
            i = 0;
            while (i < filterList.Items.Count)
            {
                if (preservedFilterChecks.Contains(filterList.Items[i].ToString()))
                {
                    filterList.SetItemChecked(i, true);
                }
                ++i;
            }
            UpdateTaskList(viewAbleList, filterList);
            this.Save();
        }

        /// <summary>
        /// Gets the current filters selected.
        /// </summary>
        /// <param name="filterList">The filter list.</param>
        /// <returns></returns>
        public List<string> GetFiltersSelected(CheckedListBox filterList)
        {
            List<string> filtersSelected = new List<string>();
            int ct = 0;
            while (ct < filterList.CheckedItems.Count)
            {
                filtersSelected.Add(filterList.CheckedItems[ct].ToString());
                ++ct;
            }
            return filtersSelected;
        }

        /// <summary>
        /// Saves the task data to file.
        /// </summary>
        public void Save()
        {
            SerializableTaskData data = new SerializableTaskData(taskList);
            SaveLoadEngine.Save(data, "data");
        }

        /// <summary>
        /// Loads the task data from file.
        /// </summary>
        /// <param name="viewAbleList">The view able list.</param>
        /// <param name="filterList">The filter list.</param>
        /// <param name="tags">The tags.</param>
        /// <returns></returns>
        public bool Load(ListView viewAbleList, CheckedListBox filterList, string[] tags)
        {
            bool fileExists = true;
            SerializableTaskData savedData = SaveLoadEngine.Load("data", ref fileExists);

            if (fileExists)
            {
                filterList.Items.Clear();
                filters.Clear();
                SetDefaultFilters(filterList, tags);
                taskList.Clear();
                taskList = savedData.taskList;
                if (taskList == null) taskList = new List<Task>();
                UpdateTaskList(viewAbleList, filterList);
            }

            return fileExists;
        }

        /// <summary>
        /// Checks the reminders and sends reminders if needed.
        /// </summary>
        public void CheckReminders()
        {
            Email email = new Email();
            foreach (Task task in taskList)
            {
                if (task.reminder && task.date.AddDays(-task.daysOfReminder).Date == System.DateTime.Today.Date
                    && ValidateEmail(task.reminderEmail))
                {
                    if (SendReminder(task, email))
                    {
                        break;
                    }
                }
            }
            this.Save();
            this.SetRemindersLeft();
        }

        /// <summary>
        /// Sends a reminder for the task.
        /// </summary>
        /// <param name="task">The t.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        private bool SendReminder(Task task, Email email)
        {
            bool reminderSucceeded = true;
            string subject = "REMINDER: " + task.tag + " - " + task.task;
            string body;

            if (task.daysOfReminder == 0)
            {
                body = "Your deadline is today, " + task.date.ToLongDateString() + " for \"" + task.tag + " - " + task.task + "\".";
            }
            else if (task.daysOfReminder == 1)
            {
                if (task.completed)
                {
                    body = "You have 1 day to until your deadline \"" + task.tag + " - " + task.task
                        + "\".\nThat is your deadline is tommorow, " + task.date.ToLongDateString() + ".";
                }
                else
                {
                    body = "You have 1 day to complete \"" + task.tag + " - " + task.task
                         + "\".\nThat is your deadline is tommorow, " + task.date.ToLongDateString() + ".";
                }
            }
            else
            {
                if (task.completed)
                {
                    body = "You have " + task.daysOfReminder.ToString() + " days to until your deadline \"" + task.tag + " - " + task.task
                        + "\".\nThat is your deadline is, " + task.date.ToLongDateString() + ".";
                }
                else
                {
                    body = "You have " + task.daysOfReminder.ToString() + " days to complete \"" + task.tag + " - " + task.task
                        + "\".\nThat is your deadline is, " + task.date.ToLongDateString() + ".";
                }
            }
            if (task.notes.Length > 0)
            {
                body += "\n\nYour notes are provided below.\n";
                body += "-----------------------------------------------\n";
                body += task.notes;
                body += "\n-----------------------------------------------";
            }
            body += "\n\nThis Message is brought to you by Task Manager.";
            email.Send(subject, body, task.reminderEmail, ref reminderSucceeded);
            if (reminderSucceeded)
            {
                task.reminder = false;
            }

            return reminderSucceeded;
        }

        /// <summary>
        /// Updates the list of email suggestions.
        /// </summary>
        /// <param name="emailComboBox">The email combo box.</param>
        public void UpdateEmailSuggestions(ComboBox emailComboBox)
        {
            foreach (Task task in taskList)
            {
                if (ValidateEmail(task.reminderEmail) && !emailComboBox.Items.Contains(task.reminderEmail))
                {
                    emailComboBox.Items.Add(task.reminderEmail);
                }
            }
        }

        /// <summary>
        /// Does very basic validation for the e-mail.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public bool ValidateEmail(string email)
        {
            return email.Length > 6 && email.Contains("@");
        }

        /// <summary>
        /// Sets the most email used the most in reminders.
        /// </summary>
        public void SetMostUsedEmail()
        {
            Dictionary<string, int> emailFrequency = new Dictionary<string, int>();
            foreach (Task task in taskList)
            {
                if (ValidateEmail(task.reminderEmail))
                {
                    if (!emailFrequency.ContainsKey(task.reminderEmail))
                    {
                        emailFrequency[task.reminderEmail] = 1;
                    }
                    else
                    {
                        emailFrequency[task.reminderEmail] += 1;
                    }
                }
            }
            string email = string.Empty;
            int frequency = 0;
            foreach (string e in emailFrequency.Keys)
            {
                if (emailFrequency[e] > frequency)
                {
                    frequency = emailFrequency[e];
                    email = e;
                }
            }

            if (email != string.Empty)
            {
                foreach (Task t in taskList)
                {
                    if (t.reminderEmail.Length == 0)
                    {
                        t.reminderEmail = email;
                    }
                }
            }
        }

        /// <summary>
        /// Checks and sets if their are reminders still scheduled.
        /// </summary>
        public void SetRemindersLeft()
        {
            foreach (Task task in taskList)
            {
                if (task.reminder)
                {
                    remindersLeft = true;
                    return;
                }
            }
            remindersLeft = false;
        }
    }
}