using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bullify.Models.Entities
{
    public partial class BulliDatabaseContext : DbContext
    {
        public BulliDatabaseContext(DbContextOptions<BulliDatabaseContext>  options) : base(options)
        {
        }

    }
}
