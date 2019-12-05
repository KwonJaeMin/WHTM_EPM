using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLibrary.Global
{
    public static class CFunctionUtils
    {
        public static string MakeLength(string _value, int length)
        {
            string _str = "";

            for (int i = 0; i <= length; i++)
            {
                if (i > _value.Length)
                {
                    _str += " ";
                }
                else if (i < _value.Length)
                {
                    _str += _value[i];
                }
            }

            return _str;
        }
    }
}
