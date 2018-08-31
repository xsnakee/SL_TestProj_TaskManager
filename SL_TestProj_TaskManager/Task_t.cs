namespace SL_TestProj_TaskManager
{
    public class Task_t
    {
        //PROP
        public string Content{ get; private set;}
        public bool Complete { get; set; }

        public uint Id { get; set; }

        public static uint Counter{ get; private set;}

        //METH
        public Task_t(string content)
        {
            Content = content;
            Id = ++Counter;
        }

        public bool ToggleStatus()
        {
            return Complete = (Complete) ? false : true;
        }

        public void ChangeContent(string NewContent)
        {
            Content = NewContent;
        }
    }
}
