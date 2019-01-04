using System.ComponentModel.DataAnnotations;

namespace LojaEsportes.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Lembrar me?")]
        public bool LembrarMe { get; set; }
    }
}