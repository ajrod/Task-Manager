// -----------------------------------------------------------------------
// Author: Alexander Rodrigues
// -----------------------------------------------------------------------


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