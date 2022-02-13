using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AllocationConstraints.JobShop
{
    [DebuggerDisplay("Task# Job={Job.Id} ,Machine = {Machine}, Time = {Time}, MinStart = {MinStart}, Reminder = {Reminder}, Order = {Order}")]
    public class Task
    {
        [JsonProperty("M")]
        public int Machine { get; set; }
        [JsonProperty("T")]
        public int Time { get; set; }
        public int MinStart { get; set; }
        public int Reminder { get; set; }
        public int OrderInJob { get; set; }
        public Task NextTask { get; set; }
        public Job Job { get; set; }
    }

}
