using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace chat_bot
{
	public class Vk
	{
		string _token;
		string _id;
		HttpWebRequest _hwReq;
		HttpWebResponse _hwRes;

		/// <summary>
		/// Работа с вк
		/// </summary>
		/// <param name="pathParam">Файл с настройками</param>
		public Vk(string pathParam)
		{
			string[] strs = File.ReadAllLines(pathParam);
			_token = strs[0];
			_id = strs[1];
		}

		public string SendToDialog(string msg, int userID)
		{
			string url = "http://api.vk.com/method/messages.send?user_id=" + userID + "&message=" + msg + "&access_token=" + _token + "&v=5.63";
			return Request(url);
		}

		public string GetForDialog(int userID)
		{
			string url = "http://api.vk.com/method/messages.getHistory?user_id=" + userID + "&count=1&access_token=" + _token + "&v=5.63";
			return Request(url);
		}

		string Request(string url)
		{
			_hwReq = (HttpWebRequest)HttpWebRequest.Create(url);
			_hwRes = (HttpWebResponse)_hwReq.GetResponse();
			string output = string.Empty;

			using (StreamReader stream = new StreamReader(_hwRes.GetResponseStream(), Encoding.UTF8))
			{
				output = stream.ReadToEnd();
			}

			output = HttpUtility.UrlDecode(output);
			output = output.Replace("{", "\n").Replace("}", "").Replace(",\"","\n").Replace("\"","");

			return output;
		}

	}
}
