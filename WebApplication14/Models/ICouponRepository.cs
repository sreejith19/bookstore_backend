using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public interface ICouponRepository
    {
        List<Coupon> GetAll();
        Coupon GetCouponById(int id);
        Coupon GetCouponByCode(string code);
        int Add(Coupon coupon);
        int Edit(Coupon coupon);
        int Delete(int id);
        bool Enable(int id);
        bool Disable(int id);

    }
}
