using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTeledoc.Db.Models
{
    public class Founder
    {
        public Guid Id { get; set; }
        public long TaxpayerIdentification { get; set; }
        public string FullName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public List<Client> Clients { get; set; }
        public Founder()
        {
            Clients = new List<Client>();
        }
    }
}
