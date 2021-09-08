using Journals.Web.Infrastructure.Repository;
using Journals.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Journals.Web.Controllers
{
    [Authorize]
    public class JournalsController : BaseController
    {
        private readonly ILogger<JournalsController> _logger;
        private IJournalsDocumentRepository journalsDocumentRepository { get; set; }
        /// <summary>
        ///  inject the repository
        /// </summary>
        /// <param name="_journalsDocumentRepository"></param>
        public JournalsController(IJournalsDocumentRepository _journalsDocumentRepository, ILogger<JournalsController> logger)
        {
            this.journalsDocumentRepository = _journalsDocumentRepository;
            _logger = logger;
        }
        /// <summary>
        ///  use the discount to transform the data to present it in the list
        /// </summary>
        /// <returns></returns>
        /// 
        
        public async Task<IActionResult> JournalsDocuments()
        {

            List<JournalsDocumentsDTO> documentList = new List<JournalsDocumentsDTO>();
            var data = journalsDocumentRepository.GetJournalsDocuments(GetUserId());
            var myDocuments = journalsDocumentRepository.GetMyJournalsDocuments(GetUserId());
            documentList.AddRange(data.ToList());
            documentList.AddRange(myDocuments.ToList());
            return View(documentList);
        }

        public IActionResult UploadDocument()
        {
            return View();
        }
        /// <summary>
        /// Save File to Db
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadDocument(IFormFile file)
        {
          
            byte[] document = null;
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("file", "file not selected");
                return View();
            }

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                document = ms.ToArray();
            }
            if (document != null)
            {
                journalsDocumentRepository.SaveDocument(new Entities.JournalsDocument
                {
                    CreatedDate = DateTime.Now,
                    Document = document,
                    Name = file.Name,
                    ResearcherId = GetUserId()
                });
            }
            return RedirectToAction("JournalsDocuments");
        }


    }
}
