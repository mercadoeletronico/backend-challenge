using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MinhaAplicacao_Cliente.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAplicacao_Cliente.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly string _apiBaseUrlComandas;
        private readonly string _apiBaseUrlCardapios;

        #region Construtores

        public PedidosController(IConfiguration configuration)
            : base(configuration)
        {
            this._apiBaseUrlComandas = $"{this._apiBaseUrl}Comandas";
            this._apiBaseUrlCardapios = $"{this._apiBaseUrl}Cardapios";
            this._apiBaseUrl += "Pedidos";
        }

        #endregion

        #region GETs

        public async Task<IActionResult> Index()
        {
            List<PedidoModel> mdeolo;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(this._apiBaseUrl);

                mdeolo = JsonConvert.DeserializeObject<List<PedidoModel>>(await response.Content.ReadAsStringAsync());
            }

            return View(mdeolo);
        }

        public async Task<IActionResult> Adicionar()
        {
            using var httpClient = new HttpClient();
            using var responseComandas = await httpClient.GetAsync(this._apiBaseUrlComandas);
            using var responseCardapios = await httpClient.GetAsync(this._apiBaseUrlCardapios);

            var modelo = new PedidoModel
            {
                //SelectComandas = this.ConverteSelectListItemComando(JsonConvert.DeserializeObject<IEnumerable<ComandaModel>>(await responseComandas.Content.ReadAsStringAsync())),
                //SelectCardapios = this.ConverteSelectListItemCardapio(JsonConvert.DeserializeObject<IEnumerable<CardapioModel>>(await responseCardapios.Content.ReadAsStringAsync()))
            };

            return this.View(modelo);
        }

        #endregion

        #region POSTs

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar(PedidoModel modelo)
        {
            if (ModelState.IsValid)
            {
                using var cliente = new HttpClient();
                var contuúdo = new StringContent(JsonConvert.SerializeObject(modelo), Encoding.UTF8, "application/json");
                using var resposta = await cliente.PostAsync(this._apiBaseUrl, contuúdo);

                if (resposta.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction(nameof(Index));
                }

                var message = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                ModelState.Clear();
                ModelState.AddModelError(string.Empty, message);
            }

            using var httpClient = new HttpClient();
            using var responseComandas = await httpClient.GetAsync(this._apiBaseUrlComandas);
            using var responseCardapios = await httpClient.GetAsync(this._apiBaseUrlCardapios);

            //modelo.SelectComandas = this.ConverteSelectListItemComando(JsonConvert.DeserializeObject<IEnumerable<ComandaModel>>(await responseComandas.Content.ReadAsStringAsync()));
            //modelo.SelectCardapios = this.ConverteSelectListItemCardapio(JsonConvert.DeserializeObject<IEnumerable<CardapioModel>>(await responseCardapios.Content.ReadAsStringAsync()));

            return View(modelo);
        }

        #endregion

        //private IEnumerable<SelectListItem> ConverteSelectListItemComando(IEnumerable<ComandaModel> comandos)
        //{
        //    return comandos.Select(x => new SelectListItem
        //    {
        //        Value = x.Id.ToString(),
        //        Text = x.Codigo
        //    });
        //}

        //private IEnumerable<SelectListItem> ConverteSelectListItemCardapio(IEnumerable<CardapioModel> comandos)
        //{
        //    return comandos.Select(x => new SelectListItem
        //    {
        //        Value = x.Id.ToString(),
        //        Text = x.Nome
        //    });
        //}
    }
}
