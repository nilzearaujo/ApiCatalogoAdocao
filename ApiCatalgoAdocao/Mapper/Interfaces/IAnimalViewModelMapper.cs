using ApiCatalgoAdocao.Domain;
using ApiCatalgoAdocao.Requests;
using ApiCatalgoAdocao.ViewModel;
using System.Collections.Generic;

namespace ApiCatalgoAdocao.Mapper.Interfaces
{
    public interface IAnimalViewModelMapper
    {
        AnimalViewModel MapViewModel(Animal animal);
        List<AnimalViewModel> MapViewModelList(List<Animal> animal);
        AnimalViewModel MapViewModel(AnimalRequest animal);
        Animal MapDomain(AnimalRequest animal);
    }
}
