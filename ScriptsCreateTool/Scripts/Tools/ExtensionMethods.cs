using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTools
{
    static class ExtensionMethods
    {

        #region List

        public static bool IsNullOrCountZero<T>(this List<T> list_)
        {
            if (list_ == null || list_.Count == 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region string
        public static bool IsNullOrEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region long

        public static long BinaryUnitConvert(this long b, string unit)
        {
            switch (unit)
            {
                case "B":
                    return b;
                case "KB":
                    return (b/1024f).CeilToInt();
                case "MB":
                    return (b / (1024f*1024)).CeilToInt();
                case "GB":
                    return (b / (1024f * 1024*1024)).CeilToInt();
                case "TB":
                    return (b / (1024f * 1024 * 1024*1024)).CeilToInt();
                default:
                    return b;
            }
        }

        #endregion
        #region float
        public static int CeilToInt(this float value)
        {
            return (int)(value + 0.5f);
        }
        #endregion
    }
}
