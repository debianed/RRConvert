/*
 * Created by SharpDevelop.
 * User: Артем
 * Date: 17.09.2018
 * Time: 21:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace RRConvert
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			//Логротейт
			if (File.Exists(Logger.logFilename)) {
				var fileInfo = new FileInfo(Logger.logFilename);
				if (fileInfo.Length > 5 * 1024 * 1024) {
					try {
						File.Delete(Logger.logFilename);
						// disable once EmptyGeneralCatchClause
					} catch (Exception) {
					}
				}
			}
			
			var TmpDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tmp");
			if (!Directory.Exists(TmpDir)) {
				try {
					Directory.CreateDirectory(TmpDir);
				}
				catch (Exception Ex) {
					Logger.Error("Ошибка создания каталога " + TmpDir + ": " + Ex.Message);
				}
			}
			
			var XSLDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XSL");
			if (!Directory.Exists(XSLDir)) {
				try {
					Directory.CreateDirectory(XSLDir);
				}
				catch (Exception Ex) {
					Logger.Error("Ошибка создания каталога " + XSLDir + ": " + Ex.Message);
				}
			}
			
			if (!File.Exists(Path.Combine(XSLDir, "Common.xsl"))) {
				SaveResourceToDisk("RRConvert.XSL.Common.xsl", Path.Combine(XSLDir, "Common.xsl"));
			}
			
			if (!File.Exists(Path.Combine(XSLDir, "Extract.xsl"))) {
				SaveResourceToDisk("RRConvert.XSL.Extract.xsl", Path.Combine(XSLDir, "Extract.xsl"));
			}
			
			if (!File.Exists(Path.Combine(XSLDir, "Footer.xsl"))) {
				SaveResourceToDisk("RRConvert.XSL.Footer.xsl", Path.Combine(XSLDir, "Footer.xsl"));
			}
			
			if (!File.Exists(Path.Combine(XSLDir, "Header.xsl"))) {
				SaveResourceToDisk("RRConvert.XSL.Header.xsl", Path.Combine(XSLDir, "Header.xsl"));
			}
			
			if (!File.Exists(Path.Combine(XSLDir, "List.xsl"))) {
				SaveResourceToDisk("RRConvert.XSL.List.xsl", Path.Combine(XSLDir, "List.xsl"));
			}
			
			if (!File.Exists(Path.Combine(XSLDir, "Notice.xsl"))) {
				SaveResourceToDisk("RRConvert.XSL.Notice.xsl", Path.Combine(XSLDir, "Notice.xsl"));
			}
			
			if (!File.Exists(Path.Combine(XSLDir, "Output.xsl"))) {
				SaveResourceToDisk("RRConvert.XSL.Output.xsl", Path.Combine(XSLDir, "Output.xsl"));
			}
			
			if (!File.Exists(Path.Combine(XSLDir, "Refusal.xsl"))) {
				SaveResourceToDisk("RRConvert.XSL.Refusal.xsl", Path.Combine(XSLDir, "Refusal.xsl"));
			}
			
			if (!File.Exists(Path.Combine(XSLDir, "CommonKV.xsl"))) {
				SaveResourceToDisk("RRConvert.XSL.CommonKV.xsl", Path.Combine(XSLDir, "CommonKV.xsl"));
			}
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			bool isFirstInstance;
			using (var mtx = new Mutex(true, "RRConvert", out isFirstInstance)) {
				if (isFirstInstance) {
					Application.Run(new MainForm());
				} else {
					// Запущен второй экземпляр - ничего не делаем
				}
			}
		}
		
		private static void SaveResourceToDisk(string ResName, string ResFile)
		{
			var resStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResName);
			
			using (var resFile = new FileStream(ResFile, FileMode.Create)) {
				var bytes = new byte[resStream.Length + 1];
				resStream.Read(bytes, 0, (int)resStream.Length);
				resFile.Write(bytes, 0, bytes.Length - 1);
				resFile.Flush();
				resFile.Close();
			}
		}
	}
}
