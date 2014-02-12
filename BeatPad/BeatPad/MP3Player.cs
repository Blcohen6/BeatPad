using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Timers;

using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;

using System.Windows.Threading;

namespace BeatPad
{
  
    class MP3Player
    {
        private String filePath = "";
        private FileStream mp3FileStream = null;
        private Mp3FileReader mp3FileReader = null;
        private WaveStream waveStream = null;
        private BlockAlignReductionStream barStream = null;
        private WaveOut waveOut = null;
        private String playerStatus;
        private System.Timers.Timer tmr = null;
        private int waitTime = 50;

        public delegate void StatusChangeHandler(object sender, string status);
        public event StatusChangeHandler StatusChange;

        Dispatcher dispatcher;

        public MP3Player(Dispatcher dispatcher) 
        {
            this.dispatcher = dispatcher;
            changeStatus("waiting");
        }

        public String Status
        {
            get
            {
                return playerStatus;
            }
        }

        public String ID
        {
            get;
            set;
        }

        public void changeStatus(string status)
        {
            playerStatus = status;

            if (StatusChange != null)
            {
                Action statusChangeAction = () => { StatusChange(this, playerStatus); };
                dispatcher.BeginInvoke(statusChangeAction);
            }
        }

        public void Play(String filePath)
        {
            Stop(); // in case audio is playing

            this.filePath = filePath;

            try
            {
                changeStatus("starting");
                mp3FileStream = File.OpenRead(filePath);
                mp3FileReader = new Mp3FileReader(mp3FileStream);
                waveStream = WaveFormatConversionStream.CreatePcmStream(mp3FileReader);
                barStream = new BlockAlignReductionStream(waveStream);
            }
            catch (Exception e)
            {
                changeStatus("error");
                throw e;
            }

            InitPlay();
        }

        private void InitPlay()
        {
            if (Status != "starting")
            {
                return;
            }

            try
            {
                waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback());
                waveOut.Init(barStream);
                waveOut.Play();
                changeStatus("playing");
            }
            catch (Exception e)
            {
                changeStatus("error");
                throw e;
            }

            tmr = new System.Timers.Timer();
            tmr.Elapsed += new ElapsedEventHandler(CheckStatus);
            tmr.Interval = this.waitTime;
            tmr.Start();
        }

        private void CheckStatus(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (waveOut.PlaybackState == PlaybackState.Playing || waveOut.PlaybackState == PlaybackState.Paused) return;
            else
            {
                tmr.Stop();
                changeStatus("stopped");
            }
        }

        public void Stop()
        {
            if (Status == "playing" || Status == "paused")
            {
                waveOut.Stop();
                tmr.Stop();
                changeStatus("stopped");
            }
        }

        public void TogglePause()
        {
            if (Status == "playing")
            {
                waveOut.Pause();
                changeStatus("paused");
            }
            else if (Status == "paused")
            {
                waveOut.Resume();
                changeStatus("playing");
            }
        }

    }

    
}

 