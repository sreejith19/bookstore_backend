using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public interface ICategoryrepository
    {
        List<Category> getAll();
        Category getCategoryById(int id);
        int addCategory(Category category);
        int editCategory(Category category);
        int deleteCategoryById(int catId);
    }
}
