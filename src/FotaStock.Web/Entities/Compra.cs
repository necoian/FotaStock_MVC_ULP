using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Entities;


public class Compra
{
    
    public int IdCompra { get; set; }

    [Required]
    public int UsuarioId { get; set; }

    public DateTime? Fecha { get; set; } = null;

    [Required]
    public string Estado { get; set; } = string.Empty;

    [Required]
    public decimal Total { get; set; }

    [Required]
    public char Moneda { get; set; }

    public Usuario? Usuario { get; set; }

    public ICollection<DetalleCompra>? DetalleCompras { get; set; }

    public ICollection<Pago>? Pagos { get; set; }

}