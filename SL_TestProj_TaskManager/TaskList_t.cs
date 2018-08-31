using System.Collections.Generic;

namespace SL_TestProj_TaskManager
{
    public class TaskList_t
    {
        //PROP
        List<Task_t> TaskList;
        //METH
        public TaskList_t() {
            TaskList = new List<Task_t>();
        }

        public Task_t GetTask(uint ID)
        {
            return SearchTask(ID);
        }

        public void AddTask(string Content)
        {
            TaskList.Add(new Task_t(Content));
        }

        public bool EditTask(uint ID, string NewContent)
        {
            Task_t tempTask = SearchTask(ID);
            if (tempTask != null)
            {
                tempTask.ChangeContent(NewContent);
                return true;
            }
            return false;
        }

        public bool DeleteTask(uint ID)
        {
            Task_t tempTask = SearchTask(ID);
            if (tempTask != null)
            {
                TaskList.Remove(tempTask);
                return true;
            }
            return false;
        }

        public bool ToggleTaskStatus(uint ID)
        {
            Task_t tempTask = SearchTask(ID);
            if (tempTask != null)
            {
                return tempTask.ToggleStatus();
            }
            return false;
        }

        private Task_t SearchTask(uint ID)
        {
            foreach(Task_t tempTask in TaskList)
            {
                if (tempTask.Id == ID)
                {
                    return tempTask;
                }
            }
            return null;
        }
    }
}
