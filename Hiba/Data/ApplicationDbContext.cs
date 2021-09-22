using Hiba.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Page> Pages { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<News> News { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CooperationAndPartners> CooperationAndPartners { get; set; }
        public DbSet<AddToYourInformation> AddToYourInformation { get; set; }
        public DbSet<TrainingProgram> TrainingProgram { get; set; }
        public DbSet<LectureWorkshop> LectureWorkshops { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Hiba.Models.Coaching> Coaching { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Banner> Banners { get; set; }
    }
}
