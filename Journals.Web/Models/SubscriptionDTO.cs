using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journals.Web.Models
{
    public class SubscriptionDTO
    {
        public int ResearcherId { get; set; }
        public string Name { get; set; }
        public bool Subscribe { get; set; }
    }
}
