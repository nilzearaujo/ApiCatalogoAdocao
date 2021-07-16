using ApiCatalgoAdocao.Requests;
using ApiCatalgoAdocao.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalgoAdocao.Services.Interfaces
{
    public interface IAnimalService
    {
        Task<List<AnimalViewModel>> GetAll(int pagina, int quantidade);
        Task<AnimalViewModel> Get(Guid id);
        Task<AnimalViewModel> Add(AnimalRequest request);
        Task Update(Guid id, AnimalRequest request);
        Task UpdateStatus(Guid id, int status);
        Task UpdatePorte(Guid id, int porte);
        Task Delete(Guid id);
    }
}
