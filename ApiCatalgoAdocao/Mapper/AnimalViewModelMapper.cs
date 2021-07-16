using ApiCatalgoAdocao.Domain;
using ApiCatalgoAdocao.Mapper.Interfaces;
using ApiCatalgoAdocao.Requests;
using ApiCatalgoAdocao.ViewModel;
using AutoMapper;
using System.Collections.Generic;

namespace ApiCatalgoAdocao.Mapper
{
    //Utilizei uma biblioteca de mapeamento seguindo esse tutorial: https://www.treinaweb.com.br/blog/utilizando-automapper-no-c
    public class AnimalViewModelMapper : IAnimalViewModelMapper
    {
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        public AnimalViewModelMapper()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Animal, AnimalViewModel>()
                   .ForMember(avm => avm.Porte,
                              map => map.MapFrom(a => (EPorteAnimal)a.Porte))
                    .ForMember(avm => avm.Status,
                              map => map.MapFrom(a => (EStatusAnimal)a.Status));

                cfg.CreateMap<AnimalRequest, AnimalViewModel>()
                .ForMember(avm => avm.Porte,
                              map => map.MapFrom(ar => (EPorteAnimal)ar.Porte))
                .ForMember(avm => avm.Status,
                              map => map.MapFrom(ar => (EStatusAnimal)ar.Status));

                cfg.CreateMap<AnimalRequest, Animal>();
            });

            _mapper = _configuration.CreateMapper();
        }

        public AnimalViewModel MapViewModel(Animal animal)
        {
            return _mapper.Map<AnimalViewModel>(animal);
        }

        public List<AnimalViewModel> MapViewModelList(List<Animal> animal)
        {
            return _mapper.Map<List<AnimalViewModel>>(animal);
        }

        public AnimalViewModel MapViewModel(AnimalRequest animal)
        {
            return _mapper.Map<AnimalViewModel>(animal);
        }
        
        public Animal MapDomain(AnimalRequest animal)
        {
            return _mapper.Map<Animal>(animal);
        }
    }
}
