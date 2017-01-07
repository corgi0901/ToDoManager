using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskListManager.src;
using TaskListManager.Control;

namespace TaskListManager
{
    public partial class MainForm : Form
    {
        TaskEditView taskEditView;
        SettingView settingView;

        public MainForm()
        {
            InitializeComponent();

            // タスク編集画面の初期化
            this.taskEditView = new TaskEditView();
            this.taskEditView.okEvent += okButton_Click;
            this.taskEditView.cancelEvent += cancelButton_Click;

            // 設定画面の初期化
            this.settingView = new SettingView();
            this.settingView.okEvent += setting_okButton_Click;
            this.settingView.cancelEvent += setting_cancelButton_Click;

            // フォームサイズの取得
            System.Drawing.Size formSize = this.DisplayRectangle.Size;

            // 各ボタンの設定
            this.addButtonToolTip.SetToolTip(this.addButton, "新規タスクの登録");

            this.settingButtonToolTip.SetToolTip(this.settingButton, "アプリケーション設定");
            this.settingButton.Location = new System.Drawing.Point(formSize.Width - this.settingButton.Width - 10, this.settingButton.Location.Y);

            this.mainPanel.SetRowSpan(this.taskListPanel, 2);
            this.mainPanel.Size = new System.Drawing.Size(formSize.Width - 4, formSize.Height - this.mainPanel.Location.Y - 2);

            refreshTaskTable();
        }

        // フォームが閉じるときの処理
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 位置とサイズの設定を保存する
            Properties.Settings.Default.Save();
        }

        // タスクの締め切り日時を画面上のリストに追加する
        private void addDateView(DateTime date)
        {
            DeadlineLabel view = new DeadlineLabel(date);
            this.taskListPanel.Controls.Add(view);
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
        private void showTaskEditView(EDIT_MODE mode)
        {
            this.mainPanel.SetRowSpan(this.taskListPanel, 1);
            this.mainPanel.SetRow(this.taskListPanel, 1);

            this.mainPanel.Controls.Add(this.taskEditView);
            this.mainPanel.SetRow(this.taskEditView, 0);

            this.settingButton.Enabled = false;
            this.settingButton.BackgroundImage = Properties.Resources.setting_disable;

            this.addButton.Enabled = false;
            this.addButton.BackgroundImage = Properties.Resources.plus_disable;

            this.taskEditView.setEditMode(mode);
        }

        // タスクの編集画面を非表示にする
        private void hideTaskEditView()
        {
            this.mainPanel.Controls.Remove(this.taskEditView);
            this.mainPanel.SetRow(this.taskListPanel, 0);
            this.mainPanel.SetRowSpan(this.taskListPanel, 2);

            this.settingButton.Enabled = true;
            this.settingButton.BackgroundImage = Properties.Resources.setting_enable;

            this.addButton.Enabled = true;
            this.addButton.BackgroundImage = Properties.Resources.plus_enable;
        }

        // 「タスクの追加」ボタンを押したときのイベント
        private void addButton_Click(object sender, EventArgs e)
        {
            showTaskEditView(EDIT_MODE.New);
        }

        // タスク追加画面で「OK」ボタンを押したときのイベント
        private void okButton_Click(object sender, EventArgs e)
        {
            TaskManager manager = TaskManager.getInstance();
            long id = this.taskEditView.ID;

            if(id < 0) // 新規タスク追加
            {
                TaskItem task = new TaskItem(this.taskEditView.Task, this.taskEditView.Deadline, this.taskEditView.RepeatType);
                manager.addTask(task);
            }
            else  // 既存タスク編集
            {
                manager.editTaskItemByID(id, this.taskEditView.Task, this.taskEditView.Deadline, this.taskEditView.RepeatType);
            }

            manager.saveTaskList();

            hideTaskEditView();

            // 画面の更新
            refreshTaskTable();
        }

        // タスクリスト表示の更新
        private void refreshTaskTable()
        {
            TaskManager manager = TaskManager.getInstance();
            List<TaskItem> taskList = manager.getTaskList();

            // タスクリストの全コントロールを削除
            this.taskListPanel.Controls.Clear();
            
            DateTime date = new DateTime();

            foreach(TaskItem task in taskList)
            {
                if(task.Deadline.Date != date)
                {
                    addDateView(task.Deadline.Date);
                    date = task.Deadline.Date;
                }
                addTaskView(task);
            }

            // スクロール領域の再設定
            this.taskListPanel.AutoScroll = false;
            this.taskListPanel.AutoScroll = true;
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

            manager.completeTaskById(taskView.getTaskItemID());
            
            manager.saveTaskList();

            refreshTaskTable();
        }

        // タスクの編集イベント
        private void edit(object sender)
        {
            TaskItem taskItem = TaskManager.getInstance().getTaskItemByID(((TaskView)sender).getTaskItemID());

            if(null != taskItem)
            {
                this.taskEditView.reflectTaskItem(taskItem);
            }
            showTaskEditView(EDIT_MODE.Edit);
        }

        // タスク期限表示の更新のタイマーイベント
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.taskListPanel.Controls.Count; i++)
            {
                System.Windows.Forms.Control control = this.taskListPanel.GetControlFromPosition(0, i);

                if(control is DeadlineLabel)
                {
                    ((DeadlineLabel)control).refreshRemainDays();
                }
            }
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            showSettingView();
        }

        // 設定画面を表示する
        private void showSettingView()
        {
            this.mainPanel.SetRowSpan(this.taskListPanel, 1);
            this.mainPanel.SetRow(this.taskListPanel, 1);

            this.mainPanel.Controls.Add(this.settingView);
            this.mainPanel.SetRow(this.settingView, 0);

            this.settingButton.Enabled = false;
            this.settingButton.BackgroundImage = Properties.Resources.setting_disable;

            this.addButton.Enabled = false;
            this.addButton.BackgroundImage = Properties.Resources.plus_disable;
        }

        // タスクの編集画面を非表示にする
        private void hideSettingView()
        {
            this.mainPanel.Controls.Remove(this.settingView);
            this.mainPanel.SetRow(this.taskListPanel, 0);
            this.mainPanel.SetRowSpan(this.taskListPanel, 2);

            this.settingButton.Enabled = true;
            this.settingButton.BackgroundImage = Properties.Resources.setting_enable;

            this.addButton.Enabled = true;
            this.addButton.BackgroundImage = Properties.Resources.plus_enable;
        }

        private void setting_okButton_Click(object sender, EventArgs e)
        {
            // フォントサイズを反映する
            this.settingView.setFontSize(Properties.Settings.Default.fontSize);
            this.taskEditView.setFontSize(Properties.Settings.Default.fontSize);

            for (int i = 0; i < this.taskListPanel.Controls.Count; i++)
            {
                System.Windows.Forms.Control control = this.taskListPanel.GetControlFromPosition(0, i);

                if (control is DeadlineLabel)
                {
                    ((DeadlineLabel)control).setFontSize(Properties.Settings.Default.fontSize);
                }
                else if(control is TaskView)
                {
                    ((TaskView)control).setFontSize(Properties.Settings.Default.fontSize);
                }
            }

            hideSettingView();

            // スクロール領域の再設定
            this.taskListPanel.AutoScroll = false;
            this.taskListPanel.AutoScroll = true;
        }

        private void setting_cancelButton_Click(object sender, EventArgs e)
        {
            hideSettingView();
        }
    }
}
