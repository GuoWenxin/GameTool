using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.Collections;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;
using NVelocity.Exception;
using NVelocity.Runtime;
using NVelocity.Tool;
using NVelocity.Util;
using System.IO;
using System.Windows.Forms;

namespace GameTools
{
    class CNVelociryHelp
    {
        public static Template GetTemplate(string tempPath)
        {
            //第一步：Creating a VelocityEngine也就是创建一个VelocityEngine的实例  
            VelocityEngine vltEngine = new VelocityEngine();
            ExtendedProperties vltProps = new ExtendedProperties();

            vltProps.AddProperty(RuntimeConstants.INPUT_ENCODING, "utf-8");
            vltProps.AddProperty(RuntimeConstants.OUTPUT_ENCODING, "utf-8");

            vltEngine.Init(vltProps);


            //第二步：Creating the Template加载模板文件 
            Template vltTemplate=new Template();
            try
            {
                vltTemplate = vltEngine.GetTemplate(tempPath);
            }
            catch (Exception e)
            {
                Debug.Log( e.Message );
                return null;
            }
            
            return vltTemplate;
        }

        public static void CreateFileByTemplate(string filePath, string templatePath, List<string> needReplace,
            ArrayList replace)
        {
            string dicPath = filePath.Substring(0, filePath.LastIndexOf(@"\"));
            if (!Directory.Exists(dicPath))
            {
                Directory.CreateDirectory(dicPath);
            }
            FileStream fs = new FileStream(filePath,
                        FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Template temp = GetTemplate(templatePath);
            if (temp!=null)
            {
                VelocityContext vltCtx = new VelocityContext();
                if (needReplace!=null && replace!=null && needReplace.Count>0&&replace.Count>0)
                {
                    for (int i = 0; i < needReplace.Count; i++)
                    {
                        vltCtx.Put(needReplace[i], replace[i]);
                    }
                }
                System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                temp.Merge(vltCtx, vltWriter);

                Console.WriteLine(vltWriter.ToString());

                sw.Write(vltWriter.ToString());
            }
            sw.Close();
            fs.Close();
        }
    }
}
