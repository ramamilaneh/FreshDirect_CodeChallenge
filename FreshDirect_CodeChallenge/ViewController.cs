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

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			setupTextField();
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
			userNameTextField.Placeholder = "Enter the screen name";
			this.userNameTextField.ShouldReturn = delegate 
			{
				userNameTextField.ResignFirstResponder();
				return true;
			};
		}
	}
}
