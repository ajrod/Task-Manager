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