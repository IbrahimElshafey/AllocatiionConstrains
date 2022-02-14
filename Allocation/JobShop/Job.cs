using System.Collections.Generic;
using System.Diagnostics;

namespace AllocationConstraints.JobShop
{
    [DebuggerDisplay("Job# Id = {Id} ,TotalTime = {TotalTime}")]
    public class Job : List<Task>
    { 
        public int TotalTime { get; private set; }
        public int Id { get; internal set; }
      
        public void CalcPreData(Machine[] machines)
        {
            //MinStart = previous tasks summation;
            //Reminders = next tasks summation;
            var totalTime = 0;
            var reversTotalTime = 0;
            for (int i = 0; i < Count; i++)
            {
                var task = this[i];
                task.Job = this;
                task.OrderInJob = i;
                task.MinStart = totalTime;
                totalTime += task.Time;
                machines[task.Machine].TotalHours += task.Time;
                machines[task.Machine].Tasks.Add(task);
            }
            for (int i = Count - 1; i >= 0; i--)
            {
                var task = this[i];
                if (reversTotalTime != 0)
                    task.NextTask = this[i + 1];
                task.Reminder = reversTotalTime;
                reversTotalTime += task.Time;
               
            }
            TotalTime = totalTime;
        }
    }

}
