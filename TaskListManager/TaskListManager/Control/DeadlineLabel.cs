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
    public partial class DeadlineLabel : UserControl
    {
        private DateTime deadline;

        public DeadlineLabel(DateTime date)
        {
            InitializeComponent();

            // ビューの設定
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Margin = new Padding(0, 0, 0, 3);

            this.deadline = date;
            this.dateLabel.Text = this.deadline.ToString("yyyy/MM/dd (ddd)");

            refreshRemainDays();

            // フォント設定
            setFontSize(Properties.Settings.Default.fontSize);           
        }

        public void refreshRemainDays()
        {
            // 残り日数表示
            TimeSpan remain = this.deadline.Date.Subtract(DateTime.Now.Date);

            if (remain.Days < 0)
            {
                this.remainDayLabel.Text = "期限切れ";
                this.dateLabel.ForeColor = Color.AntiqueWhite;
                this.remainDayLabel.ForeColor = Color.AntiqueWhite;
                this.BackColor = Color.Gray;
            }
            else if (remain.Days == 0)
            {
                this.remainDayLabel.Text = "今日まで";
                this.dateLabel.ForeColor = Color.AntiqueWhite;
                this.remainDayLabel.ForeColor = Color.AntiqueWhite;
                this.BackColor = Color.Red;
            }
            else if (remain.Days == 1)
            {
                this.remainDayLabel.Text = "明日まで";
                this.dateLabel.ForeColor = Color.Black;
                this.remainDayLabel.ForeColor = Color.Black;
                this.BackColor = Color.Orange;
            }
            else
            {
                this.remainDayLabel.Text = "あと" + remain.Days + "日";
                this.dateLabel.ForeColor = Color.Black;
                this.remainDayLabel.ForeColor = Color.Black;
                this.BackColor = Color.Aquamarine;
            }
        }

        public void setFontSize(int size)
        {
            Font font = new Font("Meiryo UI", size);
            Size strSize;

            this.dateLabel.Font = font;         
            this.remainDayLabel.Font = font;            

            this.Height = font.Height * 2;

            this.dateLabel.Height = this.Height;
            strSize = TextRenderer.MeasureText(this.dateLabel.Text, font);
            this.dateLabel.Width = strSize.Width + this.dateLabel.Padding.Left;
            this.dateLabel.Location = new Point(0, 0);

            this.remainDayLabel.Height = this.Height;
            strSize = TextRenderer.MeasureText(this.remainDayLabel.Text, font);
            this.remainDayLabel.Width = strSize.Width;
            this.remainDayLabel.Location = new Point(this.Width - strSize.Width, 0);
        }
    }
}
