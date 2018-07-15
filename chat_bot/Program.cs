using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace chat_bot
{
	class Program
	{
		static void bot_GetStr(string str)
		{
			Console.WriteLine(str); // вывод ответа
		}

		static void Main(string[] args)
		{
			ChatBot bot = new ChatBot(@"..\..\answers.txt");
			bot.GetStr += bot_GetStr;

			while (true)
			{
				string strInput = Console.ReadLine(); // Ввод вопроса
				bot.Ans(strInput);
			}
		}
	}
}