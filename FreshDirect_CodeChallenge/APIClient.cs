using System;
using Foundation;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FreshDirect_CodeChallenge
{
	public class APIClient
	{

		static string authUrl = "https://api.twitter.com/oauth2/token";
		static string userTimelineUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json";
		public delegate void handler(string bearerToken);
		public delegate void completionHandler(Dictionary<string, Object>[] jsonDic);



		// Encode consumer key and secret to Base64 encode
		public static string getBase64EncodeString()
		{
			string concatenateKeyAndSecret = Secrets.consumerKey + ":" + Secrets.consumerSecret;
			byte[] secretAndKeyData = System.Text.Encoding.UTF8.GetBytes(concatenateKeyAndSecret);
			var base64EncodeKeyAndSecret = Convert.ToBase64String(secretAndKeyData);
			return base64EncodeKeyAndSecret;
		}

		// Get the bearer token
		public static void getBearerToken(handler completion)
		{
			var client = new RestClient(authUrl);
			var request = new RestRequest(Method.POST);
			string key = getBase64EncodeString();
			request.AddHeader("Authorization", "Basic " + key);
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
			request.AddParameter("grant_type", "client_credentials");

			client.ExecuteAsync(request, response =>
			{
				Dictionary<string, string> responseJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);

				Console.WriteLine(responseJson["access_token"]);
				completion(responseJson["access_token"]);

			});


		}

		public static void getTweets(string userName, completionHandler json )
		{
			APIClient.getBearerToken((bearerToken) =>
			{
				
				var client1 = new RestClient(userTimelineUrl);
				var request1 = new RestRequest(Method.GET);
				request1.AddHeader("Authorization", "Bearer " + bearerToken);
				request1.AddParameter("screen_name", userName);
				request1.AddParameter("count", "12");

				client1.ExecuteAsync(request1, response =>
				{
					Dictionary<string, object> [] responseJson = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(response.Content);
					json(responseJson);
					Console.WriteLine(responseJson.Length);
				});

			});

		}

	}
}
