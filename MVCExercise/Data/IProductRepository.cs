using MVCExercise.Models;

namespace MVCExercise.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public Product GetProductById(int id);
    
    
}