using System;

namespace SL_TestProj_TaskManager
{

    public class UserInterface_t
    {
        //FIELDS
        TaskList_t taskList;
        const ushort RecOnScreenAmount = 10;
        int currentRec;

        string[] menu = {
            "1-Add",
            "2-Del",
            "3-Edit",
            "4-ToggleComplete",
            "5-LoadFromFile",
            "6-SaveToFile",
            "DOWN-Scroll d",
            "UP-Scroll u",
            "0-Exit"
        };

        //METH
        public UserInterface_t()
        {
            taskList = new TaskList_t();
            currentRec = 0;
        }

        public UserInterface_t(TaskList_t _taskList) {
            taskList = _taskList;
            currentRec = 0;
        }

        private bool SaveToFile()
        {
            Console.Write("Enter file name:");
            string FileName = Console.ReadLine();
            FileSaver_t file = new FileSaver_t(FileName);
            if (file.Save(ref taskList)) { 
                return true;
            }
            return false;
        }

        private bool LoadFromFile()
        {
            Console.Write("Enter file name:");
            string FileName = Console.ReadLine();
            FileLoader_t file = new FileLoader_t(FileName);
            if (file.Load(ref taskList))
            {
                return true;
            }
            return false;
        }

        private bool AddTask() {
            Console.Write("Enter task content:");
            string content = Console.ReadLine();
            if (IsValidContent(content))
            {
                Task_t newTask = new Task_t(content);
                taskList.AddTask(newTask);
                return true;
            }
            return false;
        }

        private bool DeleteTask()
        {
            uint ID = EnterId();

            if (ID != 0)
            {
                return taskList.DeleteTask(ID);
            }
            return false;

        }

        private bool EditTask()
        {
            uint ID = EnterId();
            if (ID != 0)
            {
                Console.Write("Enter new content:");
                string content = Console.ReadLine();
                if (IsValidContent(content))
                {
                    return taskList.EditTask(ID, content);
                }
            }
            return false;

        }
        private void ShowList()
        {
            int charAmountOnDisplay = 15;

            if (taskList.Length == 0)
            {
                Console.WriteLine("List is empty");
                return;
            }

            int counter = 0;
            int index = currentRec + counter;
            for (counter = 0 ; ((counter + currentRec) < taskList.Length && counter < RecOnScreenAmount); ++counter, index = currentRec + counter)
            {
                Task_t tempTask = taskList[index];
                int strLength = (tempTask.Content.Length < charAmountOnDisplay) ? tempTask.Content.Length : charAmountOnDisplay;
                Console.WriteLine("{0, 3} | {1, 20}... | {2, 7}", tempTask.Id, tempTask.Content.Substring(0, strLength), tempTask.Complete);
            }
        }

        private void PrintMenu() {
            Console.WriteLine();
            foreach (string str in menu) {
                Console.Write(str + " | ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private void KeyEventHandler(ConsoleKeyInfo pressKey) {
            switch (pressKey.Key)
            {
                case ConsoleKey.D1:
                    {
                        AddTask();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        DeleteTask();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        EditTask();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        uint ID = EnterId();
                        taskList.ToggleTaskStatus(ID);
                        break;
                    }
                case ConsoleKey.D5:
                    {//LOAD
                        if (LoadFromFile())
                        {
                            Console.WriteLine("Successful");
                        }
                        else
                        {
                            Console.WriteLine("Aborted");
                        }
                        Console.ReadKey(false);
                        break;
                    }
                case ConsoleKey.D6:
                    {//SAVE
                        if (SaveToFile())
                        {
                            Console.WriteLine("Successful");
                        } else
                        {
                            Console.WriteLine("Aborted");
                        }
                        Console.ReadKey(false);
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (currentRec < (taskList.Length - RecOnScreenAmount))
                        {
                            currentRec += RecOnScreenAmount;
                        }
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        if (currentRec >= RecOnScreenAmount)
                        {
                            currentRec -= RecOnScreenAmount;
                        }
                        break;
                    }
                case ConsoleKey.D0:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }
        private bool valInRange(int v, int minI, int maxI)
        {
            if (minI < maxI)
            {
                int temp = maxI;
                maxI = minI;
                minI = temp;
            }
            return (v >= minI && v <= maxI) ? true : false;
        }

        private bool IsValidContent(string content) {
            return true;
        }

        private uint EnterId()
        {
            Console.Write("Enter task ID:");
            string idStr = Console.ReadLine();
            uint ID;
            try
            {
                ID = uint.Parse(idStr);
            }
            catch (Exception)
            {
                return 0;
            }

            return ID;
        }
        public void Run() {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                ShowList();
                PrintMenu();
                key = Console.ReadKey(true);
                KeyEventHandler(key);
            }
            while (key.KeyChar != '0');
        }
    }
}
