using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApplication2
{
    class Program
    {
        static List<Products> Product = new List<Products>();
        //static int current;
        static void Main()
        {
            bool flag = true;
            string Continue;
            while (flag)
            {
                LoadProducts();
                Console.Clear();
                //int current = 0;
                int index ;
                Console.WriteLine("Admin menu:");
                Console.WriteLine("1. Add data");
                //Console.WriteLine("2. Change data");
                Console.WriteLine("3. Delete data");
                //Console.WriteLine("4. Sort by name");
                //Console.WriteLine("5. Sort by price");
                //Console.WriteLine("6. Find by name of the product");
                //Console.WriteLine("7. Find by price");
                Console.WriteLine("8. Find product by id");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Your choose: ");
                Continue = Console.ReadLine();
                switch (Continue)
                {
                    case "1":
                        AddProduct();

                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Put the number of product: ");
                        index = Convert.ToInt32(Console.ReadLine());
                        DeleteProduct(index);
                        break;

                    case "8":
                        Console.Clear();
                        Console.Write("Put the number of product: ");
                        index = Convert.ToInt32(Console.ReadLine());
                        ViewProduct(index);
                        break;

                    case "0":

                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Wrong choose from the menu!");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }
                //Console.Write("dla prodoljenia nagmite y(Yes)/n(no): ");
                Continue = Console.ReadLine();
            }
        }
        public static void ViewProduct(int index)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Id: " + Product[index - 1].Number);
                Console.WriteLine("Name of product: " + Product[index - 1].Name_of_product);
                Console.WriteLine("Price: " + Product[index - 1].Price);
                Console.WriteLine("Category: " + Product[index - 1].Category);
                Console.WriteLine("Description: " + Product[index - 1].Description);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("error: " + ex.Message);
                Console.Write("nagmi lubue knopku...");
                Console.ReadKey();
            }
        }
        public static void AddProduct()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("dobavlenie novogo studenta v bd");
                Console.WriteLine(new string('=', 15));
                Products products = new Products();
                products.Number = Product.Count + 1;
                Console.Write("Name of product: ");
                products.Name_of_product = Console.ReadLine();
                Console.Write("Price: ");
                products.Price = Convert.ToInt32(Console.ReadLine());
                Console.Write("Category: ");
                products.Category = Console.ReadLine();
                Console.Write("Description: ");
                products.Description = Console.ReadLine();
                Product.Add(products);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("error: " + ex.Message);
                Console.ReadKey();
            }
            finally
            {
                SaveProducts();
            }
        }
        public static void DeleteProduct(int index)
        {
            try
            {
                Product.RemoveAt(index-1);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("error: " + ex.Message);
            }
            finally
            {
                SaveProducts();
            }
        }
        public static void SaveProducts()
        {
            try
            {
                var productsXml = new XmlSerializer(typeof(List<Products>), new XmlRootAttribute("Products"));
                using (var stream = new StringWriter())
                {
                    productsXml.Serialize(stream, Product);
                    if (File.Exists("products.xml"))
                        File.Delete("products.xml");
                    File.AppendAllText("products.xml", stream.ToString().Replace("utf-16","utf-8"));
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("error: " + ex.Message);
            }
        }
        public static void LoadProducts()
        {
            try
            {
                if (File.Exists("products.xml"))
                {
                    XDocument doc = XDocument.Load("products.xml");
                    foreach (var element in doc.Root.Elements())
                    {
                        Products product = new Products();
                        product.Number = Convert.ToInt32(element.Attribute("Id").Value);
                        product.Name_of_product = element.Attribute("Name of product").Value;
                        product.Category = element.Attribute("Category").Value;
                        product.Description = element.Attribute("Description").Value;
                        product.Price = Convert.ToInt32(element.Attribute("Price").Value);
                        Product.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("error: " + ex.ToString());
            }
        }
    }
}