using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain
{
    public class Job
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
