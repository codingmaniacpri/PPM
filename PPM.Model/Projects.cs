using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PPM.Model
{
[Serializable]
public class Projects
    {
        //Project class containing the properties of projects
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return string.Format("Project Id : {0}, Project Name : {1}, Start Date : {2}, End Date : {3}", ProjectId, ProjectName, StartDate, EndDate);
        }

        public List<int> employeeprojectlist { get; set; } = new List<int>();

    }
}