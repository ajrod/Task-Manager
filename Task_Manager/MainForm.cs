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

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Task_Manager
{
    /// <summary>
    /// The main window of the task manager.
    /// </summary>
    public partial class MainForm : Form
    {


        /// <summary>
        /// True iff the current task entered by the user is a valid task.
        /// </summary>
        private bool acceptTask;
        /// <summary>
        /// The Database of existing tasks.
        /// </summary>
        public static TaskDataBase TaskData;
        /// <summary>
        /// The possible filters that can be applied to the task list.
        /// </summary>
        public static string[] filters;
        /// <summary>
        /// True iff the applicaton is in an idle state.
        /// </summary>
        public static bool idle = false;
        /// <summary>
        /// The idle counter.
        /// </summary>
        private int idleTime = 0;
        /// <summary>
        /// True iff the application should exit.
        /// </summary>
        private bool exit = false;
        /// <summary>
        /// The GUI component for the list of filter checkboxs.
        /// </summary>
        public static CheckedListBox FilterList;
        /// <summary>
        /// The GUI component for the list of tasks.
        /// </summary>
        public static ListView ViewableTasks;
        /// <summary>
        /// The location of the last selected task in the task list.
        /// </summary>
        private int lastselectedIndex = 0;
        /// <summary>
        /// True iff there is a last selected task.
        /// </summary>
        private bool lastselected = false;

        public const int MIN_TAG_LENGTH = 3; //min length for a tag
        public const int MIN_TASKBOX_LENGTH = 1; //min length for task information
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {

            Initialize();
            AddEventHandlers();
            ///attempts to load previous tasks
            this.restore();
            TaskData.SetRemindersLeft();
            this.Notify();
        }

        /// <summary>
        /// Initializes the mainform.
        /// </summary>
        private void Initialize()
        {
            InitializeComponent();
            this.initializeLists();
            TaskManagerIcon.Visible = true;
            this.MaximizeBox = false;
            ViewableTasks.ContextMenuStrip = taskContextMenuStrip;
            //ViewableTasks.HideSelection = false;
            addNotesSuggestionLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            filters = new string[9] { "All",
                "Today",
                "Next 5 Days",
                "Current Week",
                "Next Week",
                "Current Month",
                "Completed",
                "Not Completed",
                "Over Due",
            };
            TaskData = new TaskDataBase(FilterList, filters);
        }
        /// <summary>
        /// Adds the event handlers required.
        /// </summary>
        private void AddEventHandlers()
        {
            ViewableTasks.KeyDown += new KeyEventHandler(ViewableTasks_KeyDown);
            ViewableTasks.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(UpdateSelectionInterface);
            this.noteEditor.TextChanged += new System.EventHandler(this.ChangeNotes);
            FilterList.MouseUp += new MouseEventHandler(FilterTaskList);
            FilterList.ItemCheck += new ItemCheckEventHandler(FilterList_ItemCheck);
            this.TagBox.TextChanged += new System.EventHandler(CheckInput);
            this.taskBox.TextChanged += new System.EventHandler(CheckInput);
            ViewableTasks.KeyDown += new KeyEventHandler(DeleteTask);
            FilterList.EnabledChanged += new System.EventHandler(UpdateTagBox);
            this.ReminderOn.MouseUp += new MouseEventHandler(ToggleReminderSelection);
            this.setCompletionStatus.MouseUp += new MouseEventHandler(ToggleCompletedStatus);
            this.pickDaysReminderBox.ValueChanged += new System.EventHandler(SetReminderDays);
            this.emailComboBox.TextChanged += new System.EventHandler(EmailTextChanged);
            this.FormClosing += new FormClosingEventHandler(FormClosing_Event);
            Application.Idle += new System.EventHandler(SetApplicationIdle);
        }

        /// <summary>
        /// Initializes and sets up the GUI components for the lists.
        /// </summary>
        private void initializeLists()
        {
            FilterList = new System.Windows.Forms.CheckedListBox();
            ViewableTasks = new System.Windows.Forms.ListView();

            //
            // FilterList
            //
            FilterList.CheckOnClick = true;
            FilterList.FormattingEnabled = true;
            FilterList.Location = new System.Drawing.Point(511, 95);
            FilterList.Name = "FilterList";
            FilterList.Size = new System.Drawing.Size(227, 229);
            FilterList.TabIndex = 0;
            //
            // ViewableTasks
            //
            ViewableTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.taskDate,
            this.taskTag,
            this.task});
            ViewableTasks.FullRowSelect = true;
            ViewableTasks.Location = new System.Drawing.Point(37, 95);
            ViewableTasks.Name = "ViewableTasks";
            ViewableTasks.ShowItemToolTips = true;
            ViewableTasks.Size = new System.Drawing.Size(437, 419);
            ViewableTasks.TabIndex = 7;
            ViewableTasks.UseCompatibleStateImageBehavior = false;
            ViewableTasks.View = System.Windows.Forms.View.Details;

            this.Controls.Add(ViewableTasks);
            this.Controls.Add(FilterList);
        }

        /// <summary>
        /// Handles the KeyDown event of the ViewableTasks control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void ViewableTasks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if (ViewableTasks.SelectedItems.Count == 1)
                {
                    lastselected = true;
                    lastselectedIndex = ViewableTasks.SelectedIndices[0];
                }
            }
        }

        /// <summary>
        /// Handles the ItemCheck event of the FilterList control. Toggle the clicked filter's check box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        private void FilterList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == System.Windows.Forms.CheckState.Unchecked)
            {
                if (e.Index != 0)
                {
                    FilterList.SetItemChecked(0, false);
                }
                else
                {
                    //user must have selected the first filter; clear all others
                    int ct = 1;
                    while (ct < FilterList.Items.Count)
                    {
                        FilterList.SetItemChecked(ct, false);
                        ++ct;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the application as idle.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SetApplicationIdle(object sender, System.EventArgs e)
        {
            if (!idle)
            {
                idleTime = 0;
                idle = true;
            }
        }

        /// <summary>
        /// Handles the Event event of the form closing control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void FormClosing_Event(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                TaskManagerIcon.Visible = true;
                idle = false;
                this.Visible = false;
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Handle the event of the email text changing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void EmailTextChanged(object sender, System.EventArgs e)
        {
            idle = false;
            TaskData.SearchTasksBySelectedItem(ViewableTasks).reminderEmail = emailComboBox.Text;
            TaskData.SetMostUsedEmail();
            TaskData.Save();
        }

        /// <summary>
        /// Sets the number of days to be reminded for the current task.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SetReminderDays(object sender, System.EventArgs e)
        {
            idle = false;
            TaskData.SearchTasksBySelectedItem(ViewableTasks).daysOfReminder = (int)pickDaysReminderBox.Value;
            TaskData.Save();
        }

        /// <summary>
        /// Toggles the reminder checkbox for the current task.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToggleReminderSelection(object sender, System.EventArgs e)
        {
            idle = false;
            settingPanel2.Enabled = ReminderOn.Checked;
            pickDaysReminderBox.Enabled = ReminderOn.Checked;
            Task tmp = TaskData.SearchTasksBySelectedItem(ViewableTasks);
            tmp.reminder = ReminderOn.Checked;
            tmp.reminderEmail = emailComboBox.Text;
            TaskData.Save();
        }

        /// <summary>
        /// Toggles the completed status checkbox.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToggleCompletedStatus(object sender, System.EventArgs e)
        {
            idle = false;
            Task tmp = TaskData.SearchTasksBySelectedItem(ViewableTasks);
            tmp.completed = setCompletionStatus.Checked;
            Task.SetItemVisuals(ViewableTasks.SelectedItems[0], tmp);
            ViewableTasks.SelectedItems[0].ForeColor = System.Drawing.Color.White;
            ViewableTasks.SelectedItems[0].BackColor = System.Drawing.Color.Blue;

            TaskData.Save();
        }

        /// <summary>
        /// Updates the tag box.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void UpdateTagBox(object sender, System.EventArgs e)
        {
            idle = false;
            if (FilterList.Enabled)
            {
                TagBox.Items.Clear();
                List<string> existingTags = ArrayToList(filters);
                int ct = 0;
                //search existing tags to allow for convenient auto-completion
                while (ct < FilterList.Items.Count)
                {
                    if (!existingTags.Contains(FilterList.Items[ct].ToString()))
                    {
                        TagBox.Items.Add(FilterList.Items[ct].ToString());
                    }
                    ++ct;
                }
            }
        }

        /// <summary>
        /// Return a list containing the string contents of an array.
        /// </summary>
        /// <param name="strings">The array of strings.</param>
        /// <returns></returns>
        private List<string> ArrayToList(string[] strings)
        {
            List<string> list = new List<string>();
            int ct = 0;
            while (ct < strings.Length)
            {
                list.Add(strings[ct]);
                ++ct;
            }
            return list;
        }

        /// <summary>
        /// Deletes the tasks selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void DeleteTask(object sender, KeyEventArgs e)
        {
            idle = false;
            if (e.KeyCode == Keys.Delete && ViewableTasks.SelectedItems.Count > 0)
            {
                TaskData.DeleteSelectedTasks(ViewableTasks, FilterList, filters);
                noteEditor.Enabled = false;
                noteEditor.Text = "";
                addNotesSuggestionLabel.Visible = true;
                settingsPanel.Enabled = false;
            }
        }

        /// <summary>
        /// Checks the user input for creating a new task.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckInput(object sender, System.EventArgs e)
        {
            idle = false;
            if (!datePicker.Checked || TagBox.Text.Length < MIN_TAG_LENGTH || taskBox.Text.Length < MIN_TASKBOX_LENGTH)
            {
                acceptTask = false;
                this.AddTask.Cursor = System.Windows.Forms.Cursors.No;
            }
            else
            {
                acceptTask = true;
                this.AddTask.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the Click event of the AddTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AddTask_Click(object sender, System.EventArgs e)
        {
            //Don't add user does not have valid input
            if (!acceptTask) return;

            Task newTask = new Task(datePicker.Value, TagBox.Text, taskBox.Text);
            //If tasks are empty append to task list
            if (TaskData.IsEmpty())
            {
                TaskData.AddTask(newTask);
            }
            else
            {
                //Check if task already exists
                if (!TaskData.Contains(newTask))
                {
                    TaskData.InsertTask(newTask);
                }
            }

            //Update viewable task list
            TaskData.UpdateTaskList(ViewableTasks, FilterList);
            SetSelectedIndexOfTask(newTask);
            TaskData.Save();
            taskBox.Text = "";
        }

        /// <summary>
        /// Sets the selected index to the task.
        /// </summary>
        /// <param name="task">The t.</param>
        public static void SetSelectedIndexOfTask(Task task)
        {
            int ct = 0;
            //search for the task in the list and set the focus to it
            while (ct < ViewableTasks.Items.Count)
            {
                if (task.date.ToShortDateString() == ViewableTasks.Items[ct].SubItems[0].Text
                    && task.tag == ViewableTasks.Items[ct].SubItems[1].Text
                    && task.task == ViewableTasks.Items[ct].SubItems[2].Text)
                {
                    ViewableTasks.Items[ct].Selected = true;
                    ViewableTasks.Items[ct].Focused = true;
                    return;
                }
                ++ct;
            }
        }

        /// <summary>
        /// Filters the task list by the current filters selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FilterTaskList(object sender, System.EventArgs e)
        {
            idle = false;
            TaskData.UpdateTaskList(ViewableTasks, FilterList);
            noteEditor.Enabled = false;
            noteEditor.Text = "";
            settingsPanel.Enabled = false;
            addNotesSuggestionLabel.Visible = true;
        }

        /// <summary>
        /// Updates the selection interface.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void UpdateSelectionInterface(object sender, System.EventArgs e)
        {
            idle = false;
            noteEditor.Enabled = false;
            addNotesSuggestionLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            noteEditor.Text = "";
            settingsPanel.Enabled = false;
            TaskData.UpdateEmailSuggestions(emailComboBox);
            ViewableTasks.ContextMenuStrip.Items[0].Enabled = false;
            if (!(ViewableTasks.SelectedItems.Count == 0 || ViewableTasks.SelectedItems.Count > 1))
            {
                //undo previous selected high light
                ViewableTasks.ContextMenuStrip.Items[0].Enabled = true;
                this.RefreshVisuals(lastselected);
                lastselected = false;
                //manually high light selected item
                ViewableTasks.SelectedItems[0].ForeColor = System.Drawing.Color.White;
                ViewableTasks.SelectedItems[0].BackColor = System.Drawing.Color.Blue;
                addNotesSuggestionLabel.BackColor = System.Drawing.Color.White;
                noteEditor.Enabled = true;
                Task selectedTask = TaskData.SearchTasksBySelectedItem(ViewableTasks);
                if (selectedTask.notes.Length == 0)
                {
                    addNotesSuggestionLabel.Visible = true;
                }
                else
                {
                    noteEditor.Text = selectedTask.notes;
                    addNotesSuggestionLabel.Visible = false;
                }

                settingsPanel.Enabled = true;
                ReminderOn.Checked = selectedTask.reminder;
                setCompletionStatus.Checked = selectedTask.completed;
                settingPanel2.Enabled = ReminderOn.Checked;
                if (selectedTask.reminderEmail.Length > 0)
                {
                    emailComboBox.Text = selectedTask.reminderEmail;
                }
                this.pickDaysReminderBox.Enabled = ReminderOn.Checked;
                this.pickDaysReminderBox.Value = selectedTask.daysOfReminder;
            }
        }

        /// <summary>
        /// Changes the note for the current task.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ChangeNotes(object sender, System.EventArgs e)
        {
            idle = false;
            if (noteEditor.Enabled)
            {
                addNotesSuggestionLabel.Visible = false;
                TaskData.SearchTasksBySelectedItem(ViewableTasks).notes = noteEditor.Text;
                TaskData.Save();
            }
        }

        /// <summary>
        /// Attempt to load previous task data.
        /// </summary>
        private void restore()
        {
            TaskData.Load(ViewableTasks, FilterList, filters);
            ViewableTasks.SelectedItems.Clear();
            noteEditor.Enabled = false;
            noteEditor.Text = "";
        }

        /// <summary>
        /// Notifies this instance. Sends e-mail reminders and updates the task list.
        /// </summary>
        private void Notify()
        {
            if (!TaskData.HasRemindersLeft()) return;
            Thread oThread = new Thread(new ThreadStart(TaskData.CheckReminders));
            oThread.Start();
            TaskData.UpdateTaskList(ViewableTasks, FilterList);
        }

        /// <summary>
        /// Handles the Click event of the OpenTaskManagerToolStripMenuItem control. Opens the mainform.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OpenTaskManagerToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Visible = true;
        }

        /// <summary>
        /// Handles the Click event of the ExitToolStripMenuItem control. Closes the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            exit = true;
            TaskData.Save();
            TaskManagerIcon.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// Refreshes the visuals of the mainform.
        /// </summary>
        /// <param name="lastselected">if set to <c>true</c> [lastselected].</param>
        private void RefreshVisuals(bool lastselected = false)
        {
            if (lastselected)
            {
                Task.SetItemVisuals(ViewableTasks.Items[this.lastselectedIndex],
                    TaskData.SearchTasksByItem(ViewableTasks.Items[this.lastselectedIndex]));
                ViewableTasks.Items[this.lastselectedIndex].ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                int ct = 0;
                while (ct < ViewableTasks.Items.Count)
                {
                    Task.SetItemVisuals(ViewableTasks.Items[ct], TaskData.SearchTasksByItem(ViewableTasks.Items[ct]));
                    ViewableTasks.Items[ct].ForeColor = System.Drawing.Color.Black;
                    ++ct;
                }
            }
        }

        /// <summary>
        /// Handles the Tick event of the IdleTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void IdleTimer_Tick(object sender, EventArgs e)
        {
            if (idle)
            {
                idleTime += 1;
                if (idleTime > 60)
                {
                    idleTime = 0;
                    this.Notify();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ClearFilterButton control. 
        /// Clear all filters and update the task list to show all tasks.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            int ct = 0;
            while (ct < FilterList.Items.Count)
            {
                FilterList.SetItemChecked(ct, false);
                ++ct;
            }
            TaskData.UpdateTaskList(ViewableTasks, FilterList);
        }

        /// <summary>
        /// Handles the Click event of the DeleteToolStripMenuItem control. Deletes all selected tasks.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idle = false;
            TaskData.DeleteSelectedTasks(ViewableTasks, FilterList, filters);
            noteEditor.Enabled = false;
            noteEditor.Text = "";
            addNotesSuggestionLabel.Visible = true;
        }

        /// <summary>
        /// Handles the Click event of the EditToolStripMenuItem control. Edits an already existing task.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task task = TaskData.SearchTasksBySelectedItem(ViewableTasks);
            EditTaskForm edit = new EditTaskForm(task);

            edit.editDateTimePicker.Text = task.date.ToShortDateString();
            edit.editTagBox.Text = task.tag;
            edit.editTaskBox.Text = task.task;
            int ct = 0;
            while (ct < this.TagBox.Items.Count)
            {
                edit.editTagBox.Items.Add(this.TagBox.Items[ct]);
                ++ct;
            }

            this.Enabled = false;
            edit.ShowDialog();
            this.Enabled = true;
        }
    }
}