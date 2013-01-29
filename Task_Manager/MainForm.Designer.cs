//Copyright (C) 2013 Alex Rodrigues
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
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AddTask = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.taskBox = new System.Windows.Forms.TextBox();
            this.taskDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taskTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.task = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noteEditor = new System.Windows.Forms.TextBox();
            this.TagBox = new System.Windows.Forms.ComboBox();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.setCompletionStatus = new System.Windows.Forms.CheckBox();
            this.ReminderOn = new System.Windows.Forms.CheckBox();
            this.settingPanel2 = new System.Windows.Forms.Panel();
            this.emailComboBox = new System.Windows.Forms.ComboBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.setReminderDaysLabel2 = new System.Windows.Forms.Label();
            this.pickDaysReminderBox = new System.Windows.Forms.NumericUpDown();
            this.setReminderDaysLabel1 = new System.Windows.Forms.Label();
            this.TaskManagerIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TaskBarContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openTaskManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskManagerTitleLabel = new System.Windows.Forms.Label();
            this.TaskListLabel = new System.Windows.Forms.Label();
            this.FilterTasksLabel = new System.Windows.Forms.Label();
            this.TaskNotesLabel = new System.Windows.Forms.Label();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.addNotesSuggestionLabel = new System.Windows.Forms.Label();
            this.IdleTimer = new System.Windows.Forms.Timer(this.components);
            this.clearFilterButton = new System.Windows.Forms.Button();
            this.taskContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsPanel.SuspendLayout();
            this.settingPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickDaysReminderBox)).BeginInit();
            this.TaskBarContextMenuStrip.SuspendLayout();
            this.taskContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddTask
            // 
            this.AddTask.Cursor = System.Windows.Forms.Cursors.No;
            this.AddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTask.Location = new System.Drawing.Point(511, 539);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(75, 23);
            this.AddTask.TabIndex = 3;
            this.AddTask.Text = "Add Task";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(511, 352);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(27, 543);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 5;
            // 
            // taskBox
            // 
            this.taskBox.Location = new System.Drawing.Point(362, 542);
            this.taskBox.Name = "taskBox";
            this.taskBox.Size = new System.Drawing.Size(140, 20);
            this.taskBox.TabIndex = 2;
            // 
            // taskDate
            // 
            this.taskDate.Text = "Date";
            this.taskDate.Width = 126;
            // 
            // taskTag
            // 
            this.taskTag.Text = "Tag";
            this.taskTag.Width = 136;
            // 
            // task
            // 
            this.task.Text = "Task";
            this.task.Width = 171;
            // 
            // noteEditor
            // 
            this.noteEditor.Enabled = false;
            this.noteEditor.Location = new System.Drawing.Point(774, 95);
            this.noteEditor.Multiline = true;
            this.noteEditor.Name = "noteEditor";
            this.noteEditor.Size = new System.Drawing.Size(366, 229);
            this.noteEditor.TabIndex = 8;
            // 
            // TagBox
            // 
            this.TagBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TagBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TagBox.FormattingEnabled = true;
            this.TagBox.Location = new System.Drawing.Point(233, 542);
            this.TagBox.Name = "TagBox";
            this.TagBox.Size = new System.Drawing.Size(121, 21);
            this.TagBox.TabIndex = 1;
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.settingsPanel.Controls.Add(this.setCompletionStatus);
            this.settingsPanel.Controls.Add(this.ReminderOn);
            this.settingsPanel.Controls.Add(this.settingPanel2);
            this.settingsPanel.Enabled = false;
            this.settingsPanel.Location = new System.Drawing.Point(774, 352);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(366, 162);
            this.settingsPanel.TabIndex = 9;
            // 
            // setCompletionStatus
            // 
            this.setCompletionStatus.AutoSize = true;
            this.setCompletionStatus.Location = new System.Drawing.Point(13, 103);
            this.setCompletionStatus.Name = "setCompletionStatus";
            this.setCompletionStatus.Size = new System.Drawing.Size(76, 17);
            this.setCompletionStatus.TabIndex = 11;
            this.setCompletionStatus.Text = "Completed";
            this.setCompletionStatus.UseVisualStyleBackColor = true;
            // 
            // ReminderOn
            // 
            this.ReminderOn.AutoSize = true;
            this.ReminderOn.Location = new System.Drawing.Point(13, 14);
            this.ReminderOn.Name = "ReminderOn";
            this.ReminderOn.Size = new System.Drawing.Size(88, 17);
            this.ReminderOn.TabIndex = 0;
            this.ReminderOn.Text = "Reminder On";
            this.ReminderOn.UseVisualStyleBackColor = true;
            // 
            // settingPanel2
            // 
            this.settingPanel2.Controls.Add(this.emailComboBox);
            this.settingPanel2.Controls.Add(this.emailLabel);
            this.settingPanel2.Controls.Add(this.setReminderDaysLabel2);
            this.settingPanel2.Controls.Add(this.pickDaysReminderBox);
            this.settingPanel2.Controls.Add(this.setReminderDaysLabel1);
            this.settingPanel2.Location = new System.Drawing.Point(30, 32);
            this.settingPanel2.Name = "settingPanel2";
            this.settingPanel2.Size = new System.Drawing.Size(267, 53);
            this.settingPanel2.TabIndex = 10;
            // 
            // emailComboBox
            // 
            this.emailComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.emailComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.emailComboBox.FormattingEnabled = true;
            this.emailComboBox.Location = new System.Drawing.Point(52, 28);
            this.emailComboBox.Name = "emailComboBox";
            this.emailComboBox.Size = new System.Drawing.Size(212, 21);
            this.emailComboBox.TabIndex = 13;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(4, 31);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(42, 13);
            this.emailLabel.TabIndex = 12;
            this.emailLabel.Text = "E-Mail: ";
            // 
            // setReminderDaysLabel2
            // 
            this.setReminderDaysLabel2.AutoSize = true;
            this.setReminderDaysLabel2.Location = new System.Drawing.Point(95, 2);
            this.setReminderDaysLabel2.Name = "setReminderDaysLabel2";
            this.setReminderDaysLabel2.Size = new System.Drawing.Size(92, 13);
            this.setReminderDaysLabel2.TabIndex = 2;
            this.setReminderDaysLabel2.Text = "days before Task.";
            // 
            // pickDaysReminderBox
            // 
            this.pickDaysReminderBox.Location = new System.Drawing.Point(52, 0);
            this.pickDaysReminderBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.pickDaysReminderBox.Name = "pickDaysReminderBox";
            this.pickDaysReminderBox.Size = new System.Drawing.Size(37, 20);
            this.pickDaysReminderBox.TabIndex = 3;
            this.pickDaysReminderBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // setReminderDaysLabel1
            // 
            this.setReminderDaysLabel1.AutoSize = true;
            this.setReminderDaysLabel1.Location = new System.Drawing.Point(3, 2);
            this.setReminderDaysLabel1.Name = "setReminderDaysLabel1";
            this.setReminderDaysLabel1.Size = new System.Drawing.Size(43, 13);
            this.setReminderDaysLabel1.TabIndex = 1;
            this.setReminderDaysLabel1.Text = "Remind";
            // 
            // TaskManagerIcon
            // 
            this.TaskManagerIcon.ContextMenuStrip = this.TaskBarContextMenuStrip;
            this.TaskManagerIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TaskManagerIcon.Icon")));
            this.TaskManagerIcon.Text = "Task Manager";
            // 
            // TaskBarContextMenuStrip
            // 
            this.TaskBarContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTaskManagerToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.TaskBarContextMenuStrip.Name = "IconTaskBarMenu";
            this.TaskBarContextMenuStrip.Size = new System.Drawing.Size(181, 48);
            // 
            // openTaskManagerToolStripMenuItem
            // 
            this.openTaskManagerToolStripMenuItem.Name = "openTaskManagerToolStripMenuItem";
            this.openTaskManagerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openTaskManagerToolStripMenuItem.Text = "Open Task Manager";
            this.openTaskManagerToolStripMenuItem.Click += new System.EventHandler(this.OpenTaskManagerToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // TaskManagerTitleLabel
            // 
            this.TaskManagerTitleLabel.AutoSize = true;
            this.TaskManagerTitleLabel.Font = new System.Drawing.Font("Monotype Corsiva", 24.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskManagerTitleLabel.ForeColor = System.Drawing.Color.Red;
            this.TaskManagerTitleLabel.Location = new System.Drawing.Point(445, 7);
            this.TaskManagerTitleLabel.Name = "TaskManagerTitleLabel";
            this.TaskManagerTitleLabel.Size = new System.Drawing.Size(327, 40);
            this.TaskManagerTitleLabel.TabIndex = 10;
            this.TaskManagerTitleLabel.Text = "Welcome to Task Manager";
            // 
            // TaskListLabel
            // 
            this.TaskListLabel.AutoSize = true;
            this.TaskListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskListLabel.Location = new System.Drawing.Point(188, 56);
            this.TaskListLabel.Name = "TaskListLabel";
            this.TaskListLabel.Size = new System.Drawing.Size(126, 24);
            this.TaskListLabel.TabIndex = 11;
            this.TaskListLabel.Text = "Current Tasks";
            // 
            // FilterTasksLabel
            // 
            this.FilterTasksLabel.AutoSize = true;
            this.FilterTasksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterTasksLabel.Location = new System.Drawing.Point(564, 56);
            this.FilterTasksLabel.Name = "FilterTasksLabel";
            this.FilterTasksLabel.Size = new System.Drawing.Size(105, 24);
            this.FilterTasksLabel.TabIndex = 12;
            this.FilterTasksLabel.Text = "Filter Tasks";
            // 
            // TaskNotesLabel
            // 
            this.TaskNotesLabel.AutoSize = true;
            this.TaskNotesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskNotesLabel.Location = new System.Drawing.Point(900, 56);
            this.TaskNotesLabel.Name = "TaskNotesLabel";
            this.TaskNotesLabel.Size = new System.Drawing.Size(104, 24);
            this.TaskNotesLabel.TabIndex = 13;
            this.TaskNotesLabel.Text = "Task Notes";
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.Location = new System.Drawing.Point(889, 327);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(121, 24);
            this.settingsLabel.TabIndex = 14;
            this.settingsLabel.Text = "Task Settings";
            // 
            // addNotesSuggestionLabel
            // 
            this.addNotesSuggestionLabel.AutoSize = true;
            this.addNotesSuggestionLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.addNotesSuggestionLabel.Location = new System.Drawing.Point(786, 98);
            this.addNotesSuggestionLabel.Name = "addNotesSuggestionLabel";
            this.addNotesSuggestionLabel.Size = new System.Drawing.Size(247, 13);
            this.addNotesSuggestionLabel.TabIndex = 15;
            this.addNotesSuggestionLabel.Text = "Type important notes about the selected task here.";
            // 
            // IdleTimer
            // 
            this.IdleTimer.Enabled = true;
            this.IdleTimer.Interval = 1000;
            this.IdleTimer.Tick += new System.EventHandler(this.IdleTimer_Tick);
            // 
            // clearFilterButton
            // 
            this.clearFilterButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.clearFilterButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.clearFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearFilterButton.Location = new System.Drawing.Point(663, 301);
            this.clearFilterButton.Name = "clearFilterButton";
            this.clearFilterButton.Size = new System.Drawing.Size(75, 23);
            this.clearFilterButton.TabIndex = 16;
            this.clearFilterButton.Text = "Clear";
            this.clearFilterButton.UseVisualStyleBackColor = false;
            this.clearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // taskContextMenuStrip
            // 
            this.taskContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.taskContextMenuStrip.Name = "taskContextMenuStrip";
            this.taskContextMenuStrip.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1173, 586);
            this.Controls.Add(this.clearFilterButton);
            this.Controls.Add(this.addNotesSuggestionLabel);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.TaskNotesLabel);
            this.Controls.Add(this.FilterTasksLabel);
            this.Controls.Add(this.TaskListLabel);
            this.Controls.Add(this.TaskManagerTitleLabel);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.TagBox);
            this.Controls.Add(this.noteEditor);
            this.Controls.Add(this.taskBox);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.AddTask);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1189, 624);
            this.MinimumSize = new System.Drawing.Size(1189, 624);
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Manager";
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.settingPanel2.ResumeLayout(false);
            this.settingPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickDaysReminderBox)).EndInit();
            this.TaskBarContextMenuStrip.ResumeLayout(false);
            this.taskContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddTask;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox taskBox;
        private System.Windows.Forms.ColumnHeader taskDate;
        private System.Windows.Forms.ColumnHeader taskTag;
        private System.Windows.Forms.ColumnHeader task;
        private System.Windows.Forms.TextBox noteEditor;
        private System.Windows.Forms.ComboBox TagBox;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.NumericUpDown pickDaysReminderBox;
        private System.Windows.Forms.Label setReminderDaysLabel2;
        private System.Windows.Forms.Label setReminderDaysLabel1;
        private System.Windows.Forms.CheckBox ReminderOn;
        private System.Windows.Forms.Panel settingPanel2;
        private System.Windows.Forms.NotifyIcon TaskManagerIcon;
        private System.Windows.Forms.CheckBox setCompletionStatus;
        private System.Windows.Forms.Label TaskManagerTitleLabel;
        private System.Windows.Forms.Label TaskListLabel;
        private System.Windows.Forms.Label FilterTasksLabel;
        private System.Windows.Forms.Label TaskNotesLabel;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.ComboBox emailComboBox;
        private System.Windows.Forms.Label addNotesSuggestionLabel;
        private System.Windows.Forms.ContextMenuStrip TaskBarContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openTaskManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer IdleTimer;
        private System.Windows.Forms.Button clearFilterButton;
        private System.Windows.Forms.ContextMenuStrip taskContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}