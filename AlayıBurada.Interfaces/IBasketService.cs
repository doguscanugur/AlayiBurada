using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Interfaces
{
    public interface IBasketService:IGenericService<Basket>
    {
        PocoBasket ConfirmToBasket (int productId, int customerId);
    }
}
