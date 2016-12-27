using System;
using Foundation;
using UIKit;

namespace FreshDirect_CodeChallenge
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		UITextField userNameTextField = new UITextField();
		UIButton searchButton = new UIButton();

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			setupTextField();
			setupSearchButton();
			//APIClient.getTweets("michellebklynn", (jsonDic) =>
			//{
			//	Console.WriteLine(jsonDic);
			//})	;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public void setupTextField()
		{

			userNameTextField.Frame = new CoreGraphics.CGRect(this.View.Center.X - this.View.Frame.Width / 4 , this.View.Frame.Height/3, this.View.Frame.Width / 2, 50);
			this.View.AddSubview(userNameTextField);
			userNameTextField.Placeholder = "  Enter the screen name";
			userNameTextField.Layer.BorderWidth = 1;
			userNameTextField.Layer.CornerRadius = 10;
			userNameTextField.Layer.BorderColor = UIColor.DarkGray.CGColor;
			this.userNameTextField.ShouldReturn = delegate
			{
				userNameTextField.ResignFirstResponder();
				return true;
			};
		}

		public void setupSearchButton()
		{
			searchButton.Frame = new CoreGraphics.CGRect(this.View.Center.X-25, this.View.Frame.Height / 2, 50, 50);
			this.View.AddSubview(searchButton);
			searchButton.Layer.CornerRadius = 25;
			searchButton.SetImage(UIImage.FromFile("Images/twitter1.png"), UIControlState.Normal);
			searchButton.TouchUpInside += Button_TouchUpInside;


		}

		void Button_TouchUpInside(object sender, EventArgs e)
		{
			Console.WriteLine("Button Tapped");
			PerformSegue("showTweets", this);
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			// set the View Controller that’s powering the screen we’re
			// transitioning to

			var dest = segue.DestinationViewController as TweetsViewController;

			//set the Table View Controller’s list of phone numbers to the
			// list of dialed phone numbers

			if (dest != null)
			{
				string[] names = new string[3] { "Matt", "Joanne", "Robert" };

				dest.tweetsOfUser = names;
			}
		}
	}
}
