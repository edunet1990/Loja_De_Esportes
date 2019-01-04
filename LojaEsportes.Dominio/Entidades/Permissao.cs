using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaEsportes.Dominio.Entidades
{
    [Table("Permissoes")]
    public partial class Permissao
    {
        public Permissao()
        {
            this.UsuarioPermissoes = new HashSet<UsuarioPermissao>();
        }

        [Key]
        public int PermissaoId { get; set; }
        [Required(ErrorMessage = "Informe a permissão.")]
        [Display(Name = "Permissao")]
        public string Nome { get; set; }

        public virtual ICollection<UsuarioPermissao> UsuarioPermissoes { get; set; }
    }
}
