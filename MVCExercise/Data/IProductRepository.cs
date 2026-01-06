using MVCExercise.Models;

namespace MVCExercise.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public Product GetProductById(int id);
    public void CreateProduct(Product product);
    public void UpdateProduct(Product product);
    public void InsertProduct(Product productToInsert);
    public IEnumerable<Category> GetCategories();
    public Product AssignCategory();
    public void DeleteProduct(Product product);
    
    
}