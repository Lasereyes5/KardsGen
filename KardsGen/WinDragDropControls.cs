/*
 * 由SharpDevelop创建。
 * 用户： pc
 * 日期: 2025/9/23
 * 时间: 4:45
 * let's all love lain!
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace WinDragDrop
{
	/*
	public class FormWDD : Form
	{
		bool _allowWinDrop;
		[Category("Behavior")]
		[Description("WinApi version of AllowDrop property, compatible with aot.")]
		[DefaultValue(false)]
		public bool AllowWinDrop{
			get{return _allowWinDrop;}
			set{
				_allowWinDrop=value;
				WinApi.DragAcceptFiles(Handle,value);
			}
		}
		
		public delegate void StrsGeter(string[] fs);
		[Browsable(true)]
		[Description("WinApi version of DragDrop event, compatible with aot.")]
		[Category("Drag Drop")]
		public event StrsGeter WinDragDrop;
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WinApi.WM_DROPFILES:
					WinDragDrop.Invoke(FormExt.HandleFileDrop(m.WParam));
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}
		
	}
	*/
	public class PictureBoxWDD:PictureBox
	{
		bool _allowWinDrop;
		[Category("Behavior")]
		[Description("WinApi version of AllowDrop property, compatible with aot.")]
		[DefaultValue(false)]
		public bool AllowWinDrop{
			get{return _allowWinDrop;}
			set{
				_allowWinDrop=value;
				WinApi.DragAcceptFiles(Handle,value);
			}
		}
		
		public delegate void StrsGeter(string[] fs);
		[Browsable(true)]
		[Description("WinApi version of DragDrop event, compatible with aot.")]
		[Category("Drag Drop")]
		public event StrsGeter WinDragDrop;
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WinApi.WM_DROPFILES:
					WinDragDrop.Invoke(FormExt.HandleFileDrop(m.WParam));
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}
		
	}
}
