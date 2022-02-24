﻿using System;
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
         * we need to allocate activities in the time slots but we should apply constrains while allocation
         * each time slot has one or many tags 
         * multiple activities can be placed in time slot
         * each activity has one or many tags 
         * 
         * Constrain may be
         * - Static and not changed while solution running  
         * - Dynamic and changed based on the previous state
         * 
         * If we translate every constrain to a function that function will take (activities,time slots space) and return: 
         * - Time slots that can be used in allocation
         * - Activities that can be allocated
         * 
         * before any constrains applied the space available for any activity is (TimeSlot.Start,TimeSlot.End)
         * 
         * Static constrain is a function that return the same time slots and the same activity every time it called
         * Dynamic constrain is a function that changed based on previous allocation
         * Any constrain function return must be refined before the calculation
         * 
         * 

            Constrains Types
            - Intersection Constrain
                - Activities with tag/s must not overlapping
                - Activities with tag/s be in same time
            - Length Constrain
                - Fill two time slot (time length)
            - Order Constrain
                - Activity A2 must be after A1
            - Distribution Constrains
                - Activities with tag "Subject=Math,Group=Any" locate in the same time every day for the group
                - Activities with tag "Teacher1" spread over two days only
                - Activities with tag "Teacher1" must be separated by one hour at least
                - Time Preference Constrain
                    - Not available time slots per tag
                    - Priority>>Activities with the tag "Early=true" must fill slots 1-3
            
         */

        /*
         * Example
         * "Jobs":[
                [A1{"M":0,"T":3},A2{"M":1,"T":2},A3{"M":2,"T":2}],
                [A4{"M":0,"T":2},A5{"M":2,"T":1},A6{"M":1,"T":4}],
                [A7{"M":1,"T":4},A8{"M":2,"T":3}]
            ]
            TimeSlots Count= 12
            Not tags for time slots
            Activity has tags (JobId,MachineId)

            Activities:
            A1= (JobId:0,MachineId:0) = 3 
            A2= (JobId:0,MachineId:1) = 2
            A3= (JobId:0,MachineId:2) = 2
                                      
            A4= (JobId:1,MachineId:0) = 2
            A5= (JobId:1,MachineId:2) = 1
            A6= (JobId:1,MachineId:1) = 4
                                      
            A7= (JobId:2,MachineId:1) = 4
            A8= (JobId:2,MachineId:2) = 3

            Constraints
            - Ordered (A1,A2,A3) Space >=0
            - Ordered (A4,A5,A6) Space >=0
            - Ordered (A7,A8) Space >=0
            - FillSlotsSpace (A1,3)
            - FillSlotsSpace (A2,2)
            - FillSlotsSpace (A3,2)
            - FillSlotsSpace (A4,2)
            - FillSlotsSpace (A5,1)
            - FillSlotsSpace (A6,4)
            - FillSlotsSpace (A7,4)
            - FillSlotsSpace (A8,3)
            - IntersectionConflict(Tag:"MachineId",Value:"any")
                - G1 = IntersectionGroup (A1,A4) = 5
                - G2 = IntersectionGroup (A2,A6,A7) = 10
                - G3 = IntersectionGroup (A3,A5,A8) = 6

            * For each intersection group calc total
            * Allocate activities for the group with the largest sum

            1-4
            3-4
            3-6

            1-4
            5-6
            7-10


            G1 = NoIntersection(A1,A2,A3,A4)
            G2 = NoIntersection(A1,A4,A5,A6)
            G3 = NoIntersection(A4,A6,A2,A3)
            
            A1  A2  A3  A4
                A5          A6
            For each activity find elements that conflict with it
           


            
         */
    }

    public class TimeSlot
    {
        public int Index { get; set; }
        public Dictionary<string, int> Tags { get; set; }
        public HashSet<Activity> Activities { get; set; }
    }

    public class Activity
    {
        public int Id { get; set; }
        public Dictionary<string,int> Tags { get; set; }

        public HashSet<Activity> ConflictActivities { get; set; }

        public bool AllocationStatus { get; set; }
    }

}
