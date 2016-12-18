﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskListManager.src;

namespace TaskListManager
{
    public partial class MainForm : Form
    {
        TaskEditView taskEditView;

        public MainForm()
        {
            InitializeComponent();

            // タスク編集画面の初期化
            this.taskEditView = new TaskEditView();
            this.taskEditView.okEvent += okButton_Click;
            this.taskEditView.cancelEvent += cancelButton_Click;

            this.mainPanel.SetRowSpan(this.taskListPanel, 2);

            TaskManager manager = TaskManager.getInstance();
            List<TaskItem> taskList = manager.getTaskList();

            foreach(TaskItem task in taskList)
            {
                addTaskView(task);
            }
        }

        // タスクを画面上のリストに追加する
        private void addTaskView(TaskItem task)
        {
            TaskView view = new TaskView(task);
            view.doneButton_Click += done;
            view.editButton_Click += edit;

            this.taskListPanel.Controls.Add(view);
        }

        // タスクの編集画面を表示する
        private void showTaskEditView()
        {
            this.mainPanel.SetRowSpan(this.taskListPanel, 1);
            this.mainPanel.SetRow(this.taskListPanel, 1);

            this.mainPanel.Controls.Add(this.taskEditView);
            this.mainPanel.SetRow(this.taskEditView, 0);

            this.addButton.Enabled = false;
            this.addButton.BackgroundImage = Properties.Resources.plus_disable;
        }

        // タスクの編集画面を非表示にする
        private void hideTaskEditView()
        {
            this.mainPanel.Controls.Remove(this.taskEditView);
            this.mainPanel.SetRow(this.taskListPanel, 0);
            this.mainPanel.SetRowSpan(this.taskListPanel, 2);

            this.addButton.Enabled = true;
            this.addButton.BackgroundImage = Properties.Resources.plus_enable;
        }

        // 「タスクの追加」ボタンを押したときのイベント
        private void addButton_Click(object sender, EventArgs e)
        {
            showTaskEditView();
        }

        // タスク追加画面で「OK」ボタンを押したときのイベント
        private void okButton_Click(object sender, EventArgs e)
        {
            TaskManager manager = TaskManager.getInstance();
            long id = this.taskEditView.ID;

            if(id < 0) // 新規タスク追加
            {
                TaskItem task = new TaskItem(this.taskEditView.Task, this.taskEditView.Deadline);
                manager.addTask(task);
                addTaskView(task);
            }
            else  // 既存タスク編集
            {
                manager.editTaskItemByID(id, this.taskEditView.Task, this.taskEditView.Deadline);
            }

            manager.saveTaskList();

            // 画面の更新
            refreshTaskTable();
            hideTaskEditView();
        }

        // タスクリスト表示の更新
        private void refreshTaskTable()
        {
            TaskManager manager = TaskManager.getInstance();
            List<TaskItem> taskList = manager.getTaskList();

            for (int i = 0; i < this.taskListPanel.Controls.Count; i++)
            {
                TaskView taskView = (TaskView)this.taskListPanel.GetControlFromPosition(0, i);
                taskView.setTaskItem(taskList[i]);
            }
        }

        // タスクの追加画面で「Cancel」ボタンを押したときのイベント
        private void cancelButton_Click(object sender, EventArgs e)
        {
            hideTaskEditView();
        }

        // タスクの完了イベント
        private void done(object sender)
        {
            TaskView taskView = (TaskView)sender;
            TaskManager manager = TaskManager.getInstance();

            this.taskListPanel.Controls.Remove(taskView);

            manager.deleteTaskById(taskView.getTaskItemID());
            manager.saveTaskList();

            // 後片付け
            taskView = null;
        }

        // タスクの編集イベント
        private void edit(object sender)
        {
            TaskItem taskItem = TaskManager.getInstance().getTaskItemByID(((TaskView)sender).getTaskItemID());

            if(null != taskItem)
            {
                this.taskEditView.reflectTaskItem(taskItem);
            }
            showTaskEditView();
        }
    }
}
