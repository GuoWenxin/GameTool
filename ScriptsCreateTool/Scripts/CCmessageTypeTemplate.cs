using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTools
{
    public class CCmessageTypeTemplate:CSingleton<CCmessageTypeTemplate>
    {
        List<string> strEnumList=new List<string>();
        List<string> strListenerList=new List<string>();
        List<string> strHanderList=new List<string>();
        List<string> strEndList=new List<string>();

        private FileStream fs;
        private StreamWriter sw;

        public void Init(FileStream filestream,StreamWriter writer)
        {
            strEnumList.Add("/**");
            strEnumList.Add(" * @author Commuication Auto Maker");
            strEnumList.Add(" *");
            strEnumList.Add(" * @version 1.0.0");
            strEnumList.Add(" * ");
            strEnumList.Add(" * 消息");
            strEnumList.Add(" */");
            strEnumList.Add("namespace ClientGame.RPC");
            strEnumList.Add("{");
            strEnumList.Add("public enum GameMessageType{");

            strListenerList.Add("}");
            strListenerList.Add("    public class MessagePool");
            strListenerList.Add("    {");
            strListenerList.Add("        public static void addListeners()");
            strListenerList.Add("        {");

            strHanderList.Add("        }");
            strHanderList.Add("        public static MessageHandler getHandlerByName(string handlerName)");
            strHanderList.Add("        {");
            strHanderList.Add("            switch (handlerName)");
            strHanderList.Add("            {");

            strEndList.Add("                default:");
            strEndList.Add("                    return null;");
            strEndList.Add("            }");
            strEndList.Add("        }");
            strEndList.Add("     }");
            strEndList.Add("}");

            fs = filestream;
            sw = writer;
        }

        public void Write(List<string> typeList, List<string> listenerList,List<string>handerList )
        {
            foreach (var stre in strEnumList)
            {
                sw.WriteLine(stre);
            }
            if (typeList != null && typeList.Count > 0)
            {
                foreach (var tl in typeList)
                {
                    sw.WriteLine(tl);
                }
            }
            foreach (var strl in strListenerList)
            {
                sw.WriteLine(strl);
            }
            if (listenerList != null && listenerList.Count > 0)
            {
                foreach (var list in listenerList)
                {
                    sw.WriteLine(list);
                }
            }
            foreach (var hanl in strHanderList)
            {
                sw.WriteLine(hanl);
            }
            if (handerList!=null && handerList.Count>0)
            {
                foreach (var hanl in handerList)
                {
                    sw.WriteLine(hanl);
                }
            }
            foreach (var endl in strEndList)
            {
                sw.WriteLine(endl);
            }
        }

        public void Close()
        {
            sw.Close();
            fs.Close();
        }
    }
}
