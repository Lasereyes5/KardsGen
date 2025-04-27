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
using ClassExtensions;

namespace KardsGen
{
	
	public static class Material
	{
		public static System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Material));
		public static Image frameImg=((Image)(resources.GetObject("frame")));
		public static Image kreditBoardImg__12_13=((Image)(resources.GetObject("kredit-board(12,13)")));
		public static Image extraBorderImg__0_489=((Image)(resources.GetObject("extra-border(0,489)")));
		public static Image spliterImg__98_91=((Image)(resources.GetObject("spliter(98,91)")));
		
		public static Image defenseBoardImg__330_473=((Image)(resources.GetObject("board(88,468)(330,473)")));
		public static Image atteckBoardImg__88_468=GetAtteckBoard();
		public static Image HQBoardImg__166_343=((Image)(resources.GetObject("HQ-board(166,343)")));
		public static Image specialBoardImg__82_468=((Image)(resources.GetObject("special-board(82,468)")));
		
		public static Image[] nationIcon=GetNationIcons();
		public static Image[] rarityIcon=GetRarityIcons();
		public static Image[] typeIcon=GetTypeIcons();
		
		static Image GetAtteckBoard()
		{
			Image atkbdimg=(Image)defenseBoardImg__330_473.Clone();
			atkbdimg.RotateFlip(RotateFlipType.Rotate180FlipNone);
			return atkbdimg;
		}
		static Image[] GetRarityIcons()
		{
			Image[] imgs=new Image[4];
			for (int i = 0; i < 4; i++)
			{
				imgs[i]=(Image)(resources.GetObject( ((Rarity)i).ToString() ));
			}
			return imgs;
		}
		static Image[] GetTypeIcons()
		{
			Image[] imgs=new Image[8];
			for (int i = 1; i < 8; i++)
			{
				imgs[i]=(Image)(resources.GetObject( ((Type)i).ToString() ));
			}
			return imgs;
		}
		static Image[] GetNationIcons()
		{
			Image[] nationsArr=new Image[(int)Nation.None];
			for (int i = 0; i < (int)Nation.None; i++)
			{
				nationsArr[i]=(Image)(resources.GetObject( ((Nation)i).ToString() ));
			}
			return nationsArr;
			//nations[0]=((Image)(resources.GetObject("USA")));
		}
		
		public static Color GetNationColor(Nation nation)
		{
			switch (nation)
			{
				case Nation.None:return ColorFix.FromArgb(0xff50514c);
				case Nation.Soviet:return ColorFix.FromArgb(0xff665644);
				case Nation.USA:return ColorFix.FromArgb(0xff646c4e);
				case Nation.Japan:return ColorFix.FromArgb(0xffa08241);
				case Nation.Germany:return ColorFix.FromArgb(0xff5f6a67);
				case Nation.Britain:return ColorFix.FromArgb(0xff978c6f);
				case Nation.France:return ColorFix.FromArgb(0xff505a79);
				case Nation.Italy:return ColorFix.FromArgb(0xff69696a);
				case Nation.Poland:return ColorFix.FromArgb(0xff696353);
				case Nation.Finland:return ColorFix.FromArgb(0xffbdbdad);
				//default:throw new Exception("Invalid value for Nation");
			}
			return Color.Empty;
		}
		public static Point GetNationPosition(Nation nation)
		{
			switch (nation)
			{
				case Nation.None:return Point.Empty;
				case Nation.Soviet:return new Point(416,20);
				case Nation.USA:return new Point(423,26);
				case Nation.Japan:return new Point(425,27);
				case Nation.Germany:return new Point(423,25);
				case Nation.Britain:return new Point(425,27);
				case Nation.France:return new Point(425,26);
				case Nation.Italy:return new Point(425,27);
				case Nation.Poland:return new Point(425,28);
				case Nation.Finland:return new Point(425,27);
				//default:throw new Exception("Invalid value for Nation");
			}
			return Point.Empty;
		}
		
		public static Point GetTypePosition(Type type)
		{
			switch (type) {
				case Type.HQ:return Point.Empty;
				case Type.Order:return new Point(222,448);
				case Type.Countermeasure:goto case Type.Order;
				default:return new Point(208,473);
			}
			//return Point.Empty;
		}
		public static void Dispose()
		{
			foreach(var img in nationIcon)
			{
				img.Dispose();
			}
			foreach(var img in rarityIcon)
			{
				img.Dispose();
			}
			foreach(var img in typeIcon)
			{
				if(img!=null)img.Dispose();
			}
			
			frameImg.Dispose();
			kreditBoardImg__12_13.Dispose();
			extraBorderImg__0_489.Dispose();
			spliterImg__98_91.Dispose();
			
			defenseBoardImg__330_473.Dispose();
			atteckBoardImg__88_468.Dispose();
			HQBoardImg__166_343.Dispose();
			specialBoardImg__82_468.Dispose();
			
			
		}
	}
}
