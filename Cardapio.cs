using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Model
{
    public class Cardapio
    {
        public String Tipo { get; set; }
        public String Titulo { get; set; }
        public String Descricao { get; set; }
        public String Tamanho { get; set; }
        public Double Preco { get; set; }
        public Boolean Ativo { get; set; }

        public Cardapio(String tipo, String titulo, String descricao, String tamanho, Double preco, Boolean ativo)
        {
            Tipo = tipo;
            Titulo = titulo;
            Descricao = descricao;
            Tamanho = tamanho;
            Preco = preco;
            Ativo = ativo;
        }

    }
}
