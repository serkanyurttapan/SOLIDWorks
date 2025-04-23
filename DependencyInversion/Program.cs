// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
MongoConnection connection = new MongoConnection();
SqlConnection sqlConnection = new SqlConnection();
UserService service = new UserService(connection);
UserService service2 = new UserService(sqlConnection);
public interface IDatabase
{
    void ConnectDB();
}

public class SqlConnection : IDatabase
{
    // sql connection
    public void ConnectDB()
    {
        Console.WriteLine("sql con");
    }
}

public class MongoConnection : IDatabase
{
    public void ConnectDB()
    {
        Console.WriteLine("mongo con");
    }
}

public class UserService
{
    private readonly IDatabase _database;

    public UserService(IDatabase database)
    {
        _database = database;
        _database.ConnectDB();
    }
}

/*
 * Dependency Inversion Principle (DIP):
 *
 * Yüksek seviye sınıflar, düşük seviye sınıflara değil, soyutlamalara (interfacelere) bağlı olmalıdır. Soyutlamalar, somut sınıflardan bağımsız olmalıdır.
 * `PaymentService` sınıfı, ödeme işleme mekanizmasına bağımlı değil. Yalnızca `IPaymentProcessor` arayüzüne bağımlıdır.
 */