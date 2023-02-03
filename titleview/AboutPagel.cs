using System;
using System.ComponentModel;
using System.Linq;
using titleview.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace titleview.Views
{
	public partial class AboutPage : ContentPage
	{

		Button _add;
		Button _remove;
		Button _nav;
		public AboutPage()
		{
			this.BindingContext = new AboutViewModel();
			//this.ToolbarItems.Add(new ToolbarItem() { Text = "one" });
			//this.ToolbarItems.Add(new ToolbarItem() { Text = "two" });
			NavigationPage.SetTitleIconImageSource(this, "icon_feed.png");

			this.Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Children =
				{
					(_add = new Button()
					{
						Text = "+ toolbar button", FontSize= 30
					}),

					(_remove = new Button()
					{
						Text = "- toolbar button", FontSize= 30
					}),

					(_nav = new Button()
					{
						Text = "nav to child", FontSize= 30
					}),
				}
			};

			_add.Clicked += (sender, args) => { ModifyToolbarButtons(1); };
			_remove.Clicked += (sender, args) => { ModifyToolbarButtons(-1); };

			_nav.Clicked += (sender, args) => { this.Navigation.PushAsync(new AboutPage()); };
		}

		private void ModifyToolbarButtons(int to)
		{
			if (to < 0)
			{
				var btn = this.ToolbarItems.LastOrDefault();
				if (btn != null)
					this.ToolbarItems.Remove(btn);
			}
			else
			{
				if (this.ToolbarItems.Count < 2)
				{
					this.ToolbarItems.Add(new ToolbarItem() { Text = Guid.NewGuid().ToString().Substring(0, 3) });
				}
			}
		}
	}
}