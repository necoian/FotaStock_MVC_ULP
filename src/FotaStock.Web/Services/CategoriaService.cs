using FotaStock.Web.Entities;
using FotaStock.Web.Repositories;
using FotaStock.Web.Models;
using Microsoft.Identity.Client.NativeInterop;

namespace FotaStock.Web.Services;


public class CategoriaService(GenericRepository<Categoria> _categoriaRepository) {

    public async Task<IEnumerable<CategoriaVM>> GetAllAsync()
    {
        var categorias = await _categoriaRepository.GetAllAsync();

        var categoriasVM = categorias.Select(c =>
        new CategoriaVM
        {
            CategoriaId = c.CategoriaId,
            Nombre = c.Nombre,
            Descripcion = c.Descripcion,
        }).ToList();

        return categoriasVM;
    }

    public async Task<PaginatedList<CategoriaVM>> GetByPaginationAsync(int pageIndex, int pageSize)
    {
        var categorias = await _categoriaRepository.GetByPaginationAsync(pageIndex,pageSize);

        var categoriasVM = categorias.Items.Select(c =>
        new CategoriaVM
        {
            CategoriaId = c.CategoriaId,
            Nombre = c.Nombre,
            Descripcion = c.Descripcion,
        }).ToList();

        return new PaginatedList<CategoriaVM>
        (
            categoriasVM,
            pageIndex,
            categorias.TotalPages
        );
    }



    public async Task AddAsync(CategoriaVM viewModel)
    {
        var entity = new Categoria
        {
            Nombre = viewModel.Nombre,   
            Descripcion = viewModel.Descripcion,     
            };
        await _categoriaRepository.AddAsync(entity);

        

    }

    public async Task<CategoriaVM?> GetByIdAsync(int id) {
        

        var categoria = await _categoriaRepository.GetbyIdAsync(id);
        var categoriaVM = new CategoriaVM();

        if (categoria != null)
        {
            categoriaVM.Nombre = categoria.Nombre;
            categoriaVM.Descripcion = categoria.Descripcion;            
        }

        return categoriaVM;

    }

    public async Task EditAsync(CategoriaVM viewModel)
    {
        
        var entity = new Categoria
        {
            CategoriaId = viewModel.CategoriaId,
            Nombre = viewModel.Nombre,
            Descripcion = viewModel.Descripcion,
        };
        await _categoriaRepository.EditAsync(entity);
    }


    public async Task deleteAsync(int id)
    {
        var categoria = await _categoriaRepository.GetbyIdAsync(id);
        await _categoriaRepository.DeleteAsync(categoria!);

    }


}