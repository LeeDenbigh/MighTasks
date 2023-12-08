using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MighTasks.Models
{
    /// <summary>
    /// Contains the properties for the task.
    /// </summary>
    public class TaskModel
    {
        public int TaskId { get; set; }
        // Property to store the task title.
        /// <summary>
        /// Get or set the tasks title.
        /// </summary>
        public string TaskTitle { get; set; }
        // Property to store the task category info
        /// <summary>
        /// Get or set the task category info.
        /// </summary>
        public CategoryModel TaskCategory { get; set; }
        // Property to store the task general description.
        /// <summary>
        /// Get or set the task details. This is for the task description.
        /// </summary>
        public string TaskDetails { get; set; }
        // Property to store the tasks complete by date.
        /// <summary>
        /// Get or set the tasks complete by date.
        /// </summary>
        public DateTime TaskCompleteByDateTime { get; set; }
        // Property to store the tasks started date.
        /// <summary>
        /// Store the tasks start date.
        /// </summary>
        public DateTime TaskStartDateTime { get; set; }
        // Boolean property that represents whether the task has been marked as complete.
        /// <summary>
        /// Get or set whether the task has been completed.
        /// </summary>
        public bool IsComplete { get; set; }
        // Property to hold the length of time you have worked on a task.
        /// <summary>
        /// Get or set the length of time you have worked on this project.
        /// </summary>
        public TimeSpan ProjectTimer { get; set; }
        // List of checklist items for the task.
        /// <summary>
        /// Holds all of the check list items for the task.
        /// </summary>
        public List<TaskCheckListModel> TaskCheckList { get; set; }
        /// <summary>
        /// Get or set the tasks state. (e.g., "InProgress", "Complete").
        /// </summary>
        public TaskState TaskState { get; set; }
    }

    /// <summary>
    /// Assigns a state to the task.
    /// </summary>
    public enum TaskState
    {
        /// <summary>
        /// The task is still in progress.
        /// </summary>
        InProgress,
        /// <summary>
        /// The task has been marked as completed.
        /// </summary>
        Complete,
        /// <summary>
        /// The task hasn't been started yet.
        /// </summary>
        NotStarted,
        /// <summary>
        /// The task is late.
        /// </summary>
        Late,
        /// <summary>
        /// The task has been archived.
        /// </summary>
        Archived,
        /// <summary>
        /// The task has been marked as deleted.
        /// </summary>
        Deleted
    }
}
