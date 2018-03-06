using System;
using System.Collections.Generic;

namespace Bullify.Models.Entities
{
    public partial class Consultants
    {
        public Consultants()
        {
            Skills = new HashSet<Skills>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool BullyStatus { get; set; }

        public ICollection<Skills> Skills { get; set; }
    }
}
