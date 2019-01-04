using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaEsportes.Dominio.Entidades
{
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario()
        {
            this.UsuarioPermissoes = new HashSet<UsuarioPermissao>();
        }

        [Key]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Informe o login.")]
        [Display(Name = "Usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Informe o email.")]

        public virtual ICollection<UsuarioPermissao> UsuarioPermissoes { get; set; }
    }
}
