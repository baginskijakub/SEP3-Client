using System.Globalization;

namespace Domain.Models;

public class DateTime
{
    public long epoch { get; set; }
    private int year { get; set; }
    private int month { get; set; }
    private int day { get; set; }
    private int hour { get; set; }
    private int minute { get; set; }
    private int second { get; set; }

    public DateTime(int month, int day, int year, int hour, int minute, int second)
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }

    public DateTime(int month, int day, int year)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }

    public DateTime(long epoch)
    {
        this.epoch = epoch;
    }

    public string getTimeString()
    {
        string s = "";

        if (hour < 10)
        {
            s += "0";
        }

        s += hour;
        s += ":";
        if (minute < 10)
        {
            s += "0";
        }

        s += minute;

        return s + " ";

    }

    public string getDateString()
    {
        return month + "/" + day + "/" + year;
    }

    public string fullDateAndTimeString()
    {
        return getTimeString() + getDateString();
    }

    public string getFormattedString()
    {
        return null;
        
        //cannot compare this DateTime class to the DateTime class that is in C#
        //Therefore cannot compare those two dates. Only through the DateTime that is 
        //built in can you access various methods, such as "DayOfWeek", "Week number" etc.
        //This should be rethought on how to make, cuz I havent figured out a work around.
    }
}