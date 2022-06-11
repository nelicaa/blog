using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.DTO
{
   public class LogDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
