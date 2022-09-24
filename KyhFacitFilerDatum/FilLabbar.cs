using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace KyhFacitFilerDatum;

public class FilLabbar
{
    /*
     * Skapa en textfil och stoppa in några rader text

    Skriv nu ett program som läser alla rader och skriver ut VARANNAN rad till console
     */
    public void Lab1()
    {
        var odd = true;
        foreach (var row in File.ReadLines("InData.txt"))
        {
            if(odd)
                Console.WriteLine(row);
            odd = !odd;
        }
    }

    public void Lab2()
    {
        using (var file = File.CreateText("ResultLab2.txt"))
        {
            foreach (var row in File.ReadLines("Fil1.txt"))
                file.WriteLine(row);
            foreach (var row in File.ReadLines("Fil2.txt"))
                file.WriteLine(row);
        }
    }


    public void Lab3()
    {
        using (var file = File.CreateText("ResultLab3.txt"))
        {
            var index = 0;
            foreach (var row in File.ReadLines("Fil2.txt"))
            {
                file.WriteLine($"{index} {row}");
                index++;
            }
        }
    }


    public void Lab4()
    {
        var list = File.ReadAllLines("InData.txt").ToList();
        list.Sort();
        using (var file = File.CreateText("ResultLab4.txt"))
            foreach(var bird in list)
                file.WriteLine(bird);
    }

    public void Lab5()
    {
        while (true)
        {
            Console.WriteLine("a. Login");
            Console.WriteLine("b. Registrera nytt konto");
            Console.Write("Ange val:");
            var input = Console.ReadLine();
            if (input == "a")
               Login();
            else if (input == "b")
                Register();
        }
    }

    public void Register()
    {
        while (true)
        {
            Console.WriteLine("*** NEW REGISTRATION ***");
            Console.Write("Enter your username:");
            var username = Console.ReadLine();
            if (username.Length == 0)
            {
                Console.WriteLine("Ange ett username tack");
                continue;
            }

            if (UsernameExists(username))
            {
                Console.WriteLine("Användarnamnet finns redan");
                continue;
            }

            Console.Write("Enter your password:");
            var password = Console.ReadLine();
            if (password.Length == 0)
            {
                Console.WriteLine("Ange ett password tack");
                continue;
            }
            File.AppendAllLines("usernames.txt", new List<string> { username + "_" +  password } );
            break;
        }
    }


    public void Login()
    {
        Console.WriteLine("*** LOGIN ***");
        Console.Write("Enter your username:");
        var username = Console.ReadLine();
        Console.Write("Enter your password:");
        var password = Console.ReadLine();

        if (VerifyUserNameAndPassword(username, password))
            Console.WriteLine("Du är inloggad");
        else
            Console.WriteLine("Fel användarnamn eller lösenord");

    }

    public bool VerifyUserNameAndPassword(string username, string password)
    {
        if (!File.Exists("usernames.txt")) return false;
        foreach (var row in File.ReadLines("usernames.txt"))
        {
            var splitter = row.IndexOf('_');
            if (splitter != -1)
            {
                var un = row.Substring(0, splitter );
                var pwd = row.Substring(splitter + 1);
                if (un == username && pwd == password) return true;
            }
        }

        return false;

    }

    public bool UsernameExists(string username)
    {
        if (!File.Exists("usernames.txt")) return false;
        foreach (var row in File.ReadLines("usernames.txt"))
        {
            var splitter = row.IndexOf('_');
            if (splitter != -1)
            {
                var un= row.Substring(0,splitter);
                if (un == username) return true;
            }
        }

        return false;
    }




    public void Lab6()
    {
        Console.Write("Ange path->");
        var path = Console.ReadLine();
        Console.Write("Ange del av filnamn att söka efter->");
        var fileNamePart = Console.ReadLine();
        foreach (var filePath in Directory.GetFiles(path))
        {
            var fileName = Path.GetFileName(filePath);
            if (fileName.ToLower().Contains(fileNamePart.ToLower()))
            {
                var size = new FileInfo(filePath).Length;
                Console.WriteLine($"{fileName} - bytes = {size}");
            }
        }

        //Alternativ lösning
        foreach (var fileInfo in new DirectoryInfo(path).GetFiles())
        {
            if (fileInfo.Name.ToLower().Contains(fileNamePart.ToLower()))
                Console.WriteLine($"{fileInfo.Name} - bytes = {fileInfo.Length}");
        }

    }

    public void Lab7()
    {
        var allCars = new List<Car>();
        if (File.Exists("cars.txt"))
        {
            var json = File.ReadAllText("cars.txt");
            allCars = JsonConvert.DeserializeObject<List<Car>>(json);
        }
        

        while (true)
        {
            Console.WriteLine("1. Skapa ny bil");
            Console.WriteLine("2. Ta bort fil");
            Console.WriteLine("3. Exit");
            var input = Console.ReadLine();
            if (input == "1")
            {
                var car = CreateCar();
                allCars.Add(car);
            }
            if (input == "2")
            {
                RemoveCar(allCars);
            }
            if (input == "3")
            {
                var json = JsonConvert.SerializeObject(allCars);
                File.WriteAllText("cars.txt", json);
                break;
            }
        }
    }

    private void RemoveCar(List<Car> allCars)
    {
        var index = 0;
        foreach (var car in allCars)
        {
            index++;
            Console.WriteLine($"{index} {car.Name} {car.Price}");
        }
        Console.Write("Ange nummer på den du vill ta bort:");
        int sel = Convert.ToInt32(Console.ReadLine());
        allCars.RemoveAt(sel-1);
    }

    private Car CreateCar()
    {
        var car = new Car();
        Console.Write("Ange namn:");
        car.Name = Console.ReadLine();
        Console.Write("Ange modell:");
        car.Model= Console.ReadLine();
        Console.Write("Ange Year:");
        car.Year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ange Price:");
        car.Price = Convert.ToDecimal(Console.ReadLine());
        return car;

    }
}