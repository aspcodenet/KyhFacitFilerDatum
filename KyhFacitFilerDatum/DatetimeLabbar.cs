using System.Globalization;

namespace KyhFacitFilerDatum;

public class DatetimeLabbar
{
    public void Lab1()
    {
        var nu = DateTime.Now;
        Console.WriteLine(nu.ToString("yyyy-MM-dd HH:mm:ss"));
        Console.WriteLine(nu.ToString("yyyy-MM-dd"));
     }

    public void Lab2()
    {
        var dt = DateTime.Now;

        Console.WriteLine($@"year = {dt.Year}                                                                      
month = {dt.Month}                                                                        
day = {dt.Day}                                                                         
hour = {dt.Hour}                                                                         
minute = {dt.Minute}                                                                      
second = {dt.Second}                                                                      
millisecond = {dt.Millisecond}   ");



        var monthName = "";
        switch (dt.Month)
        {
            case 1:
                monthName = "Januari";
                break;
            case 2:
                monthName = "Februari";
                break;
            case 3:
                monthName = "Mars";
                break;
            case 4:
                monthName = "April";
                break;
            case 5:
                monthName = "Maj";
                break;
            case 6:
                monthName = "Juni";
                break;
            case 7:
                monthName = "Juli";
                break;
            case 8:
                monthName = "Augusti";
                break;
            case 9:
                monthName = "September";
                break;
            case 10:
                monthName = "Oktober";
                break;
            case 11:
                monthName = "November";
                break;
            case 12:
                monthName = "December";
                break;
        }
        Console.WriteLine($"Månaden heter {monthName}");


        string veckoDagsString = dt.DayOfWeek.ToString();
        Console.WriteLine($"Dagens veckodag är {veckoDagsString}");
        string inSwedish = "";
        switch (dt.DayOfWeek)
        {
            case DayOfWeek.Monday:
                inSwedish = "Måndag";
                break;
            case DayOfWeek.Tuesday:
                inSwedish = "Tisdag";
                break;
            case DayOfWeek.Wednesday:
                inSwedish = "Onsdag";
                break;
            case DayOfWeek.Thursday:
                inSwedish = "Torsdag";
                break;
            case DayOfWeek.Friday:
                inSwedish = "Fredag";
                break;
            case DayOfWeek.Saturday:
                inSwedish = "Lördag";
                break;
            case DayOfWeek.Sunday:
                inSwedish = "Söndag";
                break;

        }
        Console.WriteLine($"Dagens veckodag på svenska är {inSwedish}");

    }


    public void Lab3()
    {
        var dt = DateTime.Now;
        string inSwedish = "";
        switch (dt.DayOfWeek)
        {
            case DayOfWeek.Monday:
                inSwedish = "Måndag";
                break;
            case DayOfWeek.Tuesday:
                inSwedish = "Tisdag";
                break;
            case DayOfWeek.Wednesday:
                inSwedish = "Onsdag";
                break;
            case DayOfWeek.Thursday:
                inSwedish = "Torsdag";
                break;
            case DayOfWeek.Friday:
                inSwedish = "Fredag";
                break;
            case DayOfWeek.Saturday:
                inSwedish = "Lördag";
                break;
            case DayOfWeek.Sunday:
                inSwedish = "Söndag";
                break;

        }

        var monthName = "";
        switch (dt.Month)
        {
            case 1:
                monthName = "Januari";
                break;
            case 2:
                monthName = "Februari";
                break;
            case 3:
                monthName = "Mars";
                break;
            case 4:
                monthName = "April";
                break;
            case 5:
                monthName = "Maj";
                break;
            case 6:
                monthName = "Juni";
                break;
            case 7:
                monthName = "Juli";
                break;
            case 8:
                monthName = "Augusti";
                break;
            case 9:
                monthName = "September";
                break;
            case 10:
                monthName = "Oktober";
                break;
            case 11:
                monthName = "November";
                break;
            case 12:
                monthName = "December";
                break;
        }


        Console.WriteLine($"Idag är det {inSwedish} {dt.Day} {monthName} {dt.Year}");

        //alt
        var sv = new CultureInfo("sv-SE");
        Console.WriteLine($"Idag är det {dt.ToString("dddd", sv)} {dt.Day} {dt.ToString("MMMM", sv)} {dt.Year}");
    }


    public void Lab4()
    {
        Console.Write("Mata in ett datum yyyy-MM-dd:");
        var dt = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        Console.WriteLine(dt.Year);
    }

    public void Lab5()
    {
        Console.Write("Mata in ett år:");
        var year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Mata in en månad(1-12):");
        var month= Convert.ToInt32(Console.ReadLine());

        var firstThisMonth = new DateTime(year, month, 1);
        var firstNextMonth = firstThisMonth.AddMonths(1);
        var lastThisMonth = firstNextMonth.AddDays(-1);
        Console.WriteLine(lastThisMonth.Day);


    }


    public void Lab6()
    {
        Console.Write("Mata in ett datum yyyy-MM-dd:");
        var dt = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        Console.Write("Mata in ett till datum yyyy-MM-dd:");
        var dt2 = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        var diff = dt - dt2;
        Console.WriteLine(diff.Days);
    }


    public void Lab7()
    {
        Console.Write("Mata in ett år:");
        var year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Mata in en månad(1-12):");
        var month = Convert.ToInt32(Console.ReadLine());
        Console.Write("Mata in en dag(1-31):");
        var day = Convert.ToInt32(Console.ReadLine());

        var datum = new DateTime(year, month, day);
        if(datum.Date == DateTime.Now.Date)
            Console.WriteLine("Detta är idag");
        else
            Console.WriteLine("Detta är inte idag");
    }






}