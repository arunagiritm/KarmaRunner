using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KarmaRunner
{
    public class JsuiteSchema
    {
        public string file { get; set; }
        public DataTable suite { get;set; }

        
    }
    public class SpecDetails
    {
        public int Id { get; set; }
        public string Node { get; set; }
        public int ParentId { get; set; }
        public string Type { get; set; }
        public Boolean Active { get; set; }

    }
}
