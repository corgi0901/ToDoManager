using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToDoManager
{
    public partial class TaskOptionPanel : UserControl
    {
        public delegate void optionButtonEventHandler();
        public event optionButtonEventHandler returnEvent;
        public event optionButtonEventHandler doneEvent;
        public event optionButtonEventHandler editEvent;
        public event optionButtonEventHandler deleteEvent;

        public TaskOptionPanel()
        {
            InitializeComponent();

            setButtonImage(this.returnButton, Properties.Resources._return);
            setButtonImage(this.doneButton,   Properties.Resources.checkbox);
            setButtonImage(this.editButton,   Properties.Resources.edit);
            setButtonImage(this.deleteButton, Properties.Resources.trash_box);

            this.buttonToolTip.SetToolTip(this.returnButton, "戻る");
            this.buttonToolTip.SetToolTip(this.doneButton,   "完了");
            this.buttonToolTip.SetToolTip(this.editButton,   "編集");
            this.buttonToolTip.SetToolTip(this.deleteButton, "削除");
        }

        public void setSize(int width, int height)
        {
            this.Size = new Size(width, height);
        }

        private void setButtonImage(Button button, Bitmap bmp)
        {
            int size = 25;
            Bitmap resizeBmp = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(resizeBmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(bmp, 0, 0, size, size);
            button.BackgroundImageLayout = ImageLayout.Center;
            button.BackgroundImage = resizeBmp;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.doneEvent();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.editEvent();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.returnEvent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.deleteEvent();
        }
    }
}
