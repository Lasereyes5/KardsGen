/*
 * 由SharpDevelop创建。
 * 用户： pc
 * 日期: 2025/4/10
 * 时间: 13:31
 * let's all love lain!
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinDragDrop
{
	public static class WinApi
	{
		[DllImport("shell32.dll")]
		public static extern int DragAcceptFiles(IntPtr hWnd, bool fAccept);
		[DllImport("shell32.dll")]
		public static extern int DragQueryFile(IntPtr hDrop, uint iFile, [Out] StringBuilder lpszFile, int cch);
		[DllImport("shell32.dll")]
		public static extern void DragFinish(IntPtr hDrop);
		
		public const int WM_DROPFILES=0x0233;
		public const int MAX_PATH=260;
	}
	public static class FormExt
	{
		public static void OpenDrag(this Form f)
		{
			WinApi.DragAcceptFiles(f.Handle,true);
		}
		public static void OpenDrag(this Control c)
		{
			WinApi.DragAcceptFiles(c.Handle,true);
		}
		/*
		public static string HandleFileDrop(IntPtr hDrop,int strLength=WinApi.MAX_PATH)
		{
			StringBuilder sb = new StringBuilder(strLength);
			WinApi.DragQueryFile(hDrop, 0, sb, strLength);
			string s = sb.ToString();
			
			WinApi.DragFinish(hDrop); // 必须调用以释放资源
			return s;
		}
		*/
		
		public static string[] HandleFileDrop(IntPtr hDrop)
		{
			//StringBuilder sbnull=null;
			uint fileCount = (uint)WinApi.DragQueryFile(hDrop, 0xFFFFFFFF, null, 0);
			
			string[] sArr=new string[fileCount];
			for (uint i = 0; i < fileCount; i++)
			{
				StringBuilder sb = new StringBuilder(WinApi.MAX_PATH);
				WinApi.DragQueryFile(hDrop, i, sb, WinApi.MAX_PATH);
				sArr[i] = sb.ToString();
			}
			
			WinApi.DragFinish(hDrop); // 必须调用以释放资源
			return sArr;
		}
		
	}
}
/*
	public partial class MainForm : Form
	{
		//...
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WinApi.WM_DROPFILES:
					WinDragDrop(m.WParam);
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}
	}
*/