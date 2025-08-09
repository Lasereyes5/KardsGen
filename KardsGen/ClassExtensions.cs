/*
 * 由SharpDevelop创建。
 * 用户： pc
 * 日期: 2025/4/3
 * 时间: 4:10
 * let's all love lain!
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ClassExtensions
{
	/// <summary>
	/// Extended to escape string and let string Array interact with Enum.
	/// </summary>
	public static class stringExt
	{
		public static string EscapeNewLines(string s)
		{
			if(string.IsNullOrEmpty(s))return null;
			StringBuilder sb=new StringBuilder(s.Length+16);
			for (int i = 0; i < s.Length; i++)
			{
				switch (s[i])
				{
					case '\n':
						sb.Append("\\n");
						break;
					case  '\r':
						sb.Append("\\r");
						break;
					case  '\\':
						sb.Append("\\\\");
						break;
					default:
						sb.Append(s[i]);
						break;
				}
			}
			return sb.ToString();
		}
		public static string UnEscapeNewLines(string s)
		{
			if(string.IsNullOrEmpty(s))return null;
			StringBuilder sb=new StringBuilder(s.Length);
			for (int i = 0; i < s.Length; i++)
			{
				if(s[i]!='\\')sb.Append(s[i]);
				else //s[i]=='\\'
				{
					i++;
					if(i==s.Length)
					{
						sb.Append('\\');
						break;
					}
					switch (s[i])
					{
						case 'n':
							sb.Append('\n');
							break;
						case 'r':
							sb.Append('\r');
							break;
						case '\\':
							sb.Append('\\');
							break;
						default:
							sb.Append('\\');
							sb.Append(s[i]);
							break;
					}
				}
			}
			return sb.ToString();
		}
		
		//for Enum
		/*
		/// <summary>
		/// 根据传入的枚举类型和值从字符串数组中返回选定字符串。
		/// strArr[(int)value];
		/// </summary>
		/// <param name="value">枚举值</param>
		/// <param name="strArr">枚举类型。</param>
		/// <returns>指定字符串</returns>
		public static string GetStringFromEnum<T>(T value,string []strArr)
		{
			return strArr[(int)value];
		}
		*/
		/// <summary>
		/// 根据传入的选定字符串从字符串数组中查找索引值并转为指定的枚举类型。
		/// </summary>
		/// <param name="strValue">查找字符串</param>
		/// <param name="strArr">索引查找表</param>
		/// <returns>返回索引值转换成的枚举</returns>
		public static T GetEnumFromArray<T>(string strValue,string []strArr)where T:struct
		{
			if(!typeof(T).IsEnum)
				throw new ArgumentOutOfRangeException(string.Format("Type {0} is not Enum.",typeof(T).Name));
			
			if(string.IsNullOrEmpty(strValue))return default(T);
			
			int index=Array.IndexOf(strArr,strValue);
			
			if(!Enum.IsDefined(typeof(T),index))
				throw new ArgumentOutOfRangeException(string.Format("Value {0} is not in the Enum {1}.",index,typeof(T).Name));
			
			return (T)Enum.ToObject(typeof(T),index);
		}
		/// <summary>
		/// 根据传入的选定字符串从字符串数组中查找索引值并转为指定的枚举类型。
		/// </summary>
		/// <param name="strValue">查找字符串</param>
		/// <param name="strArr">索引查找表</param>
		/// <param name="defaultValue">默认枚举值</param>
		/// <returns>返回索引值转换成的枚举</returns>
		public static T GetEnumFromArray<T>(string strValue,string []strArr,T defaultValue)where T:struct
		{
			if(!typeof(T).IsEnum)
				throw new ArgumentOutOfRangeException(string.Format("Type {0} is not Enum.",typeof(T).Name));
			
			if(string.IsNullOrEmpty(strValue))return defaultValue;
			
			int index=Array.IndexOf(strArr,strValue);
			
			if(!Enum.IsDefined(typeof(T),index))
				throw new ArgumentOutOfRangeException(string.Format("Value {0} is not in the Enum {1}.",index,typeof(T).Name));
			
			return (T)Enum.ToObject(typeof(T),index);
		}
	}
	
	/// <summary>
	/// Extended to parse uint to Color
	/// </summary>
	public static class ColorFix
	{
		public static Color FromArgb(uint alphaColorValue)
		{
			unchecked
			{
				return Color.FromArgb((int)alphaColorValue);
			}
		}
	}
	public static class ImageExt
	{
		//https://www.cnblogs.com/masha2017/p/14022812.html
		public static Image FromBase64String(string base64String)
		{
			if(string.IsNullOrEmpty(base64String))return null;
			byte[] imgData=Convert.FromBase64String(base64String);
			using (var stream=new MemoryStream(imgData))
			{
				return Image.FromStream(stream);
			}
		}
		public static string ToBase64String(this Image img,ImageFormat fmt)
		{
			if(img==null)return null;
			using (var stream=new MemoryStream())
			{
				img.Save(stream,fmt);
				byte[] imgData=stream.ToArray();
				return Convert.ToBase64String(imgData);
			}
		}
		
		public static Image CopyFromFile(string imgPath)
		{
			using(var img=Image.FromFile(imgPath))
			{
				return CopyFromImage(img);
			};
		}
		public static Image CopyFromImage(Image img)
		{
			//*
			var bmp=new Bitmap(img.Width,img.Height,PixelFormat.Format32bppArgb);
			
			Graphics g=Graphics.FromImage(bmp);
			g.DrawImageUnscaled(img,new Point(0,0));
			g.Flush();
			g.Dispose();
			img.Dispose();
			
			return bmp;
			/*/
			Image img;
			//byte[] bytes=File.ReadAllBytes(imgPath);
			using (var fs=File.OpenRead(imgPath))
			{
				using (var ms=new MemoryStream())
				{
					fs.CopyTo(ms);
					img=Image.FromStream(ms);
				}
			}
			return img;
			//*/
		}
		
		public static ImageFormat[] supportedFormats={
			ImageFormat.Bmp,ImageFormat.Emf,ImageFormat.Exif,
			ImageFormat.Gif,ImageFormat.Icon,ImageFormat.Jpeg,
			ImageFormat.MemoryBmp,ImageFormat.Png,ImageFormat.Tiff,
			ImageFormat.Wmf
		};
		public static string ToLowerExt(this string ext)
		{
			string lowerExt=ext.ToLower();
			switch (lowerExt)
			{
				case "jpg":
					return "jpeg";
				case "tif":
					return "tiff";
				case "ico":
					return "icon";
				default:
					return lowerExt;
					//break;
			}
		}
		public static void SaveAutoFormat(this Image img,string fileName)
		{
			string fileExt=Path.GetExtension(fileName).Substring(1);//remove '.'
			bool supported=false;
			foreach (var fmt in supportedFormats)
			{
				if(fileExt.ToLowerExt()==fmt.ToString().ToLower())
				{
					img.Save(fileName,fmt);
					supported=true;
					break;
				}
			}
			if(!supported)throw new UnsupportedImageFormat("Unsupported Image Format: "+fileExt);
		}
		public class UnsupportedImageFormat:Exception
		{
			public UnsupportedImageFormat(string message):base(message)
			{
				
			}
		}
	}
	
	
	/// <summary>
	/// Extended to zoom Rectangle A to B/From A to B,or vice versa,just like PictureBox SizeMode=Zoom.
	/// </summary>
	public static class RectangleExt
	{
		public static Rectangle ZoomFromTo(this Rectangle local,Rectangle source, Rectangle destination,bool reverseZoom=false)
		{
			RectangleF sf=source,df=destination,lf=local;
			return Rectangle.Round(ZoomFromTo(lf,sf,df,reverseZoom));
		}
		public static Rectangle ZoomTo(this Rectangle source, Rectangle destination,bool reverseZoom=false)
		{
			RectangleF sf=source,df=destination;
			return Rectangle.Round(ZoomTo(sf,df,reverseZoom));
		}
		public static RectangleF ZoomFromTo(this RectangleF local,RectangleF source, RectangleF destination,bool reverseZoom=false)
		{
		    float srcRatio = source.Width / source.Height;
		    float destRatio = destination.Width / destination.Height;
			
		    bool isWidthZoom=reverseZoom? srcRatio<destRatio : srcRatio>destRatio;
		    float scale = isWidthZoom
		        ? destination.Width / source.Width   // 按宽度缩放
		        : destination.Height / source.Height; // 按高度缩放
		
		    float scaledWidth = source.Width * scale;
		    float scaledHeight = source.Height * scale;
		
		    // 计算居中坐标（相对于目标矩形的左上角）
		    float x = destination.Left + (destination.Width - scaledWidth) / 2;
		    float y = destination.Top + (destination.Height - scaledHeight) / 2;
		
		    local.Width*=scale;
		    local.Height*=scale;
		    local.X-=source.X;
		    local.Y-=source.Y;
		    local.X*=scale;
		    local.Y*=scale;
		    local.X+=x;
		    local.Y+=y;
		    return local;
		}
		//deepseek generated function(modified)
		public static RectangleF ZoomTo(this RectangleF source, RectangleF destination,bool reverseZoom=false)
		{
		    float srcRatio = source.Width / source.Height;
		    float destRatio = destination.Width / destination.Height;
		
		    bool isWidthZoom=reverseZoom? srcRatio<destRatio : srcRatio>destRatio;
		    float scale = isWidthZoom
		        ? destination.Width / source.Width   // 按宽度缩放
		        : destination.Height / source.Height; // 按高度缩放
		
		    float scaledWidth = source.Width * scale;
		    float scaledHeight = source.Height * scale;
		
		    // 计算居中坐标（相对于目标矩形的左上角）
		    float x = destination.Left + (destination.Width - scaledWidth) / 2;
		    float y = destination.Top + (destination.Height - scaledHeight) / 2;
		
		    return new RectangleF(x, y, scaledWidth, scaledHeight);
		}
	}
	
	/*
	public static class GraphicsExt
	{
		[DllImport("gdi32")]
		public static extern int SetTextCharacterExtra(IntPtr hdc,int nCharExtra);
		public static void SetTextLineGap(this Graphics g,int gap)
		{
			IntPtr hdc=g.GetHdc();
			SetTextCharacterExtra(hdc,gap);
			g.ReleaseHdc(hdc);
		}
	}
	//*/
}
