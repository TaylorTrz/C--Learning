using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 代理服务器
/// </summary>
/// key1：简单的贪心算法，但是一般是需要证明是否为最优解
/// key2：循环输入的判断
/// key3：tuple组元的使用，可以使用out,ref等关键字进行代替
namespace DaiLiFuWuQi
{
    class Program
    {

        public Tuple<string[], string[]> GetIP(string s)  // 获取输入参数
        {
            string[] Agency = new string[Convert.ToInt32(s)];
            for (int i = 0; i < Convert.ToInt32(s); i++)
            {
                Agency[i] = Console.ReadLine();
            }
            s = Console.ReadLine();
            string[] Host = new string[Convert.ToInt32(s)];
            for (int i = 0; i < Convert.ToInt32(s); i++)
            {
                Host[i] = Console.ReadLine();
            }

            Tuple<string[], string[]> tup = new Tuple<string[], string[]>(Agency, Host);
            return tup;
        }

        public int SelectIP(Tuple<string[], string[]> tup)  //选择最优代理IP
        {
            //贪心算法求最优：对于第step个步骤，第i个代理服务器能够访问最多的主服务器，依次进行访问。
            string[] Agency = tup.Item1;
            string[] Host = tup.Item2;
            int[] key = new int[Agency.Length]; //所有代理服务器访问主服务器数量
            int dis = 0;  //每步结束的访问位置
            int step = 0; //每步结束的最优代理服务器
            int sum = 0;  //代理服务器切换总次数

            //判断是否存在可行解，即当代理服务器的数量为1，且与主服务器之一重复
            if (Agency.Length == 1)
            {
                for (int k = 0; k < Host.Length; k++)
                {
                    if (Agency[0] == Host[k])
                    {
                        return -1;
                    }
                }
                return 0;
            }
            else
            {
                while (dis < Host.Length)  //访问完主服务器后停止
                {
                    int flag = -1; //保证第一步的正确性
                    int max = 0; //记录每步最优
                    for (int i = 0; i < Agency.Length; i++)
                    {
                        int j = 0;
                        //贪心记录
                        for (j = dis; j < Host.Length; j++)
                        {
                            if (Agency[i] == Host[j])
                            {
                                key[i] = j;
                                break;
                            }
                        }
                        if (j == Host.Length)  //完整访问所有服务器，直接返回
                            return sum;
                        //比较
                        if (key[i] > max)
                        {
                            max = key[i];
                            step = i;
                        }
                    }

                    if (step != flag)
                    { sum++; }
                    dis = max;
                    flag = step;
                }

                return sum - 1;
            }
        }


        static void Main(string[] args)
        {

            while (true)   //保证循环输入
                try
                {
                    string s = Console.ReadLine();
                    if (s.CompareTo("") == 0) { break; }

                    string[] Agency = { };
                    string[] Host = { };
                    Tuple<string[], string[]> tup = new Tuple<string[], string[]>(Agency, Host);
                    Program PG = new Program();
                    tup = PG.GetIP(s);
                    int key = PG.SelectIP(tup);  //my text;

                    Console.WriteLine(key);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    break;
                }

        }
    }
}
