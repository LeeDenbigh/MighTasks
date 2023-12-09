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
        /// <summary>
        /// Get or set the tasks importance. (e.g., "Low", "Medium").
        /// </summary>
        public TaskImportance TaskImportance { get; set; }
        /// <summary>
        /// Get or set the tasks category.
        /// </summary>
        public TaskCategory TaskCategory { get; set; }
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
    /// <summary>
    /// Defines the task category.
    /// </summary>
    public enum TaskCategory
    {
        /// <summary>
        /// Tasks related to your job, like meetings, project deadlines, or professional development activities.
        /// </summary>
        Work,
        /// <summary>
        /// Daily routines, hobbies, or personal goals.
        /// </summary>
        Personal,
        /// <summary>
        /// Household chores, repairs, or home improvement projects.
        /// </summary>
        Home,
        /// <summary>
        /// Exercise routines, meal planning, doctor's appointments, or meditation.
        /// </summary>
        HealthWelbeing,
        /// <summary>
        /// Budgeting, bill payments, and financial planning.
        /// </summary>
        Finance,
        /// <summary>
        /// Grocery lists, clothing, or other shopping needs.
        /// </summary>
        Shopping,
        /// <summary>
        /// Family gatherings, social events, or activities with friends.
        /// </summary>
        SocialFamily,
        /// <summary>
        /// Study sessions, assignments, or educational goals.
        /// </summary>
        Education,
        /// <summary>
        /// Planning for trips, packing lists, or travel itineraries.
        /// </summary>
        Travel,
        /// <summary>
        /// Tasks like going to the post office, bank, or dry cleaners.
        /// </summary>
        Errands,
        /// <summary>
        /// Time set aside for hobbies or leisure activities.
        /// </summary>
        HobbiesLeisure,
        /// <summary>
        /// Community service or volunteering activities.
        /// </summary>
        VolunteeringCommunity,
        /// <summary>
        /// Special dates and celebrations.
        /// </summary>
        BirthdaysAnniversaries,
        /// <summary>
        /// Larger tasks that might span over multiple days or weeks.
        /// </summary>
        Projects,
        /// <summary>
        /// Objectives or goals that you're working towards over a longer period.
        /// </summary>
        LongTermGoals
    }
    /// <summary>
    /// Defines the importance levels for the task.
    /// </summary>
    public enum TaskImportance
    {
        /// <summary>
        /// Low importance. Suitable for tasks that are not urgent and can be deferred.
        /// </summary>
        Low,

        /// <summary>
        /// Medium importance. For tasks that are of regular priority.
        /// </summary>
        Medium,

        /// <summary>
        /// High importance. Tasks that need to be completed soon but are not critical.
        /// </summary>
        High,

        /// <summary>
        /// Critical importance. These tasks have the highest priority and often have tight deadlines or significant consequences if not completed in time.
        /// </summary>
        Critical
    }

}
