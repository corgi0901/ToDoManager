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
    public partial class createTaskView : UserControl
    {
        public createTaskView()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            taskView v = new taskView(this.taskTextBox.Text, this.dateTimePicker.Value);
            this.Parent.Controls.Add(v);
            this.Parent.Controls.Remove(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
