using System;

namespace TaskListManager.src
{
    public enum REPEAT_TYPE
    {
        none = 0,
        day,
        week
    }

    public class TaskItem
    {
        private String task;
        private DateTime deadline;
        private REPEAT_TYPE repeatType;
        private long id;

        public TaskItem()
        {
        }

        public TaskItem(String task, DateTime deadline, REPEAT_TYPE type)
        {
            this.task = task;
            this.deadline = deadline;
            this.repeatType = type;
            this.id = DateTime.Now.ToFileTimeUtc();
        }

        public String Task
        {
            get { return this.task; }
            set { this.task = value; }
        }

        public DateTime Deadline
        {
            get { return this.deadline; }
            set { this.deadline = value; }
        }

        public REPEAT_TYPE RepeatType
        {
            get { return this.repeatType; }
            set { this.repeatType = value; }
        }
        public long ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}
