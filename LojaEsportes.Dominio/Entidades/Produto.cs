using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaEsportes.Dominio.Entidades
{
    [Table("Produtos")]
    public class Produto
    {
        public int ProdutoId { get; set; }
        [Required(ErrorMessage="Informe o nome do produto")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a descrição do produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe o preço do produto")]
        public decimal Preco { get; set; }
        public byte[] Imagem { get; set; }
        public string ImagemTipo { get; set; }
        [Display(Name="Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
