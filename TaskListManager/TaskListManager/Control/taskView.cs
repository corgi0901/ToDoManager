using System;
using System.Drawing;
using System.Windows.Forms;
using TaskListManager.src;

namespace TaskListManager
{
    public partial class taskView : UserControl
    {
        private Boolean isShowButton;
        private Label taskLabel;
        private optionButton optButton;
        private taskItem task;

        public String taskText;
        //public DateTime Deadline;

        public delegate void optionButtonEventHandler(object sender);
        public event optionButtonEventHandler doneButton_Click;
        public event optionButtonEventHandler editButton_Click;

        public String TaskText
        {
            get { return this.taskLabel.Text; }
            set { this.taskLabel.Text = value; }
        }

        /*
        public DateTime Deadline
        {
            get { return this.dateTimePicker.Value; }
            set { this.dateTimePicker.Value = value; }
        }
        */

        public taskView(taskItem task)
        {
            InitializeComponent();

            // 状態の初期設定
            this.isShowButton = false;
            this.task = task;

            // ビュー全体のレイアウト設定
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Margin = new Padding(0, 0, 0, 5);

            // タスク表示部の初期化
            this.taskLabel = new Label();
            this.taskLabel.Text = task.Task;
            this.taskLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.taskLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.taskLabel.Margin = new Padding(0);
            this.taskLabel.Padding = new Padding(5, 0, 0, 0);

            this.taskLabel.Click += Task_Click;

            // オプションボタンの初期化
            this.optButton = new optionButton();
            this.optButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.optButton.Margin = new Padding(0);
            this.optButton.doneEvent += doneButtun_ClickEvent;
            this.optButton.editEvent += editButtun_ClickEvent;


            // テーブルレイアウトに追加
            this.tableLayoutPanel1.Controls.Add(this.taskLabel);
            this.tableLayoutPanel1.SetColumnSpan(this.taskLabel, 2);

            // ToDo: デバッグ用。あとで消すこと。
            //this.BorderStyle = BorderStyle.FixedSingle;
            //this.taskLabel.BorderStyle = BorderStyle.FixedSingle;
            //this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }

        // タスクを取得する
        public taskItem getTask()
        {
            return this.task;
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
            doneButton_Click(this);
        }

        // 「編集」ボタンをクリックしたときの処理
        private void editButtun_ClickEvent()
        {
            editButton_Click(this);
        }
    }
}
