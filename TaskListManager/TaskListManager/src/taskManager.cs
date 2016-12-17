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

        // タスクを生成する
        public TaskItem createTask(String task, DateTime deadline)
        {
            TaskItem item = new TaskItem(task, deadline);
            this.taskList.Add(item);

            return item;
        }

        public void addTask(TaskItem item)
        {
            this.taskList.Add(item);

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
        
        // 指定したIDのタスクを編集
        public void editTaskById(long id, String task, DateTime deadline)
        {
            for(int i = 0; i < this.taskList.Count; i++)
            {
                TaskItem item = this.taskList[i];

                if(id == item.ID)
                {
                    item.Task = task;
                    item.Deadline = deadline;
                    break;
                }
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
