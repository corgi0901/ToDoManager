using System;
using System.Drawing;
using System.Windows.Forms;
using TaskListManager.src;

namespace TaskListManager
{
    public partial class TaskView : UserControl
    {
        private Boolean isShowButton;
        private Label dealineLabel;
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
            this.dealineLabel = new Label();
            this.dealineLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.dealineLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.dealineLabel.Margin = new Padding(0);
            this.dealineLabel.Padding = new Padding(5, 0, 0, 0);
            this.dealineLabel.Click += Task_Click;

            // タスク表示部の初期化
            this.taskLabel = new Label();
            this.taskLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.taskLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.taskLabel.Margin = new Padding(0);
            this.taskLabel.Padding = new Padding(5, 0, 0, 0);
            this.taskLabel.Click += Task_Click;

            // オプションボタンの初期化
            this.optButton = new TaskOptionPanel();
            this.optButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.optButton.Margin = new Padding(0);
            this.optButton.doneEvent += doneButtun_ClickEvent;
            this.optButton.editEvent += editButtun_ClickEvent;

            // テーブルレイアウトに追加
            this.tableLayoutPanel1.Controls.Add(this.dealineLabel);
            this.tableLayoutPanel1.Controls.Add(this.taskLabel);
            this.tableLayoutPanel1.SetColumnSpan(this.taskLabel, 2);

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
            this.dealineLabel.Text = taskItem.Deadline.TimeOfDay.ToString(@"hh\:mm");
            this.taskLabel.Text = taskItem.Task;
        }

        // タスクの内容がクリックされたときの処理
        private void Task_Click(object sender, EventArgs e)
        {
            if ( false == this.isShowButton )
            {
                this.tableLayoutPanel1.SetColumnSpan(this.taskLabel, 1);
                this.tableLayoutPanel1.Controls.Add(this.optButton);

                this.isShowButton = true;
            }
            else
            {
                this.tableLayoutPanel1.Controls.Remove(this.optButton);
                this.tableLayoutPanel1.SetColumnSpan(this.taskLabel, 2);

                this.isShowButton = false;
            }   
        }

        // 「完了」ボタンをクリックしたときの処理
        private void doneButtun_ClickEvent()
        {
            this.tableLayoutPanel1.Controls.Remove(this.optButton);
            this.tableLayoutPanel1.SetColumnSpan(this.taskLabel, 2);
            this.isShowButton = false;

            doneButton_Click(this);
        }

        // 「編集」ボタンをクリックしたときの処理
        private void editButtun_ClickEvent()
        {
            this.tableLayoutPanel1.Controls.Remove(this.optButton);
            this.tableLayoutPanel1.SetColumnSpan(this.taskLabel, 2);
            this.isShowButton = false;

            editButton_Click(this);
        }
    }
}
