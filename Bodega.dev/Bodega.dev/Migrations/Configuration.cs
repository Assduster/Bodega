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
            context.news.AddOrUpdate(x => x.id,
                new News() { id = 1, title = "LOREM IMPUSM LOREM UMPS", text = "LOREM IMPUSM LOREM UMPS", published = DateTime.Now },
                new News() { id = 2, title = "LOREM IMPUSM LOREM UMPS", text = "LOREM IMPUSM LOREM UMPS", published = DateTime.Now },
                new News() { id = 3, title = "LOREM IMPUSM LOREM UMPS", text = "LOREM IMPUSM LOREM UMPS", published = DateTime.Now },
                new News() { id = 4, title = "LOREM IMPUSM LOREM UMPS", text = "LOREM IMPUSM LOREM UMPS", published = DateTime.Now },
                new News() { id = 5, title = "LOREM IMPUSM LOREM UMPS", text = "LOREM IMPUSM LOREM UMPS", published = DateTime.Now },
                new News() { id = 6, title = "LOREM IMPUSM LOREM UMPS", text = "LOREM IMPUSM LOREM UMPS", published = DateTime.Now },
                new News() { id = 7, title = "LOREM IMPUSM LOREM UMPS", text = "LOREM IMPUSM LOREM UMPS", published = DateTime.Now },
                new News() { id = 8, title = "LOREM IMPUSM LOREM UMPS", text = "LOREM IMPUSM LOREM UMPS", published = DateTime.Now }

                );

        }
    }
}
