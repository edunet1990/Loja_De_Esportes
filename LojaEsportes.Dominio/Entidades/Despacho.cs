using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LojaEsportes.Dominio.Entidades
{
    public class Despacho
    {
        [Required(ErrorMessage = "Informe o nome do destinatário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o endereço de destino")]
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Informe o CEP de destino")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Informe o nome da cidade de destino")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe o nome do Estado")]
        public string Estado { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }
        public bool PacotePresente { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}
