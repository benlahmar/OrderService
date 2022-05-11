using Microsoft.AspNetCore.Mvc;
using Order.Domain.Models;
using Polly;

namespace Order.api.RemoteCall
{
    public class HttpProduit : IHttpProduit
    {
        private readonly HttpClient _httpClient;
        private readonly IAsyncPolicy<HttpResponseMessage> _policy;

        
        public HttpProduit(HttpClient httpClient, IAsyncPolicy<HttpResponseMessage> policy
)
        {
            _httpClient = httpClient;
            _policy=policy;
        }

        public Produit getById(int id)
        {
            string url = "https://localhost:7248/produits/" + id;
            Produit? r = _httpClient.GetFromJsonAsync<Produit>(url).Result;
            return r;
        }

        public async Task<ActionResult<Produit>> GetById2(int id)
        { 
            string url = "https://localhost:7248/produits/" + id;

            HttpResponseMessage response = await _policy.ExecuteAsync(()
               => _httpClient.GetAsync("https://localhost:7248/produits/" + id));

            if (response.IsSuccessStatusCode)
            {
                var prd = await response.Content.ReadFromJsonAsync<Produit>();

                return prd;
            }
            return null;


        }
    }
}
