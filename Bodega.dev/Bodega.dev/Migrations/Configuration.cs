namespace Bodega.dev.Migrations
{
    using Bodega.dev.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bodega.dev.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bodega.dev.Models.ApplicationDbContext context)
        {
            context.news.AddOrUpdate(x => x.Id,
            new News() { Id = 1, Title = "LOREM IMPUSM LOREM UMPS", Text = "LOREM IMPUSM LOREM UMPS", Published = DateTime.Now },
            new News() { Id = 2, Title = "LOREM IMPUSM LOREM UMPS", Text = "LOREM IMPUSM LOREM UMPS", Published = DateTime.Now },
            new News() { Id = 3, Title = "LOREM IMPUSM LOREM UMPS", Text = "LOREM IMPUSM LOREM UMPS", Published = DateTime.Now },
            new News() { Id = 4, Title = "LOREM IMPUSM LOREM UMPS", Text = "LOREM IMPUSM LOREM UMPS", Published = DateTime.Now },
            new News() { Id = 5, Title = "LOREM IMPUSM LOREM UMPS", Text = "LOREM IMPUSM LOREM UMPS", Published = DateTime.Now },
            new News() { Id = 6, Title = "LOREM IMPUSM LOREM UMPS", Text = "LOREM IMPUSM LOREM UMPS", Published = DateTime.Now },
            new News() { Id = 7, Title = "LOREM IMPUSM LOREM UMPS", Text = "LOREM IMPUSM LOREM UMPS", Published = DateTime.Now },
            new News() { Id = 8, Title = "LOREM IMPUSM LOREM UMPS", Text = "LOREM IMPUSM LOREM UMPS", Published = DateTime.Now }

                );

        }
    }
}
