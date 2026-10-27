using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Entities;



public class Pago
{
    
    public int IdPago { get; set; }

    [Required]
    public decimal Monto { get; set; }

    [Required]
    public DateTime FechaIntento { get; set; }

   
    public DateTime? FechaRespuesta { get; set; } = null;

    [Required]
    public string Estado { get; set; } = string.Empty;

    [Required]
    public string Metodo { get; set; } = string.Empty;

    [Required]
    public string Referencia { get; set; } = string.Empty;

    

    public Compra? Compra { get; set; }

}