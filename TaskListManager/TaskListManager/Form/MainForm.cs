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

            this.taskEditView = new TaskEditView();
            this.taskEditView.okEvent += okButton_Click;
            this.taskEditView.cancelEvent += cancelButton_Click;

            this.settingView = new SettingView();
            this.settingView.okEvent += setting_okButton_Click;
            this.settingView.cancelEvent += setting_cancelButton_Click;

            System.Drawing.Size formSize = this.DisplayRectangle.Size;

            this.addButtonToolTip.SetToolTip(this.addButton, "新規タスクの登録");

            this.settingButtonToolTip.SetToolTip(this.settingButton, "アプリケーション設定");
            this.settingButton.Location = new System.Drawing.Point(formSize.Width - this.settingButton.Width - 10, this.settingButton.Location.Y);

            this.mainPanel.SetRowSpan(this.taskListPanel, 2);
            this.mainPanel.Size = new System.Drawing.Size(formSize.Width - 4, formSize.Height - this.mainPanel.Location.Y - 2);

            refreshTaskTable();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void addDateView(DateTime date)
        {
            DeadlineLabel view = new DeadlineLabel(date);
            this.taskListPanel.Controls.Add(view);
        }

        private void addTaskView(TaskItem task)
        {
            TaskView view = new TaskView(task);
            view.doneButton_Click += done;
            view.editButton_Click += edit;
            view.deleteButton_Click += delete;
            this.taskListPanel.Controls.Add(view);
			TaskViewManager.getInstance().addTaskView(view);
        }

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

			TaskViewManager.getInstance().setTaskViewLock(true);
        }

        private void hideTaskEditView()
        {
            this.mainPanel.Controls.Remove(this.taskEditView);
            this.mainPanel.SetRow(this.taskListPanel, 0);
            this.mainPanel.SetRowSpan(this.taskListPanel, 2);

            this.settingButton.Enabled = true;
            this.settingButton.BackgroundImage = Properties.Resources.setting_enable;

            this.addButton.Enabled = true;
            this.addButton.BackgroundImage = Properties.Resources.plus_enable;

			TaskViewManager.getInstance().setTaskViewLock(false);
		}

        private void addButton_Click(object sender, EventArgs e)
        {
            showTaskEditView(EDIT_MODE.New);
			TaskViewManager.getInstance().hideAllMenuContent();
		}

        private void okButton_Click(object sender, EventArgs e)
        {
            TaskManager manager = TaskManager.getInstance();
            long id = this.taskEditView.ID;

            if(id < 0) // add new task
            {
                TaskItem task = new TaskItem(this.taskEditView.Task, this.taskEditView.Deadline, this.taskEditView.RepeatType);
                manager.addTask(task);
            }
            else  // edit task
            {
                manager.editTaskItemByID(id, this.taskEditView.Task, this.taskEditView.Deadline, this.taskEditView.RepeatType);
            }

            manager.saveTaskList();

            hideTaskEditView();

			refreshTaskTable();
        }

        private void refreshTaskTable()
        {
            TaskManager manager = TaskManager.getInstance();
            List<TaskItem> taskList = manager.getTaskList();

            this.taskListPanel.Controls.Clear();
			TaskViewManager.getInstance().clear();
            
            DateTime date = new DateTime();
            int max = Properties.Settings.Default.taskNum;

            for(int i = 0; i < taskList.Count && i < max; i++)
            {
                TaskItem task = taskList[i];

                if(task.Deadline.Date != date)
                {
                    addDateView(task.Deadline.Date);
                    date = task.Deadline.Date;
                }
                addTaskView(task);
            }

            this.taskListPanel.AutoScroll = false;
            this.taskListPanel.AutoScroll = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            hideTaskEditView();
		}

        private void done(object sender)
        {
            TaskView taskView = (TaskView)sender;
            TaskManager manager = TaskManager.getInstance();

            manager.completeTaskById(taskView.getTaskItemID());
            manager.saveTaskList();

            refreshTaskTable();
        }

        private void edit(object sender)
        {
            TaskItem taskItem = TaskManager.getInstance().getTaskItemByID(((TaskView)sender).getTaskItemID());

            if(null != taskItem)
            {
                this.taskEditView.reflectTaskItem(taskItem);
            }
            showTaskEditView(EDIT_MODE.Edit);
        }

        private void delete(object sender)
        {
            TaskView taskView = (TaskView)sender;
            TaskManager manager = TaskManager.getInstance();

            manager.deleteTaskById(taskView.getTaskItemID());

            manager.saveTaskList();
            refreshTaskTable();
        }

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

			TaskViewManager.getInstance().hideAllMenuContent();
			TaskViewManager.getInstance().setTaskViewLock(true);
		}

        private void hideSettingView()
        {
            this.mainPanel.Controls.Remove(this.settingView);
            this.mainPanel.SetRow(this.taskListPanel, 0);
            this.mainPanel.SetRowSpan(this.taskListPanel, 2);

            this.settingButton.Enabled = true;
            this.settingButton.BackgroundImage = Properties.Resources.setting_enable;

            this.addButton.Enabled = true;
            this.addButton.BackgroundImage = Properties.Resources.plus_enable;

			TaskViewManager.getInstance().setTaskViewLock(false);
		}

        private void setting_okButton_Click(object sender, EventArgs e)
        {
            SettingEventArgs args = (SettingEventArgs)e;

            hideSettingView();

            if(args.changeTaskNum)
            {
                this.refreshTaskTable();
            }
           
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

			this.taskListPanel.AutoScroll = false;
            this.taskListPanel.AutoScroll = true;
        }

        private void setting_cancelButton_Click(object sender, EventArgs e)
        {
            hideSettingView();
		}
	}
}
