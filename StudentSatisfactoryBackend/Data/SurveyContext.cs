using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StudentSatisfactoryBackend.Models;


namespace StudentSatisfactoryBackend.Data
{
    public class SurveyContext : IdentityDbContext<User>
    {
        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options) { }
    }

}
