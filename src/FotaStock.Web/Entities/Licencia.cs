using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Entities;


public class Licencia
{
    

    public int IdLicencia { get; set; }

    [Required]
    public int DetalleCompraId { get; set; }

    [Required]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    public DateTime FechaEmision { get; set; }

    [Required]

    public string Estado { get; set; } = string.Empty;


    public DetalleCompra? DetalleCompra { get; set; }



}