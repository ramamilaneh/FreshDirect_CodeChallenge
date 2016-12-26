using System;
using Foundation;
using RestSharp;
using Newtonsoft.Json;

namespace FreshDirect_CodeChallenge
{
	public class APIClient
	{

		static string authUrl = "https://api.twitter.com/oauth2/token";
		static string userTimelineUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json";

		// Encode consumer key and secret to Base64 encode
		public static string getBase64EncodeString()
		{
			string concatenateKeyAndSecret = Secrets.consumerKey + ":" + Secrets.consumerSecret;
			byte[] secretAndKeyData = System.Text.Encoding.UTF8.GetBytes(concatenateKeyAndSecret);
			var base64EncodeKeyAndSecret = Convert.ToBase64String(secretAndKeyData);
			return base64EncodeKeyAndSecret;
		}

		// Get the bearer token
		public static void getBearerToken()
		{
			var client = new RestClient(authUrl);
			var request = new RestRequest(Method.POST);
			string key = getBase64EncodeString();
			request.AddHeader("Authorization", "Basic " + key);
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
			request.AddParameter("grant_type", "client_credentials");
			client.ExecuteAsync(request, response =>
			{
				Console.WriteLine(response.Content);

			});


		}

	}
}
