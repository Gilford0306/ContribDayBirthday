using ContribDayBirthday;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
string ConnectionString = @"Data Source=DESKTOP-N6GODSK;" +
 "Initial catalog=BirhtDayBase;" +
 "Integrated Security=True;" +
 "Trusted_Connection = True;TrustServerCertificate = True;";
while (true)
{
    Console.WriteLine("Inoput 1 to Add record");
    Console.WriteLine("Inoput 2 to Deleting record");
    Console.WriteLine("Inoput 3 to Update record");


    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();

        List<Human> names = db.GetAll<Human>().ToList();

        foreach (Human name in names)
        {
            Console.WriteLine(name.Id + " " + name.FirstName + " " + name.LastName + " " + $"{name.Birthday.ToString("d")}");
        }
    }

    int f = int.Parse(Console.ReadLine());
    switch (f)
    {
        case 1:
            ADD();
            break;
        case 2:
            Del();
            break;
        case 3:
            Upd();
            break;
        default:
            break;
    }
    Console.Clear();
}


void ADD()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {


        db.Open();
        Console.WriteLine("Input name");
        string first = Console.ReadLine();
        Console.WriteLine("Input lastname");
        string second = Console.ReadLine();
        Console.Write("Enter a month: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Enter a day: ");
        int day = int.Parse(Console.ReadLine());
        Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());
        try
        {
            DateTime inputtedDate = new DateTime(year, month, day);
            Human human = new Human(first, second, inputtedDate);
            db.Insert<Human>(human);
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

    };
}
void Del()
{
    Console.Write("Enter id person to deliting ");
    int p = int.Parse(Console.ReadLine());
    try
    {
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            db.Delete<Human>(new Human { Id = p });
        }
    }
    catch (Exception ex) { Console.WriteLine(ex.Message); }

}

void Upd()
{
    try
    {
        using (IDbConnection db = new SqlConnection(ConnectionString))
        {
            db.Open();
            Console.WriteLine("Input name");
            string first = Console.ReadLine();
            Console.WriteLine("Input lastname");
            string second = Console.ReadLine();
            Console.Write("Enter a month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter id person to updating ");
            int p = int.Parse(Console.ReadLine());
            try
            {
                DateTime inputtedDate = new DateTime(year, month, day);
                Human human = new Human( p,first, second, inputtedDate);
                db.Update<Human>(human);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
    catch (Exception ex) { Console.WriteLine(ex.Message); }
}






