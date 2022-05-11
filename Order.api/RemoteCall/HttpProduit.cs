using Order.Domain.Models;

namespace Order.api.RemoteCall
{
    public class HttpProduit : IHttpProduit
    {
        private readonly HttpClient _httpClient;

        public HttpProduit(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Produit getById(int id)
        {
            string url = "https://localhost:7248/produits/" + id;
            Produit? res = _httpClient.GetFromJsonAsync<Produit>(url).Result;
            return res;
        }
    }
}
