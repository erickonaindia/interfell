using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dirmod.API.Models.Response
{
    public class ExternalApiResponse
    {
        public Result Result { get; set; } = new Result();
        public string Status { get; set; }
    }

    public class Result
    {
        public DateTime Updated { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public float Value { get; set; }
        public double Quantity { get; set; }
        public float Amount { get; set; }
    }

}
