/*
 * Created by SharpDevelop.
 * User: Артем
 * Date: 17.09.2018
 * Time: 21:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace RRConvert
{
	public partial class MainForm : Form
	{
		#region Поля
		private string BaseFolder = string.Empty;
		#endregion
		
		#region Конструктор
		public MainForm()
		{
			InitializeComponent();
			
			//Дополнительная инициализация
			this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
		}
		#endregion
		
		#region Обработчики событий
		private void SelectFolderBtnClick(object sender, EventArgs e)
		{
			if (FolderDlg.ShowDialog(this) == DialogResult.OK) {
				BaseFolder = FolderDlg.SelectedPath;
				
				FilesBox.Items.Clear();
				
				if (Directory.Exists(BaseFolder)) {
					string[] FilesToCnv = Directory.GetFiles(BaseFolder, "Response*.zip", SearchOption.TopDirectoryOnly);
					FilesBox.Items.AddRange(FilesToCnv);
				}
			}
		}
		
		private void ConvertSBtnClick(object sender, EventArgs e)
		{
			if (FilesBox.SelectedIndex == -1) { return; }
			Progress.Minimum = 0;
			Progress.Maximum = 1;
			Progress.Value = 0;
			string RFile = FilesBox.SelectedItem.ToString();
			ConvertFile(RFile, Path.Combine(BaseFolder, Path.GetFileNameWithoutExtension(RFile), Path.GetFileNameWithoutExtension(RFile) + ".html"));
			Progress.Value = 1;
			MessageBox.Show("Конвертирование файлов завершено", "Конвертор файлов", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		
		private void ConvertABtnClick(object sender, EventArgs e)
		{
			Progress.Minimum = 0;
			Progress.Maximum = FilesBox.Items.Count;
			Progress.Value = 0;
			foreach (string RFile in FilesBox.Items)
			{
				ConvertFile(RFile, Path.Combine(BaseFolder, Path.GetFileNameWithoutExtension(RFile), Path.GetFileNameWithoutExtension(RFile) + ".html"));
				Progress.Value += 1;
			}
			MessageBox.Show("Конвертирование файлов завершено", "Конвертор файлов", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		#endregion
		
		#region Дополнительные процедуры и функции
		private void ConvertFile(string Fl, string NewFl)
		{
			if (!File.Exists(Fl)) { return; }
			
			if (!Directory.Exists(Path.Combine(BaseFolder, Path.GetFileNameWithoutExtension(Fl)))) {
			    	try
			    	{
			    		Directory.CreateDirectory(Path.Combine(BaseFolder, Path.GetFileNameWithoutExtension(Fl)));
			    	}
			    	catch {
			    		return;
			    	}
			    }
			
			var TmpDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tmp");
			
			string[] FilesToDel = Directory.GetFiles(TmpDir, "*.*", SearchOption.TopDirectoryOnly);
			foreach (string FlToDel in FilesToDel) {
				if (File.Exists(FlToDel)) {
					try
					{
						File.Delete(FlToDel);
					} catch {
						Logger.Error("Ошибка удаления файла " + FlToDel);
					}
				}
			}
			
			ZipFile.ExtractToDirectory(Fl, TmpDir);
			string[] ZipFl = Directory.GetFiles(TmpDir, "*.zip", SearchOption.TopDirectoryOnly);
			try
			{
				ZipFile.ExtractToDirectory(ZipFl[0], TmpDir);
			}
			catch {}
			
			bool Flag = false;
			string[] XmlFile = Directory.GetFiles(TmpDir, "obj*.xml", SearchOption.TopDirectoryOnly);
			if (XmlFile.Length == 0) {
				XmlFile = Directory.GetFiles(TmpDir, "kv*.xml", SearchOption.TopDirectoryOnly);
				Flag = true;
			}
			var XPathDoc = new XPathDocument(XmlFile[0]) ;
			var XslTrans = new XslCompiledTransform();
			
			if (Flag) {
				//var Set = new XmlReaderSettings();
    			//Set.DtdProcessing = DtdProcessing.Parse;
    			//Set.ValidationType = ValidationType.DTD;
    			//Set.MaxCharactersFromEntities = 1024;
    			//Set.XmlResolver = null;
    			
    			XmlReader Reader = new XmlTextReader(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XSL", "CommonKV.xsl")));
    			XslTrans.Load(Reader);
    			//XslTrans.Load(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XSL", "CommonKV.xsl")));
			} else {
				XslTrans.Load(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XSL", "Common.xsl")));
			}
			
			var Writer = new XmlTextWriter(NewFl, Encoding.UTF8);
			XslTrans.Transform(XPathDoc, null, Writer);
			Writer.Flush();
			Writer.Close();
			
			try
			{
				File.Move(Fl, Path.Combine(BaseFolder, Path.GetFileNameWithoutExtension(Fl), Path.GetFileName(Fl)));
			}
			catch
			{
				return;
			}
		}
		
		private void UpdBtnClick(object sender, EventArgs e)
		{
				FilesBox.Items.Clear();
				
				if (Directory.Exists(BaseFolder)) {
					string[] FilesToCnv = Directory.GetFiles(BaseFolder, "Response*.zip", SearchOption.TopDirectoryOnly);
					FilesBox.Items.AddRange(FilesToCnv);
				}
		}
		#endregion
	}
}
