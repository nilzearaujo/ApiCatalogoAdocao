using ApiCatalgoAdocao.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalgoAdocao.Repositories.Interface
{
    public interface IAnimalRepository
    {
        Task<List<Animal>> GetAll(int pagina, int quantidade);
        Task<Animal> GetPorTutora(string nome, string nomeTutora);
        Task<Animal> Get(Guid id);
        Task<Animal> Add(Animal animal);
        Task Update(Animal animal);
        Task Delete(Guid id);
    }
}
