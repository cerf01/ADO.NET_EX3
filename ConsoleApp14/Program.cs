using System.Data.SqlClient;

namespace ConsoleApp14
{
    internal class Program
    {
        public static string connectionStr => "Data Source=DESKTOP-BRQ9LQE\\SQLEXPRESS;Initial Catalog=StationeryComp;Integrated Security=True;Connect Timeout=30;";
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Connected!");
                string q = "";
                while (q != "e")
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Navigation:exit, ex1,  ex2, ex3,  ex4, ex5, ex6, ex7, ex8, ex9, ex10, ex11, ex12, ex13, ex14");
                    q = Console.ReadLine();
                    Console.WriteLine();
                    switch (q.ToLower())
                    {
                        default:
                            Console.WriteLine("wrong input!");
                            break;
                        case "exit":
                            {

                                q = "e";
                                connection.Close();
                                Console.WriteLine("goodbye!");
                                break;
                            }
                            break;
                        case "1":
                        case "ex1":
                            {
                                string query = "SELECT * FROM Products";
                                showQuerySelect(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "2":
                        case "ex2":
                            {
                                string query = "SELECT * FROM ProductTypes";
                                showQuerySelect(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "3":
                        case "ex3":
                            {
                                string query = "SELECT * FROM Managers";
                                showQuerySelect(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "4":
                        case "ex4":
                            {
                                string query = "SELECT * FROM Products WHERE [Count] = (SELECT MAX([Count]) FROM Products)";
                                showQuerySelect(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "5":
                        case "ex5":
                            {
                                string query = "SELECT * FROM Products WHERE Cost = (SELECT MIN(Cost) FROM Products)";
                                showQuerySelect(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "6":
                        case "ex6":
                            {
                                string query = "SELECT * FROM Products WHERE Cost = (SELECT MAX(Cost) FROM Products)";
                                showQuerySelect(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "7":
                        case "ex7":
                            {
                                Console.WriteLine("Enter products type");
                                string inputType = Console.ReadLine();
                                string query = $"SELECT Products.Name FROM Products,ProductTypes WHERE ProductTypes.Id = Products.TypeId AND LOWER(ProductTypes.Name) = '{inputType.ToLower()}'";
                                showQuerySelect(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "8":
                        case "ex8":
                            {
                                Console.WriteLine("Enter managers name");
                                string inputName = Console.ReadLine();
                                string query = $"SELECT Products.Name FROM Products, Offers, Managers WHERE Products.Id = Offers.SoldProductId AND LOWER(Managers.Name) = '{inputName.ToLower()}' AND Offers.ManagerId = Managers.Id ";
                                showQuerySelect(query, connection);
                                Console.ReadKey();
                            }
                            break;
                        case "9":
                        case "ex9":
                            {
                                Console.WriteLine("Enter buyers name: ");
                                string inputBuyerName = Console.ReadLine();
                                string query = $"SELECT Products.Name FROM Products, Offers WHERE Products.Id = Offers.SoldProductId AND LOWER(Offers.BuyerName) = '{inputBuyerName.ToLower()}' ";
                                showQuerySelect(query, connection);
                                Console.ReadKey();
                            }
                            break;
                      
                    }
                }

                Console.ReadKey();
            }
        }
        public static void showQuerySelect(string query, SqlConnection connctinon)
        {
            using (var cmd = new SqlCommand(query, connctinon))
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write(reader[i] + "    ");
                    Console.WriteLine();
                }
                reader.Close();
            }
        }

        public static int setLineDigit(string str)
        {
            string numLine = str;
            if (numLine.All(c => char.IsDigit(c)))
                return Convert.ToInt32(numLine);

            Console.WriteLine("is not a digit! try again");

            setLineDigit(Console.ReadLine());
            return 0;

        }
    }
}