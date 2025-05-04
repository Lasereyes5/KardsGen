/*
 * 由SharpDevelop创建。
 * 用户： pc
 * 日期: 2025/4/27
 * 时间: 20:55
 * let's all love lain!
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace KardsGen
{
	partial class ImageClip
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.ImageView = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.ImageView)).BeginInit();
			this.SuspendLayout();
			// 
			// ImageView
			// 
			this.ImageView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImageView.Location = new System.Drawing.Point(0, 0);
			this.ImageView.Name = "ImageView";
			this.ImageView.Size = new System.Drawing.Size(284, 262);
			this.ImageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ImageView.TabIndex = 0;
			this.ImageView.TabStop = false;
			this.ImageView.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageViewPaint);
			this.ImageView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageViewMouseDown);
			this.ImageView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageViewMouseMove);
			this.ImageView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageViewMouseUp);
			//this.ImageView.Resize += new System.EventHandler(this.ImageViewResize);
			// 
			// ImageClip
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.ImageView);
			this.Name = "ImageClip";
			this.Text = "ImageClip";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageClipKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.ImageView)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.PictureBox ImageView;
	}
}
