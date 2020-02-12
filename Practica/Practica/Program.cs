using System;
using System.IO;

namespace Practika
{
    class Program
    {
        static int _stateMenu;

        static void MainMenu()
        {
            Console.Write("Choose action : \n" +
                "(0) Exit from Program. \n" +
                "(1) Enter as admin. \n" +
                "(2) Enter as customer. \n" +
                "Your choose : ");
            _stateMenu = Convert.ToInt32(Console.ReadLine());
        }
        static void AdminMenu()
        {
            Console.Write("Choose action : \n" +
                "(0) Exit from Program. \n" +
                "(1) Input Data. \n" +
                "(2) Output Data. \n" +
                "(3) Data changes. \n" +
                "(4) Adding Data. \n" +
                "(5) Delete Data. \n" +
                "Your choose : ");
            _stateMenu = Convert.ToInt32(Console.ReadLine());
        }

        static void UserMenu()
        {
            Console.Write("Choose action : \n" +
                "(0) Exit from Program. \n" +
                "(1) Output Data. \n" +
                "Your choose : ");
            _stateMenu = Convert.ToInt32(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            MainMenu();
            while (_stateMenu != 0)
            {
                switch (_stateMenu)
                {
                    //вход как админ
                    case 1:
                        Console.Clear();
                        int _password;
                        Console.Write("Enter password: ");
                        _password = Convert.ToInt32(Console.ReadLine());
                        if (_password == 54321)
                        {
                            Console.Clear();
                            AdminMenu();
                            int _action;
                            bool isData = false;
                            int number_of_data = 0;

                            while (_stateMenu != 0)
                            {
                                switch (_stateMenu)
                                {
                                    case 1:
                                        Console.Clear();

                                        Console.Write("(1) Input manually. \n" +
                                            "(2) Read from the file. \n" +
                                            "Your choose : ");
                                        _action = Convert.ToInt32(Console.ReadLine());

                                        Console.Clear();

                                        if (_action == 1)
                                        {
                                            AddData(ref number_of_data);
                                            isData = true;
                                        }
                                        else
                                        {
                                            DataReading(ref number_of_data);
                                            isData = true;
                                        }

                                        Console.ReadLine();
                                        Console.Clear();

                                        break;

                                    case 2:
                                        Console.Clear();

                                        if (isData)
                                        {
                                            Console.Write("(1) Output in console. \n" +
                                            "(2) Record to the file. \n" +
                                            "Your choose : ");
                                            _action = Convert.ToInt32(Console.ReadLine());

                                            Console.Clear();

                                            if (_action == 1)
                                            {
                                                Print();
                                            }
                                            else
                                            {
                                                SavingData();
                                            }
                                        }
                                        else

                                            Console.WriteLine("Data is empty!");


                                        Console.ReadLine();
                                        Console.Clear();
                                        break;

                                    case 3:
                                        Console.Clear();

                                        if (isData)
                                        {
                                            DataChange(number_of_data);
                                        }
                                        else
                                            Console.WriteLine("Data is empty!");

                                        Console.ReadLine();
                                        Console.Clear();
                                        break;

                                    case 4:
                                        Console.Clear();

                                        if (isData)
                                        {
                                            AddData(ref number_of_data);
                                        }
                                        else
                                            Console.WriteLine("Data is empty!");

                                        Console.ReadLine();
                                        Console.Clear();
                                        break;

                                    case 5:
                                        Console.Clear();

                                        if (isData)
                                        {
                                            DeleteData(ref number_of_data);
                                        }
                                        else
                                            Console.WriteLine("Data is empty!");

                                        Console.ReadLine();
                                        Console.Clear();
                                        break;

                                    default:
                                        Console.WriteLine("Wrong choose from the menu!");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }

                                AdminMenu();
                            }

                            //delete file after exit from the program
                            FileInfo fileInf = new FileInfo("Buffer.txt");
                            if (fileInf.Exists)
                            {
                                fileInf.Delete();
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong password!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    //вход как пользователь
                    case 2:
                        Console.Clear();
                        UserMenu();
                        int _action_user;
                        bool isData_user = false;

                        while (_stateMenu != 0)
                        {
                            switch (_stateMenu)
                            {
                                case 1:
                                    Console.Clear();

                                    if (isData_user)
                                    {
                                        Console.Write("(1) Output in console. \n" +
                                        "(2) Record to the file. \n" +
                                        "Your choose : ");
                                        _action_user = Convert.ToInt32(Console.ReadLine());

                                        Console.Clear();

                                        if (_action_user == 1)
                                        {
                                            Print();
                                        }
                                        else
                                        {
                                            SavingData();
                                        }
                                    }
                                    else

                                        Console.WriteLine("Data is empty!");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("Wrong choose from the menu!");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }
                            UserMenu();
                        }

                        break;
                    default:
                        Console.WriteLine("Wrong choose from the menu!");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        static void AddData(ref int num_of_added)
        {
            string _productName;
            int _price;
            string _description;

            int _add = 1; //добавить или нет

            string fileName = "Buffer.txt";

            //поток, позволяет выполнить операции чтения/записи в файл. 
            FileStream fStream = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter record = new StreamWriter(fStream);

            do
            {
                //перемещаем указатель в файл
                fStream.Seek(0, SeekOrigin.End);

                //добавляем даннык, для записи в файл 
                Console.Write("Write name of product: ");
                _productName = Console.ReadLine();

                Console.Write("Write price of product: ");
                _price = Convert.ToInt32(Console.ReadLine());

                Console.Write("Write description of product: ");
                _description = Console.ReadLine();



                //добавить категории типо мягкая мебель, фурниткра и т.д.



                //записуем нужные данные
                record.WriteLine(_productName);
                record.WriteLine(_price);
                record.WriteLine(_description);

                num_of_added++;//добавили 1 элемент

                //спрашиваеи нужно ли еще добавить
                Console.Write("Added more?");
                _add = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (_add == 1);// пока нужно добавлять

            //закрываем файл
            record.Close();

            Console.WriteLine("Data is added!");
        }

        static void DataReading(ref int num_of_added)
        {
            num_of_added = 0;
            string fileName;
            Console.Write("Write name of the file: ");
            fileName = Console.ReadLine();

            Console.Clear();

            string _productName;
            int _price;
            string _description;
            int i = 0;

            using (StreamReader reading = new StreamReader(fileName))
            {
                using (StreamWriter record = new StreamWriter("Buffer.txt"))
                {

                    //считываем, пока есть, что считывать
                    while (!reading.EndOfStream)
                    {
                        if (i == 0)
                        {
                            _productName = reading.ReadLine();
                            record.WriteLine(_productName);
                            i++;
                        }
                        else if (i == 1)
                        {
                            _price = Convert.ToInt32(reading.ReadLine());
                            record.WriteLine(_price);
                            i++;
                        }
                        else if (i == 2)
                        {
                            _description = reading.ReadLine();
                            record.WriteLine(_description);
                            i = 0;

                            num_of_added++;//добавили элемент
                        }
                    }
                }
            }

            Console.WriteLine($"Datas : {num_of_added} were reading from file: {fileName}");
        }

        static void Print()
        {
            string _string;
            int i = 0;
            int num_of_data = 1;

            using (StreamReader reading = new StreamReader("Buffer.txt"))
            {
                while (!reading.EndOfStream)
                {
                    if (i == 0)
                    {
                        Console.WriteLine($"Data -  {num_of_data}");

                        _string = reading.ReadLine();//считываем из буфера
                        Console.WriteLine("Name of product: " + _string);//выводим в консоль
                        i++;
                    }
                    else if (i == 1)
                    {
                        _string = reading.ReadLine();
                        Console.WriteLine("Price: " + _string);
                        i++;
                    }
                    else if (i == 2)
                    {
                        _string = reading.ReadLine();
                        Console.WriteLine("Description: " + _string);
                        i = 0;
                        num_of_data++;

                        Console.WriteLine("*********************************");
                    }
                }
            }


        }

        static void SavingData()
        {
            string fileName;

            Console.WriteLine("Write name of the file: ");
            fileName = Console.ReadLine();

            Console.Clear();

            string _string;

            using (StreamReader reading = new StreamReader("Buffer.txt"))
            {
                using (StreamWriter record = new StreamWriter(fileName))
                {
                    while (!reading.EndOfStream)
                    {
                        _string = reading.ReadLine();//считываем строку
                        record.WriteLine(_string);//получаем нужные данные
                    }
                }
            }

            Console.WriteLine("Datas were save to the file: " + fileName);
        }

        static void DataChange(int number_of_data)
        {
            //копируем буферный файл
            FileInfo fileInf = new FileInfo("Buffer.txt");
            if (fileInf.Exists)
            {
                fileInf.CopyTo("Buffer_new.txt", true);
                //если скопировался, то выбираэм нужный элемент
                Console.Write($"Choose the right element (from 1 to{number_of_data}): ");
                int _n = Convert.ToInt32(Console.ReadLine());
                _n--;//так как вводим от 1

                Console.Clear();

                //проверка на правильность ввода
                if (_n >= 0 && _n < number_of_data)
                {
                    string _productName;
                    int _price;
                    string _description;
                    int i = 0, num_of_added = 0;

                    //считываем данный из нового буфера, кроме изменяемого, его вводим вручную
                    using (StreamReader reading = new StreamReader("Buffer_new.txt"))
                    {
                        using (StreamWriter record = new StreamWriter("Buffer.txt"))
                        {
                            while (!reading.EndOfStream)
                            {
                                //если нет, то что нужно изменить
                                if (_n != num_of_added)
                                {
                                    if (i == 0)
                                    {
                                        _productName = reading.ReadLine();//считываем строку
                                        record.WriteLine(_productName);//записываем нужный данные
                                        i++;
                                    }
                                    else if (i == 1)
                                    {
                                        _price = Convert.ToInt32(reading.ReadLine());
                                        record.WriteLine(_price);
                                        i++;
                                    }
                                    else if (i == 2)
                                    {
                                        _description = reading.ReadLine();
                                        record.WriteLine(_description);
                                        i = 0;

                                        num_of_added++;//добавили эдемент
                                    }
                                }
                                else
                                {
                                    //делаем шаг, чтобы пропустить не нужные данные
                                    _productName = reading.ReadLine();//считываем строку

                                    //добавляем данные для записи в файл
                                    if (i == 0)
                                    {
                                        Console.Write("Write name of product: ");
                                        _productName = Console.ReadLine();
                                        record.WriteLine(_productName);
                                        i++;
                                    }
                                    else if (i == 1)
                                    {
                                        Console.Write("Write price of the product: ");
                                        _price = Convert.ToInt32(Console.ReadLine());
                                        record.WriteLine(_price);
                                        i++;
                                    }
                                    else if (i == 2)
                                    {
                                        Console.Write("Write description of the product: ");
                                        _description = Console.ReadLine();
                                        record.WriteLine(_description);
                                        i = 0;

                                        num_of_added++;

                                        Console.Clear();
                                    }
                                }
                            }
                        }
                    }

                    Console.Clear();
                    Console.WriteLine($"These elements:{_n + 1} were change");
                }
                else
                    Console.WriteLine("The wrong number!");
                //удаляем новый буферный файл
                fileInf = new FileInfo("Buffer_new.txt");
                fileInf.Delete();
            }
            else
                Console.WriteLine("Error with opening the file!");
        }

        static void DeleteData(ref int number_of_data)
        {
            //copy the file
            FileInfo fileInf = new FileInfo("Buffer.txt");
            if (fileInf.Exists)
            {
                fileInf.CopyTo("Buffer_new.txt", true);
                //если скопировался, то выбираем нужный элeмeнт
                Console.Write($"Choose the right element (from 1 to{number_of_data}): ");
                int _n = Convert.ToInt32(Console.ReadLine());
                _n--;

                Console.Clear();

                if (_n >= 0 && _n < number_of_data)
                {
                    int i = 0, num_of_added = 0;
                    string _string;

                    //считываем данныe из нового буфера, кроме удаляемого, его пропустим
                    using (StreamReader reading = new StreamReader("Buffer_new.txt"))
                    {
                        using (StreamWriter record = new StreamWriter("Buffer.txt"))
                        {
                            while (!reading.EndOfStream)
                            {
                                //если нет, то что нужно изменить
                                if (_n != num_of_added)
                                {
                                    if (i == 0)
                                    {
                                        _string = reading.ReadLine();//считываем строку
                                        record.WriteLine(_string);//записываем нужные данные
                                        i++;
                                    }
                                    else if (i == 1)
                                    {
                                        _string = reading.ReadLine();
                                        record.WriteLine(_string);
                                        i++;
                                    }
                                    else if (i == 2)
                                    {
                                        _string = reading.ReadLine();
                                        record.WriteLine(_string);
                                        i = 0;

                                        num_of_added++;//добавили эдемент
                                    }
                                }
                                else
                                {
                                    //делаем шаг, чтобы пропустить не нужные данные
                                    _string = reading.ReadLine();//считываем строку

                                    //добавляем данные для записи в файл
                                    if (i == 0)
                                    {
                                        i++;
                                    }
                                    else if (i == 1)
                                    {
                                        i++;
                                    }
                                    else if (i == 2)
                                    {
                                        i = 0;
                                        num_of_added++;
                                    }
                                }
                            }
                        }

                    }

                    Console.WriteLine($"The lement:{_n + 1} was deleted!");
                    number_of_data--;//из общего кол. убераем 1
                }
                else
                    Console.WriteLine("The wrong number!");
                //удаляем новый буферный файл
                fileInf = new FileInfo("Buffer_new.txt");
                fileInf.Delete();
            }
            else
                Console.WriteLine("Error with opening the file!");
        }
    }
}
