using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocation.GenericSolution
{
    public class FriendsEnemiesSolution
    {
        public static void Execute()
        {
            var activites = new List<Activity>
            {
                new Activity(1),
                new Activity(2),
                new Activity(3),
                new Activity(4),
                new Activity(5),
                new Activity(6),
                new Activity(7),
                new Activity(8),
            };
            var enemiesG1 = new List<Activity> { 
                activites[0],
                activites[1],
                activites[2],
                activites[3],
            };
            var enemiesG2 = new List<Activity> { 
                activites[1],
                activites[4],
                activites[5],
            };
            var enemiesG3 = new List<Activity> { 
                activites[0],
                activites[6],
                activites[7],
            };
            var groups = new []{ enemiesG1, enemiesG2, enemiesG3 };
            foreach (var group in groups)
            {
                foreach (var item in group)
                {
                    item.AddEnemies(group);
                }
            }
            //order groups by length
            groups=groups.OrderBy(x => x.Count).ToArray();
            var timeSlots = new List<TimeSlot>();
            //allocate group items
            foreach (var group in groups)
            {
                foreach (var activity in group)
                {
                    foreach (var slot in timeSlots)
                    {
                        //put here if no enemies
                        foreach (var enemy in activity.Enemies)
                        {
                            if (slot.Activities.Intersect(activity.Enemies).Any())
                                break;
                            else
                            {
                                slot.Activities.Add(activity);
                                activity.IsAllocated = true;
                                break;
                            }
                        }
                        if (activity.IsAllocated)
                            break;
                    }
                    if(!activity.IsAllocated)
                    {
                        timeSlots.Add(new TimeSlot());
                        timeSlots.Last().Activities.Add(activity);
                        activity.IsAllocated = true;
                    }
                }
            }
        }

        public class Activity
        {
            public Activity(int id)
            {
                ID = id;
            }

            public HashSet<Activity> Enemies { get; set; } = new HashSet<Activity>();
            public int AllocationIndex { get; set; }
            public bool IsAllocated { get; set; }
            public int ID { get; }

            public void AddEnemies(List<Activity> group)
            {
                foreach (var item in group)
                {
                    Enemies.Add(item);
                }
            }
        }

        public class TimeSlot
        {
            public HashSet<Activity> Activities { get; set; } = new HashSet<Activity>();
        }
    }
}
