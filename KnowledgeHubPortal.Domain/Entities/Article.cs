using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ArticleURL { get; set; }
        public string CatagoryId { get; set; }
        public Catagory Catagory { get; set; }
        public bool IsApproved { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime DateSubmitted { get; set; }

    }
}
