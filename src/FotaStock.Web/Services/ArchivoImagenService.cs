using FotaStock.Web.Repositories;
using FotaStock.Web.Entities;
using FotaStock.Web.Models;

namespace FotaStock.Web;

public class ArchivoImagenService(GenericRepository<ArchivoImagen> _ArchivoImagenRepository)
{

    public async Task<IEnumerable<ArchivoImagenVM>> GetAllAsync()
    {
        var archivoImagenes = await _ArchivoImagenRepository.GetAllAsync();

        var ArchivoImagenesVM = archivoImagenes.Select(c =>
        new ArchivoImagenVM
        {
            ArchivoImagenId = c.ArchivoImagenId,
            ImagenId = c.ImagenId,
            TipoArchivo = c.TipoArchivo,
            RutaAlmacenamiento = c.RutaAlmacenamiento,
            TieneMarcaAgua = c.TieneMarcaAgua,
            HashIntegridad = c.HashIntegridad,
            FechaCarga = c.FechaCarga
        }).ToList();

        return ArchivoImagenesVM;
    }

    public async Task<PaginatedList<ArchivoImagenVM>> GetByPaginationAsync(int pageIndex, int pageSize)
    {
        var archivoImagenes = await _ArchivoImagenRepository.GetByPaginationAsync(pageIndex,pageSize);

        var ArchivoImagenesVM = archivoImagenes.Items.Select(c =>
        new ArchivoImagenVM
        {
            ArchivoImagenId = c.ArchivoImagenId,
            ImagenId = c.ImagenId,
            TipoArchivo = c.TipoArchivo,
            RutaAlmacenamiento = c.RutaAlmacenamiento,
            TieneMarcaAgua = c.TieneMarcaAgua,
            HashIntegridad = c.HashIntegridad,
            FechaCarga = c.FechaCarga
        }).ToList();

        return new PaginatedList<ArchivoImagenVM>
        (
            ArchivoImagenesVM,
            pageIndex,
            archivoImagenes.TotalPages
        );
    }



    public async Task AddAsync(ArchivoImagenVM viewModel)
    {
        var entity = new ArchivoImagen
        {
            ArchivoImagenId = viewModel.ArchivoImagenId,
            ImagenId = viewModel.ImagenId,
            TipoArchivo = viewModel.TipoArchivo,
            RutaAlmacenamiento = viewModel.RutaAlmacenamiento,
            TieneMarcaAgua = viewModel.TieneMarcaAgua,
            HashIntegridad = viewModel.HashIntegridad,
            FechaCarga = viewModel.FechaCarga   
            };
        await _ArchivoImagenRepository.AddAsync(entity);

        

    }

    public async Task<ArchivoImagenVM?> GetByIdAsync(int id) {
        

        var ArchivoImagen = await _ArchivoImagenRepository.GetbyIdAsync(id);
        var archivoImagenVM = new ArchivoImagenVM();

        if (ArchivoImagen != null)
        {
            archivoImagenVM.ArchivoImagenId = ArchivoImagen.ArchivoImagenId;
            archivoImagenVM.ImagenId = ArchivoImagen.ImagenId;
            archivoImagenVM.TipoArchivo = ArchivoImagen.TipoArchivo;
            archivoImagenVM.RutaAlmacenamiento = ArchivoImagen.RutaAlmacenamiento;
            archivoImagenVM.TieneMarcaAgua = ArchivoImagen.TieneMarcaAgua;
            archivoImagenVM.HashIntegridad = ArchivoImagen.HashIntegridad;
            archivoImagenVM.FechaCarga = ArchivoImagen.FechaCarga;         
        }

        return archivoImagenVM;

    }

    public async Task EditAsync(ArchivoImagenVM viewModel)
    {
        
        var entity = new ArchivoImagen
        {
            ArchivoImagenId = viewModel.ArchivoImagenId,
            ImagenId = viewModel.ImagenId,
            TipoArchivo = viewModel.TipoArchivo,
            RutaAlmacenamiento = viewModel.RutaAlmacenamiento,
            TieneMarcaAgua = viewModel.TieneMarcaAgua,
            HashIntegridad = viewModel.HashIntegridad,
            FechaCarga = viewModel.FechaCarga   
        };
        await _ArchivoImagenRepository.EditAsync(entity);
    }


    public async Task deleteAsync(int id)
    {
        var categoria = await _ArchivoImagenRepository.GetbyIdAsync(id);
        await _ArchivoImagenRepository.DeleteAsync(categoria!);

    }

    
    


}