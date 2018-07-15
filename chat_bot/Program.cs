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
		static void Main(string[] args)
		{
			var answersDictionary = GenerationAnswers("answers.txt"); // Словарь ответов бота


			while (true)
			{
				Console.Write("Ваш вопрос: ");
				string strInput = Console.ReadLine(); // Ввод вопроса
				Console.WriteLine("Ответ бота: " + BotAnswer(strInput, answersDictionary) + "\n");
			}
		}

		/// <summary>
		/// Генерация ответа бота
		/// </summary>
		/// <param name="strInput"></param>
		/// <returns></returns>
		public static string BotAnswer(string strInput, Dictionary<string, string> answers)
		{
			string trSymbols = "!@#$%^&*():;-="; // символы, которые следует удалить
			strInput = strInput.ToLower();
			strInput = Trim(strInput, trSymbols.ToCharArray()); // удаление букв

			if (answers.ContainsKey(strInput))
				return answers[strInput];

			return "I don't know what to say";
		}

		public static Dictionary<string, string> GenerationAnswers(string path)
		{
			var res = new Dictionary<string, string>();
			string[] strings = File.ReadAllLines(path);

			for (int i = 0; i < strings.Length; i+=2)
				res.Add(strings[i], strings[i+1]);
			return res;
		}


		/// <summary>
		/// Удаление символов
		/// </summary>
		/// <param name="str"></param>
		/// <param name="symbolsDelete"></param>
		/// <returns></returns>
		public static string Trim(string str, char[] symbolsDelete)
		{
			string strRes = str;
			foreach (var x in symbolsDelete)
				strRes = strRes.Replace(char.ToString(x), "");

			return strRes;
		}
	}
}