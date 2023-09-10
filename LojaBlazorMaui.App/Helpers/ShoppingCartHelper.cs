using Blazored.LocalStorage;
using LojaBlazorMaui.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBlazorMaui.App.Helpers
{
    /// <summary>
    /// Classe para operações do carrinho de compras do aplicativo
    /// </summary>
    public class ShoppingCartHelper
    {
        private readonly ILocalStorageService? _localStorageService;
        private const string _key = "shopping-cart";

        public ShoppingCartHelper(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        /// <summary>
        /// Método para adicionar 1 item no carrinho de compras
        /// </summary>
        public async Task Add(ShoppingCartItemModel item)
        {
            //verificar se já existe um carrinho de compras criado
            var shoppingCart = await _localStorageService.GetItemAsync<ShoppingCartModel>(_key);
            if(shoppingCart == null)
            {
                //criando um carrinho de compras na local storage
                shoppingCart = new ShoppingCartModel
                {
                    Itens = new List<ShoppingCartItemModel>()
                };
            }

            //adicionar o item no carrinho de compras
            shoppingCart.Itens.Add(item);

            //gravando os dados na local storage
            await _localStorageService.SetItemAsync(_key, shoppingCart);
        }

        /// <summary>
        /// Método para limpar todo conteúdo do carrinho de compras
        /// </summary>
        public async Task RemoveAll()
        {
            await _localStorageService.RemoveItemAsync(_key);
        }

        /// <summary>
        /// Método para retornar todo conteúdo do carrinho de compras
        /// </summary>
        public async Task<ShoppingCartModel> Get()
        {
            return await _localStorageService.GetItemAsync<ShoppingCartModel>(_key);
        }
    }
}
