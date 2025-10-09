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
using System.Reflection;
using ClassExtensions;

namespace KardsGen
{
	
	public static class Material
	{
		/*
		//public static string spaceName=typeof(Material).Namespace+".Material.";
		public static string resPrefix="KardsGen.Material.";
		public static Assembly assembly = Assembly.GetExecutingAssembly();
		//public static Image frameImg=ImageExt.FromResource(resPrefix+"frame.png",assembly);//Frame 
		public static Image frameImg=ImageExt.FromResource("KardsGen.Material.frame.png",assembly);
		public static Image kreditBoardImg__12_13=ImageExt.FromResource(resPrefix+"kredit-board(12,13).png",assembly);//KreditBoard
		public static Image extraBorderImg__0_489=ImageExt.FromResource(resPrefix+"extra-border(0,489).png",assembly);//ExtraBorder
		public static Image spliterImg__98_91=ImageExt.FromResource(resPrefix+"spliter(98,91).png",assembly);//Spliter
		
		public static Image defenseBoardImg__330_473=ImageExt.FromResource(resPrefix+"board.board(88,468)(330,473).png",assembly);
		public static Image atteckBoardImg__88_468=GetAtteckBoard();
		public static Image HQBoardImg__166_343=ImageExt.FromResource(resPrefix+"board.HQ-board(166,343).png",assembly);
		public static Image specialBoardImg__82_468=ImageExt.FromResource(resPrefix+"board.special-board(82,468).png",assembly);
		
		public static Image[] nationIcon=GetNationIcons();
		public static Image[] rarityIcon=GetRarityIcons();
		public static Image[] typeIcon=GetTypeIcons();
		public static Image[] setIcon=GetSetIcons();
		*/
				//public static string spaceName=typeof(Material).Namespace+".Material.";
		public static string resPrefix="KardsGen.Material.";
		public static Assembly assembly;
		//public static Image frameImg=ImageExt.FromResource(resPrefix+"frame.png",assembly);//Frame 
		public static Image frameImg;
		public static Image kreditBoardImg__12_13;
		public static Image extraBorderImg__0_489;
		public static Image spliterImg__98_91;
		
		public static Image defenseBoardImg__330_473;
		public static Image atteckBoardImg__88_468;
		public static Image HQBoardImg__166_343;
		public static Image specialBoardImg__82_468;
		
		public static Image[] nationIcon;
		public static Image[] nationAirIcon;
		public static Image[] rarityIcon;
		public static Image[] typeIcon;
		public static Image[] setIcon;
		
		public const uint 
			defaultDark=0xff50514C,
			defaultLight=0xffC2C8B3,
			defaultColorActivate=0xffCE8A31;
		
		public const int
			nationCount=10,
			rarityCount=4,
			typeCount=8,
			setCount=12;
		
		public static void Init()
		{
			assembly = Assembly.GetExecutingAssembly();
			frameImg=ImageExt.FromResource(resPrefix+"frame.png",assembly);//Frame 
			//frameImg=ImageExt.FromResource("KardsGen.Material.frame.png",assembly);
			kreditBoardImg__12_13=ImageExt.FromResource(resPrefix+"kredit-board(12,13).png",assembly);//KreditBoard
			extraBorderImg__0_489=ImageExt.FromResource(resPrefix+"extra-border(0,402).png",assembly);//ExtraBorder
			spliterImg__98_91=ImageExt.FromResource(resPrefix+"spliter(98,91).png",assembly);//Spliter
			
			defenseBoardImg__330_473=ImageExt.FromResource(resPrefix+"board.board(88,468)(330,473).png",assembly);
			atteckBoardImg__88_468=GetAtteckBoard();
			HQBoardImg__166_343=ImageExt.FromResource(resPrefix+"board.HQ-board(166,343).png",assembly);
			specialBoardImg__82_468=ImageExt.FromResource(resPrefix+"board.special-board(82,468).png",assembly);
			
			nationIcon=GetNationIcons();
			nationAirIcon=GetNationAirIcons();
			rarityIcon=GetRarityIcons();
			typeIcon=GetTypeIcons();
			setIcon=GetSetIcons();
		}
		
		static Image GetAtteckBoard()
		{
			Image atkbdimg=(Image)defenseBoardImg__330_473.Clone();
			atkbdimg.RotateFlip(RotateFlipType.Rotate180FlipNone);
			return atkbdimg;
		}
		static Image[] GetRarityIcons()
		{
			Image[] imgs=new Image[rarityCount];
			for (int i = 0; i < rarityCount; i++)
			{
				imgs[i]=ImageExt.FromResource( resPrefix+"Rarity."+((Rarity)i).ToString()+".png" ,assembly);
			}
			return imgs;
		}
		static Image[] GetTypeIcons()
		{
			Image[] imgs=new Image[typeCount];
			for (int i = 1; i < typeCount; i++)
			{
				imgs[i]=ImageExt.FromResource( resPrefix+"Type."+((Type)i).ToString()+".png" ,assembly);
			}
			return imgs;
		}
		static Image[] GetNationIcons()
		{
			Image[] nationsArr=new Image[nationCount];
			for (int i = 0; i < nationCount; i++)
			{
				nationsArr[i]=ImageExt.FromResource( resPrefix+"Nation."+((Nation)i).ToString()+".png" ,assembly);
			}
			return nationsArr;
			//nations[0]=((Image)(resources.GetObject("USA")));
		}
		static Image[] GetNationAirIcons()
		{
			Image[] nationsArr=new Image[nationCount];
			for (int i = 0; i < nationCount; i++)
			{
				nationsArr[i]=ImageExt.FromResource( resPrefix+"Nation.Air."+((Nation)i).ToString()+".png" ,assembly);
			}
			return nationsArr;
			//nations[0]=((Image)(resources.GetObject("USA")));
		}
		static Image[] GetSetIcons()
		{
			Image[] imgs=new Image[setCount];
			for (int i = 0; i < setCount; i++)
			{
				imgs[i]=ImageExt.FromResource( resPrefix+"Set."+((Set)i).ToString()+".png" ,assembly);
			}
			return imgs;
		}
		
		public static Color GetNationColor(Nation nation)
		{
			switch (nation)
			{
				case Nation.Custom:return ColorFix.FromArgb(0xff50514c);
				case Nation.Soviet:return ColorFix.FromArgb(0xff665644);
				case Nation.USA:return ColorFix.FromArgb(0xff646c4e);
				case Nation.Japan:return ColorFix.FromArgb(0xffa08241);
				case Nation.Germany:return ColorFix.FromArgb(0xff5f6a67);
				case Nation.Britain:return ColorFix.FromArgb(0xff978c6f);
				case Nation.France:return ColorFix.FromArgb(0xff505a79);
				case Nation.Italy:return ColorFix.FromArgb(0xff69696a);
				case Nation.Poland:return ColorFix.FromArgb(0xff696353);
				case Nation.Finland:return ColorFix.FromArgb(0xffbdbdad);
				case Nation.Neutral:return ColorFix.FromArgb(0xff3b3b43);
				//default:throw new Exception("Invalid value for Nation");
			}
			return Color.Empty;
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
			foreach(var img in nationAirIcon)
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
			foreach(var img in setIcon)
			{
				img.Dispose();
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
