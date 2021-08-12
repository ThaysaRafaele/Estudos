using Crud.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        
        //public PessoaController()
        //{
        //    Constante.ListaPessoas = new List<Pessoa>()
        //    {
        //        //Nome = "Fulano",
        //        //Nasc = new DateTime(2021, 07, 06),
        //        //CPF = "055.057.011-08"
        //        new Pessoa {Nasc=new DateTime(2021, 07, 06), Nome = "Fulano", CPF = "055.057.011-08"},
        //        new Pessoa {Nasc=new DateTime(1997, 12, 16), Nome = "Ciclano", CPF = "064.245.010-29"},
        //        new Pessoa {Nasc=new DateTime(2000, 06, 18), Nome = "Beltrano", CPF = "494.768.520-46"}
        //    };
        //}

        [HttpGet]
        public List<Pessoa> ListarPessoa() //mostrando todas as pessoas da lista
        {
            return Constante.ListaPessoas;
        }

        [HttpGet("ExibirPessoa")]
        public Pessoa ExibirPessoa(string NomePessoa) //exibindo apenas uma pessoa de acordo com o parâmetro recebido via URL (HttpGet)
        {
            //var teste = Pessoas[x].Nome; //nesse caso, x é um inteiro que representa o índice da lista
            for (int i = 0; i <= 2; i++)
            {
                Debug.WriteLine("Nome: " + Constante.ListaPessoas[i].Nome + " Data Nascimento: " + Constante.ListaPessoas[i].DataNasc + " CPF: " + Constante.ListaPessoas[i].CPF);
                if (NomePessoa.Equals(Constante.ListaPessoas[i].Nome))
                {
                    return Constante.ListaPessoas[i];

                }
            }
            return null;
        }

        [HttpPost("MostrarPessoa")]
        public Pessoa MostrarPessoa([FromBody] string NomePessoa) //especificando onde vai estar o valor enviado pro post (no caso, no body do postman - padrão JSON)
        {
            for (int i = 0; i <= 2; i++)
            {
                Debug.WriteLine("Nome: " + Constante.ListaPessoas[i].Nome + " Data Nascimento: " + Constante.ListaPessoas[i].DataNasc + " CPF: " + Constante.ListaPessoas[i].CPF);
                if (NomePessoa.Equals(Constante.ListaPessoas[i].Nome))
                {
                    return Constante.ListaPessoas[i];

                }
            }
            return null;
        }

        [HttpPost("AdicionarPessoa")]
        public String AdicionarPessoa([FromBody] Pessoa pessoa)
        {
            var p = new Pessoa(pessoa.DataNasc, pessoa.Nome, pessoa.CPF);
            var p1 = new Pessoa(new DateTime().Date, "Teste", "123.456.789-10");

            Constante.ListaPessoas.Add(pessoa); //adicionando o objeto recebido (com Nome, Data nasc e CPF) na lista (em cache).


            //return "Incluído com Sucesso!";
            return JsonSerializer.Serialize("Incluido com Sucesso!"); //para corrigir o erro da requisição não aceitar o return anterior com uma sting simples

        }

        [HttpPost("AdicionarVariasPessoas")]
        public String AdicionarVariasPessoas([FromBody] List<Pessoa> ListaAddPessoas)
        {
            int count = ListaAddPessoas.Count();
            int countInic = Constante.ListaPessoas.Count();
            int aux = 0;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < countInic; j++)
                {
                    if (ListaAddPessoas[i].CPF.Equals(Constante.ListaPessoas[j].CPF)) 
                    {
                        aux++;
                        //return "O CPF: " + ListaAddPessoas[i].CPF + " Já está cadastrado!";
                    }
                }

                Constante.ListaPessoas.Add(ListaAddPessoas[i]);
                countInic = Constante.ListaPessoas.Count();

            }

            int countFim = count - aux;

            return countFim + " Pessoas incluídas com Sucesso!";

        }
    }
}
