using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskListManager.src;

namespace TaskListManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            TableLayoutPanel taskList = (TableLayoutPanel)this.mainPanel.GetControlFromPosition(0, 0);
            this.mainPanel.SetRowSpan(taskList, 2);

            TaskManager manager = TaskManager.getInstance();
            List<TaskItem> list = manager.getTaskList();

            foreach(TaskItem item in list)
            {
                TaskView v = new TaskView(item);
                v.doneButton_Click += done;
                v.editButton_Click += edit;

                this.taskListPanel.Controls.Add(v);
            }
        }

        // 「タスクの追加」ボタンを押したときのイベント
        private void addButton_Click(object sender, EventArgs e)
        {
            TaskEditView view = new TaskEditView();
            view.okEvent += okButton_Click;
            view.cancelEvent += cancelButton_Click;

            this.mainPanel.SetRowSpan(this.taskListPanel, 1);
            this.mainPanel.SetRow(this.taskListPanel, 1);

            this.mainPanel.Controls.Add(view);
            this.mainPanel.SetRow(view, 0);

            this.addButton.Enabled = false;
        }

        // タスク追加画面で「OK」ボタンを押したときのイベント
        private void okButton_Click(object sender, EventArgs e)
        {
            TaskEditView v = (TaskEditView)sender;
            TaskManager manager = TaskManager.getInstance();

            if (true == v.getIsEdit())
            {
                manager.editTaskById(v.ID, v.Task, v.Deadline);

                for(int i=0; i < this.taskListPanel.Controls.Count; i++)
                {
                    TaskView tv = (TaskView)this.taskListPanel.GetControlFromPosition(0, i);

                    if (v.ID == tv.getTask().ID)
                    {
                        tv.TaskText = v.Task;
                    }
                }
            }
            else
            {
                TaskItem task = new TaskItem(v.Task, v.Deadline);
                manager.addTask(task);

                TaskView view = new TaskView(task);
                view.doneButton_Click += done;
                view.editButton_Click += edit;

                this.taskListPanel.Controls.Add(view);
            }

            this.mainPanel.Controls.Remove((TaskEditView)sender);
            this.mainPanel.SetRow(this.taskListPanel, 0);
            this.mainPanel.SetRowSpan(this.taskListPanel, 2);

            manager.saveTaskList();

            this.addButton.Enabled = true;
        }

        // タスクの追加画面で「Cancel」ボタンを押したときのイベント
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Remove((TaskEditView)sender);
            this.mainPanel.SetRow(this.taskListPanel, 0);
            this.mainPanel.SetRowSpan(this.taskListPanel, 2);

            this.addButton.Enabled = true;
        }

        // タスクの完了イベント
        private void done(object sender)
        {
            TaskView v = (TaskView)sender;
            TaskManager manager = TaskManager.getInstance();

            this.taskListPanel.Controls.Remove(v);
                      
            manager.deleteTaskById(v.getTask().ID);
            manager.saveTaskList();
        }

        // タスクの編集イベント
        private void edit(object sender)
        {
            TaskItem item = ((TaskView)sender).getTask();

            TaskEditView v = new TaskEditView(item);
            v.okEvent += okButton_Click;
            v.cancelEvent += cancelButton_Click;

            this.mainPanel.SetRowSpan(this.taskListPanel, 1);
            this.mainPanel.SetRow(this.taskListPanel, 1);

            this.mainPanel.Controls.Add(v);
            this.mainPanel.SetRow(v, 0);

            this.addButton.Enabled = false;
        }
    }
}
