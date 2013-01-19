// -----------------------------------------------------------------------
// Author: Alexander Rodrigues
// -----------------------------------------------------------------------

namespace Task_Manager
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A serializable version of the task data.
    /// </summary>
    [Serializable]
    public class SerializableTaskData
    {
        /// <summary>
        /// Gets or sets the task list to be serialized.
        /// </summary>
        /// <value>
        /// The task list to be serialized.
        /// </value>
        public List<Task> taskList {get; set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableTaskData"/> class.
        /// </summary>
        /// <param name="TaskList">The list of tasks to be serialized.</param>
        public SerializableTaskData(List<Task> TaskList)
        {
            this.taskList = TaskList;
        }
    }
}