using System.ComponentModel.DataAnnotations;

namespace SystemMonitorowaniaWydatkowDomowych.Models
{
    public class Kategoria
    { 
        public int Id { get; set; }  

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana.")]  
        [StringLength(50)]   
        public string Nazwa { get; set; } = string.Empty;  

        public List<Wydatek> Wydatki { get; set; } = new List<Wydatek>();   
    }
}


