using System;
namespace FreshDirect_CodeChallenge
{
	public class APIClient
	{

		static string authUrl = "https://api.twitter.com/oauth2/token";
		static string userTimelineUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json";
		// Encode consumer key and secret to Base64 encode
		public string getBase64EncodeString()
		{
			string concatenateKeyAndSecret = Secrets.consumerKey + ":" + Secrets.consumerSecret;
			byte[] secretAndKeyData = System.Text.Encoding.UTF8.GetBytes(concatenateKeyAndSecret);
			var base64EncodeKeyAndSecret = Convert.ToBase64String(secretAndKeyData);
			return base64EncodeKeyAndSecret;
		}

		// Get the bearer token
		public static void getBearerToken()
		{



		}

	}
}
