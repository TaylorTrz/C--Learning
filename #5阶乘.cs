using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 注意各种整型类型，长度，存储范围
/// byte:    8位 0到255
/// short:  16位 -2^16到2^16-1
/// int:    32位 -2^32到2^32-1
/// uint:   32位 0到2^64-1
/// long:   64位 -2^64到2^64-1
/// </summary>

namespace JieCheng阶乘
{
    class Program
    {
        private Int64 Factorial(Int64 x)
        {
            if (x > 1)
            {
                x = x * Factorial(x - 1);
            }
            else
                x = 1;

            return x;
        }

        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int num = Convert.ToInt32(s);
            Int64[] X = new Int64[num];

            Program PG = new Program();
            for (int i = 0; i < num; i++)
            {
                s = Console.ReadLine();
                X[i] = Convert.ToInt64(s);
                X[i] = PG.Factorial(X[i]);
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(X[i].ToString());
            }
            Console.ReadKey();

        }
    }
}
