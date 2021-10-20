﻿/*
 * The MIT License (MIT)
 * Copyright (c) 2012 Richard Garside - www.nogginbox.co.uk
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using InlineGroupHeaderApp.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InlineGroupHeaderApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
			FilmZoom.ViewChangeStarted += OnZoomViewChanged;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
	        DataContext = App.FilmData;
        }

		private static void OnZoomViewChanged(object sender, SemanticZoomViewChangedEventArgs e)
		{
			if (e.SourceItem == null) return;

			if (e.SourceItem.Item.GetType() == typeof(Film))
			{
				var sourceFilm = (Film)e.SourceItem.Item;
				var fontsGroup = App.FilmData.GetGroupFor(sourceFilm);
				e.DestinationItem = new SemanticZoomLocation { Item = fontsGroup };
			}

			e.DestinationItem = new SemanticZoomLocation { Item = e.SourceItem.Item };
		}
    }
}
