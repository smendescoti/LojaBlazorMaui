using LojaBlazorMaui.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBlazorMaui.App.Models
{
    /// <summary>
    /// Modelo de dados do item contido no carrinho de compras
    /// </summary>
    public class ShoppingCartItemModel
    {
        public ProdutosGetModel Produto { get; set; }
        public int QtdItens { get; set; }
    }
}
