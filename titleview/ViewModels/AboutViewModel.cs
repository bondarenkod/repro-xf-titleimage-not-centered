using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace titleview.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = "About";
			OpenWebCommand = new Command( () => { });
		}

		public ICommand OpenWebCommand { get; }
	}
}