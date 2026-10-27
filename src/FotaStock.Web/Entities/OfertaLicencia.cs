using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Entities;

public class OfertaLicencia
{
    
    public int IdImagen { get; set; }

    [Required]
    public int ImagenId { get; set; }

    [Required]

    public string Nombre { get; set; } = string.Empty;

    [Required]

    public string Condiciones { get; set; } = string.Empty;


    [Required]

    public decimal Precio { get; set; }


    [Required]

    public char Moneda { get; set; }

    [Required]

    public string Estado { get; set; } = string.Empty;


    [Required]

    public DateTime FechaVigenciaDesde { get; set; }

    public DateTime? FechaVigenciaHasta { get; set; } = null;


    public Imagen? Imagen { get; set; }

    public ICollection<DetalleCompra>? DetalleCompras { get; set; }



}