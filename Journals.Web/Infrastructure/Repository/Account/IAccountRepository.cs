using Journals.Web.Entities;
using Journals.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journals.Web.Infrastructure.Repository.Account
{
   public interface IAccountRepository
    {
        public Researcher Login(string userName , string password);
        public void Register(Researcher researcher);
        public IEnumerable<SubscriptionDTO> Researchers(int researcherId);
        public void Subscribe(int subscriptionToResearcherId, int currentResearcherId);
    }
}
