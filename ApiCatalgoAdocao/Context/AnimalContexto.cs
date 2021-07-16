using ApiCatalgoAdocao.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ApiCatalgoAdocao.Context
{
  
    public class AnimalContexto
    {
        public readonly List<Animal> Animais;
        public AnimalContexto()
        {
            Animais = new List<Animal>();
            GerarDados();
        }
        public void GerarDados()
        {
            Animais.AddRange(new Animal[]{
                          new Animal()
                          {
                              Id = Guid.Parse("375d0771-b1ce-48de-9300-fd69fb21c222"),
                              Idade = 1,
                              Nome = "Meg",
                              Tutora = "Nilze",
                              Peso = 5,
                              Porte = 1,
                              Status = 1
                          },
                          new Animal()
                          {
                              Id = Guid.Parse("ae9cd75a-662a-4e1e-9449-ef18ebf8910a"),
                              Idade = 2,
                              Nome = "Belinha",
                              Tutora = "Gabriel",
                              Peso = 6,
                              Porte = 2,
                              Status = 3
                          },
                          new Animal()
                          {
                              Id = Guid.Parse("6773fafc-54e2-4b6b-ad4f-2a7568c8de04"),
                              Idade = 3,
                              Nome = "Lina",
                              Tutora = "Nilze",
                              Peso = 8,
                              Porte = 3,
                              Status = 1
                          },
                          new Animal()
                          {
                              Id = Guid.Parse("e462f064-565c-460c-a19f-588acbc0553e"),
                              Idade = 2,
                              Nome = "Juninho",
                              Tutora = "Nilze",
                              Peso = 5,
                              Porte = 2,
                              Status = 3
                          },
                          new Animal()
                          {
                              Id = Guid.Parse("0ff19cc5-00d6-47e7-a443-b7762d649a49"),
                              Idade = 1,
                              Nome = "Elune",
                              Tutora = "Gabriel",
                              Peso = 11,
                              Porte = 2,
                              Status = 3
                          }});
        }
    }
}
