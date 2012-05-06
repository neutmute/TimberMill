using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimberMill.Domain.Objects
{
    public class Batch
    {
        public int Id { get; set; }

        public Source Source { get; set; }

        public DateTime DateReceived { get; set; }
        
        public Batch()
        {
            DateReceived = DateTime.Now;
        }
    }
}
