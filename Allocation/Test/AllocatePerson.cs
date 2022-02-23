using System;
using System.Linq;

namespace AllocatePersons
{
    class Program
    {
        public static void Main1(string[] args)
        {
            var persons = new[] { 1, 2, 3, 4 };
            var timeSlots = new int[9];
            /*
             constrains
                c1= person exist zero or one in each day slot at most [person day general constrain] = 12
                c2= person appears two times at least in total [person 3 days constrain] = 24
                c3= person one can't be in day 1 [specific person day constrain] = 3
            */

            //person exist zero or one in each three time slot at most
            bool C1(int slot, int person)
            {
                var daySlots = new ArraySegment<int>(timeSlots, slot / 3, 3);
                return daySlots.Count(x => x == person) >= 0;
            }
            //person appears two times at least in total
            bool C2(int person)
            {
                return timeSlots.Count(x => x == person) >= 2;
            }
            //person one can't be in day 1 [person day constrain]
            bool C3()
            {
                var dayOne = new ArraySegment<int>(timeSlots, 0, 3);
                return dayOne.Count(x => x == 1) == 0;
            }

            int currentPerson = -1;
            int PickPerson()
            {
                var result = currentPerson + 1;
                if (result == persons.Length)
                    result = 0;
                currentPerson = result;
                return persons[result];
            }

            //put items and evaluate C1,C3
            for (int i = 0; i < 9; i++)
            {
                var person = PickPerson();
                timeSlots[i] = person;
                if (!C1(i, person))
                {
                    if (person == 1 && !C3())
                    {
                        timeSlots[i] = 0;
                        person = PickPerson();
                    }
                    //backtrack
                }

            }

            //evaluate C2
            for (int i = 1; i < 5; i++)
            {
                if (!C2(i))
                {
                    //backtrack
                }
            }

        }
    }
}
