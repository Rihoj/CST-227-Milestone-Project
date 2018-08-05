using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace CST_227_Milestone_Project
{
    class SaveData
    {
        List<PlayerStat> HighScores = new List<PlayerStat>();

        public string GetPath(string fileName = null)
        {
            string path = Path.Combine(
                       Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                       @"LiveCells\");
            if (fileName != null) {
                path = Path.Combine(path, fileName + ".xml");
            }

            return path;
        }

        public List<PlayerStat> LoadHighScores()
        {
            HighScores.Clear();
            if (Directory.Exists(GetPath()))
            {
                string[] fileEntries = Directory.GetFiles(GetPath());
                foreach (string fileName in fileEntries)
                {
                    HighScores.Add(DeSerializeObject<PlayerStat>(fileName));
                }
                HighScores.Sort();
            }

            return HighScores;
        }

        public void SaveGameData(PlayerStat player)
        {
            HighScores.Add(player);
            SaveAllGameData();
        }

        public void SaveAllGameData()
        {
            HighScores.Sort();
            if (Directory.Exists(GetPath()))
            {
                DirectoryInfo di = new DirectoryInfo(GetPath());
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (HighScores.ElementAtOrDefault(i) != null)
                    SerializeObject<PlayerStat>(HighScores[i], HighScores[i].UID);
            }
            LoadHighScores();
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(GetPath(fileName));
                    file.Directory.Create();
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(file.FullName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                // log debugging here.
            }
        }


        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                // log debugging here.
            }

            return objectOut;
        }
    }
}
