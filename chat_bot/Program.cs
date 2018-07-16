using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Enums.Filters;
using System.Windows.Forms;

namespace chat_bot
{
	public static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			#region loginVk and send message
			//ulong appId = 6633731; // указываем id приложения
			//var api = new VkApi();
			//api.Authorize(new ApiAuthParams
			//{
			//	ApplicationId = appId,
			//	Login = "login",
			//	Password = "pass",
			//	Settings = Settings.All
			//}); // авторизуемся


			/////api.Messages.GetDialogs();
			//api.Messages.Send(new MessagesSendParams { UserId = id, Message = "hey!" }); // посылаем сообщение пользователю
			#endregion

			System.Windows.Forms.Application.Run(new MainForm());

		}

		public static void bot_GetStr(string str)
		{
			Console.WriteLine(str); // вывод ответа
		}
	}
}