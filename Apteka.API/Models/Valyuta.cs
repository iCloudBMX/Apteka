using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apteka.API.Models
{
    public class Valyuta
    {
        public string title { get; set; }

        public double cb_price { get; set; }
    }
}
