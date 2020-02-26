using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace classTime_form
{
    class Time
    {
        sbyte sec;
        sbyte min;
        sbyte hour;

        public sbyte Sec
        {
            get => sec;
            set { sec = (sbyte)((value <= 59 && value >= 0) ? value : 0); }
        }
        public sbyte Min
        {
            get => min;
            set { min = (sbyte)((value <= 59 && value >= 0) ? value : 0); }
        }
        public sbyte Hour
        {
            get => hour;
            set { hour = (sbyte)((value <= 23 && value >= 0) ? value : 0); }
        }
        public Time() { }
        public Time(sbyte h, sbyte m, sbyte s)
        {
            Hour = h;
            Min = m;
            Sec = s;
        }
        public float ToHour() => hour + (min / 60.0f) + (sec / 3600.0f);

        public float ToMinute() => (hour * 60) + min + (sec / 60.0f);

        public float ToSecond() => (hour * 3600.0f) + (min * 60) + sec;

        public override string ToString() => $"{hour}:{min}:{sec}";

        public void Add_H(uint tmp)
        {
            long h = hour + tmp;

            if (h > 23)
                h = h % 24;

            hour = (sbyte)h;
        }
        public void Add_M(uint tmp)
        {
            long m = min + tmp;
            uint h = 0;

            if (m > 59)
            {
                m = m % 60;
                h++;
            }
            min = (sbyte)m;
            Add_H(h);
        }
        public void Add_S(uint tmp)
        {
            long s = sec + tmp;
            uint m = 0;
            while (s > 59)
            {
                s = s % 60;
                m++;
            }

            sec = (sbyte)s;
            Add_M(m);
        }

        public static Time operator +(Time t1, Time t2)
        {
            Time fun;
            int tmp;

            float temp, temp2;
            temp = t1.ToSecond();
            temp2 = t2.ToSecond();
            tmp = (int)(temp + temp2);
            fun = SecToTime(tmp);

            return fun;
        }
        public static Time operator -(Time t1, Time t2)
        {
            Time fun;
            int tmp;

            float temp, temp2;
            temp = t1.ToSecond();
            temp2 = t2.ToSecond();
            tmp = (int)(temp - temp2);
            fun = SecToTime(tmp);

            return fun;
        }
        public static Time SecToTime(int s)
        {
            Time b = new Time();
            b.hour = (sbyte)((s / 3600) % 24);
            b.min = (sbyte)((s % 3600) / 60);
            b.sec = (sbyte)(s % 60);

            return b;
        }
        public static bool operator ==(Time t1, Time t2) =>
          (t1.hour == t2.hour && t1.min == t2.min && t1.sec == t2.sec) ? true : false;
        public static bool operator !=(Time t1, Time t2) =>
           (!(t1 == t2)) ? true : false;
        public static bool operator >(Time t1, Time t2)
        {
            if (t1.hour > t2.hour) return true;
            if (t1.hour == t2.hour)
            {
                if (t1.min > t2.min) return true;
                if (t1.min == t2.min && t1.sec > t2.sec) return true;
            }
            return false;
        }
        public static bool operator <(Time t1, Time t2) =>
            (!(t1 > t2)) ? true : false;
        public static bool operator <=(Time t1, Time t2) =>
            (t1 == t2 || t1 < t2) ? true : false;
        public static bool operator >=(Time t1, Time t2) =>
           (t1 == t2 || t1 > t2) ? true : false;
        public Time(string number)
        {
            Regex regex = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
            if (!regex.IsMatch(number)) throw new Exception("Некорректные данные");
            for (int i = 1; i < number.Length; i++)
            {
                string[] s1 = number.Split(new char[] { ':', ':' },
                    StringSplitOptions.RemoveEmptyEntries);
                hour = (sbyte)Convert.ToSingle(s1[0]);
                min = (sbyte)Convert.ToSingle(s1[1]);
                sec = (sbyte)Convert.ToSingle(s1[2]);
                break;


            }
        }
    } 
}
