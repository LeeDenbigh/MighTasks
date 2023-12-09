using MighTasks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MighTasks.DataService
{
    public class TaskDataService
    {
        private readonly string _filePath;
        private readonly string fileName = "tasks.json";

        public TaskDataService()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(appDataPath, folderName);
            // Define the path to the json file.
            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), fileName);

            // Ensure the JSON file exists.
            InitialiseFile();
        }

        private void InitialiseFile()
        {
            // Check if the file exists.
            if (!File.Exists(_filePath))
            {
                // If the file does not exist, create it with default content (e.g., an empty list)
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(new List<TaskModel>()));

                // Debug
                Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)));
            }
        }

        public List<TaskModel> LoadTasks()
        {
            // Read and deserialise the JSON file.
            string fileContent = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<TaskModel>>(fileContent);

        }

        public void SaveTasks(List<TaskModel> tasks)
        {
            // Serialise and write the list of tasks to the json file.
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public void AddTask(TaskModel newTask)
        {
            newTask.TaskId = GenerateNewTaskId();

            var task = LoadTasks();
            task.Add(newTask);
            SaveTasks(task);
        }

        public void UpdateTask(TaskModel updateTask)
        {
            var tasks = LoadTasks();
            var taskIndex = tasks.FindIndex(t => t.TaskId == updateTask.TaskId);

            if(taskIndex != -1)
            {
                tasks[taskIndex] = updateTask;
                SaveTasks(tasks);
            }
        }

        public void DeleteTasks(int taskId)
        {
            var tasks = LoadTasks();
            tasks.RemoveAll(t => t.TaskId == taskId);
            SaveTasks(tasks);
        }

        public int GenerateNewTaskId()
        {
            var tasks = LoadTasks();

            if (!tasks.Any())
            {
                return 1;
            }

            int maxId = tasks.Max(t => t.TaskId);
            return maxId + 1;
        }
    }
}
