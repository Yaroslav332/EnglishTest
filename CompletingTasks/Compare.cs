using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishTest.CompletingTasks
{
    public partial class Compare : Form
    {
        public Compare()
        {
            InitializeComponent();
        }

        WaveRecorder recorder;
        private void Compare_Load(object sender, EventArgs e)
        {
            recorder = new WaveRecorder(btnStart, btnStop, timer1, lblTimer, 90, 120, "Compare.wav");
            recorder.StartNextTask = new Action(() => { Task_FormClosing(null, null); });
            textTask.Text = TaskVariant.ActiveTask.Task3Text;
            pictureBox1.Image = TaskVariant.ActiveTask.Task3Image_1;
            pictureBox2.Image = TaskVariant.ActiveTask.Task3Image_2;
        }

        private void RecordButtonEnabledChanged(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = ((Button)sender).Enabled ? Color.White : Color.Gray;
        }

        bool isClose = false;
        private void Task_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClose) return;
            isClose = true;
            recorder.StopTask();
            Application.Exit();
        }

        private void TextTask_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
