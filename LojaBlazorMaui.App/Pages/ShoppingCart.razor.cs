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
using LojaBlazorMaui.App.Helpers;
using LojaBlazorMaui.App.Models;
using LojaBlazorMaui.Services.Models;

namespace LojaBlazorMaui.App.Pages
{
    public partial class ShoppingCart
    {
        [Inject] //injeção de dependência
        public ShoppingCartHelper ShoppingCartHelper { get; set; }

        /// <summary>
        /// Objeto para exibir as informações do carrinho de compras
        /// </summary>
        private ShoppingCartModel? ShoppingCartModel = new ShoppingCartModel();

        /// <summary>
        /// Método executado ao abrir o componente
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            //capturar os dados do carrinho de compras gravado na local storage
            ShoppingCartModel = await ShoppingCartHelper.Get();
        }

        /// <summary>
        /// Método para limpar o conteúdo do carrinho de compras
        /// </summary>
        protected async Task LimparCarrinho()
        {
            await ShoppingCartHelper.RemoveAll();
            await OnInitializedAsync();
        }
    }
}