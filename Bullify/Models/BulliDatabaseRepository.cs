using Bullify.Models.Entities;
using Bullify.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName

                })

            .ToArray();

            return q;
        }

        public InfoBoxVM GetConsultantById(int id)
        {

            var consultant = context.Consultants
                .Include(o => o.Skills)
                .Where(o => o.Id == id)
                .Single();

            return new InfoBoxVM
            {
                Id = consultant.Id,
                Description = consultant.Description,
                Image = consultant.Image,
                Skills = consultant.Skills
                        .Select(o => o.Skillset).ToArray(),
                BullyStatus = consultant.BullyStatus
            };
        }

        public EditVM GetEditViewById(int id)
        {

            var consultant = context.Consultants
                .Include(o => o.Skills)
                .Where(o => o.Id == id)
                .Single();

            return new EditVM
            {
                FirstName = consultant.FirstName,
                LastName = consultant.LastName,
                Id = consultant.Id,
                Description = consultant.Description,
                Image = consultant.Image,
                //BullyStatus = consultant.BullyStatus,
                Skills = string.Join(", ", consultant.Skills
                .Select(o => o.Skillset))
            };
        }


        internal void UpdateConsultant(EditVM model)
        {

            var consultantToUpdate = context.Consultants.Find(model.Id);

            consultantToUpdate.FirstName = model.FirstName;
            consultantToUpdate.LastName = model.LastName;
            consultantToUpdate.Description = model.Description;

            consultantToUpdate.Skills.Clear();
            string skill = model.Skills;
            string[] makeArrayOfSkill = skill.Split(", ");

            foreach (var item in makeArrayOfSkill)
            {

                consultantToUpdate.Skills.Add(new Skills { Skillset = item });

            }


            context.SaveChanges();



        }
    }
}
