using Order.Domain.Models;

namespace Order.api.RemoteCall
{
    public interface IHttpProduit
    {
        public Produit getById(int id);
    }
}
