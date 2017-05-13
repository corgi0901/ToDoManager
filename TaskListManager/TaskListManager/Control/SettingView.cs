using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskListManager.src;

namespace TaskListManager.Control
{
    public partial class SettingView : UserControl
    {
        public SettingView()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.label1.Width = this.Width;

            this.fontSizeNumericUpDown.Value = Properties.Settings.Default.fontSize;
            this.taskNumNumericUpDown.Value = Properties.Settings.Default.taskNum;

            setFontSize(Properties.Settings.Default.fontSize);
        }

        public void setFontSize(int size)
        {
            Font font = new Font("Meiryo UI", size);
            Size strSize;

            this.label1.Font = font;
            strSize = TextRenderer.MeasureText(this.label1.Text, font);
            this.label1.Height = (int)(strSize.Height * 1.5);

            this.label2.Font = font;
            this.label2.Height = font.Height;

            this.fontSizeNumericUpDown.Font = font;
            this.fontSizeNumericUpDown.Height = font.Height;

            this.label3.Font = font;
            this.label3.Height = font.Height;

            this.taskNumNumericUpDown.Font = font;
            this.taskNumNumericUpDown.Height = font.Height;

            strSize = TextRenderer.MeasureText(this.cancelButton.Text, font);

            this.okButton.Font = font;
            this.okButton.Height = strSize.Height + 10;
            this.okButton.Width = strSize.Width + 20;

            this.cancelButton.Font = font;
            this.cancelButton.Height = strSize.Height + 10;
            this.cancelButton.Width = strSize.Width + 20;

            this.label1.Location = new Point(0, 0);

            this.label2.Location = new Point(5, this.label1.Location.Y + this.label1.Height + 5);
            this.fontSizeNumericUpDown.Location = new Point(this.label2.Location.X, this.label2.Location.Y + this.label2.Height + 3);

            this.label3.Location = new Point(5, this.fontSizeNumericUpDown.Location.Y + this.fontSizeNumericUpDown.Height + 5);
            this.taskNumNumericUpDown.Location = new Point(this.label3.Location.X, this.label3.Location.Y + this.label3.Height + 3);

            this.okButton.Location = new Point(this.taskNumNumericUpDown.Location.X, this.taskNumNumericUpDown.Location.Y + this.taskNumNumericUpDown.Height + 5);
            this.cancelButton.Location = new Point(this.okButton.Location.X + this.okButton.Width + 5, this.okButton.Location.Y);

            this.Height = this.okButton.Location.Y + this.okButton.Height + 10;
        }

        public delegate void CreateSettingViewEventHandler(object sender, EventArgs e);
        public event CreateSettingViewEventHandler okEvent;
        public event CreateSettingViewEventHandler cancelEvent;

        private void okButton_Click(object sender, EventArgs e)
        {
            SettingEventArgs args = new SettingEventArgs();

            if(Properties.Settings.Default.fontSize != this.fontSizeNumericUpDown.Value)
            {
                args.changeFontSize = true;
            }

            if (Properties.Settings.Default.taskNum != this.taskNumNumericUpDown.Value)
            {
                args.changeTaskNum = true;
            }

            Properties.Settings.Default.fontSize = (int)this.fontSizeNumericUpDown.Value;
            Properties.Settings.Default.taskNum = (int)this.taskNumNumericUpDown.Value;
            Properties.Settings.Default.Save();

            this.okEvent(this, args);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.cancelEvent(this, new EventArgs());
        }
    }
}
