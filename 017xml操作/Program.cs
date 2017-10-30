using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _017xml操作
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Skill> skillList = new List<Skill>();
            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(File.ReadAllText("xml技能信息.txt")); //另一种方法，读入一个xml字符串
            xmlDoc.Load("xml技能信息1.txt"); // 读入xml文件,该文本文件应该为UTF-8编码的
            XmlNode rootNode = xmlDoc.FirstChild;   // 读入第一个节点（根节点）
            XmlNode skillListNode = rootNode.FirstChild;
            XmlNodeList skillNodeList = skillListNode.ChildNodes;   //读入技能节点列表
            foreach(XmlNode sn in skillNodeList)    //遍历技能节点列表
            {
                Skill s = new Skill();
                XmlElement nameEle = sn["Name"];    //通过名字获取子节点，XmlElement继承XmlNode
                s.Name = nameEle.InnerText;  // 获取节点内文本
                XmlAttributeCollection col =  sn.Attributes;    //获取该节点的属性集合
                s.SkillID = Int32.Parse(col["SkillID"].Value);  //获取属性的值
                s.SkillEngName = col["SkillEngName"].Value;
                s.TriggerType = Int32.Parse(col["TriggerType"].Value);
                s.AvailableRace = Int32.Parse(col["AvailableRace"].Value);
                skillList.Add(s);
            }
            foreach (var skill in skillList)
                Console.WriteLine(skill);
            Console.ReadKey();
        }
    }
}
