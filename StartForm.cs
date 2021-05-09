using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishTest
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void BtnDo_Click(object sender, EventArgs e)
        {
            TaskVariant v = new TaskVariant();
            v.Task1Text = "... You don’t see many bir\r\nds in \n" +
                "winter.Most have left your area.T" +
                "hose that stay are not as active.";
            v.Task2Text = "You are considering visiting the city and now you'd like to get more information. In 1.5 minutes you are to ask five direct questions to find out the following:";
            v.Task2Image = Image.FromFile(@"C:\Users\Home\Downloads\06700.jpg");
            v.Task3Image_1 = Image.FromFile(@"C:\Users\Home\Downloads\y_0bLpZbdSU.jpg");
            v.Task3Image_2 = Image.FromFile(@"C:\Users\Home\Downloads\2w9v46.jpg");
            v.Task3Text = "Study the two photographs. In 1.5 minutes be ready to compare and contrast the photographs:";
            TaskVariant.ActiveTask = v;
            Form c = new CompletingTasks.EnterName();
            c.Owner = this;
            c.ShowDialog();            
        }

        #region DoNotTouchMyTrash

        public static bool CloseApplicationAll = false;
        public static bool CloseApplication()
        {
            var result = MessageBox.Show("Вы действительно хотите закончить?", "Внимание",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);
            if (result == DialogResult.Yes) CloseApplicationAll = true;
            return result == DialogResult.Yes;
        }

        #endregion
    }
}
