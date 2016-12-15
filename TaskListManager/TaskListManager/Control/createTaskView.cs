using System;
using System.Windows.Forms;

namespace TaskListManager
{
    public partial class createTaskView : UserControl
    {
        public String task;
        public DateTime deadline;

        public String Task
        {
            get { return this.taskTextBox.Text; }
            set { this.taskTextBox.Text = value; }
        }

        public DateTime Deadline
        {
            get { return this.dateTimePicker.Value; }
            set { this.dateTimePicker.Value = value; }
        }

        public createTaskView()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.okEvent(this, new EventArgs());
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.cancelEvent(this, new EventArgs());
        }

        public delegate void CreateTaskViewEventHandler(object sender, EventArgs e);
        public event CreateTaskViewEventHandler okEvent;
        public event CreateTaskViewEventHandler cancelEvent;
    }
}
