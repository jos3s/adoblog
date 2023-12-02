using adoblog;
using adoblog.Screens;
using Microsoft.Data.SqlClient;

public class Program
{
    public const string CONNECTION_STRING = @"Server=localhost, 1433;Database=baltaBlog;User Id=sa; Password=1q2w3e4r@#$; Trusted_Connection=False; TrustServerCertificate=True;";

    private static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(CONNECTION_STRING);

        Database.Connection.Open();
        MenuScreen.Load();
        Console.ReadKey();
        Database.Connection.Close();
    }
}