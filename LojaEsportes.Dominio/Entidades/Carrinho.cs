using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEsportes.Dominio.Entidades
{
    //classe que representa
    // o carrinho de compras
    public class Carrinho
    {
        private List<CarrinhoItem> _itensCarrinho = new List<CarrinhoItem>();

        //adicionar item
        public void AdicionarItem(Produto _produto, int _quantidade)
        {
            CarrinhoItem _item = _itensCarrinho.Where(p => p.Produto.ProdutoId == _produto.ProdutoId).FirstOrDefault();

            if (_item == null)
            {
                _itensCarrinho.Add(new CarrinhoItem
                 {
                     Produto = _produto,
                     Quantidade = _quantidade
                 });
            }
            else
            {
                _item.Quantidade += _quantidade;
            }
        }

        //remover item
        public void RemoverItem(Produto _produto)
        {
            _itensCarrinho.RemoveAll(item => item.Produto.ProdutoId == _produto.ProdutoId);
        }

        //calcular o total
        public decimal CalcularValorTotal()
        {
            return _itensCarrinho.Sum(p => p.Produto.Preco * p.Quantidade);
        }

        // limpar carrinho
        public void LimparCarrinho()
        {
            _itensCarrinho.Clear();
        }
        
        //Itens
        public IEnumerable<CarrinhoItem> Items
        {
            get { return _itensCarrinho; }
        }
    }

    //classe que representa 
    //os itens do carrinho
    public class CarrinhoItem
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
