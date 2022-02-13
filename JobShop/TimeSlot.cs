namespace AllocationConstraints.JobShop
{
    public class TimeSlot
    {
        public Task Task { get; set; }
        public int AllocatedJob { get; set; } = -1;
    }

}
