using Journals.Web.Entities;
using Journals.Web.Infrastructure.Data;
using Journals.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journals.Web.Infrastructure.Repository.Account
{
    public class AccountRepository : IAccountRepository
    {

        private readonly SqliteDbContext _dBContext;
        public AccountRepository(SqliteDbContext sqliteDbContext)
        {
            _dBContext = sqliteDbContext;
        }
        public Researcher Login(string userName, string password)
        {
            string passwordEncrypt = Utils.Utils.GenerarHashSHA256(password);
            if (!_dBContext.Researchers.Any(e => e.UserName == userName && e.Password == passwordEncrypt))
            {
                throw new Exception("Invalid user name or password");
            }
            return _dBContext.Researchers.FirstOrDefault(e => e.UserName == userName && e.Password == passwordEncrypt);
        }

        public void Register(Researcher researcher)
        {
            string passwordEncrypt = Utils.Utils.GenerarHashSHA256(researcher.Password);
            if (_dBContext.Researchers.Any(e => e.UserName == researcher.UserName))
            {
                throw new Exception("User Name Already exists");
            }
            researcher.Password = passwordEncrypt;
            _dBContext.Researchers.Add(researcher);
            _dBContext.SaveChanges();
        }

        public IEnumerable<SubscriptionDTO> Researchers(int researcherId)
        {
            var data = from r in _dBContext.Researchers.Where(e => e.ResearcherId != researcherId)
                       join s in _dBContext.Subscriptions.Where(e => e.ResearcherId == researcherId) on r.ResearcherId equals s.SubscriptionToResearcherId into subscriptions
                       from subscription in subscriptions.DefaultIfEmpty()
                       select new SubscriptionDTO
                       {
                           Name = r.Name,
                           ResearcherId = r.ResearcherId,
                           Subscribe = subscription != null ? true : false
                       };
            return data;
        }

        public void Subscribe(int subscriptionToResearcherId, int currentResearcherId)
        {
            var data = _dBContext.Subscriptions.ToList();
            if (_dBContext.Subscriptions.Any(e => e.ResearcherId == currentResearcherId && e.SubscriptionToResearcherId == subscriptionToResearcherId))
            {
                var itemToDelete = _dBContext.Subscriptions.FirstOrDefault(e => e.ResearcherId == currentResearcherId && e.SubscriptionToResearcherId == subscriptionToResearcherId);
                _dBContext.Remove(itemToDelete);
                _dBContext.SaveChanges();
            }
            else {
                _dBContext.Subscriptions.Add(new Subscriptions { 
                ResearcherId = currentResearcherId,
                SubscriptionToResearcherId = subscriptionToResearcherId
                });
                _dBContext.SaveChanges();
            }
        }
    }
}
