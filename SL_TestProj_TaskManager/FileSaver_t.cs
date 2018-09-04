using System;
using System.IO;

namespace SL_TestProj_TaskManager
{
    public class FileSaver_t : Saver_i<TaskList_t>
    {
        private FileStream InFile = null;

        public FileSaver_t(string FileName)
        {
            try
            {
                InFile = new FileStream(FileName, FileMode.Create);
            }
            catch (FileLoadException)
            {
                Console.WriteLine("File not open");
            }
        }

        public bool Save(ref TaskList_t list) { 
        
            BinaryWriter BinInFile = null;
            try
            {
                BinInFile = new BinaryWriter(InFile);
                foreach (var i in list.GetReadOnlyList())
                {
                    BinInFile.Write(i.Id);
                    BinInFile.Write(i.Content);
                }
            }
            catch (Exception ob)
            {
                Console.WriteLine("Exception: " + ob.Message);
                return false;
            }
            finally
            {
                if (InFile != null)
                {
                    BinInFile.Close();
                }
            }
            return true;
        }
    }
}
