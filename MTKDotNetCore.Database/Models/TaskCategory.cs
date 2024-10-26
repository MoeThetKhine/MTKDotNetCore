using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.Database.Models
{
    public class TaskCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsDelete {  get; set; }
    }
}
