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
	public enum Type
	{
		//target
		HQ,
		//unit
		Infantry,
		Tank,
		Fighter,
		Bomber,
		Artillery,
		//command
		Order,
		Countermeasure
	};
	public enum Rarity
	{
		Standard,Limited,Special,Elite,None
	};
	public enum Nation
	{
		Soviet,
		USA,
		Japan,
		Germany,
		Britain,
		France,
		Italy,
		Poland,
		Finland,
		Neutral,
		
		Custom
	};
	public enum Set
	{
		Base,
		Allegiance,
		Theaters,
		Breakthrough,
		Legions,
		World,
		Brothers,
		Winter,
		Covert,
		Blood,
		Naval,
		FanMade,
		
		Custom
	};
	public static class TextData
	{
		public static string[] TypeText=new string[] {
			"总部",
			"步兵",
			"坦克",
			"战斗机",
			"轰炸机",
			"高射炮",
			"指令",
			"反制"
		};
		public static string[] RarityText=new string[] {
			"普通",
			"限定",
			"特殊",
			"精英",
			
			"衍生"
		};
		public static string[] NationText=new string[] {
			"苏联",
			"美国",
			"日本",
			"德国",
			"英国",
			"法国",
			"意大利",
			"波兰",
			"芬兰",
			"中立",
			
			"自定义"
		};
		public static string[] SetText=new string[] {
			"基础",
			"忠诚",
			"战区",
			"突破",
			"军团",
			"世纪大战",
			"战友",
			"冬季战争",
			"秘密行动",
			"血与铁",
			"海战",
			"同人创作",
			
			"自定义"
		};
	}
}
