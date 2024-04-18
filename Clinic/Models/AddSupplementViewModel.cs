using Clinic.Models;

namespace Clinic.Models
{
    public class AddSupplementViewModel
    {
        public List<CategoryWithSupplements> CategoriesWithSupplements { get; set; }
        public Supplement NewSupplement { get; set; }
    }

    public class CategoryWithSupplements
    {
        public string CategorieName { get; set; }
        public List<Supplement> Supplements { get; set; }
    }
}
