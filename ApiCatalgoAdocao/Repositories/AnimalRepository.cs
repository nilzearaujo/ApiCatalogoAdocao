using ApiCatalgoAdocao.Context;
using ApiCatalgoAdocao.Domain;
using ApiCatalgoAdocao.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalgoAdocao.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {

        private readonly AnimalContexto _contexto;

        public AnimalRepository(AnimalContexto contexto)
        {
            _contexto = contexto;
        }

        public Task<Animal> Add(Animal animal)
        {
            _contexto.Animais.Add(animal);
            return Task.FromResult(animal);
        }

        public Task Delete(Guid id)
        {
            return Task.FromResult(_contexto.Animais.RemoveAll(q => q.Id == id));
        }

        public Task<Animal> Get(Guid id)
        {
            return Task.FromResult(_contexto.Animais.FirstOrDefault(q => q.Id == id));
        }

        public Task<List<Animal>> GetAll(int pagina, int quantidade)
        {
            return Task.FromResult(_contexto.Animais.Skip(pagina).Take(quantidade).ToList());
        }

        public Task<Animal> GetPorTutora(string nome, string nomeTutora)
        {
            return Task.FromResult(_contexto.Animais.FirstOrDefault(q => q.Nome == nome && q.Tutora == nomeTutora));
        }

        public Task Update(Animal animal)
        {
            var paraAtualizar = _contexto.Animais.FirstOrDefault(q => q.Id == animal.Id);
            _contexto.Animais.Remove(animal);
            _contexto.Animais.Add(animal);
            return Task.FromResult(animal);
        }
    }
}
