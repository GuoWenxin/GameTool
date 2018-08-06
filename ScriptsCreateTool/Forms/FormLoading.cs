using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTools.Forms
{
    public partial class FormLoading : Form
    {
        private bool IsPause = true;
        private Thread thread;
        private static FormLoading _instance;

        public static FormLoading Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance=new FormLoading();
                }
                return _instance;
            }
        }
        public FormLoading()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public void Start()
        {
            IsPause = false;
            this.ShowDialog();
            labelProgress.Text =  "0%";
            thread = new Thread(ChangeProgress);
            thread.Start();
        }

        public void Stop()
        {
            IsPause = true;
            thread.Abort();
            this.Hide();
        }
        /// <summary>
        /// 显示进度
        /// </summary>
        /// <param name="progerss">进度值(0--100)</param>
        public void SetProgerss(float progerss)
        {
            labelProgress.Text = progerss + "%";
        }
        private void ChangeProgress()
        {
            int index = 1;
            string text = "";
            while (!IsPause)
            {
                text = "";
                for (int i = 1; i < index; i++)
                {
                    text += ".";
                }
                labelcontrol.Text = text;
                Thread.Sleep(200);
            }
        }
    }
}
