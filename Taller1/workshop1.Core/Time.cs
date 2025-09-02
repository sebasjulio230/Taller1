namespace workshop1.Core;

public class Time
{
    //private fields
    private int _hours;
    private int _milliseconds;
    private int _minutes;
    private int _seconds;


    // Properties
    public int Hours
    {
        get => _hours;
        set
        {
            if (!ValidHour(value))
                throw new ArgumentException($"The hour: {value}, is not valid.");

            _hours = value;
        }
    }

    public int Milliseconds
    {
        get => _milliseconds;
        set
        {
            if (!ValidMillisecond(value))
                throw new ArgumentOutOfRangeException(nameof(value), " Milliseconds must be between 0 and 999.");
            _milliseconds = value;
        }
    }

    public int Minutes
    {
        get => _minutes;
        set
        {
            if (!ValidMinute(value))
                throw new ArgumentOutOfRangeException(nameof(value), "Minutes must be between 0 and 59.");
            _minutes = value;
        }
    }

    public int Seconds
    {
        get => _seconds;
        set
        {
            if (!ValidSecond(value))
                throw new ArgumentOutOfRangeException(nameof(value), "Seconds must be between 0 and 59.");
            _seconds = value;
        }
    }

    //method add
    public Time Add(Time other)
    {
        
        long totalMs = this.ToMilliseconds() + other.ToMilliseconds();

        int hr = (int)((totalMs / 3600000L) % 24);
        int min = (int)((totalMs / 60000L) % 60);
        int sec = (int)((totalMs / 1000L) % 60);
        int ms = (int)(totalMs % 1000);

        return new Time(hr, min, sec, ms);
    }
     

    //method isOtherDay
    public bool IsOtherDay(Time other)
    {
        long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
        return totalMs >= 24 * 3600000L;
    }

    // Constructors

    public Time()
    {
        Hours = 00; Minutes = 00; Seconds = 00; Milliseconds = 000;
    }

    public Time(int hour)
    {
        Hours = hour; Minutes = 0; Seconds = 0; Milliseconds = 0;
    }

    public Time(int hour, int minute)
    {
        Hours = hour; Minutes = minute; Seconds = 0; Milliseconds = 0;
    }

    public Time(int hour, int minute, int second)
    {
        Hours = hour; Minutes = minute; Seconds = second; Milliseconds = 0;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hours = hour; Minutes = minute; Seconds = second; Milliseconds = millisecond;
    }



    public long ToMilliseconds()
    {
        return (Hours * 3600000L) + (Minutes * 60000L) + (Seconds * 1000L) + Milliseconds;
    }

    public long ToMinutes()
    {
        return (Hours * 60L) + Minutes;
    }

    public long ToSeconds()
    {
        return (Hours * 3600L) + (Minutes * 60L) + Seconds;

    }

    public override string ToString()
    {
        DateTime dt = new DateTime(1, 1, 1, Hours, Minutes, Seconds, Milliseconds);
        return dt.ToString("hh:mm:ss.fff tt");
    }



    //validators
    public bool ValidHour(int h) => h >= 0 && h < 24;
    public bool ValidMinute(int m) => m >= 0 && m < 60;
    public bool ValidSecond(int s) => s >= 0 && s < 60;
    public bool ValidMillisecond(int ms) => ms >= 0 && ms < 1000;

}

