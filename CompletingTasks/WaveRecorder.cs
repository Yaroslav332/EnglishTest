using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using System.IO;

namespace EnglishTest.CompletingTasks
{
    class WaveRecorder
    {
        public static string SavePath;

        Button Start;
        Button Stop;
        bool Preparation = true;
        Timer timer;
        Label lblTimer;
        int PreparationTime;
        int TaskTime;
        int CurrentTime;
        string TaskName;
        public WaveRecorder(Button Start, Button Stop, Timer timer, Label lblTimer, int PreparationTime, int TaskTime, string TaskName)
        {
            this.timer = timer;
            this.Start = Start;
            this.Stop = Stop;
            this.lblTimer = lblTimer;
            Start.Enabled = true;
            Stop.Enabled = false;
            this.TaskTime = TaskTime;
            this.PreparationTime = PreparationTime;
            this.TaskName = TaskName;

            timer.Tick += Timer_Tick;
            CurrentTime = PreparationTime;
            Start.Click += (s, e) =>
            {
                StartTask();
            };
            Stop.Click += (s, e) =>
            {
                StopTask();
            };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime -= 1;
            lblTimer.Text = (CurrentTime / 160).ToString() + ((CurrentTime / 60) % 10).ToString() + ":" + ((CurrentTime % 60) / 10).ToString() + (CurrentTime % 10).ToString();
            if (CurrentTime == 0)
            {
                if (Preparation) StartTask();
                else StopTask();
                
            }
        }

        WaveInEvent WaveIn;
        WaveFileWriter Writer;
        public void StartTask()
        {
            timer.Stop();
            timer.Start();
            Preparation = false;
            Start.Enabled = false;
            Stop.Enabled = true;
            CurrentTime = TaskTime;

            WaveIn = new WaveInEvent();
            Writer = new WaveFileWriter(Path.Combine(SavePath, TaskName), WaveIn.WaveFormat);
            WaveIn.DataAvailable += (s, a) =>
            {
                Writer.Write(a.Buffer, 0, a.BytesRecorded);
            };
            WaveIn.RecordingStopped += (s, a) =>
            {
                Writer.Close();
                Writer?.Dispose();
                WaveIn.Dispose();
                Uploading = Task.Run(() => DiscWriter.UploadFile(Path.Combine(SavePath, TaskName), TaskName));
                Task.WaitAll(Uploading);
                StartNextTask?.Invoke();
            };
            WaveIn.StartRecording();
        }
        public void StopTask()
        {
            WaveIn?.StopRecording();
        }

        public Action StartNextTask;
        public Task Uploading;
    }
}
