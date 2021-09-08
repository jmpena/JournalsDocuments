using Journals.Web.Infrastructure.Repository.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Journals.Web.Controllers
{
    public class SubscriptionController : BaseController
    {
        private readonly ILogger<SubscriptionController> _logger;
        private IAccountRepository accountRepository { get; set; }
        /// <summary>
        ///  inject the repository
        /// </summary>
        /// <param name="_journalsDocumentRepository"></param>
        public SubscriptionController(IAccountRepository _accountRepository, ILogger<SubscriptionController> logger)
        {
            this.accountRepository = _accountRepository;
            _logger = logger;
        }
        public IActionResult ResearcherSubscriptions()
        {
            var data = this.accountRepository.Researchers(GetUserId());
            return View(data);
        }

        [HttpPost]
        public IActionResult Subscribe(int subscriptionToResearcherId)
        {
            accountRepository.Subscribe(subscriptionToResearcherId, GetUserId());
            return RedirectToAction("ResearcherSubscriptions");
        }
    }
}
