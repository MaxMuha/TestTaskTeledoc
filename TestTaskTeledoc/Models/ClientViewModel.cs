using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskTeledoc.Db.Models;

namespace TestTaskTeledoc.Models
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        public long TaxpayerIdentification { get; set; }
        public string Name { get; set; }
        public TypeClientViewModel Type { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public List<FounderViewModel> Founders { get; set; }
    }
}
