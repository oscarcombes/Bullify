using Bullify.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullify.Models.ViewModels
{
    public class InfoBoxVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool BullyStatus { get; set; }

        public ICollection<Skills> Skills { get; set; }

    }
}
