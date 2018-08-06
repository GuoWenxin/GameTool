using UnityEngine;
using System.Collections;
using GameCore;

namespace ClientGame
{
    public class Q_find_npc: CReferenceManager<Q_find_npc>
    {
        public readonly static string FileName = @"reference/$Path.txt";

        /// <summary
        ///平台
        /// <summary>
        public string q_agents{ get; private set; }
        /// <summary
        ///区服
        /// <summary>
        public string q_zones{ get; private set; }
        /// <summary
        ///刷新次数
        /// <summary>
        public int q_activity_findtimes{ get; private set; }
        /// <summary
        ///当前NPC可完成次数
        /// <summary>
        public  q_task_times{ get; private set; }
        /// <summary
        ///NPC刷新坐标(地图_X_Y;地图_X_Y;..)
        /// <summary>
        public string q_npc_points{ get; private set; }
        /// <summary
        ///任务(ID；ID)
        /// <summary>
        public string q_task_id{ get; private set; }


        public override void ReadTxt(CArchiveRecord ar)
        {
            //base.ReadTxt(ar);
            q_agents=ReadText();
            q_zones=ReadText();
            q_activity_findtimes=ReadInt();
            q_npc_points=ReadText();
            q_task_id=ReadText();

        }
    }
}
