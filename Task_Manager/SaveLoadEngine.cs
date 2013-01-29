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

using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task_Manager
{
    /// <summary>
    /// A utility class for saving and loading task data.
    /// </summary>
    public class SaveLoadEngine
    {
        /// <summary>
        /// The current version of the application data.
        /// </summary>
        const int VERSION = 1;


        /// <summary>
        /// Saves the specified task data.
        /// </summary>
        /// <param name="taskData">The task data.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void Save(SerializableTaskData taskData, string fileName)
        {
            Stream stream = null;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, VERSION);
                formatter.Serialize(stream, taskData);
            }
            catch
            {
            }
            finally
            {
                if (null != stream)
                    stream.Close();
            }
        }

        /// <summary>
        /// Loads the task data from specified file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileExists">if set to <c>true</c> [file_exists].</param>
        /// <returns></returns>
        public static SerializableTaskData Load(string fileName, ref bool fileExists)
        {
            Stream stream = null;
            SerializableTaskData taskData = null;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                int version = (int)formatter.Deserialize(stream);
                //check that the task data is the same version
                Debug.Assert(version == VERSION);
                taskData = (SerializableTaskData)formatter.Deserialize(stream);
            }
            catch
            {
                fileExists = false;
            }
            finally
            {
                if (null != stream)
                    stream.Close();
            }
            return taskData;
        }
    }
}