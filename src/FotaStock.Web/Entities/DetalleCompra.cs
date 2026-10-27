using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace FotaStock.Web.Entities;



public class DetalleCompra
{
    

    public int IdDetalleCompra { get; set; }

    [Required]
    public int CompraId { get; set; }

    [Required]
    public int OfertaLicenciaId { get; set; }

    [Required]
    public decimal PrecioUnitario { get; set; }

    [Required]
    public string CondicionesSnapshot { get; set; } = string.Empty;

    public Compra? Compra { get; set; }

    public OfertaLicencia? OfertaLicencia { get; set; }

    public ICollection<Licencia>? Licencias { get; set; }


    

}