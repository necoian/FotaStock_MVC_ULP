using FotaStock.Web.Entities;
using FotaStock.Web.Repositories;
using FotaStock.Web.Models;

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
        }).ToList();

        return categoriasVM;
    }

}