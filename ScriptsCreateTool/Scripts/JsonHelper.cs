using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameTools;
using SimpleJSON;

namespace GameTools
{
    public class JsonHelper
    {
        private static JsonHelper _instance;

        public static JsonHelper Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance=new JsonHelper();
                }
                return _instance;
            }
        }

        public void SelectJsonFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string jsonPath = PlayerPref.GetData("JsonDecodePath");
            if (jsonPath != null)
            {
                fileDialog.FileName = jsonPath;
            }
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择Json文件路径";
            fileDialog.Filter = "Json文件 (*.json)|*.json|All文件 (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                PlayerPref.SetData("JsonDecodePath", fileDialog.FileName);
                JsonDecode(fileDialog.FileName);
            }
        }

        private void JsonDecode(string name)
        {
            StreamReader sr=new StreamReader(name);
            string text = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();
            JSONNode node=JSONNode.Parse(text);
            JsonDecodeNode(node);
        }

        private void JsonDecodeChild(JSONNode node)
        {
            if (node.Count>0)
            {
                for (int i = 0; i < node.Count; i++)
                {
                    JsonDecodeNode(node[i]);
                }
            }
        }

        private void JsonDecodeNode(JSONNode node)
        {
            if (node.Count>0)
            {
                JsonDecodeChild(node);
            }
            else
            {
                string temp = node.ToString();
                Debug.Log(temp);
            }
        }
    }
}
