using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllocationConstraints.Test
{
    public partial class Test
    {
        public static void Execute()
        {
            /*
                * Every day, each shift is assigned to a single nurse, and no nurse works more than one shift.
                * Each nurse is assigned to at least two shifts during the three-day period.
             */
            const int numNurses = 4;
            const int numDays = 3;
            const int numShifts = 3;
            var timeSlots = new int[numDays, numShifts];
            var denezs = new int[] { 1, 2, 3, 4 };

            /*
             * all possible solutions count
             * denzens factorial ^ (time slots count/denzens count)
             * (4*3*2*1)*(4*3*2*1)*(4)=2304
             * 
             * # # #, # # #, # # #
             * 1 # #, 1 # #, # # #
             * 1 2 #, 1 2 #, # # #
             * 1 2 3, 1 2 3, # # #
             * 1 2 3, 1 2 3, 4 # #
             * 1 2 3, 1 2 4, 4 3 # SWAP & PUT
             * 1 2 3, 1 2 4, 4 3 1
             * 
             * 1 2 3
             * 1 2 4
             * 4 3 1
             */
            /*
             * Algorithm
             * - Pick denezn
             * - Put it in slots based on constrains
             * - Check constrains
             *      - if all ok and time slots not ended > contiue 
             *      - if false rollback
             */

            /*
             * tasks per person in one day <= 1 [0,3,_]
             * tasks per person in three days >= 2 [2,9,_]
             * person one can't be in day one or two = [x,x,3]
             * 
             * 
             * 
             */
        }

        /*
         * Time Space cosntrained problem
         * Entities are:
         * - Time
         * - Place
         * - Person/Group
         * - Task/Subject
         * 
         * # Constrains
         * - Place/Time
         * - Task /Time
         * - Person /Time
         * - Task/Repetation
         * - Person/Person
         * - Task/Task
         * - Order constrains
         */

        static void Test1()
        {
            /*
               * Three days and three shifts per day 
               * Every day, each shift is assigned to a single nurse, and no nurse works more than one shift.
               * Each nurse is assigned to at least two shifts during the three-day period.
               * time slots = three days * three shifts = 3*3 = 9
               * place = 1
               * persons = 4 nurses
               * Tasks per person = one or zero in day,Two or more in three days = ([0..1],in day)([2..9],in week)
               * Max Tasks per person = max per day * days = 1*3 = 3
               * Max Tasks for all = total (max per person) = 3*4 = 12
               * All Tasks = time slots = 9
               * Now from 12 Tasks where each 3 is different pick 9 where each three is different
               * Tasks must be greater than or equal to time slots
               * Tasks = 111222333444 the picked = XXX,XXX,XXX
               * Mandtory/Optional matrix for tasks 111222333444 MMOMMOMMO
               * Mandatory count must be greater or equal to time slots
               * 
               * Each task is linked to another tasks
               * 
               * Now illustration
               * We have 12 activites [111222333444 MMOMMOMMO] and we need to put then in 9 time slots [XXX,XXX,XXX]
            */
        }
    }
}
