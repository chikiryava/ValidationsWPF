using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract11.Extensions
{
    public static class IsbnExtension
    {
        public static bool IsIsbn10(this string input)
        {
            string[] part = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if(part.Length!=4)
                return false;
            for(int i = 0; i < part.Length; i++)
            {
                if(i==0 ||i == part.Length - 1)
                {
                    if (part[i].Length != 1 || !int.TryParse(part[i], out _))
                        return false;
                }
                else
                {
                    if (part[i].Length != 4 || !int.TryParse(part[i], out _))
                        return false;
                }
            }
            return true;
        }
    }
}
