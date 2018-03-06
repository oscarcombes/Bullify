using Bullify.Models.Entities;
using Bullify.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullify.Models
{
    public class BulliDatabaseRepository
    {

        private readonly BulliDatabaseContext context;

        public BulliDatabaseRepository(BulliDatabaseContext context) //Homecontroller konstruktorn anropas av MVC --> saturnrepository konstruktorn anropas --> saturncontext anropas. Vi vill inte länka homecontroller för tätt mot vår databas eftersom vi kan lägga saturnrepository i ett klassbibliotek nu (graden av återanvändningsbarhet är numera hög!), det skulle inte vara möjligt om vi hade länken homecontroller --> saturncontext direkt!
        {
            this.context = context;
        }


        

        internal IndexVM[] GetAllConsultants()
        {
            var q = context
                .Consultants
                .Select(c => new IndexVM
                {
                    Id=c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName

                })
                
            .ToArray();

            return q;
        }

        public InfoBoxVM GetConsultantById(int id)
        {
            
            var consultant = context.Consultants.Find(id);
            return new InfoBoxVM {Id = consultant.Id,
                Description = consultant.Description,
                Image = consultant.Image,
                Skills = consultant.Skills,
                BullyStatus = consultant.BullyStatus};
            

         
          
        }
    }
}
