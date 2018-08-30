namespace SL_TestProj_TaskManager
{
    public class TaskList_t
    {
        //PROP

        //METH
        public TaskList_t() { }

        public Task_t GetTask()
        {
            return new Task_t("Test content");
        }

        public bool EditTask(uint ID, string NewContent)
        {
            return false;
        }

        public bool DeleteTask(uint ID)
        {
            return false;
        }

        public bool ToggleTaskStatus(uint ID)
        {
            return false;
        }

        private Task_t SearchTask(uint ID)
        {
            return new Task_t("Test content");
        }
    }
}
