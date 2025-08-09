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
			EnableDragDrop(pictureBoxPreview,(s)=>UpdateCard(s));
			EnableDragDrop(pictureBoxImgView,(s)=>UpdatePic(s));
			EnableDragDrop(pictureBoxNationView,(s)=>UpdateNation(s));
			EnableDragDrop(pictureBoxSetView,(s)=>UpdateSet(s));
			pictureBoxNationView.BackColor=gen.nationColor;
			
			comboBoxType.Items.AddRange(TextData.TypeText);
			comboBoxRarity.Items.AddRange(TextData.RarityText);
			comboBoxNation.Items.AddRange(TextData.NationText);
			comboBoxSet.Items.AddRange(TextData.SetText);
			
			comboBoxType.SelectedIndex=(int)Type.HQ;
			comboBoxRarity.SelectedIndex=(int)Rarity.Standard;
			comboBoxNation.SelectedIndex=(int)Nation.Custom;
			comboBoxSet.SelectedIndex=(int)Set.FanMade;
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
		void UpdateCard(string cardPath)
		{
			gen.LoadIniFile(cardPath);
			UpdateUI();
			UpdatePreview();
			
		}
		void UpdateUI()
		{
			comboBoxType.SelectedIndex=(int)gen.type;
			comboBoxRarity.SelectedIndex=(int)gen.rarity;
			comboBoxNation.SelectedIndex=(int)gen.nation;
			comboBoxSet.SelectedIndex=(int)gen.set;
			
			textBoxDeploymentCost.Text=gen.depoymentCost.ToString();
			textBoxOperationCost.Text=gen.operationCost.ToString();
			textBoxAtteck.Text=gen.atteck.ToString();
			textBoxdefense.Text=gen.defense.ToString();
			textBoxName.Text=gen.name;
			textBoxDescription.Text=gen.description;
			
			checkBoxIsDark.Checked=gen.isDarkName;
			pictureBoxNationView.BackColor=gen.nationColor;
			pictureBoxNationView.Image=gen.nationIcon;
			pictureBoxSetView.Image=gen.setIcon;
			pictureBoxImgView.Image=gen.pic;
			isCliped=false;
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
		void UpdateNation(string picPath)
		{
			//if(pictureBoxNationPreview.Image!=null)pictureBoxNationPreview.Image=null;
			if(gen.nationIcon!=null)gen.nationIcon.Dispose();
			pictureBoxNationView.Image=ImageExt.CopyFromFile(picPath);
			gen.nationIcon=pictureBoxNationView.Image;
			UpdatePreview();
		}
		void UpdateSet(string picPath)
		{
			//if(pictureBoxNationPreview.Image!=null)pictureBoxNationPreview.Image=null;
			if(gen.setIcon!=null)gen.setIcon.Dispose();
			pictureBoxSetView.Image=ImageExt.CopyFromFile(picPath);
			gen.setIcon=pictureBoxSetView.Image;
			UpdatePreview();
		}
		
		DialogResult OpenPic()
		{
			string s=null;
			var ret=OpenImage(ref s);
			if(ret==DialogResult.OK)
			{
				UpdatePic(s);
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
		DialogResult OpenNationPic()
		{
			string s=null;
			var ret=OpenImage(ref s);
			if(ret==DialogResult.OK)
			{
				UpdateNation(s);
			}
			else 
			{
				pictureBoxNationView.Image=null;
				if(gen.nationIcon!=null)gen.nationIcon.Dispose();
				gen.nationIcon=null;
				UpdatePreview();
			}
			return ret;
		}
		DialogResult OpenSetPic()
		{
			string s=null;
			var ret=OpenImage(ref s);
			if(ret==DialogResult.OK)
			{
				UpdateSet(s);
			}
			else 
			{
				pictureBoxSetView.Image=null;
				if(gen.setIcon!=null)gen.setIcon.Dispose();
				gen.setIcon=null;
				UpdatePreview();
			}
			return ret;
		}
		DialogResult OpenImage(ref string s)
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
				s=open.FileName;
				return ret;
			}
		}
		DialogResult SaveFile()
		{
			using (var save=new SaveFileDialog())
			{
				save.RestoreDirectory=true;
				save.Filter=
					"Initialization File (*.ini)|*.ini"+
					"|All Files (*.*)|*.*"
				;
				var ret=save.ShowDialog();
				if(ret== DialogResult.OK)
					try {gen.SaveIniFile(save.FileName);}
					catch(Exception ex)
					{
						MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						throw ex;
					}
				return ret;
			}
		}
		DialogResult LoadFile()
		{
			using (var open=new OpenFileDialog())
			{
				open.RestoreDirectory=true;
				open.Filter=
					"Initialization File (*.ini)|*.ini"+
					"|All Files (*.*)|*.*"
				;
				var ret=open.ShowDialog();
				if(ret== DialogResult.OK)
					try {UpdateCard(open.FileName);}
					catch(Exception ex)
					{
						MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						throw ex;
					}
				return ret;
			}
		}
		
		public delegate void StrGeter(string r);
		void EnableDragDrop(Control c,StrGeter gs)
		{
			c.AllowDrop=true;
			c.DragEnter+= DragEnterFunc;
			c.DragDrop+=(sender,e)=>{
				string path = (
					(string[])e
					.Data
					.GetData(DataFormats.FileDrop)
				)[0];
				gs.Invoke(path);
			};
			
		}
		void EnableDragDrop(Control c)
		{
			c.AllowDrop=true;
			c.DragEnter+= DragEnterFunc;
		}
		void DragEnterFunc(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;			//重要代码：表明是所有类型的数据，比如文件路径
			else
				e.Effect = DragDropEffects.None;
		}
		/*
		void PictureBoxImgViewDragDrop(object sender, DragEventArgs e)
		{
			string path = (
				(string[])e
				.Data
				.GetData(DataFormats.FileDrop)
			)[0];
			UpdatePic(path);
		}
		*/
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
			pictureBoxNationView.AllowDrop= gen.nation==Nation.Custom;
			switch (gen.type) {
				case Type.HQ:
					checkBoxIsDark.Enabled=false;
					break;
				case Type.Order:goto case Type.HQ;
				case Type.Countermeasure:goto case Type.HQ;
				default:
					checkBoxIsDark.Enabled= gen.nation==Nation.Custom;
					break;
			}
			UpdatePreview();
		}
		
		void ComboBoxTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			gen.type=(Type)((ComboBox)sender).SelectedIndex;
			switch (gen.type) {
				case Type.HQ:
					checkBoxIsDark.Enabled=false;
					break;
				case Type.Order:goto case Type.HQ;
				case Type.Countermeasure:goto case Type.HQ;
				default:
					checkBoxIsDark.Enabled= gen.nation==Nation.Custom;
					break;
			}
			UpdatePreview();
		}
		
		void ComboBoxRaritySelectedIndexChanged(object sender, EventArgs e)
		{
			gen.rarity=(Rarity)((ComboBox)sender).SelectedIndex;
			UpdatePreview();
		}
		
		void PictureBoxPreviewClick(object sender, EventArgs e)
		{
			if(((MouseEventArgs)e).Button== MouseButtons.Left)
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
			else if(((MouseEventArgs)e).Button== MouseButtons.Right)
			{
				if(SaveFile()== DialogResult.OK)MessageBox.Show("卡牌文件已保存!");;
			}
			
		}
		
		void PictureBoxPreviewDoubleClick(object sender, EventArgs e)
		{
			LoadFile();
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
		
		
		
		
		
		void PictureBoxNationViewClick(object sender, EventArgs e)
		{
			if(gen.nation!= Nation.Custom)return;
			if(((MouseEventArgs)e).Button== MouseButtons.Left)
			{
				OpenNationPic();
			}
			else if(((MouseEventArgs)e).Button== MouseButtons.Right)
			{
				using(var cdl=new ColorDialog())
				{
					cdl.AllowFullOpen=true;
					cdl.FullOpen=true;
					//int[] colors=(int[3]){(int)Material.defaultDark,(int)Material.defaultLight,(int)Material.defaultColorActivate};
					cdl.CustomColors=new int[3]{
						ColorFix.FromArgb(Material.defaultDark).ToArgb(),
						ColorFix.FromArgb(Material.defaultLight).ToArgb(),
						ColorFix.FromArgb(Material.defaultColorActivate).ToArgb()
					};
					cdl.Color=gen.nationColor;
					cdl.ShowDialog();
					gen.nationColor=cdl.Color;
					pictureBoxNationView.BackColor=gen.nationColor;
					UpdatePreview();
				}
			}
		}
		
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			gen.isDarkName=((CheckBox)sender).Checked;
			UpdatePreview();
		}
		
		void ComboBoxSetSelectedIndexChanged(object sender, EventArgs e)
		{
			gen.set=(Set)((ComboBox)sender).SelectedIndex;
			UpdatePreview();
		}
		
		void PictureBoxSetViewClick(object sender, EventArgs e)
		{
			if(gen.set!= Set.Custom)return;
			OpenSetPic();
			UpdatePreview();
		}
		
		
		
	}
}
