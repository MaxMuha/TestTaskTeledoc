using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTeledoc.Db.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public long TaxpayerIdentification { get; set; }
        public string Name { get; set; }
        public TypeClient Type { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public List<Founder> Founders { get; set; }
        public Client()
        {
            Founders = new List<Founder>();
        }
    }
}
