using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaistinesPastas.Repository.Models
{
    public class QueryLog
    {
        [Key]
        public int LogId { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
        public double DurationInMilliseconds { get; set; }
        public string QueryText { get; set; }
        public string QueryParameters { get; set; }
        public string TableChanged { get; set; }
        public string QueryType { get; set; }
    }
}
