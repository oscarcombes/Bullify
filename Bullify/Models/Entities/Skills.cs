using System;
using System.Collections.Generic;

namespace Bullify.Models.Entities
{
    public partial class Skills
    {
        public int Id { get; set; }
        public int ConsultantsId { get; set; }
        public string Skillset { get; set; }

        public Consultants Consultants { get; set; }
    }
}
