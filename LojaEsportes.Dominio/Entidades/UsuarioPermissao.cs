using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaEsportes.Dominio.Entidades
{
    [Table("UsuarioPermissoes")]
    public partial class UsuarioPermissao
    {
        [Key]
        public int PermissaoUsuarioId { get; set; }

        [Display(Name = "Permissão")]
        public int PermissaoId { get; set; }
        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }

        public virtual Permissao Permissao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}