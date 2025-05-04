/*
 * 由SharpDevelop创建。
 * 用户： pc
 * 日期: 2025/4/27
 * 时间: 20:55
 * let's all love lain!
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ClassExtensions;

namespace KardsGen
{
	/// <summary>
	/// Window to clip image.
	/// </summary>
	public partial class ImageClip : Form
	{
		bool isDragging=false;
		Graphics canvas;
		Pen pen=new Pen(Color.Red);
		Point p0,p;
		Rectangle ctlRange,initRange;
		Rectangle imgRange;
		
		public delegate void RectSeter(Rectangle r);
		public event RectSeter SetRect;
		
		public ImageClip(Image img,Rectangle range)//=Rectangle.Empty)
		{
			InitializeComponent();
			ImageView.Image=img;
			canvas=ImageView.CreateGraphics();
			imgRange=range;
			initRange=FromImgToView(range);
			ctlRange=initRange;
   this.ImageView.Resize += new System.EventHandler(this.ImageViewResize);
		}
		
		Rectangle FromImgToView(Rectangle r)
		{
			return FromImgToBox(ImageView,r);
		}
		Rectangle FromViewToImg(Rectangle r)
		{
			return FromBoxToImg(ImageView,r);
		}
		public static Rectangle FromImgToBox(PictureBox pb,Rectangle r)
		{
			return r.ZoomFromTo(
				new Rectangle(
					new Point(0,0),
					pb.Image.Size
				),
				pb.ClientRectangle
			);
		}
		public static Rectangle FromBoxToImg(PictureBox pb,Rectangle r)
		{
			return r.ZoomFromTo(
				pb.ClientRectangle,
				new Rectangle(
					new Point(0,0),
					pb.Image.Size
				),
				true
			);
		}
		
		public static Image GetClipedImage(Image img,Rectangle range)
		{
			var bmp=new Bitmap(range.Width,range.Height);
			var g=Graphics.FromImage(bmp);
			g.DrawImage(img,0,0,range,GraphicsUnit.Pixel);
			//g.DrawImageUnscaled(img,range);
			g.Dispose();
			return bmp;
		}
		
		void ImageViewMouseDown(object sender, MouseEventArgs e)
		{
			isDragging=true;
			p0=e.Location;
		}
		
		void ImageViewMouseUp(object sender, MouseEventArgs e)
		{
			if(!isDragging)return;
			isDragging=false;
			initRange=ctlRange;
			imgRange=FromViewToImg(ctlRange);
			SetRect.Invoke(imgRange);
		}
		
		void ImageViewMouseMove(object sender, MouseEventArgs e)
		{
			if(!isDragging)return;
			//redraw rect to replace clear
			
			//canvas.FillRectangle(backStyle,clipedRange);
			p=e.Location;
			
			ctlRange.X=Math.Min(p.X,p0.X);
			ctlRange.Y=Math.Min(p.Y,p0.Y);
			
			ctlRange.Width=Math.Abs(p.X-p0.X);
			ctlRange.Height=Math.Abs(p.Y-p0.Y);
			
			
			if(ctlRange.Width==0)ctlRange.Width=1;
			if(ctlRange.Height==0)ctlRange.Height=1;
			((PictureBox)sender).Invalidate();
			
			//canvas.DrawRectangle(pen,ctlRange);
		}
		void ImageViewPaint(object sender, PaintEventArgs e)
		{
			if(ctlRange!=Rectangle.Empty)
			{
				e.Graphics.DrawRectangle(pen,ctlRange);
			}
		}
		
		void ImageViewResize(object sender, EventArgs e)
		{
			ctlRange=FromImgToView(imgRange);
			((Control)sender).Invalidate();
		}
		
		void ImageClipKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:goto case Keys.F12;
				case Keys.F12:
					if(ctlRange==Rectangle.Empty)this.Close();
					ctlRange=Rectangle.Empty;
					initRange=Rectangle.Empty;
					imgRange=Rectangle.Empty;
					ImageView.Invalidate();
					SetRect.Invoke(imgRange);
					break;
				case Keys.Escape:
					if(isDragging)
					{
						isDragging=false;
						ctlRange=initRange;
					}
					else this.Close();
					break;
			}
		}
	}
}
