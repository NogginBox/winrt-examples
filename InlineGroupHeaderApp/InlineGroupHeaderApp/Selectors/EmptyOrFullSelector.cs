using System;
using InlineGroupHeaderApp.Model;
using NogginBox.WinRT.Extra.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace InlineGroupHeaderApp.Selectors
{
	class EmptyOrFullSelector : DataTemplateSelector
	{
		public DataTemplate Full { get; set; }
		public DataTemplate Empty { get; set; }

		protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
		{
			var groupItem = item as Group<Film>;
			var isEmpty = groupItem == null || groupItem.IsEmpty;

			// Disable empty items
			var selectorItem = container as SelectorItem;
			if (selectorItem != null)
			{
				selectorItem.IsEnabled = !isEmpty;
			}

			return (!isEmpty) ? Full : Empty;
		}
	}
}
