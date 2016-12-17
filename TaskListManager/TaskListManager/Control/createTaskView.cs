using System;
using System.Windows.Forms;
using TaskListManager.src;

namespace TaskListManager
{
    public partial class createTaskView : UserControl
    {
        public String task;
        public DateTime deadline;
        public long id;

        private Boolean isEdit;

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

        public long ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public createTaskView()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.isEdit = false;
        }

        public createTaskView(taskItem item)
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.taskTextBox.Text = item.Task;
            this.dateTimePicker.Value = item.Deadline;
            this.id = item.ID;

            this.isEdit = true;
        }

        public Boolean getIsEdit()
        {
            return isEdit;
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
