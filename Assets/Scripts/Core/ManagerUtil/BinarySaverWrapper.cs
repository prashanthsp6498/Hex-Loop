using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using HexLoop.Core.Log;

namespace HexLoop
{
    public static class BinarySaverWrapper
    {

        /// <summary>
        /// Write Any Object as binary data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Object Data and It should be serializable</param>
        /// <param name="path">Directory Path(If it doesn't Exist create one)</param>
        /// <param name="fileName">File name</param>
        public static void Write<T>(T data, string path, string fileName)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            BinaryFormatter formatter = new();
            using Stream stream = File.OpenWrite(Path.Combine(path, fileName));
            formatter.Serialize(stream, data);
        }

        /// <summary>
        /// Read binary from disk and cast to required type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public static T Read<T>(string path)
        {
            if (!File.Exists(path))
            {
                Logger.Assert(true, "File doesn't exist");
                return default;
            }

            BinaryFormatter formatter = new();
            using FileStream fs = File.Open(path, FileMode.Open);
            T objData = (T)formatter.Deserialize(fs);
            return objData;
        }
    }
}
