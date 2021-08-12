using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Model
{
    public class Pessoa
    {
        public DateTime DataNasc { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public Pessoa()
        {

        }
        

        public Pessoa(DateTime dataNasc, string nome, string cPF)
        {
            //DateTime Data = DateTime.Now;
            //string DataFormato = nasc.ToString("D");
            DataNasc = dataNasc;
            Nome = nome;
            CPF = cPF;
        }
    }

}
