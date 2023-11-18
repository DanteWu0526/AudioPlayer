namespace AudioPlayer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.volumeLabel = new System.Windows.Forms.Label();
            this.playPositionLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.volumeScrollBar = new System.Windows.Forms.HScrollBar();
            this.playPositionScrollBar = new System.Windows.Forms.HScrollBar();
            this.playerListBox = new System.Windows.Forms.ListBox();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.openListButton = new System.Windows.Forms.Button();
            this.WindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.playPauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.browseFileButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(12, 396);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(43, 16);
            this.volumeLabel.TabIndex = 4;
            this.volumeLabel.Text = "音量:";
            // 
            // playPositionLabel
            // 
            this.playPositionLabel.AutoSize = true;
            this.playPositionLabel.Location = new System.Drawing.Point(12, 429);
            this.playPositionLabel.Name = "playPositionLabel";
            this.playPositionLabel.Size = new System.Drawing.Size(75, 16);
            this.playPositionLabel.TabIndex = 5;
            this.playPositionLabel.Text = "播放位置:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // volumeScrollBar
            // 
            this.volumeScrollBar.Location = new System.Drawing.Point(157, 397);
            this.volumeScrollBar.Name = "volumeScrollBar";
            this.volumeScrollBar.Size = new System.Drawing.Size(391, 15);
            this.volumeScrollBar.TabIndex = 6;
            this.volumeScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.volumeScrollBar_Scroll);
            // 
            // playPositionScrollBar
            // 
            this.playPositionScrollBar.Location = new System.Drawing.Point(157, 430);
            this.playPositionScrollBar.Name = "playPositionScrollBar";
            this.playPositionScrollBar.Size = new System.Drawing.Size(391, 15);
            this.playPositionScrollBar.TabIndex = 7;
            this.playPositionScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.playPositionScrollBar_Scroll);
            // 
            // playerListBox
            // 
            this.playerListBox.FormattingEnabled = true;
            this.playerListBox.ItemHeight = 16;
            this.playerListBox.Location = new System.Drawing.Point(557, 12);
            this.playerListBox.Name = "playerListBox";
            this.playerListBox.Size = new System.Drawing.Size(203, 436);
            this.playerListBox.TabIndex = 9;
            this.playerListBox.SelectedIndexChanged += new System.EventHandler(this.playerListBox_SelectedIndexChanged);
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(187, 12);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(80, 40);
            this.prevButton.TabIndex = 10;
            this.prevButton.Text = "上一首";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(273, 12);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(80, 40);
            this.nextButton.TabIndex = 11;
            this.nextButton.Text = "下一首";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // openListButton
            // 
            this.openListButton.Location = new System.Drawing.Point(468, 12);
            this.openListButton.Name = "openListButton";
            this.openListButton.Size = new System.Drawing.Size(80, 40);
            this.openListButton.TabIndex = 12;
            this.openListButton.Text = "開啟清單";
            this.openListButton.UseVisualStyleBackColor = true;
            this.openListButton.Click += new System.EventHandler(this.openListButton_Click);
            // 
            // WindowsMediaPlayer
            // 
            this.WindowsMediaPlayer.Enabled = true;
            this.WindowsMediaPlayer.Location = new System.Drawing.Point(12, 58);
            this.WindowsMediaPlayer.Name = "WindowsMediaPlayer";
            this.WindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WindowsMediaPlayer.OcxState")));
            this.WindowsMediaPlayer.Size = new System.Drawing.Size(538, 314);
            this.WindowsMediaPlayer.TabIndex = 13;
            // 
            // playPauseButton
            // 
            this.playPauseButton.Location = new System.Drawing.Point(12, 12);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(80, 40);
            this.playPauseButton.TabIndex = 14;
            this.playPauseButton.Text = "播放";
            this.playPauseButton.UseVisualStyleBackColor = true;
            this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(98, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(80, 40);
            this.stopButton.TabIndex = 15;
            this.stopButton.Text = "停止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // browseFileButton
            // 
            this.browseFileButton.Location = new System.Drawing.Point(382, 12);
            this.browseFileButton.Name = "browseFileButton";
            this.browseFileButton.Size = new System.Drawing.Size(80, 40);
            this.browseFileButton.TabIndex = 16;
            this.browseFileButton.Text = "瀏覽檔案";
            this.browseFileButton.UseVisualStyleBackColor = true;
            this.browseFileButton.Click += new System.EventHandler(this.browseFileButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 589);
            this.Controls.Add(this.browseFileButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playPauseButton);
            this.Controls.Add(this.WindowsMediaPlayer);
            this.Controls.Add(this.openListButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.playerListBox);
            this.Controls.Add(this.playPositionScrollBar);
            this.Controls.Add(this.volumeScrollBar);
            this.Controls.Add(this.playPositionLabel);
            this.Controls.Add(this.volumeLabel);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "AudioPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Label playPositionLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.HScrollBar volumeScrollBar;
        private System.Windows.Forms.HScrollBar playPositionScrollBar;
        private System.Windows.Forms.ListBox playerListBox;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button openListButton;
        private AxWMPLib.AxWindowsMediaPlayer WindowsMediaPlayer;
        private System.Windows.Forms.Button playPauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button browseFileButton;
        private System.Windows.Forms.Timer timer1;
    }
}

