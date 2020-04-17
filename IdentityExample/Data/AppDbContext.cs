using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityExample.Data
{
    //IdentityDbContext contains all the user tables
    public class AppDbContext : IdentityDbContext
    {
        //constuctor to pass options to DbContext in order to being sql or memory connection
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
