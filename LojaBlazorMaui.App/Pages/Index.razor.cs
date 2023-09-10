using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using LojaBlazorMaui.App;
using LojaBlazorMaui.App.Shared;
using Bogus;
using LojaBlazorMaui.Services.Models;
using LojaBlazorMaui.Services;
using LojaBlazorMaui.App.Helpers;
using LojaBlazorMaui.App.Models;

namespace LojaBlazorMaui.App.Pages
{
    public partial class Index
    {
        [Inject] //injeção de dependência
        public ShoppingCartHelper ShoppingCartHelper { get; set; }

        [Inject] //injeção de dependência
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Lista de produtos exibida na página do aplicativo
        /// </summary>
        private List<ProdutosGetModel> produtos = new List<ProdutosGetModel>();

        /// <summary>
        /// Exibir os dados de 1 produto selecionado pelo usuário
        /// </summary>
        private ProdutosGetModel produtoSelecionado = new ProdutosGetModel();

        /// <summary>
        /// Método executado quando a página é carregada
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            var produtosService = new ProdutosService();
            produtos = await produtosService.GetAll();
        }

        /// <summary>
        /// Método para capturar 1 produto selecionado pelo usuário
        /// </summary>
        protected async Task SelecionarProduto(ProdutosGetModel item)
        {
            produtoSelecionado = item;
        }

        /// <summary>
        /// Método para adicionar 1 item ao carringo de compras
        /// </summary>
        protected async Task AdicionarAoCarrinho(ProdutosGetModel item)
        {
            var shoppingCartItem = new ShoppingCartItemModel
            {
                QtdItens = 1,
                Produto = item
            };

            await ShoppingCartHelper.Add(shoppingCartItem);

            //redirecionar para a página do carrinho de compras
            NavigationManager.NavigateTo("/shopping-cart", true);
        }
    }
}