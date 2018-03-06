using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullify.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public int ConsultantId { get; set; }
        public string Skillset { get; set; }

    }
}
