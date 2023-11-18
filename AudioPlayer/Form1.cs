using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Media;
using AxWMPLib;
using System.Diagnostics;

namespace AudioPlayer
{
    public partial class Form1 : Form
    {
        enum ProcessDPIAwareness
        {
            DPIUnaware = 0, SystemDPIAware = 1, MonitorDPIAware = 2
        }
        [DllImport("shcore.dll")]
        static extern int SetProcessDpiAwareness(ProcessDPIAwareness v);

        private List<string> playList;
        private int currentPlay;
        public Form1()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDpiAwareness(ProcessDPIAwareness.MonitorDPIAware);
            }
            InitializeComponent();
            playList = new List<string>();
            currentPlay = 0;
            WindowsMediaPlayer.uiMode = "none";
            playerListBox.Visible = false;

        }

        /// <summary>
        /// 更新播放清單
        /// </summary>
        private void UpdatePlayListBox()
        {
            playerListBox.Items.Clear();
            foreach (string song in playList)
            {
                playerListBox.Items.Add(Path.GetFileName(song));
            }
        }

        /// <summary>
        /// 資料選擇功能
        /// </summary>
        private void OpenFile()
        {
            openFileDialog.Title = "選擇影片或音訊檔";
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "音訊檔案|*.mp3;*.wmv;*.wav;*.mp4|所有檔案|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                playList.AddRange(openFileDialog.FileNames);
                UpdatePlayListBox();
            }
            else
            {
                return;
            }
            playPauseButton.Text = "播放";
        }

        private void PlaySelectedSong()
        {

            if (playList.Count > 0)
            {
                IWMPMedia mediaInfo;
                WindowsMediaPlayer.URL = playList[currentPlay];
                mediaInfo = WindowsMediaPlayer.newMedia(WindowsMediaPlayer.URL);

                volumeScrollBar.Value = WindowsMediaPlayer.settings.volume;
                playPositionScrollBar.Value = (int)WindowsMediaPlayer.Ctlcontrols.currentPosition;
                playPositionScrollBar.Maximum = (int)mediaInfo.duration;


                string str = mediaInfo.name;
                this.Text = "目前播放 " + str;
                playerListBox.SelectedIndex = currentPlay;
                //WindowsMediaPlayer.PlayStateChange -= AutoPlayNext;
                WindowsMediaPlayer.PlayStateChange += AutoPlayNext;
                WindowsMediaPlayer.Ctlcontrols.play();
            }
        }

        private void AutoPlayNext(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                this.BeginInvoke(new Action(() => PlayNext()));
            }
        }

        /// <summary>
        /// 當前無撥放
        /// </summary>
        private void MedaiNull()
        {
            if (WindowsMediaPlayer.currentMedia == null)
            {
                return;
            }
        }

        /// <summary>
        /// 播放上一個
        /// </summary>
        private void PlayPrevious()
        {
            try
            {
                //MedaiNull();
                currentPlay = (currentPlay - 1 + playList.Count) % playList.Count;
                PlaySelectedSong();
            }
            catch
            {
                if (currentPlay == playList.Count)
                {
                    MessageBox.Show("無上一首，請增加");
                }
            }
        }

        /// <summary>
        /// 播放下一個
        /// </summary>
        private void PlayNext()
        {
            currentPlay = (currentPlay + 1) % playList.Count;
            PlaySelectedSong();

            /*try
            {
                MedaiNull();
                currentPlay = (currentPlay + 1) % playList.Count;
                PlaySelectedSong();
            }
            catch
            {
                if (currentPlay == playList.Count)
                {
                    MessageBox.Show("無下一首，請增加");
                }
            }*/
        }

        /// <summary>
        /// 停止撥放
        /// </summary>
        private void PlayStop()
        {
            WindowsMediaPlayer.Ctlcontrols.stop();
            playPauseButton.Text = "播放";
        }

        /// <summary>
        /// 音量控制
        /// </summary>
        private void SoundCtl()
        {
            WindowsMediaPlayer.settings.volume = volumeScrollBar.Value;
            volumeLabel.Text = "音量: " + WindowsMediaPlayer.settings.volume;
        }

        /// <summary>
        /// 撥放位置控制
        /// </summary>
        private void PlayPositionCtl()
        {
            WindowsMediaPlayer.Ctlcontrols.pause();
            WindowsMediaPlayer.Ctlcontrols.currentPosition = playPositionScrollBar.Value;
            WindowsMediaPlayer.Ctlcontrols.play();
            playPositionScrollBar.Value = (int)WindowsMediaPlayer.Ctlcontrols.currentPosition;
            playPositionLabel.Text = "撥放位置: " + WindowsMediaPlayer.Ctlcontrols.currentPositionString;
        }

        private void openListButton_Click(object sender, EventArgs e)
        {
            if (openListButton.Text == "開啟清單")
            {
                playerListBox.Visible = true;
                openListButton.Text = "隱藏清單";
            }
            else
            {
                playerListBox.Visible = false;
                openListButton.Text = "開啟清單";
            }
        }

        private void browseFileButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (playList.Count  == 0)
            {
                MessageBox.Show("播放清單空白，請增加");
                OpenFile();
            }

            if (playPauseButton.Text == "播放")
            {
                if (playList.Count > 0)
                {
                    PlaySelectedSong();
                    playPauseButton.Text = "暫停";
                }
            }
            else
            {
                playPauseButton.Text = "播放";
                WindowsMediaPlayer.Ctlcontrols.pause();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            PlayStop();
        }

        private void playerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPlay = (int)playerListBox.SelectedIndex;
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            PlayPrevious();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            PlayNext();
        }

        private void volumeScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            SoundCtl();
        }

        private void playPositionScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            PlayPositionCtl();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            playPositionLabel.Text = "撥放位置: " + WindowsMediaPlayer.Ctlcontrols.currentPositionString;
            playPositionScrollBar.Value = (int)WindowsMediaPlayer.Ctlcontrols.currentPosition;
        }


        /*private void axWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            int w, h;
            if (e.newState == (int)WMPLib.WMPOpenState.wmposMediaOpen)
            {
                w = axWindowsMediaPlayer1.currentMedia.imageSourceWidth;
                h = axWindowsMediaPlayer1.currentMedia.imageSourceHeight;
                this.Text += ", " + w.ToString() + "x " + h.ToString();
            }
        }*/

    }
}
