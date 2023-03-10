using System.Collections.Generic;
using AView = Android.Views.View;
using AViewGroup = Android.Views.ViewGroup;

namespace Xamarin.Forms.Platform.Android
{
	internal static class ViewGroupExtensions
	{
		internal static IEnumerable<T> GetChildrenOfType<T>(this AViewGroup self) where T : AView
		{
			for (var i = 0; i < self.ChildCount; i++)
			{
				AView child = self.GetChildAt(i);
				var typedChild = child as T;
				if (typedChild != null)
					yield return typedChild;

				if (child is AViewGroup)
				{
					IEnumerable<T> myChildren = (child as AViewGroup).GetChildrenOfType<T>();
					foreach (T nextChild in myChildren)
						yield return nextChild;
				}
			}
		}

		public static T GetFirstChildOfType<T>(this AViewGroup viewGroup) where T : AView
		{
			for (var i = 0; i < viewGroup.ChildCount; i++)
			{
				AView child = viewGroup.GetChildAt(i);

				if (child is T typedChild)
					return typedChild;

				if (child is AViewGroup vg)
				{
					var descendant = vg.GetFirstChildOfType<T>();
					if (descendant != null)
					{
						return descendant;
					}
				}
			}

			return null;
		}
	}
}