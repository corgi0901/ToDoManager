using System;
using System.Drawing;
using System.Windows.Forms;
using ToDoManager.src;

namespace ToDoManager
{
    public enum EDIT_MODE
    {
        New = 0,
        Edit
    }

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
            get { return getDeadLine(); }
            set { setDeadLine(value); }
        }

        public REPEAT_TYPE RepeatType
        {
            get { return (REPEAT_TYPE)this.repeatComboBox.SelectedIndex; }
            set { this.repeatComboBox.SelectedIndex = (int)value; }
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
            this.titleLabel.Width = this.Width;
            setFontSize(Properties.Settings.Default.fontSize);
            reset();
        }

        public void setFontSize(int size)
        {
            Font font = new Font("Meiryo UI", size);
            Size strSize;

            this.titleLabel.Font = font;
            strSize = TextRenderer.MeasureText(this.titleLabel.Text, font);
            this.titleLabel.Height = (int)(strSize.Height * 1.5);

            this.label1.Font = font;
            this.label2.Font = font;
            this.label3.Font = font;

            this.taskTextBox.Font = font;
            this.taskTextBox.Width = this.Width - 10;

            this.datePicker.Font = font;
            strSize = TextRenderer.MeasureText("0000/00/00 (日)", font);
            this.datePicker.Width = strSize.Width + 30;

            this.timePicker.Font = font;
            strSize = TextRenderer.MeasureText("00:00", font);
            this.timePicker.Width = strSize.Width + 30;

            this.repeatComboBox.Font = font;
            strSize = TextRenderer.MeasureText("なし", font);
            this.repeatComboBox.Width = strSize.Width + 30;

            strSize = TextRenderer.MeasureText(this.cancelButton.Text, font);

            this.okButton.Font = font;
            this.okButton.Height = strSize.Height + 10;
            this.okButton.Width = strSize.Width + 20;

            this.cancelButton.Font = font;
            this.cancelButton.Height = strSize.Height + 10;
            this.cancelButton.Width = strSize.Width + 20;

            this.titleLabel.Location = new Point(0, 0);        
            this.label1.Location = new Point(5, this.titleLabel.Location.Y + this.titleLabel.Height + 5);
            this.taskTextBox.Location = new Point(5, this.label1.Location.Y + this.label1.Height + 3);
			this.label2.Location = new Point(5, this.taskTextBox.Location.Y + this.taskTextBox.Height + 5);
            this.datePicker.Location = new Point(5, this.label2.Location.Y + this.label2.Height + 3);
            this.timePicker.Location = new Point(this.datePicker.Location.X + this.datePicker.Width + 3, this.datePicker.Location.Y);
            this.label3.Location = new Point(5, this.datePicker.Location.Y + this.datePicker.Height + 5);
            this.repeatComboBox.Location = new Point(this.label3.Location.X, this.label3.Location.Y + this.label3.Height + 3);
            this.okButton.Location = new Point(5, this.repeatComboBox.Location.Y + this.repeatComboBox.Height + 5);
            this.cancelButton.Location = new Point(this.okButton.Location.X + this.okButton.Width + 3, this.okButton.Location.Y);
            this.Height = this.okButton.Location.Y + this.okButton.Height + 10;
        }

        public void setEditMode(EDIT_MODE mode)
        {
            if(mode == EDIT_MODE.New)
            {
                this.titleLabel.Text = "新規タスクの登録";
            }
            else if(mode == EDIT_MODE.Edit)
            {
                this.titleLabel.Text = "既存タスクの編集";
            }
        }

        public void reflectTaskItem(TaskItem task)
        {
            this.Task = task.Task;
            this.Deadline = task.Deadline;
            this.RepeatType = task.RepeatType;
            this.ID = task.ID;
        }

        private void setDeadLine(DateTime deadline)
        {
            this.datePicker.Value = deadline;
            this.timePicker.Value = deadline;
        }

        private DateTime getDeadLine()
        {
            DateTime day = this.datePicker.Value;
            DateTime time = this.timePicker.Value;

            return new DateTime(day.Year, day.Month, day.Day, time.Hour, time.Minute, 0);
        }

        private void reset()
        {
            this.taskTextBox.Text = "";
            this.datePicker.Value = DateTime.Now;
            this.timePicker.Value = DateTime.Parse("12:00");
            this.repeatComboBox.SelectedIndex = 0;
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
