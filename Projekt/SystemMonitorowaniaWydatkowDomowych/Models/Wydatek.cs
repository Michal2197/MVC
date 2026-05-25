using System.ComponentModel.DataAnnotations;

namespace SystemMonitorowaniaWydatkowDomowych.Models
{
    public class Wydatek
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [StringLength(100)] 
        public string Opis { get; set; } = string.Empty; 

        [Required(ErrorMessage = "Kwota jest wymagana.")]
        [Range(0.01, 999999)]    
        public decimal Kwota { get; set; }

        [Required(ErrorMessage = "Data jest wymagana.")]   
        public DateTime Data { get; set; }

        public int KategoriaId { get; set; }   

        public Kategoria? Kategoria { get; set; }  

        public int MetodaPlatnosciId { get; set; }

        public MetodaPlatnosci? MetodaPlatnosci { get; set; }  
        
    }
}


