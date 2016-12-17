using System;
using System.Collections.Generic;

namespace TaskListManager.src
{
    class taskManager
    {
        private const String confName = "taskList.xml";
        private List<taskItem> taskList;
        private static taskManager instance = null;

        // プライベートコンストラクタ
        private taskManager()
        {
            try
            {
                using (System.IO.TextReader reader = new System.IO.StreamReader(confName))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<taskItem>));
                    this.taskList = (List<taskItem>)serializer.Deserialize(reader);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                // ファイルがない場合(初回起動時など)は空リストを作る
                this.taskList = new List<taskItem>();
            }
        }

        // シングルトンインスタンスの取得
        public static taskManager getInstance()
        {
            if (null == instance)
            {
                instance = new taskManager();
            }

            return instance;
        }

        // タスクを生成する
        public taskItem createTask(String task, DateTime deadline)
        {
            taskItem item = new taskItem(task, deadline);
            this.taskList.Add(item);

            return item;
        }

        public void addTask(taskItem item)
        {
            this.taskList.Add(item);

        }

        // 指定したIDのタスクを削除
        public void deleteTaskById(long id)
        {
            for (int i = 0; i < this.taskList.Count; i++)
            {
                taskItem task = this.taskList[i];

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
                taskItem item = this.taskList[i];

                if(id == item.ID)
                {
                    item.Task = task;
                    item.Deadline = deadline;
                    break;
                }
            }          
        }

        // タスクのリストを取得
        public List<taskItem> getTaskList()
        {
            return this.taskList;
        }

        // タスクをファイルに保存
        public void saveTaskList()
        {
            using (System.IO.TextWriter writer = new System.IO.StreamWriter(confName))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<taskItem>));
                serializer.Serialize(writer, this.taskList);
            }
        }
    }
}
