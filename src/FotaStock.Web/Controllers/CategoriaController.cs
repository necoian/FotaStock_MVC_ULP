using FotaStock.Web.Context;
using FotaStock.Web.Models;
using FotaStock.Web.Services;
using Microsoft.AspNetCore.Mvc;


namespace FotaStock.Web.Controllers;


public class CategoriaController(CategoriaService _categoriaService) : Controller
{
    
    public async Task<IActionResult> Index()
    {
        
        var categorias =await _categoriaService.GetAllAsync();
        return View(categorias);

    }


}