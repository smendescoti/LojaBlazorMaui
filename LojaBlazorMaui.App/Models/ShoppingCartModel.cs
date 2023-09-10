using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBlazorMaui.App.Models
{
    /// <summary>
    /// Modelo de dados do carrinho de compras
    /// </summary>
    public class ShoppingCartModel
    {
        public int QtdItens 
        { 
            get
            {
                if (Itens != null && Itens.Count > 0)
                    return Itens.Sum(item => item.QtdItens);
                else
                    return 0;
            }
        }

        public decimal ValorTotal
        {
            get
            {
                if (QtdItens > 0)
                {
                    var valorTotal = 0m;
                    foreach (var item in Itens)
                    {
                        if(item.Produto != null && item.Produto.Price != null)
                            valorTotal += item.QtdItens * item.Produto.Price.Value;
                    }

                    return valorTotal;
                }
                else
                    return 0m;
            }
        }

        public List<ShoppingCartItemModel> Itens { get; set; }
    }
}
