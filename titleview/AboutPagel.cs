using System;
using System.ComponentModel;
using System.Linq;
using titleview.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace titleview.Views
{
	public partial class AboutPage : ContentPage
	{
		static bool isImageTitleView = true;
		Button _add;
		Button _remove;
		Button _nav;
		Button _switch;
		public AboutPage()
		{
			this.BindingContext = new AboutViewModel();

			InitUI();
		}

		private void InitUI()
		{
			if (isImageTitleView)
			{
				NavigationPage.SetTitleIconImageSource(this, "icon_feed.png");
			}
			else
			{
				var title = new StackLayout
				{
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.Green,
					Children =
					{
						 new Label()
						{
							Text = "<<>>>>> | <<<<<>>", FontSize= 30
						},
					}
				};

				NavigationPage.SetTitleIconImageSource(this, null);
				NavigationPage.SetTitleView(this, title);
			}

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

					(_switch = new Button()
					{
						Text = "switch the mode", FontSize= 30
					}),
				}
			};

			_add.Clicked += (sender, args) => { ModifyToolbarButtons(1); };
			_remove.Clicked += (sender, args) => { ModifyToolbarButtons(-1); };
			_nav.Clicked += (sender, args) => { this.Navigation.PushAsync(new AboutPage()); };
			_switch.Clicked += (sender, args) =>
			{
				isImageTitleView = !isImageTitleView;
				this.InitUI();
			};
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