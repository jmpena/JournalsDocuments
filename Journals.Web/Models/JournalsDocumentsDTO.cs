using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journals.Web.Models
{
    public class JournalsDocumentsDTO : Entities.JournalsDocument
    {
        public string PDFBase64 { get; set; }
     
        public bool IsSubscribe { get; set; }
    }
}
