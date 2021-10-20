using NogginBox.WinRT.Extra.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace InlineGroupHeaderApp.Selectors
{
	class ItemOrHeaderSelector : DataTemplateSelector
	{
		public DataTemplate Group { get; set; }
		public DataTemplate Item { get; set; }

		protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
		{
			var itemType = item.GetType();
			var isGroup = itemType.Name == "Group`1" && itemType.Namespace == "NogginBox.WinRT.Extra.Collections";

			// Disable headers so they can't be selected - NOt used in this example, but useful
			var selectorItem = container as SelectorItem;
			if (selectorItem != null)
			{
				selectorItem.IsEnabled = !isGroup;
			}

			return (isGroup) ? Group : Item;
		}
	}
}
