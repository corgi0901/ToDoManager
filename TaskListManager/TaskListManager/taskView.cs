using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskListManager
{
    public partial class taskView : UserControl
    {
        private Boolean isShowButton;
        private Label taskLabel;
        private optionButton optButton;

        public taskView(String task, DateTime limit)
        {
            InitializeComponent();

            // 状態の初期設定
            isShowButton = false;

            // ビュー全体のレイアウト設定
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //this.BorderStyle = BorderStyle.FixedSingle;

            // 各ビューの初期化
            this.taskLabel = new Label();
            this.taskLabel.Text = task;
            this.taskLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.taskLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.taskLabel.Click += Task_Click;

            this.optButton = new optionButton();
            this.optButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // テーブルレイアウトに追加
            this.tableLayoutPanel1.Controls.Add(this.taskLabel);
            this.tableLayoutPanel1.SetColumnSpan(this.taskLabel, 2);

            // ToDo: デバッグ用。あとで消すこと。
            //this.taskLabel.BorderStyle = BorderStyle.FixedSingle;
            //this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
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
    }
}
