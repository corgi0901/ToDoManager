﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToDoManager.src;

namespace ToDoManager
{
    public partial class TaskView : UserControl
    {
        private Label timeLabel;
        private Label taskLabel;
        private TaskOptionPanel optButton;
        private long ID;
		private bool isShowMenu;
		private bool isLock;

        public delegate void optionButtonEventHandler(object sender);
        public event optionButtonEventHandler doneButton_Click;
        public event optionButtonEventHandler editButton_Click;
        public event optionButtonEventHandler deleteButton_Click;

        public TaskView(TaskItem taskItem)
        {
            InitializeComponent();

			this.isShowMenu = false;
			this.isLock = false;

            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Margin = new Padding(0, 0, 0, 3);

            this.timeLabel = new Label();
            this.timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.timeLabel.Margin = new Padding(0);
            this.timeLabel.Padding = new Padding(0, 0, 0, 0);
            this.timeLabel.Click += Task_Click;

            this.taskLabel = new Label();
            this.taskLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.taskLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.taskLabel.Margin = new Padding(0);
            this.taskLabel.Padding = new Padding(0, 0, 0, 0);
            this.taskLabel.Click += Task_Click;

            this.optButton = new TaskOptionPanel();
            this.optButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.optButton.Margin = new Padding(0);
            this.optButton.doneEvent += doneButton_ClickEvent;
            this.optButton.editEvent += editButton_ClickEvent;
            this.optButton.returnEvent += returnButton_ClickEvent;
            this.optButton.deleteEvent += deleteButton_ClickEvent;

            this.mainPanel.Controls.Add(this.timeLabel);
            this.mainPanel.Controls.Add(this.taskLabel);

            setFontSize(Properties.Settings.Default.fontSize);

            setTaskItem(taskItem);
        }

        public long getTaskItemID()
        {
            return this.ID;
        }

        public void setTaskItem(TaskItem taskItem)
        {
            this.ID = taskItem.ID;
            this.timeLabel.Text = taskItem.Deadline.TimeOfDay.ToString(@"hh\:mm");

            this.taskLabel.Text = taskItem.Task;

            int line = taskItem.Task.Count(c => c == '\n') + 1;
            this.Height = (int)(this.taskLabel.Font.GetHeight() * (line + 2));

            this.optButton.setSize(this.taskLabel.Font.Height * 4, this.taskLabel.Height);

            switch (taskItem.RepeatType)
            {
                case REPEAT_TYPE.none:
                    break;
                case REPEAT_TYPE.day:
                    this.timeLabel.Text += "\n(毎日)";
                    break;
                case REPEAT_TYPE.week:
                    this.timeLabel.Text += "\n(毎週)";
                    break;
                default:
                    break;
            }
        }

        public void setFontSize(int size)
        {
            Font font = new Font("Meiryo UI", size);

            this.timeLabel.Font = font;
            this.taskLabel.Font = font;
            
            this.mainPanel.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, font.Height * 4);

            int line = this.taskLabel.Text.Count(c => c == '\n') + 1;

            if (line < 2) line = 2;
            this.Height = (int)(this.taskLabel.Font.GetHeight() * (line + 1));
        }

		public void hideMenuContent()
		{
			if(this.isShowMenu == true)
			{
				this.showTaskContent();
			}		
		}

		public void setLock(bool value)
		{
			this.isLock = value;
		}

        private void Task_Click(object sender, EventArgs e)
        {
			this.showMenuContent();
        }

		private void showMenuContent()
		{
			if (this.isLock)
			{
				return;
			}

			this.mainPanel.Controls.Clear();
			this.mainPanel.Controls.Add(this.optButton, 0, 0);
			this.mainPanel.SetColumnSpan(this.optButton, this.mainPanel.ColumnCount);
			this.isShowMenu = true;

			TaskViewManager.getInstance().indicateShowMenu(this);
		}

        private void showTaskContent()
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(this.timeLabel);
            this.mainPanel.Controls.Add(this.taskLabel);
			this.isShowMenu = false;
        }

        private void returnButton_ClickEvent()
        {
            this.showTaskContent();
        }

        private void doneButton_ClickEvent()
        {
            this.showTaskContent();
            doneButton_Click(this);
        }

        private void editButton_ClickEvent()
        {
            this.showTaskContent();
            editButton_Click(this);
        }

        private void deleteButton_ClickEvent()
        {
            this.showTaskContent();
            deleteButton_Click(this);
        }
    }
}