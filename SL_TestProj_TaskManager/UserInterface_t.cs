using System;

namespace SL_TestProj_TaskManager
{   

    public class UserInterface_t
    {
        //FIELDS
        TaskList_t taskList;
        const ushort RecOnScreenAmount = 10;
        string[] menu = {
            "1-Add",
            "2-Del",
            "3-Edit",
            "4-ToggleComplete",
            "DOWN-Scroll d",
            "UP-Scroll u",
            "0-Exit"
        };

        //METH
        public UserInterface_t()
        {
            taskList = new TaskList_t();
        }

        public UserInterface_t(TaskList_t _taskList) {
            taskList = _taskList;
        }

        private bool AddTask() {
            Console.Write("Enter task content:");
            string content = Console.ReadLine();
            if (IsValidContent(content))
            {
                taskList.AddTask(content);
                return true;
            }
            return false;
        }

        private bool DeleteTask()
        {
           uint ID = EnterId();
            return taskList.DeleteTask(ID);
            
        }

        private bool EditTask()
        {
            uint ID = EnterId();
            Console.WriteLine("Current content: \n" + taskList.GetTask(ID).Content);
            Console.Write("Enter new content:");
            string content = Console.ReadLine();
            if (IsValidContent(content))
            {
                return taskList.EditTask(ID,content);                
            }
            return false;

        }
        private void ShowList()
        {
        }
        
        private void PrintMenu() {
            Console.WriteLine();
            foreach (string str in menu) {
                Console.Write(str + " | ");
            }

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
                        break;
                    }
                case ConsoleKey.D6:
                    {//SAVE
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {

                        break;
                    }
                case ConsoleKey.UpArrow:
                    {

                        break;
                    }
                case ConsoleKey.D0:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
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
                ShowList();
                PrintMenu();
                key = Console.ReadKey();
                KeyEventHandler(key);
            }
            while (key.KeyChar != '0');
        }
    }
}
