// -----------------------------------------------------------------------
// Author: Alexander Rodrigues
// -----------------------------------------------------------------------

using System.Windows.Forms;

namespace Task_Manager
{
    /// <summary>
    /// The form for editing an already existing task.
    /// </summary>
    public partial class EditTaskForm : Form
    {
        /// <summary>
        /// The task being edited.
        /// </summary>
        private Task editableTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditTaskForm"/> class.
        /// </summary>
        /// <param name="taskToEdit">The task to edit.</param>
        public EditTaskForm(Task taskToEdit)
        {
            editableTask = taskToEdit;
            InitializeComponent();
            saveEditButton.Enabled = false;
            this.editTaskBox.TextChanged += new System.EventHandler(CheckInput);
            this.editTagBox.TextChanged += new System.EventHandler(CheckInput);
        }

        /// <summary>
        /// Checks the user input being entered into the edit form.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckInput(object sender, System.EventArgs e)
        {
            MainForm.idle = false;
            if (!editDateTimePicker.Checked || editTagBox.Text.Length < MainForm.MIN_TAG_LENGTH || editTaskBox.Text.Length < MainForm.MIN_TASKBOX_LENGTH)
            {
                saveEditButton.Enabled = false;
            }
            else
            {
                saveEditButton.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the CancelEditButton control. Closes the edit form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CancelEditButton_Click(object sender, System.EventArgs e)
        {
            MainForm.idle = false;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the SaveEditButton control. Updates the task selected with the new information gathered.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveEditButton_Click(object sender, System.EventArgs e)
        {
            MainForm.idle = false;
            MainForm.TaskData.DeleteSelectedTasks(MainForm.ViewableTasks, MainForm.FilterList, MainForm.filters);
            Task task = new Task(this.editDateTimePicker.Value, this.editTagBox.Text, this.editTaskBox.Text);
            task.reminder = editableTask.reminder;
            task.notes = editableTask.notes;
            task.completed = editableTask.completed;
            task.daysOfReminder = editableTask.daysOfReminder;
            task.reminderEmail = editableTask.reminderEmail;
            MainForm.TaskData.InsertTask(task);
            MainForm.TaskData.UpdateTaskList(MainForm.ViewableTasks, MainForm.FilterList);
            MainForm.SetSelectedIndexOfTask(task);
            MainForm.TaskData.Save();
            this.Close();
        }
    }
}