using System.Text.Json;
using Newtonsoft.Json;

namespace AllocationConstraints.JobShop
{
    public class JobShopData
    {
        [JsonProperty("MC")]
        public int MachinesCount { get; set; }
        public Job[] Jobs { get; set; }
    }

}
