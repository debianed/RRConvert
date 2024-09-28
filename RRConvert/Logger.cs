/*
 * Создано в SharpDevelop.
 * Пользователь: Барбышев Артем
 * Дата: 07.07.2017
 * Время: 9:13
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.IO;
using System.Reflection;

namespace RRConvert
{
	public static class Logger
	{
		#region Атрибуты
		public enum Level
		{
			Debug = 1,
			Info = 2,
			Success = 4,
			Warning = 8,
			Error = 16,
			Fatal = 32
		}
		#endregion
		
		#region Поля
		public static string logFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) + ".log");
		#endregion
		
		#region Методы
		public static void Debug(string Msg)
		{
			WriteLogMsg(Level.Debug, Msg);
		}

		public static void Info(string Msg)
		{
			WriteLogMsg(Level.Info, Msg);
		}

		public static void Success(string Msg)
		{
			WriteLogMsg(Level.Success, Msg);
		}

		public static void Warning(string Msg)
		{
			WriteLogMsg(Level.Warning, Msg);
		}

		public static void Error(string Msg)
		{
			WriteLogMsg(Level.Error, Msg);
		}

		public static void Fatal(string Msg)
		{
			WriteLogMsg(Level.Fatal, Msg);
		}
		#endregion
		
		#region
		private static void WriteLogMsg(Level Lvl, string Msg)
		{
			lock ("self") {
				StreamWriter logFile = null;
				
				if (!File.Exists(logFilename)) {
					try {
						logFile = File.CreateText(logFilename);
					} catch (Exception) {
						return;
					}
				} else {
					try {
						logFile = File.AppendText(logFilename);
					} catch (Exception) {
						return;
					}
				}
					
				DateTime tmNow = DateTime.Now;
				string logMsg = String.Format("{0} {1}  {2}: {3}",
					                tmNow.ToShortDateString(), tmNow.ToLongTimeString(),
					                Lvl.ToString().Substring(0, 1), Msg);
				logFile.AutoFlush = true;
				logFile.WriteLine(logMsg);
				logFile.Close();
			}
		}
		#endregion
	}
}
