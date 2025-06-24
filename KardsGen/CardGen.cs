/*
 * 由SharpDevelop创建。
 * 用户： pc
 * 日期: 2025/4/3
 * 时间: 2:03
 * let's all love lain!
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using ClassExtensions;

namespace KardsGen
{
	/// <summary>
	/// Description of CardGen.
	/// </summary>
	public class CardGen
	{
		//proerty
		public Type type;
		public Rarity rarity;
		public Nation nation;
		public Set set;
		public Image nationIcon;
		public Color nationColor=ColorFix.FromArgb(0xff50514c);
		public Image setIcon;
		
		public bool isDarkName=false;
		public string name;
		public string description;
		
		string fontname="Microsoft YaHei UI";
		//public Font font=new Font(;
		
		public Bitmap resultBmp;
		public Graphics resultG;
		public Image pic;
		
		public int depoymentCost=0;
		public int operationCost=0;
		public int atteck=0;
		public int defense=0;
		
		public CardGen()
		{
			resultBmp=new Bitmap(Material.frameImg.Width,Material.frameImg.Height);
			resultG=Graphics.FromImage(resultBmp);
			resultG.TextRenderingHint= TextRenderingHint.AntiAlias;
			//resultG.SetTextLineGap(10);
		}
		public Bitmap Generate()
		{
			return Generate(resultG);
		}
		public Bitmap Generate(Graphics g)
		{
			bool isHQ=false,isUnit=false,isCmd=false;
			switch (type) {
				case Type.HQ:isHQ=true;break;
				case Type.Order:isCmd=true;break;
				case Type.Countermeasure:isCmd=true;break;
				default:isUnit=true;break;//unit
			}
			g.Clear(Color.Transparent);
			//g.FillRectangle(Brushes.Transparent, new Rectangle(new Point(0,0), resultBmp.Size));
			//DrawFrame(g);
			if(pic!=null)
			{
				//Point drawLocation=new Point(12,13);
				/*
				int picy=(isUnit)?99:13;
				g.DrawImage(pic,new Rectangle(
					12,picy,//name bar in unit
					476,525-picy-( (isUnit)?0:36 )
				));
				*/
				g.DrawImage(pic,
					(isUnit)?//name bar in unit
						new Rectangle(12,99,476,426)//525-99
					:
						new Rectangle(12,13,476,476)//525-13-36
				);
			}
			if(isUnit)DrawNameBar(g);//name bar
			//or extra border
			else DrawExtraBorder(g);
			if(isUnit||isCmd)DrawKredit(g,isUnit);
			DrawNation(g);
			
			DrawFrame(g);
			if((isUnit||isCmd)&&rarity!=Rarity.None)DrawRarity(g);
			if(isUnit||isCmd)DrawSet(g);
			
			DrawValue(g);
			if(!isHQ)DrawType(g);
			
			DrawText(g);
			
			return resultBmp;
		}
		
		
		void DrawNameBar(Graphics g)
		{
			Brush b=new SolidBrush(nation==Nation.Custom?nationColor:Material.GetNationColor(nation));
			g.FillRectangle(b,98,13,390,86);
			b.Dispose();
			g.DrawImageUnscaled(Material.spliterImg__98_91,new Point(98,91));
		}
		void DrawExtraBorder(Graphics g)
		{
			g.DrawImageUnscaled(Material.extraBorderImg__0_489,new Point(0,489));
		}
		void DrawFrame(Graphics g)
		{
			g.DrawImageUnscaled(Material.frameImg,new Point(0,0));
		}
		void DrawNation(Graphics g)
		{
			Image img;
			//g.DrawImageUnscaled(Material.nationIcon[(int)nation],Material.GetNationPosition(nation));
			if(nation!=Nation.Custom)img=Material.nationIcon[(int)nation];
			else img=nationIcon;
			
			if(img==null)return;
			Point pos=new Point(//draw image at center (450,52)
				450-img.Width/2,
				52-img.Height/2
			);
			g.DrawImageUnscaled(img,pos);
			
		}
		void DrawSet(Graphics g)
		{
			Image img;
			//g.DrawImageUnscaled(Material.nationIcon[(int)nation],Material.GetNationPosition(nation));
			if(set!=Set.Custom)img=Material.setIcon[(int)set];
			else img=setIcon;
			
			if(img==null)return;
			Point pos=new Point(//draw image at right bottom corner (490,690)
				488-img.Width,
				692-img.Height
			);
			g.DrawImageUnscaled(img,pos);
			
		}
		void DrawRarity(Graphics g)
		{
			g.DrawImage(Material.rarityIcon[(int)rarity],new Point(222,675));
		}
		void DrawKredit(Graphics g,bool isUnit)
		{
			g.DrawImage(Material.kreditBoardImg__12_13,new Point(12,13));
			string dcstr=depoymentCost.ToString();
			
			
			if(dcstr.Length>1)//small K & small num
			{
				//draw K
				DrawStr(g,"K",17,new PointF(80,25),Material.defaultColorActivate);
				//draw cost 33
				DrawNum(g,depoymentCost,45,new PointF(42,12));
				if(isUnit)DrawNum(g,operationCost,15,new PointF(80,50));
			}
			else 
			{
				//draw K
				DrawStr(g,"K",22,new PointF(75,20),Material.defaultColorActivate);
				//draw cost
				DrawNum(g,depoymentCost,45,new PointF(40,12));
				if(isUnit)DrawNum(g,operationCost,20,new PointF(75,50));
			}
			
		}
		void DrawValue(Graphics g)
		{
			switch (type) {
				case Type.HQ:
					g.DrawImage(Material.HQBoardImg__166_343,new Point(166,343));
					DrawNum(g,defense,70,new PointF(250,365));
					return;
				case Type.Bomber:
					g.DrawImage(Material.specialBoardImg__82_468,new Point(82,468));
					break;
				case Type.Artillery:goto case Type.Bomber;
				case Type.Order:return;
				case Type.Countermeasure:return;
				default:
					g.DrawImage(Material.atteckBoardImg__88_468,new Point(88,468));
					break;
				
			}
			g.DrawImage(Material.defenseBoardImg__330_473,new Point(330,473));
			DrawNum(g,atteck,40,new PointF(130,481));
			DrawNum(g,defense,40,new PointF(372,481));
			
		}
		void DrawType(Graphics g)
		{
			if(type!= Type.HQ)g.DrawImageUnscaled(Material.typeIcon[(int)type],Material.GetTypePosition(type));
		}
		void DrawText(Graphics g)
		{
			switch (type) {
				case Type.HQ:
					DrawStr(g,name,30,new PointF(250,505),Material.defaultDark);
					break;
				case Type.Order:goto case Type.HQ;
				case Type.Countermeasure:goto case Type.HQ;
				default:
					uint colorCode=Material.defaultLight;//light title by default
					if(nation==Nation.Finland)
					{
						colorCode=Material.defaultDark;//dark title in finland unit
					}
					else if(nation==Nation.Custom&&isDarkName)
					{
						colorCode=Material.defaultDark;
					}
					DrawStr(g,name,35,new PointF(265,19),colorCode);
					break;
			}
			int lineCount=1;//,sizeOffset=0;
			float printSize=25;
			if(!string.IsNullOrEmpty(description))
				foreach (var c in description)
				{
					if(c=='\n')lineCount++;
				}
			if(lineCount>2)printSize*=100f/(35*lineCount);
			DrawStrLight(g,description,Convert.ToInt32(printSize),new PointF(250,552),Material.defaultDark);
		}
		
		void DrawNum(Graphics g,int n,int size,PointF pos,uint colorCode=Material.defaultLight)
		{
			string numStr=n.ToString();
			float printSize=size*(float)Math.Pow(0.85,numStr.Length>0?numStr.Length-1:0);
			pos.Y+=(size-printSize);
			DrawStr(g,numStr,Convert.ToInt32(printSize),pos,colorCode);
		}
		void DrawStr(Graphics g,string s,int size,PointF pos,uint colorCode=Material.defaultLight)
		{
			Font f=new Font(fontname,size,FontStyle.Bold);
			Brush b=new SolidBrush(ColorFix.FromArgb(colorCode));
			StringFormat sf=new StringFormat();
			sf.Alignment=StringAlignment.Center;
			g.DrawString(s,f,b,pos,sf);
			sf.Dispose();
			f.Dispose();
			b.Dispose();
		}
		void DrawStrLight(Graphics g,string s,int size,PointF pos,uint colorCode=0xffC2C8B3)
		{
			Font f=new Font(fontname,size);
			Brush b=new SolidBrush(ColorFix.FromArgb(colorCode));
			StringFormat sf=new StringFormat();
			sf.Alignment=StringAlignment.Center;
			g.DrawString(s,f,b,pos,sf);
			sf.Dispose();
			f.Dispose();
			b.Dispose();
		}
		
		public void Dispose()
		{
			resultG.Dispose();
			resultBmp.Dispose();
			if(pic!=null)pic.Dispose();
			if(nationIcon!=null)nationIcon.Dispose();
		}
	}
	
}
