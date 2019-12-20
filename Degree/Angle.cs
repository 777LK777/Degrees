using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib
{
    public class Angle : IAngle, IEquatable<Angle>
    {
        // TODO: Задокументировать!!!

        // TODO: Написать статические методы для вычисления синусов и косинусов
        

        // Секунды
        private double _seconds;

        #region Константы
        //Оформление
        const char DEG_SYMB = '°';
        const char MIN_SYMB = '\'';
        const char SEC_SYMB = '\"';

        //Вычисления
        const int CNT_SEC_IN_MIN = 60;
        const int CNT_SEC_IN_DEG = 60 * 60;
        const int CNT_SEC_IN_CIRCLE = 360 * 60 * 60;

        const int CNT_MIN_IN_DEG = 60;

        const int CNT_DEG_IN_CIRCLE = 360;
        #endregion

        #region Свойства
        // Эти свойства позволяют обрабатывать цикличность. Т.е. 365° = 5°

        /// <summary>
        /// Возвращает количество целую часть угла в градусах
        /// </summary>
        public int Degrees
        {
            get
            {
                return (int)(_seconds / CNT_SEC_IN_DEG % CNT_DEG_IN_CIRCLE);
            }
        }

        /// <summary>
        /// Возвращает количество минут из дробной части
        /// </summary>
        public int Minutes
        {
            get
            {
                return (int)(_seconds / CNT_SEC_IN_MIN % CNT_MIN_IN_DEG);
            }            
        }

        /// <summary>
        /// Возвращает количество секунд из дробной части, с округлением до пяти знаков после запятой
        /// </summary>
        public double Seconds
        {
            get
            {
                return Math.Round(_seconds % CNT_SEC_IN_CIRCLE - Minutes * CNT_SEC_IN_MIN - Degrees * CNT_SEC_IN_DEG, 5);
            }
        }
        // --- --- --- ---



        // Тригонометрия
        /// <summary>
        /// Возвращает размер угла в радианах
        /// </summary>
        public double Rad
        {
            get
            {
                // 180 - HALF A CIRCLE
                return (Degrees + Minutes / CNT_MIN_IN_DEG + Seconds / CNT_SEC_IN_DEG) * (Math.PI / 180);
            }
        }

        /// <summary>
        /// Возвращает синус угла, с округлением до пяти знаков после запятой
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
        /// Возвращает косинус угла, с округлением до пяти знаков после запятой
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
            double temp = Seconds + Minutes * CNT_SEC_IN_MIN + Degrees * CNT_SEC_IN_DEG;
            if (temp >= 0) 
                _seconds = temp % CNT_SEC_IN_CIRCLE;
            else
                _seconds = CNT_SEC_IN_CIRCLE - Math.Abs(temp % CNT_SEC_IN_CIRCLE);
        }

        public Angle() : this(0, 0, 0) { }
        public Angle(double Degrees) : this(Degrees, 0, 0) { }
        public Angle(double Degrees, double Minutes) : this(Degrees, Minutes, 0) { }
        public Angle(Angle obj) : this(obj.Degrees, obj.Minutes, obj.Seconds) { }
        #endregion

        #region Операторы
        public static bool operator ==(Angle angle1, Angle angle2)
        {
            if (((object)angle1) == null || ((object)angle2) == null)
                return Object.Equals(angle1, angle2);

            return angle1.Equals(angle2);
        }

        public static bool operator !=(Angle angle1, Angle angle2)
        {
            if (((object)angle1) == null || ((object)angle2) == null)
                return !Object.Equals(angle1, angle2);

            return !(angle1.Equals(angle2));
        }

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
            StringBuilder result = new StringBuilder(Degrees.ToString() + DEG_SYMB);

            if (Seconds != 0)
            {
                return result.Append(Minutes.ToString() + MIN_SYMB + Seconds.ToString() + SEC_SYMB).ToString();
            }
            else if (Minutes != 0)
            {
                return result.Append(Minutes.ToString() + MIN_SYMB).ToString();
            }
            else
                return result.ToString();
        }
        #endregion

        #region IEquatable
        public bool Equals(Angle other)
        {
            if (other == null)
                return false;

            if (this._seconds == other._seconds)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Angle angleObj = obj as Angle;
            if (angleObj == null)
                return false;
            else
                return Equals(angleObj);
        }

        public override int GetHashCode()
        {
            return _seconds.GetHashCode();
        }
        #endregion
    }
}
