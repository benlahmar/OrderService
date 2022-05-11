using Microsoft.AspNetCore.Mvc;
using Order.Domain.Models;

namespace Order.api.RemoteCall
{
    public interface IHttpProduit
    {
        public Produit getById(int id);
        public Task<ActionResult<Produit>> GetById2(int id);
    }
}
