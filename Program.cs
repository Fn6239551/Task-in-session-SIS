using Student_Information_System.Data;

namespace Student_Information_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SIS EF Core ready. Run migrations from Package Manager Console.");
            
            using var db = new SISContext();
            Console.WriteLine(db.Database.ProviderName);
        }
    }
}
