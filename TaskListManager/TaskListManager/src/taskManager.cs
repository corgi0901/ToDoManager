using System;
using System.Collections.Generic;

namespace TaskListManager.src
{
    class TaskManager
    {
        private const String confName = "taskList.xml";
        private List<TaskItem> taskList;
        private static TaskManager instance = null;

        // プライベートコンストラクタ
        private TaskManager()
        {
            try
            {
                using (System.IO.TextReader reader = new System.IO.StreamReader(confName))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<TaskItem>));
                    this.taskList = (List<TaskItem>)serializer.Deserialize(reader);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                // ファイルがない場合(初回起動時など)は空リストを作る
                this.taskList = new List<TaskItem>();
            }
        }

        // シングルトンインスタンスの取得
        public static TaskManager getInstance()
        {
            if (null == instance)
            {
                instance = new TaskManager();
            }

            return instance;
        }

        // タスクを追加する
        public void addTask(TaskItem item)
        {
            this.taskList.Add(item);
            this.taskList.Sort(delegate (TaskItem a, TaskItem b) { return a.Deadline.CompareTo(b.Deadline); });
        }

        // 指定したIDのタスクを削除
        public void deleteTaskById(long id)
        {
            for (int i = 0; i < this.taskList.Count; i++)
            {
                TaskItem task = this.taskList[i];

                if (task.ID == id)
                {
                    this.taskList.Remove(task);
                    break;
                }
            }
        }
        
        // 指定したIDのタスクを取得する
        public TaskItem getTaskItemByID(long id)
        {
            TaskItem item = null;

            for(int i=0; i<this.taskList.Count; i++)
            {
                if(id == this.taskList[i].ID)
                {
                    item = this.taskList[i];
                    break;
                }
            }

            return item;
        }

        // IDを指定してタスク内容を変更する
        public void editTaskItemByID(long id, String task, DateTime deadline)
        {
            TaskItem taskItem = getTaskItemByID(id);

            if (null != taskItem)
            {
                taskItem.Task = task;
                taskItem.Deadline = deadline;
                this.taskList.Sort(delegate (TaskItem a, TaskItem b) { return a.Deadline.CompareTo(b.Deadline); });
            }
        }

        // タスクのリストを取得
        public List<TaskItem> getTaskList()
        {
            return this.taskList;
        }

        // タスクをファイルに保存
        public void saveTaskList()
        {
            using (System.IO.TextWriter writer = new System.IO.StreamWriter(confName))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<TaskItem>));
                serializer.Serialize(writer, this.taskList);
            }
        }
    }
}
