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
                this.taskTableLayoutPanel.Controls.Add(v);

            }
        }

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

        private void okButton_Click(object sender, EventArgs e)
        {
            createTaskView v = (createTaskView)sender;
            taskManager manager = taskManager.getInstance();

            taskItem task = new taskItem(v.Task, v.Deadline);
            manager.addTask(task);

            taskView view = new taskView(task);

            this.tableLayoutPanel.Controls.Remove((createTaskView)sender);
            this.tableLayoutPanel.SetRow(this.taskTableLayoutPanel, 0);
            this.tableLayoutPanel.SetRowSpan(this.taskTableLayoutPanel, 2);

            this.taskTableLayoutPanel.Controls.Add(view);

            manager.saveTaskList();

            this.addButton.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.tableLayoutPanel.Controls.Remove((createTaskView)sender);
            this.tableLayoutPanel.SetRow(this.taskTableLayoutPanel, 0);
            this.tableLayoutPanel.SetRowSpan(this.taskTableLayoutPanel, 2);

            this.addButton.Enabled = true;
        }
    }
}
