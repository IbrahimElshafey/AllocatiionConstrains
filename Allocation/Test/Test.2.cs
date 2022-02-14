using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllocationConstraints.Test
{
    public partial class Test
    {
        static void ConstrainsAlgo()
        {
            /*
            * we have a list of time slots
            * time slots devided to days
            * we have a list of activites that should be allocated in time slots
            * we have a list of constrains that must be satisfied while allocation
            
            * Constrains types
            *   after allocation check  
            *		- activity x appears only one time in a day >> day.count(x)=0|1
            *   before allocation check 
            *		- activity x and y cant be in same day >> day.contains(x,y)==false
            *   after allocation action (
            *		- if activity x allocated in day y it must be allocated in day z 
            *		- if activity x allocated in time slot y it must in the same time slot the other days 
            *		
            *	Algorithm
            *	- Order activites acording to available time slots from min to max
            *	- Pick an activity
            *		- pick first available time slot
            *		- calc before allocation check
            *		- Allocate it to a time slot if no conflict exist with the previous allocated activites
            *		- clac after allocation check
            *		- if no conflicts exist >> execute after allocation action
            *		- if there are conflicts >> 
            *		    - pick next available time slot and repeat
            *		    - keep history of conflicts
            *		- if you run out of time slots and cant allocate activity
            *		- select the lightest conflict from the history
            *		- unallocate the conflicted activites and allocate the current one
            *		- keep history record for activity unallocation
            *		
            *		
            *		A5 conflict with A3,A10 and cant be allocated
            *		Then unallocate A3,A10 and then allocate A5
            *		Conflict history record will be like {A5,A5 Time slot we try to use,(A3,A3 Time Slot),(A10,A10 Time Slot)}
            *		This record translate to blocking some time slots for unallocated activites
            *		
            *		what constrain function/method should take and what is it's return type
            *		- Takes/applied on time slot/s and activity or more activites
            *		- return true/false and that mean there are free time slots for activity to allocate
            *		- also return the time slots that can be allocated
            */

            /*
			 * FET Algorithm
				1) Sort the activities, most difficult first. Not critical step, but speeds up the algorithm maybe 10 times or more.

				2) Try to place each activity (A_i) in an allowed time slot, following the above order, one at a time.
				Search for an available slot (T_j) for A_i, in which this activity can be placed respecting the constraints.
				If more slots are available, choose a random one. If none is available, do recursive swapping:

					2 a) For each time slot T_j, consider what happens if you put A_i into T_j. There will be a list of other
					activities which don't agree with this move (for instance, activity A_k is on the same slot T_j and has the
					same teacher or same students as A_i). Keep a list of conflicting activities for each time slot T_j.
	
					2 b) Choose a slot (T_j) with lowest number of conflicting activities. Say the list of activities in this
					slot contains 3 activities: A_p, A_q, A_r.
	
					2 c) Place A_i at T_j and make A_p, A_q, A_r unallocated.
	
					2 d) Recursively try to place A_p, A_q, A_r (if the level of recursion is not too large, say 14,
					and if the total number of recursive calls counted since step (2) on A_i began is not too large, say 2*n),
					as in step (2).
	
					2 e) If successfully placed A_p, A_q, A_r, return with success, otherwise try other time slots
					(go to step (2 b) and choose the next best time slot).
	
					2 f) If all (or a reasonable number of) time slots were tried unsuccessfully, return without success.
	
					2 g) If we are at level 0, and we had no success in placing A_i, place it like in steps (2 b) and (2 c),
					but without recursion. We have now 3 - 1 = 2 more activities to place. Go to step (2) (some methods to
					avoid cycling are used here).
             */
        }
    }
}
