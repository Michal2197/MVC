using Microsoft.EntityFrameworkCore;
using SystemMonitorowaniaWydatkowDomowych.Models;

namespace SystemMonitorowaniaWydatkowDomowych.Data
{
    public class KontekstBazyDanych : DbContext
    {
        public KontekstBazyDanych(

            DbContextOptions<KontekstBazyDanych> options)  
            : base(options)
        {
        }

        public DbSet<Wydatek> Wydatki { get; set; }  

        public DbSet<Kategoria> Kategorie { get; set; }  

        public DbSet<MetodaPlatnosci> MetodyPlatnosci { get; set; }  


    }
}


