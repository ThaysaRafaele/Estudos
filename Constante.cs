using Crud.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api
{
    public class Constante
    {
        public static List<Pessoa> ListaPessoas = new List<Pessoa>();

        public static List<Cardapio> ListaCardapio { get; internal set; }
    }
}
