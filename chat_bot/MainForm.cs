using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_bot
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			LoginVk vk = new LoginVk();
			vk.ShowDialog();
			vkA = new Vk(@"..\..\1.txt");
			bot.GetStr += bot_GetStr;
			bot2.GetStr += HandleAction;
			timer1.Enabled = true;
			timer2.Enabled = true;

		}

		Vk vkA;
		string myQ = string.Empty;
		string myQ2 = string.Empty;
		string old = string.Empty;
		string old2 = string.Empty;
		ChatBot bot = new ChatBot(@"..\..\answers.txt");
		ChatBot bot2 = new ChatBot(@"..\..\answers.txt");




		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		private void timer1_Tick_1(object sender, EventArgs e)
		{
			string str = vkA.GetForDialog(Convert.ToInt32(textBox1.Text));
			try
			{
				str = str.Split(new string[] { "body:"}, StringSplitOptions.None )[1];
				str = str.Split(new string[] { "user_id:" }, StringSplitOptions.None)[0];

				if ((str != myQ) && (str != old) && (str != " ") && (str != "\t") && (str != "\n") && (str != "введите ответ\n") && (str != string.Empty) && (true /*неведомое условие*/))
				{
					bot.Ans(str.Trim('\n'));
					old = str;
				}
			}
			catch{ }
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			string str = vkA.GetForDialog(Convert.ToInt32(textBox2.Text));
			try
			{
				str = str.Split(new string[] { "body:" }, StringSplitOptions.None)[1];
				str = str.Split(new string[] { "user_id:" }, StringSplitOptions.None)[0];

				if ((str != myQ2) && (str != old2) && (str != " ") && (str != "\t") && (str != "\n") && (str != "введите ответ\n") && (str != string.Empty) && (true /*неведомое условие*/))
				{
					bot2.Ans(str.Trim('\n'));
					old2 = str;
				}
			}
			catch { }
		}

		void bot_GetStr(string obj)
		{
			myQ = obj + "\n";
			vkA.SendToDialog(obj, Convert.ToInt32(textBox1.Text));
		}

		void HandleAction(string obj)
		{
			myQ2 = obj + "\n";
			vkA.SendToDialog(obj, Convert.ToInt32(textBox2.Text));
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
