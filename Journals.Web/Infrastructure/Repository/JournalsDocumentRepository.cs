using Journals.Web.Entities;
using Journals.Web.Infrastructure.Data;
using Journals.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journals.Web.Infrastructure.Repository
{
    public class JournalsDocumentRepository : IJournalsDocumentRepository
    {
        private readonly SqliteDbContext _dBContext;
        public JournalsDocumentRepository(SqliteDbContext sqliteDbContext)
        {
            _dBContext = sqliteDbContext;
        }
        /// <summary>
        /// Get List of Journals Documents
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JournalsDocumentsDTO> GetJournalsDocuments(int researcherId)
        {
            /// 
            var data = (from r in _dBContext.JournalsDocuments
                        join s in _dBContext.Subscriptions.Where(e => e.ResearcherId == researcherId) on r.ResearcherId equals s.SubscriptionToResearcherId
                         
                        select new JournalsDocumentsDTO
                        {
                            Name = r.Name,
                            ResearcherId = r.ResearcherId,
                            IsSubscribe = true,
                            CreatedDate = r.CreatedDate,
                            Document = r.Document,
                            Id = r.Id,
                            PDFBase64 = Convert.ToBase64String(r.Document, 0, r.Document.Length),
                        });

            return data;
        }

        public IEnumerable<JournalsDocumentsDTO> GetMyJournalsDocuments(int researcherId)
        {
             
            var data = _dBContext.JournalsDocuments.Where(e => e.ResearcherId == researcherId).Select(r => new JournalsDocumentsDTO {
                Name = r.Name,
                ResearcherId = r.ResearcherId,
                IsSubscribe = true,
                CreatedDate = r.CreatedDate,
                Document = r.Document,
                Id = r.Id,
                PDFBase64 = Convert.ToBase64String(r.Document, 0, r.Document.Length),
            });


            return data;
        }

        /// <summary>
        /// Implement Save Document 
        /// </summary>
        /// <param name="document"></param>
        public void SaveDocument(JournalsDocument document)
        {
            _dBContext.JournalsDocuments.Add(document);
            _dBContext.SaveChanges();

        }
    }
}
