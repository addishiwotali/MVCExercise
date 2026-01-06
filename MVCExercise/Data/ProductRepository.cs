using System.Data;
using MVCExercise.Models;
using Dapper;

namespace MVCExercise.Data;

public class ProductRepository: IProductRepository
{ 
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM Products");
    }

    public Product GetProductById(int id)
    {
        return _connection.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
    }

    public void CreateProduct(Product product)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new {name = product.Name, price = product.Price, id = product.ProductID });
    }
    
        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new {name = product.Name, price = product.Price, id = product.ProductID });
        }
    
}