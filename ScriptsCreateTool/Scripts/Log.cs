using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTools
{
    public class Debug
    {
        public static List<LogMessage> _allInfoList=new List<LogMessage>();
        public static List<LogMessage> _whiteInfoList=new List<LogMessage>();
        public static List<LogMessage> _yellowInfoList=new List<LogMessage>();
        public static List<LogMessage> _redInfoList=new List<LogMessage>();
        public static List<LogMessage> _purpleInfoList=new List<LogMessage>();
        private static Color WHITE = Color.White;
        private static Color YELLOW = Color.Yellow;
        private static Color RED = Color.Red;
        private static Color PURPLE = Color.Purple;
        public static Queue<LogMessage> _showLogMessages=new Queue<LogMessage>();  
        public static void Log(object message,int level=1)
        {
            LogMessage lm=new LogMessage();
            lm.message = message;
            switch (level)
            {
                case 2:
                    lm.color = YELLOW;
                    _yellowInfoList.Add(lm);
                    break;
                case 3:
                    lm.color = RED;
                    _redInfoList.Add(lm);
                    break;
                case 4:
                    lm.color = PURPLE;
                    _purpleInfoList.Add(lm);
                    break;
                default:
                    lm.color = WHITE;
                    _whiteInfoList.Add(lm);
                    break;
            }
            _allInfoList.Add(lm);
            switch (FormMain.DebugType)
            {
                case 1:
                {
                    ShowLog(lm);
                }
                    break;
                case 2:
                    if (level==1)
                    {
                        ShowLog(lm);
                    }
                    break;
                case 3:
                    if (level == 2)
                    {
                        ShowLog(lm);
                    }
                    break;
                case 4:
                    if (level == 3)
                    {
                        ShowLog(lm);
                    }
                    break;
                case 5:
                    if (level == 4)
                    {
                        ShowLog(lm);
                    }
                    break;
            }
        }

        public static void ChangeLog(int type)
        {
            FormMain.LogText.Text = "";
            switch (type)
            {
                case 1:
                    ShowLog(_allInfoList);
                    break;
                case 2:
                    ShowLog(_whiteInfoList);
                    break;
                case 3:
                    ShowLog(_yellowInfoList);
                    break;
                case 4:
                    ShowLog(_redInfoList);
                    break;
                case 5:
                    ShowLog(_purpleInfoList);
                    break;
            }
        }

        private static void ShowLog(LogMessage msg_)
        {
            lock (_showLogMessages)
            {
                _showLogMessages.Enqueue(msg_);
            }
            /*lock (FormMain.LogText)
            {
                if (FormMain.LogText.InvokeRequired)
                {
                    Action<LogMessage> actionDelegate = (x) =>
                    {
                        int length1 = FormMain.LogText.TextLength;
                        FormMain.LogText.AppendText(x.message + "\r\n");
                        int length2 = FormMain.LogText.TextLength;
                        FormMain.LogText.Select(length1, length2);
                        FormMain.LogText.SelectionColor = x.color;
                    };
                    FormMain.LogText.Invoke(actionDelegate, msg_);
                }
                else
                {
                    int length1 = FormMain.LogText.TextLength;
                    FormMain.LogText.AppendText(msg_.message + "\r\n");
                    int length2 = FormMain.LogText.TextLength;
                    FormMain.LogText.Select(length1, length2);
                    FormMain.LogText.SelectionColor = msg_.color;
                }
            }*/
        }

        public static void Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (_showLogMessages)
            {
                if (_showLogMessages.Count>0)
                {
                    while (_showLogMessages.Count>0)
                    {
                        LogMessage lm = _showLogMessages.Dequeue();
                        int length1 = FormMain.LogText.TextLength;
                        FormMain.LogText.AppendText(lm.message + "\r\n");
                        int length2 = FormMain.LogText.TextLength;
                        FormMain.LogText.Select(length1, length2);
                        FormMain.LogText.SelectionColor = lm.color;
                    }
                }
            }
        }
        private static void ShowLog(List<LogMessage> msgList)
        {
            for (int i = 0; i < msgList.Count; i++)
            {
                ShowLog(msgList[i]);
            }
        }

        public static void Clearmessages()
        {
            _allInfoList.Clear();
            _whiteInfoList.Clear();
            _yellowInfoList.Clear();
            _redInfoList.Clear();
            _purpleInfoList.Clear();
            FormMain.LogText.Text = "";
        }
    }

    public class LogMessage
    {
        public Color color;
        public object message;

        public LogMessage(object msg_, Color color_)
        {
            message = msg_;
            color = color_;
        }
        public LogMessage()
        {
        }
    }
}
