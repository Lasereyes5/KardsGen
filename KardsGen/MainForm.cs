/*
 * 由SharpDevelop创建。
 * 用户： pc
 * 日期: 2025/3/30
 * 时间: 14:11
 * let's all love lain!
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ClassExtensions;

namespace KardsGen
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		CardGen gen=new CardGen();
		Pen pen=new Pen(Color.Red);
		Rectangle range=Rectangle.Empty;
		Rectangle showRange=Rectangle.Empty;
		bool isCliped=false;
		bool isClipping=false;
		void Init()
		{
			InitializeComponent();
			comboBoxNation.Items.AddRange(TextData.NationText);
			comboBoxType.Items.AddRange(TextData.TypeText);
			comboBoxRarity.Items.AddRange(TextData.RarityText);
			
			comboBoxNation.SelectedIndex=(int)Nation.None;
			comboBoxType.SelectedIndex=(int)Type.HQ;
			comboBoxRarity.SelectedIndex=(int)Rarity.Standard;
		}
		public MainForm(string path)
		{
			Init();
			if(!string.IsNullOrEmpty(path))
			{
				UpdatePic(path);
			}
			
		}
		
		void UpdatePreview()
		{
			pictureBoxPreview.Image=gen.Generate();
		}
		void UpdatePic(string picPath)
		{
			isCliped=false;
			if(pictureBoxImgView.Image!=null)pictureBoxImgView.Image=null;
			if(gen.pic!=null)gen.pic.Dispose();
			pictureBoxImgView.Image=ImageExt.CopyFromFile(picPath);
			//gen.pic=ImageExt.CopyFromImage(pictureBoxImgView.Image);
			if(range!=Rectangle.Empty)
			{
				isCliped=true;
				gen.pic=ImageClip.GetClipedImage(pictureBoxImgView.Image,range);
			}
			else gen.pic=pictureBoxImgView.Image;
			UpdatePreview();
			//pictureBoxPreview.Image=gen.Generate();
		}
		DialogResult OpenPic()
		{
			using (OpenFileDialog open = new OpenFileDialog())
			{
				/*
				ImageFormat
					.Bmp
					.Emf
					.Exif
					.Gif
					.Icon
					.Jpeg
					.Png
					.Tiff
					.Wmf
				*/
				open.Filter=
					"Portable NetWork Graphics (*.png)|*.png"+
					"|Joint Photographic Experts Group (*.jpg)|*.jpg"+
					"|Bitmap File (*.bmp)|*.bmp"+
					"|All Files (*.*)|*.*"
				;
				open.RestoreDirectory=true;
				var ret=open.ShowDialog();
				if(ret==DialogResult.OK)
				{
					UpdatePic(open.FileName);
				}
				else 
				{
					pictureBoxImgView.Image=null;
					if(gen.pic!=null)gen.pic.Dispose();
					gen.pic=null;
					UpdatePreview();
				}
				return ret;
			}
		}
		
		
		void MainFormDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;			//重要代码：表明是所有类型的数据，比如文件路径
			else
				e.Effect = DragDropEffects.None;
		}
		
		void MainFormDragDrop(object sender, DragEventArgs e)
		{
			string path = (
				(string[])e
				.Data
				.GetData(DataFormats.FileDrop)
			)[0];
			UpdatePic(path);
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			gen.Dispose();
			Material.Dispose();
		}
		
		void TextBoxDeploymentCostTextChanged(object sender, EventArgs e)
		{
			int temp=gen.depoymentCost;
			int.TryParse(((TextBox)sender).Text,out gen.depoymentCost);
			if(gen.depoymentCost!=temp)UpdatePreview();
		}
		
		void TextBoxOperationCostTextChanged(object sender, EventArgs e)
		{
			int temp=gen.operationCost;
			int.TryParse(((TextBox)sender).Text,out gen.operationCost);
			if(gen.operationCost!=temp)UpdatePreview();
		}
		
		void TextBoxAtteckTextChanged(object sender, EventArgs e)
		{
			int temp=gen.atteck,t;
			int.TryParse(((TextBox)sender).Text,out t);
			if(t==temp)return;
			gen.atteck=t;
			UpdatePreview();
		}
		
		void TextBoxdefenseTextChanged(object sender, EventArgs e)
		{
			int temp=gen.defense,t;
			int.TryParse(((TextBox)sender).Text,out t);
			if(t==temp)return;
			gen.defense=t;
			UpdatePreview();
		}
		
		
		
		void ComboBoxNationSelectedIndexChanged(object sender, EventArgs e)
		{
			gen.nation=(Nation)((ComboBox)sender).SelectedIndex;
			UpdatePreview();
		}
		
		void ComboBoxTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			gen.type=(Type)((ComboBox)sender).SelectedIndex;
			UpdatePreview();
		}
		
		void ComboBoxRaritySelectedIndexChanged(object sender, EventArgs e)
		{
			gen.rarity=(Rarity)((ComboBox)sender).SelectedIndex;
			UpdatePreview();
		}
		
		void PictureBoxPreviewClick(object sender, EventArgs e)
		{
			using(var save=new SaveFileDialog())
			{
				//Stream file;
				/*
				ImageFormat
					.Bmp
					.Emf
					.Exif
					.Gif
					.Icon
					.Jpeg
					.Png
					.Tiff
					.Wmf
				*/
				save.Filter=
					"Portable NetWork Graphics (*.png)|*.png"+
					"|Joint Photographic Experts Group (*.jpg)|*.jpg"+
					"|Bitmap File (*.bmp)|*.bmp"+
					"|All Files (*.*)|*.*"
				;
				save.RestoreDirectory=true;
				if(save.ShowDialog()==DialogResult.OK)
				{
					try
					{
						gen.resultBmp.SaveAutoFormat(save.FileName);
						MessageBox.Show("图片已保存!");
					}
					catch (ImageExt.UnsupportedImageFormat ex)
					{
						MessageBox.Show(ex.Message,"保存失败",MessageBoxButtons.OK,MessageBoxIcon.Error);
						//throw;
					}
				}
			}
		}
		
		void TextBoxNameTextChanged(object sender, EventArgs e)
		{
			gen.name=((TextBox)sender).Text;
			UpdatePreview();
		}
		
		void TextBoxDescriptionTextChanged(object sender, EventArgs e)
		{
			gen.description=((TextBox)sender).Text;
			UpdatePreview();
		}
		
		
		ImageClip ic;
		void PictureBoxImgViewClick(object sender, EventArgs e)
		{
			if(isClipping)
			{
				if(ic!=null)ic.Activate();
				return;
			}
			if(((MouseEventArgs)e).Button== MouseButtons.Left)
			{
				OpenPic();
			}
			else if(((MouseEventArgs)e).Button== MouseButtons.Right)
			{
				if(((PictureBox)sender).Image==null)
				{
					if(OpenPic()!=DialogResult.OK)return;
				}
				
				isClipping=true;
				ic=new ImageClip(((PictureBox)sender).Image,range);
				
				ic.Closed+=(csender,ce)=>{
					ic=null;
					isClipping=false;
				};
				ic.SetRect+=(r)=>{
					//clip range preview
					range=r;
					showRange=ImageClip.FromImgToBox(((PictureBox)sender),range);
					((Control)sender).Invalidate();
					//update pic
					var deimg=gen.pic;
					if(isCliped)if(deimg!=null)deimg.Dispose();
					if(r!=Rectangle.Empty)
					{
						gen.pic=ImageClip.GetClipedImage(((PictureBox)sender).Image,range);
						UpdatePreview();
						isCliped=true;
					}
					else
					{
						gen.pic=((PictureBox)sender).Image;
						UpdatePreview();
						isCliped=false;
					}
				};
				ic.Show();
				
			}
			
			
			
		}
		
		
		void PictureBoxImgViewPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(pen,showRange);
		}
	}
}
