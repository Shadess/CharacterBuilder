using _9th.Sacred.Objects.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Requests
{
    public class RaceRequest
    {
        public string UserToken { get; set; }
        public Race Race { get; set; }
    }
}
