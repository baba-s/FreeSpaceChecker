using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Slack
{
	public sealed class Payload
	{
		public string       channel;
		public string       username;
		public string       text;
		public string       icon_emoji;
		public string       icon_url;
		public Attachment[] attachments;
	}

	public sealed class Attachment
	{
		public string   fallback;
		public string   color;
		public string   pretext;
		public string   author_name;
		public string   author_link;
		public string   author_icon;
		public string   title;
		public string   title_link;
		public string   text;
		public Field[]  fields;
		public string   image_url;
		public string   thumb_url;
		public string   footer;
		public string   footer_icon;
		public string   ts;
		public string[] mrkdwn_in;
	}

	public sealed class Field
	{
		public string title;
		public string value;
		public string @short;
	}

	public static class IncomingWebhooks
	{
		public static void SendMessage( string url, Payload payload )
		{
			var json   = JsonConvert.SerializeObject( payload );
			var client = new WebClient { Encoding = Encoding.UTF8 };
			client.Headers.Add( HttpRequestHeader.ContentType, "application/json;charset=UTF-8" );
			client.UploadString( url, json );
		}
	}
}