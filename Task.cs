using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Capstone_TaskList
{
    class Task
    {
        #region fields
        private string _name;
        private string _description;
        private DateTime _dueDate;
        private bool _complete; //may need to set this to true/false... we'll see how the program reacts once we get there
        #endregion


        #region properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }
        public bool Complete
        {
            get { return _complete; }
            set { _complete = value;  }
        }
        #endregion

        #region constructors
        public Task() { }
        public Task(string name, string description, DateTime dueDate, bool complete)
        {
            _name = name;
            _description = description;
            _dueDate = dueDate;
            _complete = complete;
        }
        public void PrintTask()
        {
            Console.WriteLine($"{_name} has a task with the description {_description}. This task is due on {_dueDate.ToShortDateString()}. Is the task complete? {Complete}");
        }
        public void FormatedPrintTask()
        {
            Console.WriteLine($"\tName: {_name}");
            Console.WriteLine($"\tDue Date: {_dueDate.ToShortDateString()}");
            Console.WriteLine($"\tComplete: {_complete}");
            Console.WriteLine($"\tDescription: {_description}");
        }
        #endregion

    }
}
