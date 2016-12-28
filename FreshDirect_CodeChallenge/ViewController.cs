using System;
using CoreAnimation;
using CoreGraphics;
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
			createGradientColor();

		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			userNameTextField.Text = "";
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
			
			PerformSegue("showTweets", this);

		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			var dest = segue.DestinationViewController as TweetsViewController;
			if (dest != null)
			{
				dest.userName = userNameTextField.Text;
			}
		}

		public void createGradientColor()
		{
			var gradient = new CAGradientLayer();
			gradient.Frame = View.Bounds;
			//var firstColor = new UIColor(red: 122 / 255, green: 202 / 255, blue: 204 / 255, alpha: 1);
			var firstColor = new UIColor(red: 126 / 255, green: 242 / 255, blue: 245 / 255, alpha: (System.nfloat)0.3);

			gradient.StartPoint = new CGPoint( x:0.0,  y:0.0);
			gradient.EndPoint = new CGPoint(x: 1.0, y: 1.0);
			gradient.Locations = new NSNumber[] { new NSNumber(0),new NSNumber(0.3),new NSNumber(1)};
			gradient.Colors = new CGColor[] { firstColor.CGColor, UIColor.Cyan.CGColor,UIColor.White.CGColor };
			this.View.Layer.InsertSublayer(gradient, 0);


		}
	}
}
