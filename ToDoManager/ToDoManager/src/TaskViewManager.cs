using System.Collections.Generic;

namespace ToDoManager.src
{
	class TaskViewManager
    {
		private List<TaskView> taskViewList;
        private static TaskViewManager instance = null;

        private TaskViewManager()
        {
			taskViewList = new List<TaskView>();
        }

		public static TaskViewManager getInstance()
		{
			if(null == instance)
			{
				instance = new TaskViewManager();
			}

			return instance;
		}

		public void addTaskView(TaskView view)
		{
			this.taskViewList.Add(view);
		}

		public void clear()
		{
			this.taskViewList.Clear();
		}

		public void hideAllMenuContent()
		{
			foreach(TaskView view in this.taskViewList)
			{
				view.hideMenuContent();
			}
		}

		public void setTaskViewLock(bool value)
		{
			foreach (TaskView view in this.taskViewList)
			{
				view.setLock(value);
			}
		}

		public void indicateShowMenu(TaskView src)
		{
			for(int i = 0; i < this.taskViewList.Count; i++)
			{
				TaskView view = this.taskViewList[i];
				if(view != src)
				{
					view.hideMenuContent();
				}
			}
		}
    }
}
