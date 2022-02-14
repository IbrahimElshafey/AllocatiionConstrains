using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AllocationConstraints.JobShop
{
    [DebuggerDisplay("Machine# TimeLine={TimeLineString()}, TotalHours = {TotalHours}")]
    public class Machine
    {
        internal string TimeLineString()
        {
            if (TimeLine == null) return null;
            var items= TimeLine.Select(x => x.AllocatedJob == -1 ? "_" : x.AllocatedJob.ToString()).ToArray();
            return string.Join(' ',items);
        }
        public static Machine[] GetNewMachines(int count)
        {
            var result = Enumerable.Range(1, count).Select(x=>new Machine()).ToArray();
            return result;
        }
        public int TotalHours { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<TimeSlot> TimeLine { get; set; }
        public void OrderTasks()
        {
            Tasks=Tasks.OrderBy(x => x.MinStart).ThenByDescending(x => x.Reminder).ToList();
        }

        public void InitiateTimeLine(int maxTotalMachine)
        {
            TimeLine = Enumerable.Range(0,maxTotalMachine).Select(x=>new TimeSlot()).ToList();
        }

        public void PlaceTasksOnTimeLine()
        {
            /*
              *  - task place start point on time line can't small than it's postion in job
              *  - check if next task in same job is placed > if yes then.. 
              *         the current job start and end can't exceed the next (task start,end)
           */
            for (int i = 0; i < Tasks.Count; i++)
            {
                Task task = Tasks[i];
                int firstAvailbleLocation = task.MinStart;
                //find first empty time slot for the job
                for (; TimeLine[firstAvailbleLocation].AllocatedJob != -1; firstAvailbleLocation++) ;
                
                if(TimeLine.Count-firstAvailbleLocation >= task.Time)
                {
                    var end = firstAvailbleLocation + task.Time;
                    for (; firstAvailbleLocation < end; firstAvailbleLocation++)
                    {
                        TimeLine[firstAvailbleLocation].AllocatedJob = task.Job.Id;
                        TimeLine[firstAvailbleLocation].Task = task;
                    }
                }
                else
                {
                    //todo:if not add padding time slots in time line
                    //Example: TimeLine.Count=10 ,firstAvailbleLocation=8, task.Time=3  >> so we need to add 3-(10-8)=1
                    var toAdd = task.Time - (TimeLine.Count - firstAvailbleLocation);
                    TimeLine.AddRange(Enumerable.Range(0, toAdd).Select(x => new TimeSlot()));
                    //todo:do this for all timelines
                    i--;
                }
              
            }
        }
    }

}
