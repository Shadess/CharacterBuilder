using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9th.Sacred.Objects.Data
{
    public class PowerSpecialization
    {
        public int Id { get; set; }
        public int PowerId { get; set; }
        public string Description { get; set; }

        public PowerSpecialization()
        {
            InitializeValues();
        }

        //-------------------------------------------------
        public void InitializeValues()
        {
            Id = 0;
            PowerId = 0;
            Description = string.Empty;
        }
    }
}
