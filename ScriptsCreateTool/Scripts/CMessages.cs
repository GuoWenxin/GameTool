using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameTools
{
    public class CMessages
    {
        public string ID="";
        public string name="";
        public string explain="";
        public CBean[] beans;
        public CMessage[] messages;
        /// <summary>
        /// 导入文件AS和Java使用
        /// </summary>
        public string import = "";

        public string beanSuper = "";
        public string handler = "";
    }

    public class CBean
    {
        public string name="";
        public string explain="";
        public CField[] fileds;
        public CList[] lists;
        public List<CMessgaeItem> items;
    }

    public class CMessage
    {
        public string ID="";
        public string msType="";
        public string name="";
        public string explain="";
        public CField[] fields;
        public CList[] lists;
        public List<CMessgaeItem> items;
    }

    public class  CMessgaeItem
    {
        public string classType = "";
        public string name = "";
        public string explain = "";
        /// <summary>
        /// false表示普通Field；true表示List
        /// </summary>
        public bool isList = false;
        /// <summary>
        /// 是否有前缀 如com.game.backpack.bean.ItemInfo
        /// false表示没有，TRUE表示有
        /// </summary>
        public bool isHavePrefix = false;

        public string realClassType = "";

        public  CMessgaeItem(XmlElement element)
        {
            if (element.Name== "field")
            {
            }
            else//element.Name="list"
            {
                isList =true;
            }
            name = element.GetAttribute("name");
            explain = element.GetAttribute("explain").Replace("\n", "").Replace("\r", "").Replace("\t", "");
            classType = element.GetAttribute("class");
            if (classType.Contains("."))
            {
                isHavePrefix = true;
                realClassType = classType.Substring(classType.LastIndexOf(".") + 1);
            }
            else
            {
                realClassType = classType;
            }
        }

    }
    public class CField
    {
        public string fieldType="";
        public string name="";
        public string explain="";
    }

    public class CList
    {
        public string listType = "";
        public string name = "";
        public string explain = "";
    }
    public class BeanVar
    {
        private string _name;
        public string explain { get; set; }

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                UpperName = Global.FirstCharToUpper(_name);
            }
        }
        public string className { get; set; }
        public string UpperName { get; set; }

        public BeanVar()
        {}
        public BeanVar(CField field)
        {
            explain = field.explain;
            name = field.name;
            className = field.fieldType;
        }

        public BeanVar(CList list)
        {
            explain = list.explain;
            name = list.name;
            className = list.listType;
        }
    }
    public class CMessageFieldAndList
    {
        private string _name;
        public string explain { get; set; }

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                UpperName = Global.FirstCharToUpper(_name);
            }
        }

        public string UpperName { get; set; }
        /// <summary>
        /// 0表示field,1表示list
        /// </summary>
        public string isList { get; set; }
        /// <summary>
        /// 0:不带前缀 如:Position，
        /// 1:带前缀如:com.game.structs.Position
        /// </summary>
        public string isPrefix { get; set; }
        public string className { get; set; }
        /// <summary>
        /// 前缀处理过后的类名
        /// </summary>
        public string classNameReal { get; set; }

        public CMessageFieldAndList (CMessgaeItem item)
        {
            if (item.isList)
            {
                isList = "1";
            }
            else
            {
                isList = "0";
            }
            name = item.name;
            explain = item.explain;
            if (item.isHavePrefix)
            {
                isPrefix = "1";
            }
            else
            {
                isPrefix = "0";
            }
            className = item.classType;
            classNameReal = item.realClassType;
        }
    }
}
