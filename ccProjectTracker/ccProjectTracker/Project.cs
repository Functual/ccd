using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ccProjectTracker
{
    /// <summary>
    /// represents a Project, which is composed of a series of tasks
    /// </summary>
    [Serializable]
    [XmlType("Project")]
    public class Project : IDisposable
    {
        string _name = "No Name";
        List<ProjectTask> _tasks;        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<ProjectTask> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }
        public Project() { }
        public Project(string name)
        {
            Name = name;
        }
        public void Add(ProjectTask newTask)
        {
            if (_tasks == null)
                _tasks = new List<ProjectTask>();
            _tasks.Add(newTask);
        }
        public override string ToString()
        {
            return _name;
        }
        public void Dispose()
        {
            
        }
    }
}
