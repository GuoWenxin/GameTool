using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameTools
{
    class PlayerPref
    {
        private static PlayerDatas data;
        private static XmlSerializer xmlser;
        private static Dictionary<string,string> dic=new Dictionary<string, string>(); 
        public static void Init()
        {
            xmlser = new XmlSerializer(typeof(PlayerDatas));
            if (File.Exists(@".\Config\PlayerSettingConfig.xml"))
            {
                StringReader reader = new StringReader(File.ReadAllText(@".\Config\PlayerSettingConfig.xml"));
                data = (PlayerDatas) xmlser.Deserialize(reader);
            }
            else
            {
                data=new PlayerDatas();
            }
            if (data.dtats!=null && data.dtats.Count>0)
            {
                foreach (var playerData in data.dtats)
                {
                    dic[playerData.name] = playerData.data;
                }
            }
        }

        public static string  GetData(string name,string defauleValue=null)
        {
            if (dic.ContainsKey(name))
            {
                return dic[name];
            }
            dic[name] = defauleValue;
            data.dtats.Add(new PlayerData() { name = name, data = defauleValue });
            return defauleValue;
        }

        public static void SetData(string key, string value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
                foreach (var playerData in data.dtats)
                {
                    if (playerData.name == key)
                    {
                        playerData.data = value;
                    }
                }
            }
            else
            {
                dic[key] = value;
                data.dtats.Add(new PlayerData() {name = key, data = value});
            }
            FileStream sw=new FileStream(@".\Config\PlayerSettingConfig.xml", FileMode.Create,FileAccess.Write);
            xmlser.Serialize(sw,data);
            sw.Close();
        }
    }

    [XmlRoot("Root")]
    public class PlayerDatas
    {
        [XmlArray("datas"),XmlArrayItem("data")]
         public  List<PlayerData> dtats=new List<PlayerData>();
    }
    [XmlRoot]
    public class PlayerData
    {
        [XmlAttribute("name")]
        public string name;
        [XmlText]
        public string data;
    }
}
