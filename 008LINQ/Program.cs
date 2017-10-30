using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化武林高手
            var masterList = new List<MartialArtsMaster>(){
    new MartialArtsMaster(){ Id = 1, Name = "黄蓉",    Age = 18, Menpai = "丐帮", Kungfu = "打狗棒法",  Level = 9  },
    new MartialArtsMaster(){ Id = 2, Name = "洪七公",  Age = 70, Menpai = "丐帮", Kungfu = "打狗棒法",  Level = 10 },
    new MartialArtsMaster(){ Id = 3, Name = "郭靖",    Age = 22, Menpai = "丐帮", Kungfu = "降龙十八掌",Level = 10 },
    new MartialArtsMaster(){ Id = 4, Name = "任我行",  Age = 50, Menpai = "明教", Kungfu = "葵花宝典",  Level = 1  },
    new MartialArtsMaster(){ Id = 5, Name = "东方不败",Age = 35, Menpai = "明教", Kungfu = "葵花宝典",  Level = 10 },
    new MartialArtsMaster(){ Id = 6, Name = "林平之",  Age = 23, Menpai = "华山", Kungfu = "葵花宝典",  Level = 7  },
    new MartialArtsMaster(){ Id = 7, Name = "岳不群",  Age = 50, Menpai = "华山", Kungfu = "葵花宝典",  Level = 8  },
    new MartialArtsMaster() { Id = 8, Name = "令狐冲", Age = 23, Menpai = "华山", Kungfu = "独孤九剑", Level = 10 },
new MartialArtsMaster() { Id = 9, Name = "梅超风", Age = 23, Menpai = "桃花岛", Kungfu = "九阴真经", Level = 8 },
new MartialArtsMaster() { Id =10, Name = "黄药师", Age = 23, Menpai = "梅花岛", Kungfu = "弹指神通", Level = 10 },
new MartialArtsMaster() { Id = 11, Name = "风清扬", Age = 23, Menpai = "华山", Kungfu = "独孤九剑", Level = 10 }
};
            //初始化武学
            var kungfuList = new List<Kungfu>(){
    new Kungfu(){KungfuId=1, KungfuName="打狗棒法", Power=90},
    new Kungfu(){KungfuId=2, KungfuName="降龙十八掌", Power=95},
    new Kungfu(){KungfuId=3, KungfuName="葵花宝典", Power=100},
    new Kungfu() { KungfuId=  4, KungfuName = "独孤九剑", Power = 100 },
    new Kungfu() { KungfuId = 5, KungfuName = "九阴真经", Power = 100 },
    new Kungfu() { KungfuId = 6, KungfuName = "弹指神通", Power = 100 }};

            //1.普通LINQ查询
            var result1 = from m in masterList where m.Age > 25 select m;
            foreach (var m in result1)
                Console.WriteLine(m);
            Console.WriteLine();

            //2.普通LINQ扩展方法查询
            var result2 = kungfuList.Where(k=>k.Power>=95);
            foreach (var k in result2)
                Console.WriteLine(k);
            Console.WriteLine();

            //3.LINQ联合查询
            var result3 = from m in masterList from k in kungfuList
                          where m.Kungfu == k.KungfuName && k.Power >= 100 select new { m, k }; 
            foreach (var r in result3)
                Console.WriteLine(r);

            Console.WriteLine();

            //4.LINQ扩展方法联合查询
            //SelectMany的两个参数都为委托，第一个需返回要联合查询的另一个集合，第二个返回联合后的集合
            var result4 = masterList.SelectMany(m=>kungfuList, (m, k)=>new { m, k })
                .Where(r=>r.m.Kungfu == r.k.KungfuName && r.k.Power >= 100);
            foreach (var r in result4)
                Console.WriteLine(r);
            Console.WriteLine();

            //5.LINQ查询结果排序
            var result5 = from m in masterList where m.Age > 25
                          orderby m.Age descending //倒序排列
                          select m;
            foreach (var m in result5)
                Console.WriteLine(m);
            Console.WriteLine();

            //6.LINQ扩展方法查询结果多重排序
            var result6 = masterList.Where(m=>m.Age>25).OrderBy(m=>m.Age).ThenByDescending(m=>m.Id);
            foreach (var m in result6)
                Console.WriteLine(m);
            Console.WriteLine();

            //7.join on 集合联合 equals左右侧应该对应join的左右侧，不能颠倒
            var result7 = from m in masterList
                          join k in kungfuList on m.Kungfu equals k.KungfuName
                          select new { m, k};
            foreach (var r in result7)
                Console.WriteLine(r);
            Console.WriteLine();

            //8.分组查询 into ..... (将武林高手按所学武功分类，统计每项武功修炼的人数)
            //按照 join左侧的集合为一方进行分组
            var result8 = from k in kungfuList
                          join m in masterList on k.KungfuName equals m.Kungfu
                          into groups
                          orderby groups.Count()
                          select new { kungfu = k, count = groups.Count()};
            foreach (var r in result8)
                Console.WriteLine(r);
            Console.WriteLine();

            //9.按照自身字段分组 group ... by ... into ...
            var result9 = from m in masterList
                          group m by m.Menpai into g
                          select new { count = g.Count(), key = g.Key};    //g.Key表示按照其分组的那个字段
            foreach (var r in result9)
                Console.WriteLine(r);
            Console.WriteLine();

            //10.量词操作符 all/any,判断集合是否满足某个条件
            bool res1 = masterList.Any(m => m.Menpai == "丐帮");
            Console.WriteLine("any丐帮:"+res1);
            bool res2 = masterList.All(m => m.Menpai == "丐帮");
            Console.WriteLine("all丐帮:" + res2);

            Console.ReadKey();
        }
    }
}
