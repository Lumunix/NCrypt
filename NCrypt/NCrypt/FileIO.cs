using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NCrypt
{
    class FileIO
    {
        public Int64 CheckFileSize(string FilePath)
        {
           FileInfo File = new FileInfo(FilePath);
           return File.Length;
        }
        
        public byte[] ReadFileBytes(string FilePath)
        {
           
            using (FileStream File = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                // Read the source file into a byte array. 
                byte[] Bytes = new byte[File.Length];
                int NumBytesToRead = (int)File.Length;
                int NumBytesRead = 0;
                while (NumBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead. 
                    int n = File.Read(Bytes, NumBytesRead, NumBytesToRead);

                    // Break when the end of the file is reached. 
                    if (n == 0)
                        break;

                    NumBytesRead += n;
                    NumBytesToRead -= n;
                }
                return Bytes;
            }

        }
        public void WriteFileFromBytes(string FilePath, byte[] Data)
        {
            //grab the name and directory
            string FileName = Path.GetFileName(FilePath);
            string Directory = Path.GetDirectoryName(FilePath) + "\\";
            //where do we want to write?
            string OutFile = Directory + FileName;
            using (FileStream outFs = new FileStream(OutFile, FileMode.Create))
            {
                outFs.Write(Data, 0, Data.Length);
            }
        }

        public string ReadFileString(string FilePath)
        {
            string Data;
            StreamReader sr = new StreamReader(FilePath);
            Data = sr.ReadToEnd();
            sr.Close();
            return Data;
        }

        public void WriteFileFromString(string FilePath, string Data)
        {
            //grab the name and directory
            string FileName = Path.GetFileName(FilePath);
            string Directory = Path.GetDirectoryName(FilePath) + "\\";
            //where do we want to write?
            string OutFile = Directory + FileName;
            StreamWriter sw = new StreamWriter(OutFile, false);
            sw.Write(Data);
            sw.Close();
        }

        public bool XMLTagExists(string FilePath, string SearchTag)
        {

            System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(FilePath);
            while (reader.Read())
            {
                reader.MoveToContent();
                if (reader.NodeType == System.Xml.XmlNodeType.Element)
                {
                    if (reader.Name == SearchTag)
                        return true;
                }
            }
            return false;
        }
    }
}
