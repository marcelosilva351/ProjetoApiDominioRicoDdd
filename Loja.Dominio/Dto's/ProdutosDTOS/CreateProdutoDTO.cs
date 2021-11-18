using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Dto_s.ProdutosDTOS
{
    public class CreateProdutoDTO
    {
        [Required(ErrorMessage ="É necessario um nome para cadastrar o produto")]
        public string Titulo { get; private set; }
        [Required(ErrorMessage = "É necessario um preço para cadastrar o produto")]
        public double Preco { get; private set; }

        public CreateProdutoDTO(string titulo, double preco)
        {
            Titulo = titulo;
            Preco = preco;
        }
    }
}
