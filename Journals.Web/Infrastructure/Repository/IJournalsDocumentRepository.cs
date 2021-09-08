using Journals.Web.Entities;
using Journals.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journals.Web.Infrastructure.Repository
{
    public interface IJournalsDocumentRepository
    {
        public void SaveDocument(JournalsDocument document);
        public IEnumerable<JournalsDocumentsDTO> GetJournalsDocuments(int researcherId);
        public IEnumerable<JournalsDocumentsDTO> GetMyJournalsDocuments(int researcherId);
    }
}
