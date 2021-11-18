using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Dto_s.ClientesDTOS
{
    public class CreateClienteDTO
    {
        [Required(ErrorMessage ="Nome do cliente é obrigatorio para cadastro")]
        public string Nome { get; private set; }
        [EmailAddress]
        [Required]
        public string Email { get; private set; }

        public CreateClienteDTO(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
