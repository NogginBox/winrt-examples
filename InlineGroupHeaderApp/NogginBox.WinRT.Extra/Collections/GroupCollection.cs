/*
 * The MIT License (MIT)
 * Copyright (c) 2012 Richard Garside - www.nogginbox.co.uk
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NogginBox.WinRT.Extra.Collections
{
	/// <summary>
	/// A collection of Groups of T that gives you easy access to all items and also selected items
	/// </summary>
	public class GroupCollection<T> : PropertyChangeNotifier
	{
		#region Constructors

		public GroupCollection(IEnumerable<String> groupTitles, Func<T, String> groupTitleFunc, Func<T, object> itemOrderFunc = null)
		{
			Groups = new ObservableCollection<Group<T>>();
			Items = new ObservableCollection<T>();
			ItemsWithHeaders = new ObservableCollection<object>();
			_groupTitleFunc = groupTitleFunc;
			_itemOrderFunc = itemOrderFunc;
			InitGroups(groupTitles);
		}

		#endregion

		#region Properties

		public ObservableCollection<Group<T>> Groups { get; private set; }

		public ObservableCollection<T> Items { get; private set; }

		public ObservableCollection<object> ItemsWithHeaders { get; private set; } 

		private readonly Func<T, String> _groupTitleFunc;

		private readonly Func<T, object> _itemOrderFunc;

		#endregion

		#region Calculated read only properties

		/// <summary>
		/// Number of items in all groups
		/// </summary>
		public int ItemCount
		{
			get
			{
				return Groups.Select(fg => fg.Items.Count).Sum();
			}
		}

		#endregion

		#region Public methods

		public void AddItems(IEnumerable<T> items)
		{
			AddItemsToGroups(items);
			AddItemsGenerateItemsList();
			RaisePropertyChanged("ItemCount");
		}

		private void AddItemsGenerateItemsList()
		{
			Items.Clear();
			ItemsWithHeaders.Clear();

			foreach (var group in Groups)
			{
				if(!group.Items.Any()) continue;

				ItemsWithHeaders.Add(group);
				foreach (var item in group.Items)
				{
					Items.Add(item);
					ItemsWithHeaders.Add(item);
				}
			}
		}

		private void AddItemsToGroups(IEnumerable<T> items)
		{
			var itemGroups = items.GroupBy(_groupTitleFunc);

			foreach (var itemGroup in itemGroups)
			{
				var title = itemGroup.Key;
				var group = Groups.FirstOrDefault(g => g.Title == title);
				if (group == null)
				{
					group = new Group<T>(title);
					InsertGroup(group);
				}

				AddNewItemsToGroup(itemGroup, group);
			}
		}

		/// <summary>
		/// Add all items that aren't already in the group
		/// </summary>
		private void AddNewItemsToGroup(IEnumerable<T> items, Group<T> group)
		{
			foreach (var item in items.Where(i => !group.Items.Contains(i)))
			{
				group.Items.Add(item);
			}

			if (_itemOrderFunc != null) group.ReorderItems(_itemOrderFunc);
		}

		public Group<T> GetGroupFor(T item)
		{
		return Groups.FirstOrDefault(fg => fg.Items.Contains(item));
		}

		/// <summary>
		/// Inserts a group in the correct place in the collection of groups
		/// </summary>
		/// <param name="group"></param>
		public void InsertGroup(Group<T> group)
		{
			var orderedTitles = Groups.Select(g => g.Title).Union(new List<String> {group.Title}).OrderBy(t => t).ToList();
			var place = orderedTitles.IndexOf(group.Title);
			Groups.Insert(place, group);
		}

		public void RemoveItem(T item)
		{
			Items.Remove(item);
			ItemsWithHeaders.Remove(item);

			var groupToRemoveFrom = GetGroupFor(item);
			groupToRemoveFrom.Items.Remove(item);
			RemoveGroupIfEmpty(groupToRemoveFrom);

			RaisePropertyChanged("ItemCount");
		}

		private void RemoveGroupIfEmpty(Group<T> group)
		{
			if (!group.Items.Any())
			{
				ItemsWithHeaders.Remove(group);
			}
		}

		public void ClearItems()
		{
			foreach (var group in Groups)
			{
				group.Items.Clear();
			}
			Items.Clear();
			ItemsWithHeaders.Clear();
			RaisePropertyChanged("ItemCount");
		}

		#endregion

		#region Init methods

		private void InitGroups(IEnumerable<String> groupTitles)
		{
			if (groupTitles == null) return;

			foreach(var groupTitle in groupTitles)
			{
				var group = new Group<T>(groupTitle);
				Groups.Add(group);
			}
		}

		#endregion
	}
}