using System.Globalization;
using System.Runtime.CompilerServices;

namespace Domain.Models;

public class DateTime
{
    public long Epoch { get; set; }
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

    public DateTime()
    {
    }

    public DateTime(long epoch)
    {
        this.Epoch = epoch;
        epoch2string(Epoch);

    }

    public string GetTimeString()
    {
        epoch2string(Epoch);
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

    public string GetDateString()
    {
        epoch2string(Epoch);
        return month + "/" + day + "/" + year;
    }

    public string FullDateAndTimeString()
    {
        return GetTimeString() + GetDateString();
    }

    public string GetFormattedString()
    {
        return null;
        
        //cannot compare this DateTime class to the DateTime class that is in C#
        //Therefore cannot compare those two dates. Only through the DateTime that is 
        //built in can you access various methods, such as "DayOfWeek", "Week number" etc.
        //This should be rethought on how to make, cuz I havent figured out a work around.
    }
    
    private  void epoch2string(long epoch) {
        System.DateTime date = new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        year = date.Year;
        month = date.Month;
        day = date.Day;
        hour = date.Hour;
        minute = date.Minute;
        second = date.Second;
    }
}