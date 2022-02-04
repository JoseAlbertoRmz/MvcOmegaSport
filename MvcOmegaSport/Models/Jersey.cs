using System.ComponentModel.DataAnnotations;

namespace MvcOmegaSport.Models
{
    public class Jersey
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

       /* [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }   */
        public string? Talla { get; set; }  // S , M,  G
        public string? Equipacion { get; set; }   //local  visitante alternativa
        public string? Marca { get; set; }   //local  visitante alternativa
        public decimal Precio { get; set; }
    }
}

