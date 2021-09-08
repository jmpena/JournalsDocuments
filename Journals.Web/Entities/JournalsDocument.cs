using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Journals.Web.Entities
{
    public class JournalsDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Document { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ResearcherId { get; set; }
        public Researcher Researcher { get; set; }
    }
}
