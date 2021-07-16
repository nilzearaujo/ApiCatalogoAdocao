using ApiCatalgoAdocao.Domain;
using ApiCatalgoAdocao.Mapper.Interfaces;
using ApiCatalgoAdocao.Repositories.Interface;
using ApiCatalgoAdocao.Requests;
using ApiCatalgoAdocao.Services.Interfaces;
using ApiCatalgoAdocao.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalgoAdocao.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;
        private readonly IAnimalViewModelMapper _mapper;

        public AnimalService(IAnimalRepository repository, IAnimalViewModelMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AnimalViewModel> Add(AnimalRequest request)
        {
            var animalValidador = await _repository.GetPorTutora(request.Nome, request.Tutora);

            if (animalValidador != null)
            {
                throw new InvalidOperationException("Animal com mesmo nome já esta com essa tutora!");
            }

            var animal = _mapper.MapDomain(request);
            animal.Id = Guid.NewGuid();
            await _repository.Add(animal);
            return _mapper.MapViewModel(animal);
        }

        public async Task Delete(Guid id)
        {
            var paraDeletar = await _repository.Get(id);

            if (paraDeletar == null)
            {
                throw new InvalidOperationException("Animal não está cadastrado!");
            }

            await _repository.Delete(id);
        }

        public async Task<AnimalViewModel> Get(Guid id)
        {
            Animal animal = await _repository.Get(id);
            return _mapper.MapViewModel(animal);
        }

        public async Task<List<AnimalViewModel>> GetAll(int pagina, int quantidade)
        {
            List<Animal> animais = await _repository.GetAll(pagina, quantidade);
            return _mapper.MapViewModelList(animais);
        }

        public async Task Update(Guid id, AnimalRequest request)
        {
            var paraAtualizar = await _repository.Get(id);

            if (paraAtualizar == null)
            {
                throw new InvalidOperationException("Animal não está cadastrado!");
            }

            Guid idAnimal = paraAtualizar.Id;

            paraAtualizar = _mapper.MapDomain(request);
            paraAtualizar.Id = idAnimal;
            await _repository.Update(paraAtualizar);
        }

        public async Task UpdatePorte(Guid id, int porte)
        {
            var paraAtualizar = await _repository.Get(id);

            if (paraAtualizar == null)
            {
                throw new InvalidOperationException("Animal não está cadastrado!");
            }

            paraAtualizar.Porte = porte;
            await _repository.Update(paraAtualizar);
        }

        public async Task UpdateStatus(Guid id, int status)
        {
            var paraAtualizar = await _repository.Get(id);

            if (paraAtualizar == null)
            {
                throw new InvalidOperationException("Animal não está cadastrado!");
            }

            paraAtualizar.Status = status;
            await _repository.Update(paraAtualizar);
        }
    }
}
