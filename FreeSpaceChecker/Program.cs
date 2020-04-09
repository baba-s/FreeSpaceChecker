using CommandLine;
using Slack;
using System.IO;

namespace FreeSpaceChecker
{
	internal static class Program
	{
		private sealed class Options
		{
			[Option( "driveName", Required = true )]
			public string DriveName { get; set; }

			[Option( "webhookUrl", Required = true )]
			public string WebhookUrl { get; set; }

			[Option( "channel", Required = true )] 
			public string Channel { get; set; }

			[Option( "format", Required = true )] 
			public string Format { get; set; }
		}

		private static void Main( string[] args )
		{
			Parser.Default
				.ParseArguments<Options>( args )
				.WithParsed( c => Send( c ) )
				;
		}

		private static void Send( Options options )
		{
			var driveName  = options.DriveName;
			var webhookUrl = options.WebhookUrl;
			var channel    = options.Channel;
			var format     = options.Format;
			var info       = new DriveInfo( driveName );
			var size       = info.TotalFreeSpace / 1024d / 1024d / 1024d;
			var text       = string.Format( format, size.ToString( "0.##" ) );

			var payload = new Payload
			{
				channel = channel,
				text    = text,
			};

			IncomingWebhooks.SendMessage( webhookUrl, payload );
		}
	}
}