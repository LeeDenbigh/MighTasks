using MighTasks.DataService;
using MighTasks.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MighTasks.ViewModels
{
    public class TasksViewModel : INotifyPropertyChanged
    {
        // Field for accessing TaskDataService.
        // This is used to interact with the underlying data storage (e.g., file system, database) for task operations.
        private readonly TaskDataService _taskDataService;

        // Private field holding the collection of task models.
        // ObservableCollection is used because it provides notifications when items get added, removed, or the entire list is refreshed.
        private ObservableCollection<TaskModel> _tasks;

        // Event declaration for PropertyChanged.
        // This is used in the context of INotifyPropertyChanged to notify the UI when a property value changes.
        public event PropertyChangedEventHandler PropertyChanged;

        // Public property for tasks.
        // Provides access to the _tasks field and notifies the UI when the collection changes.
        /// <summary>
        /// Get or set tasks property. This property is bound to the UI, where changes in the collection will update the UI accordingly.
        /// </summary>
        public ObservableCollection<TaskModel> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks)); // Notify that Tasks property has changed
            }
        }

        // Constructor for the TasksViewModel.
        // Initializes the TaskDataService and loads tasks.
        /// <summary>
        /// The constructor for the TasksViewModel class. It initializes the TaskDataService and loads the initial set of tasks.
        /// </summary>
        public TasksViewModel()
        {
            _taskDataService = new TaskDataService(); // Initialize the TaskDataService
            LoadTasks(); // Load tasks from the data service
        }


        // LoadTasks: This method loads the list of tasks from the TaskDataService and updates the Tasks collection.
        // The Tasks collection is bound to the view, so updating this collection will update the UI accordingly.
        private void LoadTasks()
        {
            var taskList = _taskDataService.LoadTasks();
            Tasks = new ObservableCollection<TaskModel>(taskList);
        }

        // AddNewTask: This method is responsible for adding a new task.
        // It calls the AddTask method of TaskDataService to save the new task and then reloads the task list to update the UI.
        public void AddNewTask(TaskModel newTask)
        {
            _taskDataService.AddTask(newTask);
            LoadTasks(); // Reload tasks to reflect the new addition
        }

        // UpdateTask: This method is used to update an existing task.
        // It calls the UpdateTask method of TaskDataService with the updated task data and then reloads the task list.
        public void UpdateTask(TaskModel updateTask)
        {
            _taskDataService.UpdateTask(updateTask);
            LoadTasks(); // Reload tasks to reflect the updates
        }

        // DeleteTask: This method is used to delete a task based on its ID.
        // It calls the DeleteTask method of TaskDataService and then reloads the task list to ensure the UI is up-to-date.
        public void DeleteTask(int taskId)
        {
            _taskDataService.DeleteTasks(taskId);
            LoadTasks(); // Reload tasks to reflect the deletion
        }

        // OnPropertyChanged: This method is used to notify the view of property value changes.
        // When a property value changes, the PropertyChanged event is raised with the name of the property, updating the binding in the UI.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
