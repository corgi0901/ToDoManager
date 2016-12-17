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

            TableLayoutPanel taskList = (TableLayoutPanel)this.tableLayoutPanel.GetControlFromPosition(0, 0);
            this.tableLayoutPanel.SetRowSpan(taskList, 2);

            taskManager manager = taskManager.getInstance();
            List<taskItem> list = manager.getTaskList();

            foreach(taskItem item in list)
            {
                taskView v = new taskView(item);
                v.doneButton_Click += done;
                v.editButton_Click += edit;

                this.taskTableLayoutPanel.Controls.Add(v);
            }
        }

        // 「タスクの追加」ボタンを押したときのイベント
        private void addButton_Click(object sender, EventArgs e)
        {
            createTaskView v = new createTaskView();
            v.okEvent += okButton_Click;
            v.cancelEvent += cancelButton_Click;

            this.tableLayoutPanel.SetRowSpan(this.taskTableLayoutPanel, 1);
            this.tableLayoutPanel.SetRow(this.taskTableLayoutPanel, 1);

            this.tableLayoutPanel.Controls.Add(v);
            this.tableLayoutPanel.SetRow(v, 0);

            this.addButton.Enabled = false;
        }

        // タスク追加画面で「OK」ボタンを押したときのイベント
        private void okButton_Click(object sender, EventArgs e)
        {
            createTaskView v = (createTaskView)sender;
            taskManager manager = taskManager.getInstance();

            if (true == v.getIsEdit())
            {
                manager.editTaskById(v.ID, v.Task, v.Deadline);

                for(int i=0; i < this.taskTableLayoutPanel.Controls.Count; i++)
                {
                    taskView tv = (taskView)this.taskTableLayoutPanel.GetControlFromPosition(0, i);

                    if (v.ID == tv.getTask().ID)
                    {
                        tv.TaskText = v.Task;
                    }
                }
            }
            else
            {
                taskItem task = new taskItem(v.Task, v.Deadline);
                manager.addTask(task);

                taskView view = new taskView(task);
                view.doneButton_Click += done;
                view.editButton_Click += edit;

                this.taskTableLayoutPanel.Controls.Add(view);
            }

            this.tableLayoutPanel.Controls.Remove((createTaskView)sender);
            this.tableLayoutPanel.SetRow(this.taskTableLayoutPanel, 0);
            this.tableLayoutPanel.SetRowSpan(this.taskTableLayoutPanel, 2);

            manager.saveTaskList();

            this.addButton.Enabled = true;
        }

        // タスクの追加画面で「Cancel」ボタンを押したときのイベント
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.tableLayoutPanel.Controls.Remove((createTaskView)sender);
            this.tableLayoutPanel.SetRow(this.taskTableLayoutPanel, 0);
            this.tableLayoutPanel.SetRowSpan(this.taskTableLayoutPanel, 2);

            this.addButton.Enabled = true;
        }

        // タスクの完了イベント
        private void done(object sender)
        {
            taskView v = (taskView)sender;
            taskManager manager = taskManager.getInstance();

            this.taskTableLayoutPanel.Controls.Remove(v);
                      
            manager.deleteTaskById(v.getTask().ID);
            manager.saveTaskList();
        }

        // タスクの編集イベント
        private void edit(object sender)
        {
            taskItem item = ((taskView)sender).getTask();

            createTaskView v = new createTaskView(item);
            v.okEvent += okButton_Click;
            v.cancelEvent += cancelButton_Click;

            this.tableLayoutPanel.SetRowSpan(this.taskTableLayoutPanel, 1);
            this.tableLayoutPanel.SetRow(this.taskTableLayoutPanel, 1);

            this.tableLayoutPanel.Controls.Add(v);
            this.tableLayoutPanel.SetRow(v, 0);

            this.addButton.Enabled = false;
        }
    }
}
