/*
 * Created by SharpDevelop.
 * User: Артем
 * Date: 17.09.2018
 * Time: 21:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RRConvert
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button SelectFolderBtn;
		private System.Windows.Forms.ListBox FilesBox;
		private System.Windows.Forms.Button ConvertSBtn;
		private System.Windows.Forms.ProgressBar Progress;
		private System.Windows.Forms.FolderBrowserDialog FolderDlg;
		private System.Windows.Forms.Button ConvertABtn;
		private System.Windows.Forms.Button UpdBtn;
		
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
			this.SelectFolderBtn = new System.Windows.Forms.Button();
			this.FilesBox = new System.Windows.Forms.ListBox();
			this.ConvertSBtn = new System.Windows.Forms.Button();
			this.Progress = new System.Windows.Forms.ProgressBar();
			this.FolderDlg = new System.Windows.Forms.FolderBrowserDialog();
			this.ConvertABtn = new System.Windows.Forms.Button();
			this.UpdBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SelectFolderBtn
			// 
			this.SelectFolderBtn.Location = new System.Drawing.Point(4, 4);
			this.SelectFolderBtn.Name = "SelectFolderBtn";
			this.SelectFolderBtn.Size = new System.Drawing.Size(644, 23);
			this.SelectFolderBtn.TabIndex = 0;
			this.SelectFolderBtn.Text = "Выбрать каталог с ответами из Росреестра";
			this.SelectFolderBtn.UseVisualStyleBackColor = true;
			this.SelectFolderBtn.Click += new System.EventHandler(this.SelectFolderBtnClick);
			// 
			// FilesBox
			// 
			this.FilesBox.FormattingEnabled = true;
			this.FilesBox.Location = new System.Drawing.Point(8, 36);
			this.FilesBox.Name = "FilesBox";
			this.FilesBox.Size = new System.Drawing.Size(768, 459);
			this.FilesBox.TabIndex = 1;
			// 
			// ConvertSBtn
			// 
			this.ConvertSBtn.Location = new System.Drawing.Point(8, 500);
			this.ConvertSBtn.Name = "ConvertSBtn";
			this.ConvertSBtn.Size = new System.Drawing.Size(380, 23);
			this.ConvertSBtn.TabIndex = 2;
			this.ConvertSBtn.Text = "Конвертировать выбранный файл";
			this.ConvertSBtn.UseVisualStyleBackColor = true;
			this.ConvertSBtn.Click += new System.EventHandler(this.ConvertSBtnClick);
			// 
			// Progress
			// 
			this.Progress.Location = new System.Drawing.Point(8, 532);
			this.Progress.Name = "Progress";
			this.Progress.Size = new System.Drawing.Size(768, 23);
			this.Progress.TabIndex = 3;
			// 
			// ConvertABtn
			// 
			this.ConvertABtn.Location = new System.Drawing.Point(396, 500);
			this.ConvertABtn.Name = "ConvertABtn";
			this.ConvertABtn.Size = new System.Drawing.Size(380, 23);
			this.ConvertABtn.TabIndex = 4;
			this.ConvertABtn.Text = "Конвертировать все файлы";
			this.ConvertABtn.UseVisualStyleBackColor = true;
			this.ConvertABtn.Click += new System.EventHandler(this.ConvertABtnClick);
			// 
			// UpdBtn
			// 
			this.UpdBtn.Location = new System.Drawing.Point(652, 4);
			this.UpdBtn.Name = "UpdBtn";
			this.UpdBtn.Size = new System.Drawing.Size(124, 23);
			this.UpdBtn.TabIndex = 5;
			this.UpdBtn.Text = "Обновить";
			this.UpdBtn.UseVisualStyleBackColor = true;
			this.UpdBtn.Click += new System.EventHandler(this.UpdBtnClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.UpdBtn);
			this.Controls.Add(this.ConvertABtn);
			this.Controls.Add(this.Progress);
			this.Controls.Add(this.ConvertSBtn);
			this.Controls.Add(this.FilesBox);
			this.Controls.Add(this.SelectFolderBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "MainForm";
			this.Text = "Конвертер ответов из Росреестра";
			this.ResumeLayout(false);

		}
	}
}
