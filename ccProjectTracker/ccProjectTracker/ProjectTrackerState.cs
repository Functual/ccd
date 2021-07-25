using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ccProjectTracker
{
    /// <summary>
    /// This class handles saving and restoring project tracker info
    /// Keeps track of current Projects
    /// </summary>
    [Serializable]
    public class ProjectTrackerState
    {
        private List<Project> _projects = null;
        private ProjectTask _currentTask = null;
        [XmlIgnore]
        public ProjectTask CurrentTask
        {
            get { return _currentTask; }
            set { _currentTask = value; }
        }
        public string LastKnownProject
        {
            get;
            set;
        }
        public List<Project> Projects
        {
            get { return _projects; }
            set { _projects = value; }
        }        
        public ProjectTrackerState()
        {
            _projects = new List<Project>();
        }
        public void SaveToFile(string filePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ProjectTrackerState));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                ser.Serialize(writer, this);
            }
        }
        public static ProjectTrackerState LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new ProjectTrackerState();
            XmlSerializer ser = new XmlSerializer(typeof(ProjectTrackerState));
            using (TextReader reader = new StreamReader(filePath))
            {
                return (ProjectTrackerState)ser.Deserialize(reader);
            }
        }
        ~ProjectTrackerState()
        {
            SaveState();
        }

        public void SaveState()
        {
            SaveToFile("ccProjectTracker.xml");
        }

        public bool HasProject(string projectName)
        {
            if (GetProject(projectName) == null)
                return false;
            return true;
        }

        public Project GetProject(string projectName)
        {
            var matchingProjects = from j in _projects where j.Name == projectName select j;
            if (matchingProjects.Count<Project>() < 1)
                return null;
            return matchingProjects.ElementAt<Project>(0);
        }

        public bool RemoveProject(Project projectItem)
        {
            return _projects.Remove(projectItem);
        }

        public bool StartNewProjectTask(string projectName, string taskDescription="general")
        {
            Project projectForTheTask = GetProject(projectName);
            if (projectForTheTask == null)                        // if we have not created this project yet, do so now
            {
                projectForTheTask = new Project(projectName);
                _projects.Add(projectForTheTask);
            } 
            if (_currentTask != null)
                _currentTask.Stop();
            _currentTask = new ProjectTask(taskDescription);
            projectForTheTask.Add(_currentTask);
            _currentTask.Start();
            LastKnownProject = projectName;
            SaveState();
            return true;
        }

        public bool EndCurrentProjectTask()
        {
            if (_currentTask != null)
                _currentTask.Stop();
            SaveState();
            _currentTask = null;
            return true;
        }
    }
}
