using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace chat_bot
{
	public partial class LoginVk : Form
	{
		WebBrowser webBrowser1;
		public LoginVk()
		{
			InitializeComponent();
			//webBrowser1 = new WebBrowser();
			//webBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=6633731&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=friends&scope=messages&response_type=token&v=5.62");
		}

		private void LoginVk_Load(object sender, EventArgs e)
		{

		}

		void webBrowser1_DocumentCompleated(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			string url = "";
			string l = url.Split('s')[1];
			if (l[0] == 'a')
			{
				string[] strs = new string[2];
				strs[0] = l.Split('&')[0].Split('=')[1];
				strs[1] = l.Split('=')[3];
				File.WriteAllLines(@"..\..\1.txt", strs);
				this.Close();
			}
		}
	}
}
