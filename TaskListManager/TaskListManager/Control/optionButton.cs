using System;
using System.Windows.Forms;

namespace TaskListManager
{
    public partial class optionButton : UserControl
    {
        public delegate void optionButtonEventHandler();
        public event optionButtonEventHandler doneEvent;
        public event optionButtonEventHandler editEvent;

        public optionButton()
        {
            InitializeComponent();
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
