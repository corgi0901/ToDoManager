﻿using System;

namespace TaskListManager.src
{
    public class TaskItem
    {
        public String task;
        public DateTime deadline;
        public long id;

        public TaskItem()
        {
        }

        public TaskItem(String task, DateTime deadline)
        {
            this.task = task;
            this.deadline = deadline;
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

        public long ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}
