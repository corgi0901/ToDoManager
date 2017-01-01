using System;
using System.Drawing;
using System.Windows.Forms;
using TaskListManager.src;

namespace TaskListManager
{
    public partial class TaskView : UserControl
    {
        private Boolean isShowButton;
        private Label timeLabel;
        private Label taskLabel;
        private TaskOptionPanel optButton;
        private long ID;

        public delegate void optionButtonEventHandler(object sender);
        public event optionButtonEventHandler doneButton_Click;
        public event optionButtonEventHandler editButton_Click;

        public TaskView(TaskItem taskItem)
        {
            InitializeComponent();

            // 状態の初期設定
            this.isShowButton = false;

            // ビュー全体のレイアウト設定
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Margin = new Padding(0, 0, 0, 3);

            // 時刻表示部の初期化
            this.timeLabel = new Label();
            this.timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.timeLabel.Margin = new Padding(0);
            this.timeLabel.Padding = new Padding(0, 0, 0, 0);
            this.timeLabel.Click += Task_Click;

            // タスク表示部の初期化
            this.taskLabel = new Label();
            this.taskLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.taskLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.taskLabel.Margin = new Padding(0);
            this.taskLabel.Padding = new Padding(0, 0, 0, 0);
            this.taskLabel.Click += Task_Click;

            // オプションボタンの初期化
            this.optButton = new TaskOptionPanel();
            this.optButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.optButton.Margin = new Padding(0);
            this.optButton.doneEvent += doneButtun_ClickEvent;
            this.optButton.editEvent += editButtun_ClickEvent;

            // テーブルレイアウトに追加
            this.mainPanel.Controls.Add(this.timeLabel);
            this.mainPanel.Controls.Add(this.taskLabel);
            this.mainPanel.SetColumnSpan(this.taskLabel, 2);

            setFontSize(10);

            // タスクの内容を反映
            setTaskItem(taskItem);
        }

        // 表示されているタスクを取得する
        public long getTaskItemID()
        {
            return this.ID;
        }

        // 表示するタスクを設定する
        public void setTaskItem(TaskItem taskItem)
        {
            this.ID = taskItem.ID;
            this.timeLabel.Text = taskItem.Deadline.TimeOfDay.ToString(@"hh\:mm");
            this.taskLabel.Text = taskItem.Task;

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
            this.Height = font.Height * 4;
            this.mainPanel.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, font.Height * 4);
            this.mainPanel.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, font.Height * 4);
            this.optButton.setSize(font.Height * 4, font.Height * 4);
        }

        // タスクの内容がクリックされたときの処理
        private void Task_Click(object sender, EventArgs e)
        {
            if ( false == this.isShowButton )
            {
                this.mainPanel.SetColumnSpan(this.taskLabel, 1);
                this.mainPanel.SetColumn(this.taskLabel, 2);
                this.mainPanel.SetColumn(this.timeLabel, 1);
                this.mainPanel.Controls.Add(this.optButton, 0, 0);

                this.isShowButton = true;
            }
            else
            {
                this.mainPanel.Controls.Remove(this.optButton);
                this.mainPanel.SetColumnSpan(this.taskLabel, 2);

                this.isShowButton = false;
            }   
        }

        // 「完了」ボタンをクリックしたときの処理
        private void doneButtun_ClickEvent()
        {
            this.mainPanel.Controls.Remove(this.optButton);
            this.mainPanel.SetColumnSpan(this.taskLabel, 2);
            this.isShowButton = false;

            doneButton_Click(this);
        }

        // 「編集」ボタンをクリックしたときの処理
        private void editButtun_ClickEvent()
        {
            this.mainPanel.Controls.Remove(this.optButton);
            this.mainPanel.SetColumnSpan(this.taskLabel, 2);
            this.isShowButton = false;

            editButton_Click(this);
        }
    }
}
