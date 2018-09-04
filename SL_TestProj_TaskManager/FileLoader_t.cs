using System;
using System.IO;

namespace SL_TestProj_TaskManager
{
    public class FileLoader_t : Loader_i<TaskList_t>
    {
        private FileStream OutFile = null;

        public FileLoader_t(string FileName)
        {
            try
            {
                OutFile = new FileStream(FileName, FileMode.Open);
            }
            catch (Exception)
            {
                Console.WriteLine("File not open");
            }
        }

        public bool Load(ref TaskList_t list)
        {

            BinaryReader BinOutFile = null;
            try
            {
                BinOutFile = new BinaryReader(OutFile);
                while (BinOutFile.BaseStream.Position != BinOutFile.BaseStream.Length)
                {
                    uint id = BinOutFile.ReadUInt32();
                    string content = BinOutFile.ReadString();
                    list.AddTask(new Task_t(id, content));
                }
            }
            catch (Exception ob)
            {
                Console.WriteLine("Exception: " + ob.Message);
                return false;
            }
            finally
            {
                if (OutFile != null) {
                    BinOutFile.Close();
                }
            }
            return true;
        }
    }
}
