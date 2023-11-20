using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WMPLib;
using System.Runtime.InteropServices;
using System.IO;
using AxWMPLib;

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
            WindowsMediaPlayer.settings.volume = 50;
        }

        #region 資料選擇及清單區塊
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
        #endregion

        #region 撥放邏輯區塊
        /// <summary>
        /// 撥放邏輯
        /// </summary>
        private void PlaySelectedSong()
        {

            if (playList.Count > 0)
            {
                IWMPMedia mediaInfo;
                WindowsMediaPlayer.URL = playList[currentPlay];
                mediaInfo = WindowsMediaPlayer.newMedia(WindowsMediaPlayer.URL);

                volumeScrollBar.Value = WindowsMediaPlayer.settings.volume;
                volumeLabel.Text = "音量: " + volumeScrollBar.Value;

                playPositionScrollBar.Value = (int)WindowsMediaPlayer.Ctlcontrols.currentPosition;
                playPositionScrollBar.Maximum = (int)mediaInfo.duration;

                this.Text = "AudioPlayer";
                string str = mediaInfo.name;
                this.Text += "目前播放 " + str;
                playerListBox.SelectedIndex = currentPlay;
                WindowsMediaPlayer.PlayStateChange += AutoPlayNext;
                WindowsMediaPlayer.Ctlcontrols.play();
            }
        }

        /// <summary>
        /// 使用UI優先判斷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoPlayNext(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                this.BeginInvoke(new Action(() => PlayNext()));
            }
        }
        #endregion

        #region 撥放控制區塊
        /// <summary>
        /// 播放上一個
        /// </summary>
        private void PlayPrevious()
        {
            try
            {
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
        #endregion

        #region WinForm各項控制區塊
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

        private void WindowsMediaPlayer_OpenStateChange(object sender, _WMPOCXEvents_OpenStateChangeEvent e)
        {
            int w, h;
            if (e.newState == (int)WMPLib.WMPOpenState.wmposMediaOpen)
            {
                w = WindowsMediaPlayer.currentMedia.imageSourceWidth;
                h = WindowsMediaPlayer.currentMedia.imageSourceHeight;
                this.Text += ", " + w.ToString() + "x " + h.ToString();
            }
        }
        #endregion

    }
}
