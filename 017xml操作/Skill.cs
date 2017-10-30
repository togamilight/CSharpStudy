using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017xml操作
{
    class Skill
    {
        public int SkillID { get; set; }
        public string Name { get; set; }
        public string SkillEngName { get; set; }
        public int TriggerType { get; set; }
        public int AvailableRace { get; set; }

        public override string ToString()
        {
            return "id:"+SkillID+" name:"+Name+" EngName:"+SkillEngName+" triggerType:" +TriggerType+ " availableRace:" +AvailableRace;
        }
    }
}
