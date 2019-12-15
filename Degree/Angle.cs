using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree
{
    public class Angle : IAngle
    {
        // TODO: Задокументировать!!!
        
        // TODO: Написать статические методы для вычисления синусов и косинусов  
        // TODO: Обработать отрицательный угол
        // TODO: Перегруженные операторы должны работать только с секундами        

        // Секунды
        private double _seconds;

        #region Оформление
        const char DegSimbol = '°';
        const char MinutesSimbol = '\'';
        const char SecSimbol = '\"';
        #endregion

        #region Свойства
        // Эти свойства позволяют обрабатывать цикличность. Т.е. 365° = 5°
        private int Degrees
        {
            get
            {
                return (int)(_seconds / 3600.0 % 360.0);
            }
        }

        private int Minutes
        {
            get
            {
                return (int)(_seconds / 60.0 % 60.0);
            }            
        }
        
        private double Seconds
        {
            get
            {
                return Math.Round(_seconds % (360.0 * 60 * 60) - Minutes * 60 - Degrees * 60 * 60, 5);
            }
        }
        // --- --- --- ---

        

        // Тригонометрия
        private double Rad
        {
            get
            {
                return (Degrees + Minutes / 60.0 + Seconds / 3600.0) * (Math.PI / 180);
            }
        }

        /// <summary>
        /// Синус угла
        /// </summary>
        public double Sin
        {
            get
            {
                return Math.Round(Math.Sin(Rad), 5);
            }
        }

        // TODO: Косинус 90° возвращает не ноль
        /// <summary>
        /// Косинус угла
        /// </summary>
        public double Cos
        {
            get
            {
                return Math.Round(Math.Cos(Rad), 5);
            }
        }
        #endregion

        #region Конструкторы
        public Angle(double Degrees, double Minutes, double Seconds)
        {
            _seconds = Seconds + Minutes * 60 + Degrees * 60 * 60;
        }

        public Angle() : this(0, 0, 0) { }
        public Angle(double Degrees) : this(Degrees, 0, 0) { }
        public Angle(double Degrees, double Minutes) : this(Degrees, Minutes, 0) { }
        public Angle(Angle obj) : this(obj.Degrees, obj.Minutes, obj.Seconds) { }
        #endregion

        #region Операторы
        public static Angle operator +(Angle FirstAngle, Angle SecondAngle)
        {
            Angle resultAngle = new Angle
            {
                _seconds = FirstAngle._seconds + SecondAngle._seconds
            };
            return resultAngle;
        }

        public static Angle operator -(Angle FirstAngle, Angle SecondAngle)
        {
            Angle resultAngle = new Angle
            {
                _seconds = FirstAngle._seconds - SecondAngle._seconds
            };

            return resultAngle;
        }

        #endregion

        #region Методы
        public override string ToString()
        {
            string result = Degrees.ToString() + DegSimbol;
            if(Minutes == 0)
            {
                return result;
            }
            else
            {
                result += Minutes.ToString() + MinutesSimbol;
            }
            if(Seconds == 0)
            {
                return result;
            }
            else
            {
                result += Seconds.ToString() + SecSimbol;
                return result;
            }
        }
        #endregion

    }
}
