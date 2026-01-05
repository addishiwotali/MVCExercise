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
        return _connection.Query<Product>("SELECT * FROM Products WHERE Id = @id", new { id }).FirstOrDefault();
    }
}