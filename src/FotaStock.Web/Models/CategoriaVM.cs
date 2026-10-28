using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Models;


public class CategoriaVM
{
    
    public int CategoriaId { get; set; }


    public string Nombre { get; set; } = string.Empty;

   

    public string Descripcion { get; set; } = string.Empty;




}