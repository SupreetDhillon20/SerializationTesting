using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment3.Test
{
    public static class SerializationHelper
    {
        // Serializes the SLL<T> data to a file in binary format
        public static void SerializeUsers<T>(SLL<T> data, string fileName) where T : class
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create(fileName))
            {
                formatter.Serialize(stream, data);
            }
        }

        // Deserializes the SLL<T> data from a file in binary format
        public static SLL<T> DeserializeUsers<T>(string fileName) where T : class
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (SLL<T>)formatter.Deserialize(stream);
            }
        }
    }
}
