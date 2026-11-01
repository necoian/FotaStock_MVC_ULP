using FotaStock.Web.Context;
using FotaStock.Web.Models;
using FotaStock.Web.Services;
using Microsoft.AspNetCore.Mvc;


namespace FotaStock.Web.Controllers;


public class CategoriaController(CategoriaService _categoriaService) : Controller
{
    
    public async Task<IActionResult> Index()
    {
        
        //var categorias =await _categoriaService.GetAllAsync();

        return View(/*categorias*/);

    }

    //Enviar GET a VUE.js
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        
        var categorias =await _categoriaService.GetAllAsync();

        if(categorias == null)
        {
            return NotFound();
        }

        return Ok(categorias);


    }

    [HttpGet]
    public async Task<IActionResult> AddEdit()
    {
        
        
        return View();

    }

    [HttpPost]
    public async Task<IActionResult> AddEdit(CategoriaVM entityVM)
    {
        
        await _categoriaService.AddAsync(entityVM);

        ViewBag.message = "Categoria creada";
        return View();

    }


}