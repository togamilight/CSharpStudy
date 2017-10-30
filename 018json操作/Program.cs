using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;
using System.IO;

namespace _018json操作
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Equip> equipList = new List<Equip>();
            //需要引入litJson包
            //使用JsonMapper解析json
            JsonData jsonData1 = JsonMapper.ToObject(File.ReadAllText("json武器装备信息.txt"));
            //此时，jsonData1是一个数组
            foreach (JsonData jd in jsonData1)
            {
                Equip e = new Equip();
                //通过字符串索引器，由键找到值
                e.id = int.Parse(jd["id"].ToString());
                e.name = jd["name"].ToString();
                e.iconName = jd["iconName"].ToString();
                e.price = int.Parse(jd["price"].ToString());
                e.starLevel = int.Parse(jd["starLevel"].ToString());
                e.quality = int.Parse(jd["quality"].ToString());
                e.damage = int.Parse(jd["damage"].ToString());
                e.des = jd["des"].ToString();
                equipList.Add(e);
            }
            foreach (var e in equipList)
                Console.WriteLine(e);

            //使用泛型方式解析json
            Equip[] equips = JsonMapper.ToObject<Equip[]>(File.ReadAllText("json武器装备信息.txt"));
            //也可以解析成List
            //equipList = JsonMapper.ToObject<List<Equip>>(File.ReadAllText("json武器装备信息.txt"));
            foreach (var e in equipList)
                Console.WriteLine(e);

            //对象转为json
            string json = JsonMapper.ToJson(equips);
            Console.WriteLine(json);
            Console.ReadKey();
        }
    }
}
