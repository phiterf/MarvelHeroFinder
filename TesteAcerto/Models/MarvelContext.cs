namespace TesteAcerto.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MarvelContext : DbContext
    {
        public MarvelContext()
            : base("name=MarvelContext")
        {
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}