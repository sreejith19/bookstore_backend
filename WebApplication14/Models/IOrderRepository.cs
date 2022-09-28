using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetOrderById(int id);
        List<Order> GetOrderByUserId(int id);
        int Place(Order order);
        int Edit(Order order);
        int Delete(Order order);
        double ApplyCoupons(Order order);
        string[] GetCouponsByOrderId(int id);
        int GetOrderId(Order order);
        bool SetStatus(int orderId, int status);
        bool Enable(int id);
        bool Disable(int id);
    }
}
