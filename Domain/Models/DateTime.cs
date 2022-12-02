using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Domain.Models;

public class DateTime
{
    public long Epoch { get; set; }
    private int Year { get; set; }
    private int Month { get; set; }
    private int Day { get; set; }
    private int Hour { get; set; }
    private int Minute { get; set; }
    private int Second { get; set; }

    public DateTime(int month, int day, int year, int hour, int minute, int second)
    {
        this.Year = year;
        this.Month = month;
        this.Day = day;
        this.Hour = hour;
        this.Minute = minute;
        this.Second = second;
        
        var dateTime = new System.DateTime(Year, Month, Day, Hour, Minute, Second, DateTimeKind.Utc);
        var dateWithOffset = new DateTimeOffset(dateTime).ToUniversalTime();
        Epoch = dateWithOffset.ToUnixTimeSeconds();
        
    }

    public DateTime(int month, int day, int year)
    {
        this.Year = year;
        this.Month = month;
        this.Day = day;
    }

    public DateTime()
    {
    }

    public DateTime(long epoch)
    {
        this.Epoch = epoch;
        Epoch2String(Epoch);

    }

    public string GetTimeString()
    {
        Epoch2String(Epoch);
        string s = "";

        if (Hour < 10)
        {
            s += "0";
        }

        s += Hour;
        s += ":";
        if (Minute < 10)
        {
            s += "0";
        }

        s += Minute;

        return s + " ";

    }

    public string GetDateString()
    {
        Epoch2String(Epoch);
        return Month + "/" + Day + "/" + Year;
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
    
    private  void Epoch2String(long epoch) {
        System.DateTime date = new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        Year = date.Year;
        Month = date.Month;
        Day = date.Day;
        Hour = date.Hour;
        Minute = date.Minute;
        Second = date.Second;
    }
}