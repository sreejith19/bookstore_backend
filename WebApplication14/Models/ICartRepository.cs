using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    internal interface ICartRepository
    {
        List<WishListEntry> GetWishList(int userId);
        List<CartEntry> GetCart(int userId);
        bool AddToWishList(int userId, int bookId);
        bool AddToCart(int userId, int bookId);
        bool RemoveFromWishList(int userId, int bookId);
        bool RemoveFromCart(int userId, int bookId);
    }
}
