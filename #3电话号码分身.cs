using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// #3 电话号码分身
/// </summary>

//思路
//"Z"ERO
//                                     ""O""NE
//T"W"O
//                                    TH""R""EE
//FO"U"R
//                                       ""F""IVE
//SI"X"
//                                     ""S""EVEN
//EI"G"HT
//                                        NINE

//第一次查找关键字：找到后删除相应字符，并记录关键字出现的次数
//第二次同样查找后记录并删除
//将所有数字出现次数放入数组中，输出字符串即可！

//1.String类与StringBuilder类的区别
//2.StringBuilder类的常用方法
    //可以预设置容量和长度、
    //常用方法s.Append("string")、s.AppendFormat()、s.Insert(int,string)、s.Remove(index,int)、s.Replace(string,string);

//3.String类的常用方法
    //string s = new string(char[] a) //将字符串数组转换为字符串
    //string s = new string(char r,int i) //生成i个字符r的字符串
    //Compare(s1,s2)与s1.CompareTo(s2)
    //Concat(s1,s2) //字符串连接
    //IsNullOrEmpty判断字符串是否为空
    //string.Join(s1,string[] s2);
    //s1.Contains(s2) //bool类型
    //s1.Equals(s2)   //bool类型
    //int = s1.IndexOf(s2)  int = s2.IndexOf(s3);
    //s1.Replace(s2,s3);
    //s1.Insert(Index,s2);
    //s1.Remove(Index,int);
    //char[] s = str.ToCharArray();
namespace DianHuaHaoMaFenShen
{
    public class MyFun
    {
        public string FindNumbers(string s)
        {
            int[] num = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };    //数据出现次数

            while (s.Contains("Z") || s.Contains("W") || s.Contains("U") || s.Contains("X") || s.Contains("G"))  //一次循环
            {
                if (s.Contains("Z"))
                {
                    num[2]++;
                    s = s.Remove(s.LastIndexOf("Z"), 1);
                    s = s.Remove(s.LastIndexOf("E"), 1);
                    s = s.Remove(s.LastIndexOf("R"), 1);
                    s = s.Remove(s.LastIndexOf("O"), 1);
                }
                if (s.Contains("W"))
                {
                    num[4]++;
                    s = s.Remove(s.LastIndexOf("T"), 1);
                    s = s.Remove(s.LastIndexOf("W"), 1);
                    s = s.Remove(s.LastIndexOf("O"), 1);
                }
                if (s.Contains("U"))
                {
                    num[6]++;
                    s = s.Remove(s.LastIndexOf("F"), 1);
                    s = s.Remove(s.LastIndexOf("O"), 1);
                    s = s.Remove(s.LastIndexOf("U"), 1);
                    s = s.Remove(s.LastIndexOf("R"), 1);
                }
                if (s.Contains("X"))
                {
                    num[8]++;
                    s = s.Remove(s.LastIndexOf("S"), 1);
                    s = s.Remove(s.LastIndexOf("I"), 1);
                    s = s.Remove(s.LastIndexOf("X"), 1);
                }
                if (s.Contains("G"))
                {
                    num[0]++;
                    s = s.Remove(s.LastIndexOf("E"), 1);
                    s = s.Remove(s.LastIndexOf("I"), 1);
                    s = s.Remove(s.LastIndexOf("G"), 1);
                    s = s.Remove(s.LastIndexOf("H"), 1);
                    s = s.Remove(s.LastIndexOf("T"), 1);
                }
            }

            while (s.Contains("O") || s.Contains("R") || s.Contains("F") || s.Contains("S")) //二次循环
            {
                if (s.Contains("O"))
                {
                    num[3]++;
                    s = s.Remove(s.LastIndexOf("O"), 1);
                    s = s.Remove(s.LastIndexOf("N"), 1);
                    s = s.Remove(s.LastIndexOf("E"), 1);
                }
                if (s.Contains("R"))
                {
                    num[5]++;
                    s = s.Remove(s.LastIndexOf("T"), 1);
                    s = s.Remove(s.LastIndexOf("H"), 1);
                    s = s.Remove(s.LastIndexOf("R"), 1);
                    s = s.Remove(s.LastIndexOf("E"), 1);
                    s = s.Remove(s.LastIndexOf("E"), 1);
                }
                if (s.Contains("F"))
                {
                    num[7]++;
                    s = s.Remove(s.LastIndexOf("F"), 1);
                    s = s.Remove(s.LastIndexOf("I"), 1);
                    s = s.Remove(s.LastIndexOf("V"), 1);
                    s = s.Remove(s.LastIndexOf("E"), 1);
                }
                if (s.Contains("S"))
                {
                    num[9]++;
                    s = s.Remove(s.LastIndexOf("S"), 1);
                    s = s.Remove(s.LastIndexOf("E"), 1);
                    s = s.Remove(s.LastIndexOf("V"), 1);
                    s = s.Remove(s.LastIndexOf("E"), 1);
                    s = s.Remove(s.LastIndexOf("N"), 1);
                }
            }

            while (s.Contains("E"))                          //三次循环
            {
                s = s.Remove(s.LastIndexOf("E"), 1);
                num[1]++;
            }

            StringBuilder ShunXu = new StringBuilder();
            for (int i = 0; i < num.Length; i++)           //累加得到电话号码
            {
                int j = num[i];
                while (j > 0)
                {
                    ShunXu.Append(Convert.ToString(i));
                    j--;
                }
            }

            string shunXu = Convert.ToString(ShunXu);
            return shunXu;

        }

        class Program
        {
            static void Main(string[] args)
            {
                int T = Convert.ToInt32(Console.ReadLine());
                string[] s = new string[T];
                for (int i = 0; i < T; i++)
                {
                    s[i] = Console.ReadLine();
                }

                MyFun my = new MyFun();
                for (int i = 0; i < T; i++)
                {
                    s[i] = my.FindNumbers(s[i]);                 //修改static，无法使用实例引用来访问成员
                    Console.WriteLine(s[i]);
                }

                Console.ReadKey();
            }

        }
    }
}
