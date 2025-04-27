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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ClassExtensions
{
	/*
	/// <summary>
	/// Extended to let ComboBox interact with Enum.
	/// https://blog.csdn.net/aYsd32/article/details/107659427
	/// </summary>
	public static class ComboBoxExt
	{
		/// <summary>
		/// 将指定的枚举型绑定至指定的ComboBox，结果表示是否绑定成功。
		/// 用法示例：comboBox1.BindEnum<EnumType>();
		/// </summary>
		/// <param name="cb">下拉框。</param>
		/// <param name="type">枚举类型。</param>
		/// <returns></returns>
		public static bool BindEnum<T>(this ComboBox cb)
		{
			Type type = typeof(T);
			if (!type.IsEnum || Enum.GetValues(type).Length == 0 || cb == null)
				return false;

			cb.Items.Clear();
			foreach (var item in Enum.GetValues(type))
			{
				cb.Items.Add(item.ToString());
			}

			// 默认选择第0项。
			cb.SelectedIndex = 0;
			// 这里不是必需的，但是由于枚举型不能有额外的，所以设置为 DrawDownList.
			cb.DropDownStyle = ComboBoxStyle.DropDownList;

			return true;
		}



		/// <summary>
		/// 根据ComboBox的选定字符串，返回指定的枚举类型。如果转换失败，则返回缺少值。
		/// 用法示例：EnumType et = comboBox1.GetEnum<EnumType>();
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="cb"></param>
		/// <returns></returns>

		public static T GetEnum<T>(this ComboBox cb)
		{
			T t = default(T); // 先初始化的默认值。
			try
			{
				t = (T)Enum.Parse(typeof(T), cb.SelectedItem.ToString()); // 进行类型转换。
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message); // 可以根据需要做相应的异常处理。 
			}

			return t;
		}
	}
	*/
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
		public static Image CopyFromFile(string imgPath)
		{
			//*
			var img=Image.FromFile(imgPath);
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
	//*
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
