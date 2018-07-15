using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace chat_bot
{
	/// <summary>
	/// Чат-бот
	/// </summary>
	class ChatBot
	{
		private string question;                    // Вопрос
		private string userAnswer;					// Ответ пользователя (для обучения)
		private string path;                        // Путь к базе
		private Dictionary<string, string> samples; // База ответов
		private bool flag = true;                   // Переключатель: учеба/работа
		public event Action<string> GetStr;         // Событие


		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="_path">Путь</param>
		public ChatBot(string _path)
		{
			path = _path;
			try
			{
				samples = new Dictionary<string, string>();
				string[] strings = File.ReadAllLines(path, Encoding.GetEncoding(1251));

				for (int i = 0; i < strings.Length; i += 2)
					samples.Add(strings[i], strings[i + 1]);
			}
			catch
			{
				//если базы нет, то она остается пустой
			}

			GetStr += ChatBot_GetStr; // подписка на событие, когда говорит бот (заглушка)
			GetStr("\nВашш вопрос: ");
		}

		public string BotAnswer(string strInput)
		{
			string trSymbols = "!@#$%^&*():;-=";				// символы, которые следует удалить
			strInput = strInput.ToLower();						// перевод в нижний регистр
			strInput = Trim(strInput, trSymbols.ToCharArray()); // удаление букв

			if (samples.ContainsKey(strInput)) // поиск ответа в словаре
				return samples[strInput];
			return "";
		}

		/// <summary>
		/// Генерация ответа
		/// </summary>
		/// <param name="qw"></param>
		public void Ans(string qw)
		{
			if (flag)
			{
				question = qw;
				string ans = BotAnswer(qw);

				// переход в режим обучения
				if (ans == string.Empty)
				{
					flag = false;
					GetStr("Введите ответ: ");
				}
				// режим работы
				else
					GetStr("Ответ бота: " + ans + "\n\nВаш вопрос: "); // Ответ
			}
			// Обучуние
			else
			{
				flag = true;
				userAnswer = qw;
				Teach();
				GetStr("\nВаш вопрос: ");
			}
		}

		/// <summary>
		/// Обучение бота (вопрос-ответ)
		/// </summary>
		private void Teach()
		{
			samples.Add(question, userAnswer);		// добавление новой записи
			File.AppendAllText(path, "\n");			// сохранение в файл
			File.AppendAllText(path, (question+ "\n"));
			File.AppendAllText(path, userAnswer);
			// '\n' не отображается в блокноте! 
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

		//заглушка
		private void ChatBot_GetStr(string str)
		{

		}
	}
}
