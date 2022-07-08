namespace DropIcons
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._openDiag = new System.Windows.Forms.OpenFileDialog();
            this.OFolder = new System.Windows.Forms.Label();
            this.OTiny = new System.Windows.Forms.Label();
            this.NoImages = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.Info = new System.Windows.Forms.PictureBox();
            this.Reload = new System.Windows.Forms.PictureBox();
            this.Img3 = new System.Windows.Forms.PictureBox();
            this.Img2 = new System.Windows.Forms.PictureBox();
            this.Img1 = new System.Windows.Forms.PictureBox();
            this.Loading = new AltoControls.ProcessingControl();
            this.SlideFolder = new AltoControls.SlideButton();
            this.SlideTiny = new AltoControls.SlideButton();
            this.Convert = new AltoControls.AltoButton();
            this.Decoration = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Decoration)).BeginInit();
            this.SuspendLayout();
            // 
            // _openDiag
            // 
            resources.ApplyResources(this._openDiag, "_openDiag");
            this._openDiag.Multiselect = true;
            this._openDiag.RestoreDirectory = true;
            // 
            // OFolder
            // 
            resources.ApplyResources(this.OFolder, "OFolder");
            this.OFolder.Name = "OFolder";
            // 
            // OTiny
            // 
            resources.ApplyResources(this.OTiny, "OTiny");
            this.OTiny.Name = "OTiny";
            // 
            // NoImages
            // 
            resources.ApplyResources(this.NoImages, "NoImages");
            this.NoImages.Cursor = System.Windows.Forms.Cursors.Default;
            this.NoImages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.NoImages.Name = "NoImages";
            this.NoImages.Click += new System.EventHandler(this.AddImages_Click);
            this.NoImages.MouseEnter += new System.EventHandler(this.NoImages_MouseEnter);
            this.NoImages.MouseLeave += new System.EventHandler(this.NoImages_MouseLeave);
            // 
            // Exit
            // 
            resources.ApplyResources(this.Exit, "Exit");
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Name = "Exit";
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Exit_MouseDown);
            this.Exit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Exit_MouseUp);
            // 
            // Info
            // 
            resources.ApplyResources(this.Info, "Info");
            this.Info.BackColor = System.Drawing.Color.Transparent;
            this.Info.Image = global::DropIcons.Properties.Resources.info_circle;
            this.Info.Name = "Info";
            this.Info.TabStop = false;
            this.Info.Click += new System.EventHandler(this.Info_Click);
            this.Info.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Info_MouseDown);
            this.Info.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Info_MouseUp);
            // 
            // Reload
            // 
            resources.ApplyResources(this.Reload, "Reload");
            this.Reload.BackColor = System.Drawing.Color.Transparent;
            this.Reload.Image = global::DropIcons.Properties.Resources.refresh_alt;
            this.Reload.Name = "Reload";
            this.Reload.TabStop = false;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            this.Reload.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Reload_MouseDown);
            this.Reload.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Reload_MouseUp);
            // 
            // Img3
            // 
            this.Img3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.Img3, "Img3");
            this.Img3.Name = "Img3";
            this.Img3.TabStop = false;
            // 
            // Img2
            // 
            this.Img2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.Img2, "Img2");
            this.Img2.Name = "Img2";
            this.Img2.TabStop = false;
            // 
            // Img1
            // 
            this.Img1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.Img1, "Img1");
            this.Img1.Name = "Img1";
            this.Img1.TabStop = false;
            // 
            // Loading
            // 
            this.Loading.BackColor = System.Drawing.Color.Transparent;
            this.Loading.IndexColor = System.Drawing.Color.LightGray;
            this.Loading.Interval = 100;
            resources.ApplyResources(this.Loading, "Loading");
            this.Loading.Name = "Loading";
            this.Loading.NCircle = 7;
            this.Loading.Others = System.Drawing.Color.LightGray;
            this.Loading.Radius = 3;
            this.Loading.Spin = true;
            // 
            // SlideFolder
            // 
            this.SlideFolder.BorderColor = System.Drawing.Color.GreenYellow;
            this.SlideFolder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SlideFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.SlideFolder.IsOn = true;
            resources.ApplyResources(this.SlideFolder, "SlideFolder");
            this.SlideFolder.Name = "SlideFolder";
            this.SlideFolder.TextEnabled = false;
            // 
            // SlideTiny
            // 
            this.SlideTiny.BorderColor = System.Drawing.Color.GreenYellow;
            this.SlideTiny.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SlideTiny.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.SlideTiny.IsOn = false;
            resources.ApplyResources(this.SlideTiny, "SlideTiny");
            this.SlideTiny.Name = "SlideTiny";
            this.SlideTiny.TextEnabled = false;
            // 
            // Convert
            // 
            this.Convert.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(141)))), ((int)(((byte)(255)))));
            this.Convert.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(141)))), ((int)(((byte)(255)))));
            this.Convert.BackColor = System.Drawing.Color.Transparent;
            this.Convert.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.Convert, "Convert");
            this.Convert.ForeColor = System.Drawing.Color.White;
            this.Convert.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Convert.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Convert.Name = "Convert";
            this.Convert.Radius = 4;
            this.Convert.Stroke = false;
            this.Convert.StrokeColor = System.Drawing.Color.Black;
            this.Convert.Transparency = false;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // Decoration
            // 
            this.Decoration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.Decoration, "Decoration");
            this.Decoration.Name = "Decoration";
            this.Decoration.TabStop = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::DropIcons.Properties.Resources.border;
            this.Controls.Add(this.Decoration);
            this.Controls.Add(this.Loading);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Reload);
            this.Controls.Add(this.OFolder);
            this.Controls.Add(this.SlideFolder);
            this.Controls.Add(this.OTiny);
            this.Controls.Add(this.SlideTiny);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.Img3);
            this.Controls.Add(this.NoImages);
            this.Controls.Add(this.Img2);
            this.Controls.Add(this.Img1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Decoration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog _openDiag;
        private AltoControls.ProcessingControl Loading;
        private System.Windows.Forms.PictureBox Exit;
        private System.Windows.Forms.PictureBox Info;
        private System.Windows.Forms.PictureBox Reload;
        private System.Windows.Forms.Label OFolder;
        private AltoControls.SlideButton SlideFolder;
        private System.Windows.Forms.Label OTiny;
        private AltoControls.SlideButton SlideTiny;
        private AltoControls.AltoButton Convert;
        private System.Windows.Forms.PictureBox Img3;
        private System.Windows.Forms.Label NoImages;
        private System.Windows.Forms.PictureBox Img2;
        private System.Windows.Forms.PictureBox Img1;
        private System.Windows.Forms.PictureBox Decoration;
    }
}

