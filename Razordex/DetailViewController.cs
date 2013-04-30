using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Razordex
{
	public partial class DetailViewController : UIViewController
	{
		Pokemon detailItem;
		
		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		public void SetDetailItem (Pokemon newDetailItem)
		{
			if (detailItem != newDetailItem) {
				detailItem = newDetailItem;

				ConfigureView ();
			}
		}
		
		void ConfigureView ()
		{
			if (!IsViewLoaded || detailItem == null)
				return;

			Title = detailItem.name;

			var template = new PokemonHTMLView () { Model = detailItem };
			webDetailView.LoadHtmlString (template.GenerateString (), NSBundle.MainBundle.BundleUrl);
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ConfigureView ();
		}
	}
}

