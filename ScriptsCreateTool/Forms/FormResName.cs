using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTools
{
    public partial class FormResName : Form
    {
        public event Action<string> EvenCapter;
        public FormResName()
        {
            InitializeComponent();
        }

        public void InitSetting(string name,bool isadd=true)
        {
            textBoxName.Text = name;
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (EvenCapter != null)
            {
                EvenCapter(textBoxName.Text);
                EvenCapter = null;
            }
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
