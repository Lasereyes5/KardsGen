/*
 * 由SharpDevelop创建。
 * 用户： pc
 * 日期: 2025/3/30
 * 时间: 14:11
 * let's all love lain!
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace KardsGen
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxDeploymentCost = new System.Windows.Forms.TextBox();
			this.textBoxOperationCost = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxNation = new System.Windows.Forms.ComboBox();
			this.textBoxAtteck = new System.Windows.Forms.TextBox();
			this.comboBoxType = new System.Windows.Forms.ComboBox();
			this.textBoxdefense = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.comboBoxRarity = new System.Windows.Forms.ComboBox();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.pictureBoxImgView = new System.Windows.Forms.PictureBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImgView)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxDeploymentCost
			// 
			this.textBoxDeploymentCost.Location = new System.Drawing.Point(13, 13);
			this.textBoxDeploymentCost.Name = "textBoxDeploymentCost";
			this.textBoxDeploymentCost.Size = new System.Drawing.Size(21, 21);
			this.textBoxDeploymentCost.TabIndex = 0;
			this.textBoxDeploymentCost.TextChanged += new System.EventHandler(this.TextBoxDeploymentCostTextChanged);
			// 
			// textBoxOperationCost
			// 
			this.textBoxOperationCost.Location = new System.Drawing.Point(57, 13);
			this.textBoxOperationCost.Name = "textBoxOperationCost";
			this.textBoxOperationCost.Size = new System.Drawing.Size(21, 21);
			this.textBoxOperationCost.TabIndex = 1;
			this.textBoxOperationCost.TextChanged += new System.EventHandler(this.TextBoxOperationCostTextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(41, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(10, 21);
			this.label1.TabIndex = 2;
			this.label1.Text = "K";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxNation
			// 
			this.comboBoxNation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxNation.FormattingEnabled = true;
			this.comboBoxNation.Location = new System.Drawing.Point(84, 14);
			this.comboBoxNation.Name = "comboBoxNation";
			this.comboBoxNation.Size = new System.Drawing.Size(69, 20);
			this.comboBoxNation.TabIndex = 3;
			this.comboBoxNation.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNationSelectedIndexChanged);
			// 
			// textBoxAtteck
			// 
			this.textBoxAtteck.Location = new System.Drawing.Point(14, 148);
			this.textBoxAtteck.Name = "textBoxAtteck";
			this.textBoxAtteck.Size = new System.Drawing.Size(21, 21);
			this.textBoxAtteck.TabIndex = 4;
			this.textBoxAtteck.TextChanged += new System.EventHandler(this.TextBoxAtteckTextChanged);
			// 
			// comboBoxType
			// 
			this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxType.FormattingEnabled = true;
			this.comboBoxType.Location = new System.Drawing.Point(41, 148);
			this.comboBoxType.Name = "comboBoxType";
			this.comboBoxType.Size = new System.Drawing.Size(86, 20);
			this.comboBoxType.TabIndex = 5;
			this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTypeSelectedIndexChanged);
			// 
			// textBoxdefense
			// 
			this.textBoxdefense.Location = new System.Drawing.Point(133, 148);
			this.textBoxdefense.Name = "textBoxdefense";
			this.textBoxdefense.Size = new System.Drawing.Size(21, 21);
			this.textBoxdefense.TabIndex = 6;
			this.textBoxdefense.TextChanged += new System.EventHandler(this.TextBoxdefenseTextChanged);
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(14, 175);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(140, 21);
			this.textBoxName.TabIndex = 7;
			this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxNameTextChanged);
			// 
			// comboBoxRarity
			// 
			this.comboBoxRarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxRarity.FormattingEnabled = true;
			this.comboBoxRarity.Location = new System.Drawing.Point(41, 273);
			this.comboBoxRarity.Name = "comboBoxRarity";
			this.comboBoxRarity.Size = new System.Drawing.Size(86, 20);
			this.comboBoxRarity.TabIndex = 9;
			this.comboBoxRarity.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRaritySelectedIndexChanged);
			// 
			// pictureBoxPreview
			// 
			this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPreview.Location = new System.Drawing.Point(160, 13);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new System.Drawing.Size(200, 280);
			this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPreview.TabIndex = 10;
			this.pictureBoxPreview.TabStop = false;
			this.pictureBoxPreview.Click += new System.EventHandler(this.PictureBoxPreviewClick);
			// 
			// pictureBoxImgView
			// 
			this.pictureBoxImgView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxImgView.Location = new System.Drawing.Point(12, 40);
			this.pictureBoxImgView.Name = "pictureBoxImgView";
			this.pictureBoxImgView.Size = new System.Drawing.Size(140, 102);
			this.pictureBoxImgView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxImgView.TabIndex = 11;
			this.pictureBoxImgView.TabStop = false;
			this.pictureBoxImgView.Click += new System.EventHandler(this.PictureBoxImgViewClick);
			this.pictureBoxImgView.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxImgViewPaint);
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Location = new System.Drawing.Point(14, 202);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(140, 65);
			this.textBoxDescription.TabIndex = 12;
			this.textBoxDescription.TextChanged += new System.EventHandler(this.TextBoxDescriptionTextChanged);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 306);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.pictureBoxImgView);
			this.Controls.Add(this.pictureBoxPreview);
			this.Controls.Add(this.comboBoxRarity);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.textBoxdefense);
			this.Controls.Add(this.comboBoxType);
			this.Controls.Add(this.textBoxAtteck);
			this.Controls.Add(this.comboBoxNation);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxOperationCost);
			this.Controls.Add(this.textBoxDeploymentCost);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "KardsGen";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainFormDragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainFormDragEnter);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImgView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.PictureBox pictureBoxImgView;
		private System.Windows.Forms.PictureBox pictureBoxPreview;
		private System.Windows.Forms.ComboBox comboBoxRarity;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxdefense;
		private System.Windows.Forms.ComboBox comboBoxType;
		private System.Windows.Forms.TextBox textBoxAtteck;
		private System.Windows.Forms.ComboBox comboBoxNation;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxOperationCost;
		private System.Windows.Forms.TextBox textBoxDeploymentCost;
	}
}
