using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using SQLite;

namespace Razordex
{
	public class Pokemon
	{
		public int number { get; set; }
		public string name { get; set; }
		public string primary_type { get; set; }
		public string secondary_type { get; set; }
		public string biography { get; set; }
		public string primary_ability { get; set; }
		public string secondary_ability { get; set; }
	}

	public partial class RootViewController : UITableViewController
	{
		DataSource dataSource;

		public RootViewController (IntPtr handle) : base (handle)
		{
			Title = "Razordex";
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TableView.Source = dataSource = new DataSource (this);
		}
		
		class DataSource : UITableViewSource
		{
			static readonly NSString CellIdentifier = new NSString ("DataSourceCell");

			List<Pokemon> objects = new List<Pokemon> ();

			RootViewController controller;

			public DataSource (RootViewController controller)
			{
				this.controller = controller;

				var Storage = new SQLiteConnection("pokemon.sqlite");
				foreach (var item in Storage.Table<Pokemon>())
					objects.Add(item);
			}

			public IList<Pokemon> Objects {
				get { return objects; }
			}

			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return objects.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = (UITableViewCell)tableView.DequeueReusableCell (CellIdentifier, indexPath);

				cell.TextLabel.Text = objects [indexPath.Row].name;

				return cell;
			}

			public override bool CanEditRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				return false;
			}
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail") {
				var indexPath = TableView.IndexPathForSelectedRow;
				var item = dataSource.Objects [indexPath.Row];

				((DetailViewController)segue.DestinationViewController).SetDetailItem (item);
			}
		}
	}
}

