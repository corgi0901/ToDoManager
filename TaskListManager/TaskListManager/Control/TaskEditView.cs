using System;
using System.Windows.Forms;
using TaskListManager.src;

namespace TaskListManager
{
    public partial class TaskEditView : UserControl
    {
        private long id;

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

        public TaskEditView()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            reset();
        }

        // 指定されたタスクの内容をビューに反映する
        public void reflectTaskItem(TaskItem task)
        {
            this.Task = task.Task;
            this.Deadline = task.Deadline;
            this.ID = task.ID;
        }

        // 諸々の設定をリセット
        private void reset()
        {
            this.taskTextBox.Text = "";
            this.dateTimePicker.Value = DateTime.Now;
            this.id = -1;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.okEvent(this, new EventArgs());
            reset();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.cancelEvent(this, new EventArgs());
            reset();
        }

        public delegate void CreateTaskViewEventHandler(object sender, EventArgs e);
        public event CreateTaskViewEventHandler okEvent;
        public event CreateTaskViewEventHandler cancelEvent;
    }
}
