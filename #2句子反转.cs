using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// #2 句子反转
/// </summary>

//1.Length与Count的区别
//简易理解：Length计算所有维度下的长度、Count统计一行的长度

//2.String与StringBuilder的区别
//基类分别是System.String、System.Text.StringBuilder
//string是引用类型，存储在堆上。构造不需要new。但是一旦初始化后，就是不可变的(长度、内容都是不变的)+"字符串留用机制"
//StringBuilder由Char数组组成，初始化时系统会自动分配容量，进行Append操作，可以创建新的数组容量翻倍。修改字符串操作时增加性能

//3.字符串大小比较函数 
//从两个字符串的第一个字符开始逐个比较(ASCII)，直到出现不同字符或'\0'
//Compare(s1,s2)=int  s1.CompareTo(s2)=int  int可以是-1、0、1

namespace JuZiFanZhuan
{
    public class Sort
    {
        public static StringBuilder SortMyStr(string mystr)
        {
            string[] str;
            StringBuilder newStr = new StringBuilder();

            //拆分
            str = mystr.Split(' ');

            //排序+拼接
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    newStr.Append(str[i] + ' ');
                }
                else
                {
                    newStr.Append(str[i]);
                }
            }

            return newStr;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            string mystr;
            string[] str;
            StringBuilder newStr = new StringBuilder();

            mystr = Console.ReadLine();

            Sort s = new Sort();
            newStr = Sort.SortMyStr(mystr);
            Console.WriteLine(newStr);

            Console.ReadKey();
        }
    }
}
