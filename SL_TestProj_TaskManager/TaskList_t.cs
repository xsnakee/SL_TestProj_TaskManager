using System.Collections.Generic;

namespace SL_TestProj_TaskManager
{
    public class TaskList_t
    {
        //PROP
        private List<Task_t> TaskList;
        public int Length { get; private set; }
        public Task_t this[int index]{
            get
            {
                return TaskList[index];
            }
            private set { }
        }
        //METH
        public TaskList_t() {
            TaskList = new List<Task_t>();
            Length = 0;
        }
        public Task_t GetTask(uint ID)
        {
            return SearchTask(ID);
        }

        public void AddTask(string Content)
        {
            TaskList.Add(new Task_t(Content));
            ++Length;
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
                --Length;
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
