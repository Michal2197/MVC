using System.ComponentModel.DataAnnotations;

namespace SystemMonitorowaniaWydatkowDomowych.Models
{
    public class MetodaPlatnosci
    { 
        public int Id { get; set; }  

        [Required(ErrorMessage = "Nazwa metody płatności jest wymagana.")]
        [StringLength(50)]  
        public string Nazwa { get; set; } = string.Empty;   

        public List<Wydatek> Wydatki { get; set; } = new List<Wydatek>();    
    }
}



