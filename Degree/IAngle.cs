using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib
{
    public interface IAngle
    {
        /// <summary>
        /// Синус угла
        /// </summary>
        double Sin { get; }

        /// <summary>
        /// Косинус угла
        /// </summary>
        double Cos { get; }
    }
}
