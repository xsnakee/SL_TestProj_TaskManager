using System;
using System.Collections.Generic;

namespace SL_TestProj_TaskManager
{
    public static class main
    {
        public static void Main()
        {
            TaskList_t taskList = new TaskList_t();
            UserInterface_t consoleInterfaceViewer = new UserInterface_t(taskList);
            consoleInterfaceViewer.Run();
            return;
        }
    }
}
