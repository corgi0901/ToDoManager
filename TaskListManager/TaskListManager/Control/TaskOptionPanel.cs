using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskListManager
{
    public partial class TaskOptionPanel : UserControl
    {
        public delegate void optionButtonEventHandler();
        public event optionButtonEventHandler doneEvent;
        public event optionButtonEventHandler editEvent;

        public TaskOptionPanel()
        {
            InitializeComponent();
        }

        public void setSize(int width, int height)
        {
            this.Size = new Size(width, height);

            this.doneButton.Width = width;
            this.doneButton.Height = height / 2;

            this.editButton.Width = width;
            this.editButton.Height = height / 2;
            this.editButton.Location = new System.Drawing.Point(0, height / 2);
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.doneEvent();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.editEvent();
        }
    }
}
