using System;

namespace ToDoManager.src
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
