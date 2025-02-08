using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public class CommentDisplay
    {
        public decimal? COMMENT_ID { get; set; }
        public System.DateTime? COMMENT_DATE { get; set; }
        public decimal? USER_ID { get; set; }
        public decimal? RECORD_ID { get; set; }
        public string CONTENT { get; set; }
        public string SupplierNameString { get; set; }
        public List<string> SupplierNameList { get; set; }

    }
}
