using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllocationConstraints.GenericSolution
{
    public class AllocationConstraints
    {
        /*
         * we have list of time slots and another of activities
         * we need to allocate activites in the time slots but we should apply constrains while allocation
         * time slots may be divided into time ranges (days)
         * multiple activites can be placed in time slot
         * each activity has a list of tags
         * 
         * Constrain may be
         * - Static and not changed while solution running  
         * - Dynamic and changed based on the previous state
         * 
         * If we translate every constrain to a function that function will take (activities,tags,or both) and return: 
         * - Time slots that can be used in allocation
         * - Activites that can be allocated
         * 
         * Static constrain is a function that return the same time slots and the same activity every time it called
         * Dynamic constrain is a function that changed based on previous allocation
         * Any constrain function return must be refined before the calculation
         * 
         * "Jobs":[
                [A1{"M":0,"T":3},A2{"M":1,"T":2},A3{"M":2,"T":2}],
                [A4{"M":0,"T":2},A5{"M":2,"T":1},A6{"M":1,"T":4}],
                [A7{"M":1,"T":4},A8{"M":2,"T":3}]
            ]

            Constrains Types
            - Order Constrain
                - Activity A2 must be after A1
            - Space/Distance Constrains
                - Actities with tag "Teacher1" must be separated by one hour at least
            - Time specific constrains
                - Activities with tag/s must not overlapping
                - Not available time slots per tag 
            - Distribution Constrain
                - Activities with tag "Subject=Math,Group=Any" locate in the same time every day for the group
                - Activities with tag "Teacher1" spread over two days only
         */
    }

    public class TimeSlot
    {
        public int TimeRange { get; set; }
        public HashSet<Activity> Activities { get; set; }
    }

    public class Activity
    {
        public Dictionary<string,int> Tags { get; set; }
    }

}
