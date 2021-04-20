using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Assistencia
    {
        public int assistencia_id { get; set; }
        public DateTime actualStart { get; set; }
        public DateTime actualEnd { get; set; }
        public int pjo_tipodeatividade { get; set; }
        public string description { get; set; }
        public int pjo_empreendimentoid { get; set; }
        public int pjo_blocoid { get; set; }
        public int pjo_unidadeid { get; set; }

    }

}
