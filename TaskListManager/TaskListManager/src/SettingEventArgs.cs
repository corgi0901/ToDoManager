using System;

namespace TaskListManager.src
{
    class SettingEventArgs : EventArgs
    {
        public bool changeFontSize;
        public bool changeTaskNum;

        public SettingEventArgs()
        {
            this.changeFontSize = false;
            this.changeTaskNum = false;
        }
    }
}
