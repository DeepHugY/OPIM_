using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Common.DataModels
{
    public class Results
    {
        public Results()
        {
            this.Success = true;
        }
        public Results(string error)
        {
            this.Success = false;
            this.ErrorMessage = error;
        }

        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
