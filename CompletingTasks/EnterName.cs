using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EnglishTest.CompletingTasks
{
    public partial class EnterName : Form
    {
        public EnterName()
        {
            InitializeComponent();
        }
        string SavePath = Path.Combine(Application.StartupPath, "Audio");
        private void EnterName_Load(object sender, EventArgs e)
        {

        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="" && txtLastName.Text!="" && txtClass.Text!="")
            {
                foreach (var i in Path.GetInvalidFileNameChars())
                {
                    if (txtName.Text.Contains(i))
                    {
                        MessageBox.Show("Неверные значения!");
                        return;
                    }
                }
                string path1 = Path.Combine(txtClass.Text, txtName.Text + " " + txtLastName.Text);
                string path2 = "/Audio/" + txtClass.Text + "/" + txtName.Text + " " + txtLastName.Text;
                if (Task.Run(() => DiscWriter.CheckUserPassed(path2)).Result)
                {
                    MessageBox.Show("Пользователь уже проходил тест");
                    return;
                }
                WaveRecorder.SavePath = Path.Combine(SavePath, path1);
                DiscWriter.SavePath += "/" + txtClass.Text;
                DiscWriter.SavePath += "/" + txtName.Text + " " + txtLastName.Text;
                if (!Directory.Exists(WaveRecorder.SavePath)) Directory.CreateDirectory(WaveRecorder.SavePath);
                new CheckAudio().Show();
                this.Close();
                Owner.Hide();
            }
        }

        private void TextName_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
