using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaistinesPastas.Repository.Models
{
    public class PostITResponse
    {
        public string status { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public int message_code { get; set; }
        public int total { get; set; }
        public List<Data> data { get; set; }
    }
}
