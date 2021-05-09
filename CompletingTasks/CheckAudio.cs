using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;

namespace EnglishTest.CompletingTasks
{
    public partial class CheckAudio : Form
    {
        public CheckAudio()
        {
            InitializeComponent();
        }

        private void CheckAudio_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnPlay;
            btnStop.Enabled = false;
            btnPlay.Enabled = false;
            btnStart.Enabled = true;
            RecordButtonEnabledChanged(btnStop,null);
            RecordButtonEnabledChanged(btnPlay, null);
            RecordButtonEnabledChanged(btnStart, null);
        }

        WaveInEvent WaveIn;
        WaveFileWriter Writer;
        WaveOutEvent Player;
        private void BtnStart_Click(object sender, EventArgs e)
        {
            Clear();
            WaveIn = new WaveInEvent();
            Writer = new WaveFileWriter(Path.Combine(WaveRecorder.SavePath, "Test.wav"), WaveIn.WaveFormat);
            WaveIn.StartRecording();

            WaveIn.DataAvailable += (s, a) =>
            {
                Writer.Write(a.Buffer, 0, a.BytesRecorded);
                if (Writer.Position > WaveIn.WaveFormat.AverageBytesPerSecond * 10)
                {
                    WaveIn.StopRecording();
                }
            };
            WaveIn.RecordingStopped += (s, a) =>
            {
                Writer.Close();
                Writer?.Dispose();
                Writer = null;
                btnStop.Enabled = false;
                btnStart.Enabled = true;
                btnPlay.Enabled = true;
                timer1.Stop();
            };

            btnStop.Enabled = true;
            btnStart.Enabled = false;
            btnPlay.Enabled = false;

            timer1.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            WaveIn.StopRecording();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            AudioFileReader audioFile = new AudioFileReader(Path.Combine(WaveRecorder.SavePath, "Test.wav"));
            Player = new WaveOutEvent();
            Player.Init(audioFile);
            Player.PlaybackStopped += (s, a) =>
            {
                Player.Dispose();
                Player = null;
                audioFile.Dispose();
                audioFile = null;
                btnPlay.Enabled = true;
                btnStart.Enabled = true;
                if (DeleteFile) DeleteTestFile();
            };
            Player.Play();
            btnStop.Enabled = false;
            btnStart.Enabled = false;
            btnPlay.Enabled = false;
        }

        private void CheckAudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StartForm.CloseApplicationAll || Continue)
            {
                Clear();
                return;
            }


            if (StartForm.CloseApplication())
            {
                Clear();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Clear()
        {
            WaveIn?.Dispose();
            Writer?.Close();
            Writer?.Dispose();
            DeleteFile = true;
            if (Player != null)
            {
                Player.Stop();
            }
        }
        private void DeleteTestFile()
        {
            if (File.Exists(Path.Combine(WaveRecorder.SavePath, "Test.wav")))
            {
                File.Delete(Path.Combine(WaveRecorder.SavePath, "Test.wav"));
                DeleteFile = false;
            }
        }

        private void RecordButtonEnabledChanged(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = ((Button)sender).Enabled ? Color.White : Color.Gray;
        }

        bool Continue = false;
        bool DeleteFile = true;
        private void BtnContinue_Click(object sender, EventArgs e)
        {
            new Reading().Show();
            Continue = true;
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int t = Writer.TotalTime.Seconds;
            if (Writer != null) lblTimer.Text = (t / 160).ToString() + ((t / 60) % 10).ToString() + ":" + ((t % 60) / 10).ToString() + (t % 10).ToString();
            else lblTimer.Text = "00:00";
        }

        private void TextBoxInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
