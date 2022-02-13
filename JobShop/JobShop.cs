using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AllocationConstraints.JobShop
{
    public class JobShop
    {
        public static void Execute()
        {
            /*
             * (M,T)
             * job 0 = [(0, 3), (1, 2), (2, 2)] = totaltime(7) = machines(3,0 1 2)
             * job 1 = [(0, 2), (2, 1), (1, 4)] = totaltime(7) = machines(3,0 2 1)
             * job 2 = [(1, 4), (2, 3)]= totaltime(7) = machines(2,1 2)
             * 
             * 
             *  
             *  
             *  3   2   2
             *  
             *  algorithm
             *  - select the machine with the largest working hours summation
             *  - for this machine create a list of pairs (job id,start time,end time,remainder) let's call it (tasks list)
             *  - order tasks list by start time(smallest first),length(smallest first),then by remainder(smallest first)
             *  - place tasks on time line sequentially, go to step one and repeat for each machine
             *      - task place start point on time line can't small than it's postion in job
             *      - check if next task in same job is placed > if yes then.. the current job start and end can't exceed the next (task start,end)
             *  
             *  - find conflicts in the generated timelines, if no conflict then you have the best solution
             *  - if there are conflicts, solve it by moving the [least difficult] to left
             */

            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<JobShopData>(File.ReadAllText(@"..\..\..\..\JobShop.json"));
            var machines = Machine.GetNewMachines(data.MachinesCount);
            var jobs = data.Jobs;
            for (int i = 0; i < jobs.Length; i++)
            {
                Job job = jobs[i];
                job.Id = i;
                job.CalcPreData(machines);
            }
            machines = machines.OrderByDescending(x => x.TotalHours).ToArray();
            foreach (var machine in machines)
            {
                machine.OrderTasks();
                var maxTotalMachine = machines.Max(x => x.TotalHours);
                machine.InitiateTimeLine(maxTotalMachine);
                machine.PlaceTasksOnTimeLine();
            }
            //Find conflicts
            /*
             * Resolve conflicts
             * for each pair of conflicted timeline slots do the following
             *      - Try to move any one of conflicted tasks to left if available , task can be moved to left if
             *          - there are space to move in (empty hours)
             *          - next task start time not Exceeded
             *      - Calc conflict for the task after move with other machines time line,if there are no conflict,pick the next conflict
             *      - If you can't solve the conflict with moving left strategy try below:
             *      - insert conflict wide spaces to the timeline contains the task with higher order (task that execueted next)
            */
        }


    }

}
