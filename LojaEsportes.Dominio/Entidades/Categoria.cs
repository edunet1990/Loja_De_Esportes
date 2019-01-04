using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaEsportes.Dominio.Entidades
{
    [Table("Categorias")]
    public class Categoria
    {
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Informe o nome da catagoria")]
        [Display(Name = "Categoria")]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
