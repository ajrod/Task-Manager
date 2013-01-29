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
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// A scheduled task. This can be a deadline or an assignment and anything in between.
    /// </summary>
    [Serializable]
    public class Task
    {
        /// <summary>
        /// Gets or sets the unique tag assigned to this tag. To be used in filtering.
        /// </summary>
        /// <value>
        /// The unique tag assigned to this tag. To be used in filtering.
        /// </value>
        public String tag { get; set; }
        /// <summary>
        /// Gets or sets the date of the task.
        /// </summary>
        /// <value>
        /// The date for this task.
        /// </value>
        public DateTime date { get; set; }
        /// <summary>
        /// Gets or sets the task information.
        /// </summary>
        /// <value>
        /// The task information.
        /// </value>
        public String task { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The additional notes for the task.
        /// </value>
        public string notes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Task"/> has a reminder.
        /// </summary>
        /// <value>
        ///   <c>true</c> if a reminder should be sent; otherwise, <c>false</c>.
        /// </value>
        public bool reminder { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Task"/> is completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.
        /// </value>
        public bool completed { get; set; }
        /// <summary>
        /// Gets or sets the number of days a reminder should be sent before the deadline.
        /// </summary>
        /// <value>
        /// The number of days a reminder should be sent before the deadline.
        /// </value>
        public int daysOfReminder { get; set; }
        /// <summary>
        /// Gets or sets the email that the reminder should be sent too.
        /// </summary>
        /// <value>
        /// The email that the reminder should be sent too
        /// </value>
        public String reminderEmail { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="task">The task.</param>
        public Task(DateTime date, String tag, String task)
        {
            reminder = false;
            completed = false;
            daysOfReminder = 2;
            reminderEmail = String.Empty;
            this.date = date;
            this.tag = tag;
            this.task = task;
            this.notes = "";
        }

        /// <summary>
        /// Adds the task to the list view at the index given.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="index">The index for insertion.</param>
        public void Add(ListView list, int index)
        {
            list.Items.Insert(index, date.ToShortDateString());
            list.Items[index].SubItems.Add(tag);
            list.Items[index].SubItems.Add(task);
            Task.SetItemVisuals(list.Items[index], this);
        }

        /// <summary>
        /// Sets the list item visuals for the specified task.
        /// </summary>
        /// <param name="item">The list item.</param>
        /// <param name="task">The task.</param>
        public static void SetItemVisuals(ListViewItem item, Task task)
        {
            if (task.completed)
            {
                item.ToolTipText = "This task has finished.";
                item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
                item.ToolTipText = "";
            }

            if (task.date.Date < System.DateTime.Today.Date)
            {
                //list.Items[i].BackColor = ProfessionalColors.SeparatorDark;
                if (task.completed)
                {
                    item.BackColor = System.Drawing.Color.LightGray;
                    item.ToolTipText = "This task has finished and deadline passed.";
                }
                else
                {
                    item.ToolTipText = "This task is over due. If this task is actually completed check completed off in the settings box.";
                    item.BackColor = System.Drawing.Color.Red;
                }
            }
            else if (task.date.Date == System.DateTime.Today.Date)
            {
                if (task.completed)
                {
                    item.BackColor = System.Drawing.Color.LimeGreen;
                    item.ToolTipText = "This task is finished and the deadline is today.";
                }
                else
                {
                    item.ToolTipText = "This task is still not completed and the deadline is today.";
                    item.BackColor = System.Drawing.Color.Orange;
                }
            }
            else if (task.date.Date == System.DateTime.Today.AddDays(1).Date)
            {
                if (task.completed)
                {
                    item.BackColor = System.Drawing.Color.LimeGreen;
                    item.ToolTipText = "This task is finished and the deadline is tommorow.";
                }
                else
                {
                    item.ToolTipText = "This task is still not completed and the deadline is tommorow.";
                    item.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
            }
            else
            {
                if (task.completed)
                {
                    item.BackColor = System.Drawing.Color.LightGreen;
                    int daysToSpare = (task.date.Date - System.DateTime.Today.Date).Days;
                    if (daysToSpare == 1)
                    {
                        item.ToolTipText = "This task has finished with " + daysToSpare.ToString() + " day to the deadline.";
                    }
                    else
                    {
                        item.ToolTipText = "This task has finished with " + daysToSpare.ToString() + " days to the deadline.";
                    }
                }
                else
                {
                    item.BackColor = System.Drawing.Color.White;
                    int daysToSpare = (task.date.Date - System.DateTime.Today.Date).Days;
                    if (daysToSpare == 1)
                    {
                        item.ToolTipText = "This task is incomplete with " + daysToSpare.ToString() + " day to the deadline.";
                    }
                    else
                    {
                        item.ToolTipText = "This task is incomplete with " + daysToSpare.ToString() + " days to the deadline.";
                    }
                }
            }
        }

        /// <summary>
        /// Sets the days of reminder for the task.
        /// </summary>
        /// <param name="reminderDays">The number of reminder days.</param>
        public void SetReminder(int reminderDays)
        {
            this.daysOfReminder = reminderDays;
        }
    }
}