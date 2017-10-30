using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;   //正则表达式类
using System.Threading.Tasks;

namespace _004正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello World!";
            string res1 = Regex.Replace(s, "^", "start:");  //  ^  开头定位符
            Console.WriteLine(res1);

            string res2 = Regex.Replace(s, "$", "end");  //  $  结尾定位符
            Console.WriteLine(res2);

            string s1 = Console.ReadLine();
            string pattern1 = @"^\d*$";  //任意个数字组成的字符串
            bool isMatch = Regex.IsMatch(s1, pattern1);
            Console.WriteLine(isMatch);

            string s2 = "321abc___{}??_()__";
            string pattern2 = @"\d|[a-z]|_{2,3}"; //匹配单个数字、单个字母或者2到3个下划线
            MatchCollection matches = Regex.Matches(s2, pattern2);
            foreach (Match match in matches)
                Console.WriteLine(match);
            Console.ReadKey();
        }
    }
}
