/*
 * The MIT License (MIT)
 * Copyright (c) 2012 Richard Garside - www.nogginbox.co.uk
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using InlineGroupHeaderApp.Model;
using NogginBox.WinRT.Extra.Collections;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace InlineGroupHeaderApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
	    public static GroupCollection<Film> FilmData;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

			// Always loading app data to keep it simple
	        SetupAppFilmData();

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

		/// <summary>
		/// Populates app with top 250 films from IMDB
		/// </summary>
		private void SetupAppFilmData()
		{
			var films = CreateFilms();
			var yearHeaders = Enumerable.Range(1912, 100).Select(t => t.ToString());
			FilmData = new GroupCollection<Film>(yearHeaders, f => f.Year.ToString());
			FilmData.AddItems(films);
		}

	    private static IEnumerable<Film> CreateFilms()
	    {
			// Data from http://www.imdb.com/chart/top

		    yield return new Film { Link="http://www.imdb.com/title/tt0111161/", Title="The Shawshank Redemption", Year=1994};
			yield return new Film { Link="http://www.imdb.com/title/tt0068646/", Title="The Godfather", Year=1972};
			yield return new Film { Link="http://www.imdb.com/title/tt0071562/", Title="The Godfather: Part II", Year=1974};
			yield return new Film { Link="http://www.imdb.com/title/tt0110912/", Title="Pulp Fiction", Year=1994};
			yield return new Film { Link="http://www.imdb.com/title/tt0060196/", Title="The Good, the Bad and the Ugly", Year=1966};
			yield return new Film { Link="http://www.imdb.com/title/tt0050083/", Title="12 Angry Men", Year=1957};
			yield return new Film { Link="http://www.imdb.com/title/tt0108052/", Title="Schindler's List", Year=1993};
			yield return new Film { Link="http://www.imdb.com/title/tt0468569/", Title="The Dark Knight", Year=2008};
			yield return new Film { Link="http://www.imdb.com/title/tt0167260/", Title="The Lord of the Rings: The Return of the King", Year=2003};
			yield return new Film { Link="http://www.imdb.com/title/tt0137523/", Title="Fight Club", Year=1999};
			yield return new Film { Link="http://www.imdb.com/title/tt0080684/", Title="Star Wars: Episode V - The Empire Strikes Back", Year=1980};
			yield return new Film { Link="http://www.imdb.com/title/tt0073486/", Title="One Flew Over the Cuckoo's Nest", Year=1975};
			yield return new Film { Link="http://www.imdb.com/title/tt0120737/", Title="The Lord of the Rings: The Fellowship of the Ring", Year=2001};
			yield return new Film { Link="http://www.imdb.com/title/tt1375666/", Title="Inception", Year=2010};
			yield return new Film { Link="http://www.imdb.com/title/tt0099685/", Title="Goodfellas", Year=1990};
			yield return new Film { Link="http://www.imdb.com/title/tt0076759/", Title="Star Wars: Episode IV - A New Hope", Year=1977};
			yield return new Film { Link="http://www.imdb.com/title/tt0047478/", Title="Seven Samurai", Year=1954};
			yield return new Film { Link="http://www.imdb.com/title/tt0133093/", Title="The Matrix", Year=1999};
			yield return new Film { Link="http://www.imdb.com/title/tt0317248/", Title="City of God", Year=2002};
			yield return new Film { Link="http://www.imdb.com/title/tt0109830/", Title="Forrest Gump", Year=1994};
			yield return new Film { Link="http://www.imdb.com/title/tt0064116/", Title="Once Upon a Time in the West", Year=1968};
			yield return new Film { Link="http://www.imdb.com/title/tt0167261/", Title="The Lord of the Rings: The Two Towers", Year=2002};
			yield return new Film { Link="http://www.imdb.com/title/tt0034583/", Title="Casablanca", Year=1942};
			yield return new Film { Link="http://www.imdb.com/title/tt0114369/", Title="Se7en", Year=1995};
			yield return new Film { Link="http://www.imdb.com/title/tt0102926/", Title="The Silence of the Lambs", Year=1991};
			yield return new Film { Link="http://www.imdb.com/title/tt1345836/", Title="The Dark Knight Rises", Year=2012};
			yield return new Film { Link="http://www.imdb.com/title/tt0082971/", Title="Raiders of the Lost Ark", Year=1981};
			yield return new Film { Link="http://www.imdb.com/title/tt0114814/", Title="The Usual Suspects", Year=1995};
			yield return new Film { Link="http://www.imdb.com/title/tt0047396/", Title="Rear Window", Year=1954};
			yield return new Film { Link="http://www.imdb.com/title/tt0054215/", Title="Psycho", Year=1960};
			yield return new Film { Link="http://www.imdb.com/title/tt0038650/", Title="It's a Wonderful Life", Year=1946};
			yield return new Film { Link="http://www.imdb.com/title/tt0110413/", Title="Leon", Year=1994};
			yield return new Film { Link="http://www.imdb.com/title/tt0043014/", Title="Sunset Boulevard", Year=1950};
			yield return new Film { Link="http://www.imdb.com/title/tt0209144/", Title="Memento", Year=2000};
			yield return new Film { Link="http://www.imdb.com/title/tt0120586/", Title="American History X", Year=1998};
			yield return new Film { Link="http://www.imdb.com/title/tt0078788/", Title="Apocalypse Now", Year=1979};
			yield return new Film { Link="http://www.imdb.com/title/tt0103064/", Title="Terminator 2: Judgment Day", Year=1991};
			yield return new Film { Link="http://www.imdb.com/title/tt0057012/", Title="Dr. Strangelove", Year=1964};
			yield return new Film { Link="http://www.imdb.com/title/tt0120815/", Title="Saving Private Ryan", Year=1998};
			yield return new Film { Link="http://www.imdb.com/title/tt0053125/", Title="North by Northwest", Year=1959};
			yield return new Film { Link="http://www.imdb.com/title/tt0078748/", Title="Alien", Year=1979};
			yield return new Film { Link="http://www.imdb.com/title/tt0021749/", Title="City Lights", Year=1931};
			yield return new Film { Link="http://www.imdb.com/title/tt0245429/", Title="Spirited Away", Year=2001};
			yield return new Film { Link="http://www.imdb.com/title/tt0033467/", Title="Citizen Kane", Year=1941};
			yield return new Film { Link="http://www.imdb.com/title/tt0081505/", Title="The Shining", Year=1980};
			yield return new Film { Link="http://www.imdb.com/title/tt0169547/", Title="American Beauty", Year=1999};
			yield return new Film { Link="http://www.imdb.com/title/tt0027977/", Title="Modern Times", Year=1936};
			yield return new Film { Link="http://www.imdb.com/title/tt0075314/", Title="Taxi Driver", Year=1976};
			yield return new Film { Link="http://www.imdb.com/title/tt0052357/", Title="Vertigo", Year=1958};
			yield return new Film { Link="http://www.imdb.com/title/tt0435761/", Title="Toy Story 3", Year=2010};
			yield return new Film { Link="http://www.imdb.com/title/tt0407887/", Title="The Departed", Year=2006};
			yield return new Film { Link="http://www.imdb.com/title/tt0253474/", Title="The Pianist", Year=2002};
			yield return new Film { Link="http://www.imdb.com/title/tt0088763/", Title="Back to the Future", Year=1985};
			yield return new Film { Link="http://www.imdb.com/title/tt0022100/", Title="M", Year=1931};
			yield return new Film { Link="http://www.imdb.com/title/tt0050825/", Title="Paths of Glory", Year=1957};
			yield return new Film { Link="http://www.imdb.com/title/tt0036775/", Title="Double Indemnity", Year=1944};
			yield return new Film { Link="http://www.imdb.com/title/tt0090605/", Title="Aliens", Year=1986};
			yield return new Film { Link="http://www.imdb.com/title/tt0118799/", Title="Life Is Beautiful", Year=1997};
			yield return new Film { Link="http://www.imdb.com/title/tt0910970/", Title="WALL·E", Year=2008};
			yield return new Film { Link="http://www.imdb.com/title/tt0405094/", Title="The Lives of Others", Year=2006};
			yield return new Film { Link="http://www.imdb.com/title/tt0066921/", Title="A Clockwork Orange", Year=1971};
			yield return new Film { Link="http://www.imdb.com/title/tt0211915/", Title="Amelie", Year=2001};
			yield return new Film { Link="http://www.imdb.com/title/tt0056592/", Title="To Kill a Mockingbird", Year=1962};
			yield return new Film { Link="http://www.imdb.com/title/tt0056172/", Title="Lawrence of Arabia", Year=1962};
			yield return new Film { Link="http://www.imdb.com/title/tt0172495/", Title="Gladiator", Year=2000};
			yield return new Film { Link="http://www.imdb.com/title/tt0120689/", Title="The Green Mile", Year=1999};
			yield return new Film { Link="http://www.imdb.com/title/tt0482571/", Title="The Prestige", Year=2006};
			yield return new Film { Link="http://www.imdb.com/title/tt0105236/", Title="Reservoir Dogs", Year=1992};
			yield return new Film { Link="http://www.imdb.com/title/tt0032553/", Title="The Great Dictator", Year=1940};
			yield return new Film { Link="http://www.imdb.com/title/tt0082096/", Title="Das Boot", Year=1981};
			yield return new Film { Link="http://www.imdb.com/title/tt0180093/", Title="Requiem for a Dream", Year=2000};
			yield return new Film { Link="http://www.imdb.com/title/tt0041959/", Title="The Third Man", Year=1949};
			yield return new Film { Link="http://www.imdb.com/title/tt0338013/", Title="Eternal Sunshine of the Spotless Mind", Year=2004};
			yield return new Film { Link="http://www.imdb.com/title/tt0040897/", Title="The Treasure of the Sierra Madre", Year=1948};
			yield return new Film { Link="http://www.imdb.com/title/tt1675434/", Title="Untouchable", Year=2011};
			yield return new Film { Link="http://www.imdb.com/title/tt0071315/", Title="Chinatown", Year=1974};
			yield return new Film { Link="http://www.imdb.com/title/tt0095765/", Title="Cinema Paradiso", Year=1988};
			yield return new Film { Link="http://www.imdb.com/title/tt0119488/", Title="L.A. Confidential", Year=1997};
			yield return new Film { Link="http://www.imdb.com/title/tt0087843/", Title="Once Upon a Time in America", Year=1984};
			yield return new Film { Link="http://www.imdb.com/title/tt0093058/", Title="Full Metal Jacket", Year=1987};
			yield return new Film { Link="http://www.imdb.com/title/tt0071853/", Title="Monty Python and the Holy Grail", Year=1975};
			yield return new Film { Link="http://www.imdb.com/title/tt0086190/", Title="Star Wars: Episode VI - Return of the Jedi", Year=1983};
			yield return new Film { Link="http://www.imdb.com/title/tt0110357/", Title="The Lion King", Year=1994};
			yield return new Film { Link="http://www.imdb.com/title/tt0112573/", Title="Braveheart", Year=1995};
			yield return new Film { Link="http://www.imdb.com/title/tt0045152/", Title="Singin' in the Rain", Year=1952};
			yield return new Film { Link="http://www.imdb.com/title/tt0053291/", Title="Some Like It Hot", Year=1959};
			yield return new Film { Link="http://www.imdb.com/title/tt0848228/", Title="Avengers Assemble", Year=2012};
			yield return new Film { Link="http://www.imdb.com/title/tt0364569/", Title="Oldboy", Year=2003};
			yield return new Film { Link="http://www.imdb.com/title/tt0086879/", Title="Amadeus", Year=1984};
			yield return new Film { Link="http://www.imdb.com/title/tt0042876/", Title="Rashomon", Year=1950};
			yield return new Film { Link="http://www.imdb.com/title/tt0017136/", Title="Metropolis", Year=1927};
			yield return new Film { Link="http://www.imdb.com/title/tt0040522/", Title="Bicycle Thieves", Year=1948};
			yield return new Film { Link="http://www.imdb.com/title/tt0042192/", Title="All About Eve", Year=1950};
			yield return new Film { Link="http://www.imdb.com/title/tt0105695/", Title="Unforgiven", Year=1992};
			yield return new Film { Link="http://www.imdb.com/title/tt0053604/", Title="The Apartment", Year=1960};
			yield return new Film { Link="http://www.imdb.com/title/tt0081398/", Title="Raging Bull", Year=1980};
			yield return new Film { Link="http://www.imdb.com/title/tt0062622/", Title="2001: A Space Odyssey", Year=1968};
			yield return new Film { Link="http://www.imdb.com/title/tt0050212/", Title="The Bridge on the River Kwai", Year=1957};
			yield return new Film { Link="http://www.imdb.com/title/tt0070735/", Title="The Sting", Year=1973};
			yield return new Film { Link="http://www.imdb.com/title/tt0097576/", Title="Indiana Jones and the Last Crusade", Year=1989};
			yield return new Film { Link="http://www.imdb.com/title/tt0119698/", Title="Princess Mononoke", Year=1997};
			yield return new Film { Link="http://www.imdb.com/title/tt1832382/", Title="A Separation", Year=2011};
			yield return new Film { Link="http://www.imdb.com/title/tt0095016/", Title="Die Hard", Year=1988};
			yield return new Film { Link="http://www.imdb.com/title/tt0457430/", Title="Pan's Labyrinth", Year=2006};
			yield return new Film { Link="http://www.imdb.com/title/tt0363163/", Title="Downfall", Year=2004};
			yield return new Film { Link="http://www.imdb.com/title/tt0051201/", Title="Witness for the Prosecution", Year=1957};
			yield return new Film { Link="http://www.imdb.com/title/tt0372784/", Title="Batman Begins", Year=2005};
			yield return new Film { Link="http://www.imdb.com/title/tt0031679/", Title="Mr. Smith Goes to Washington", Year=1939};
			yield return new Film { Link="http://www.imdb.com/title/tt0095327/", Title="Grave of the Fireflies", Year=1988};
			yield return new Film { Link="http://www.imdb.com/title/tt0057115/", Title="The Great Escape", Year=1963};
			yield return new Film { Link="http://www.imdb.com/title/tt0361748/", Title="Inglourious Basterds", Year=2009};
			yield return new Film { Link="http://www.imdb.com/title/tt0055630/", Title="Yojimbo", Year=1961};
			yield return new Film { Link="http://www.imdb.com/title/tt1049413/", Title="Up", Year=2009};
			yield return new Film { Link="http://www.imdb.com/title/tt0059578/", Title="For a Few Dollars More", Year=1965};
			yield return new Film { Link="http://www.imdb.com/title/tt0208092/", Title="Snatch.", Year=2000};
			yield return new Film { Link="http://www.imdb.com/title/tt0080678/", Title="The Elephant Man", Year=1980};
			yield return new Film { Link="http://www.imdb.com/title/tt0047296/", Title="On the Waterfront", Year=1954};
			yield return new Film { Link="http://www.imdb.com/title/tt0050976/", Title="The Seventh Seal", Year=1957};
			yield return new Film { Link="http://www.imdb.com/title/tt0033870/", Title="The Maltese Falcon", Year=1941};
			yield return new Film { Link="http://www.imdb.com/title/tt0113277/", Title="Heat", Year=1995};
			yield return new Film { Link="http://www.imdb.com/title/tt1205489/", Title="Gran Torino", Year=2008};
			yield return new Film { Link="http://www.imdb.com/title/tt0032976/", Title="Rebecca", Year=1940};
			yield return new Film { Link="http://www.imdb.com/title/tt0114709/", Title="Toy Story", Year=1995};
			yield return new Film { Link="http://www.imdb.com/title/tt0017925/", Title="The General", Year=1926};
			yield return new Film { Link="http://www.imdb.com/title/tt0083658/", Title="Blade Runner", Year=1982};
			yield return new Film { Link="http://www.imdb.com/title/tt0050986/", Title="Wild Strawberries", Year=1957};
			yield return new Film { Link="http://www.imdb.com/title/tt0116282/", Title="Fargo", Year=1996};
			yield return new Film { Link="http://www.imdb.com/title/tt0052311/", Title="Touch of Evil", Year=1958};
			yield return new Film { Link="http://www.imdb.com/title/tt0118715/", Title="The Big Lebowski", Year=1998};
			yield return new Film { Link="http://www.imdb.com/title/tt0012349/", Title="The Kid", Year=1921};
			yield return new Film { Link="http://www.imdb.com/title/tt0089881/", Title="Ran", Year=1985};
			yield return new Film { Link="http://www.imdb.com/title/tt0086250/", Title="Scarface", Year=1983};
			yield return new Film { Link="http://www.imdb.com/title/tt0061512/", Title="Cool Hand Luke", Year=1967};
			yield return new Film { Link="http://www.imdb.com/title/tt0077416/", Title="The Deer Hunter", Year=1978};
			yield return new Film { Link="http://www.imdb.com/title/tt0401792/", Title="Sin City", Year=2005};
			yield return new Film { Link="http://www.imdb.com/title/tt0044079/", Title="Strangers on a Train", Year=1951};
			yield return new Film { Link="http://www.imdb.com/title/tt0073195/", Title="Jaws", Year=1975};
			yield return new Film { Link="http://www.imdb.com/title/tt0015864/", Title="The Gold Rush", Year=1925};
			yield return new Film { Link="http://www.imdb.com/title/tt0477348/", Title="No Country for Old Men", Year=2007};
			yield return new Film { Link="http://www.imdb.com/title/tt0025316/", Title="It Happened One Night", Year=1934};
			yield return new Film { Link="http://www.imdb.com/title/tt0395169/", Title="Hotel Rwanda", Year=2004};
			yield return new Film { Link="http://www.imdb.com/title/tt0044706/", Title="High Noon", Year=1952};
			yield return new Film { Link="http://www.imdb.com/title/tt0167404/", Title="The Sixth Sense", Year=1999};
			yield return new Film { Link="http://www.imdb.com/title/tt0091763/", Title="Platoon", Year=1986};
			yield return new Film { Link="http://www.imdb.com/title/tt0120735/", Title="Lock, Stock and Two Smoking Barrels", Year=1998};
			yield return new Film { Link="http://www.imdb.com/title/tt0064115/", Title="Butch Cassidy and the Sundance Kid", Year=1969};
			yield return new Film { Link="http://www.imdb.com/title/tt0084787/", Title="The Thing", Year=1982};
			yield return new Film { Link="http://www.imdb.com/title/tt0032138/", Title="The Wizard of Oz", Year=1939};
			yield return new Film { Link="http://www.imdb.com/title/tt0266697/", Title="Kill Bill: Vol. 1", Year=2003};
			yield return new Film { Link="http://www.imdb.com/title/tt0038787/", Title="Notorious", Year=1946};
			yield return new Film { Link="http://www.imdb.com/title/tt0117951/", Title="Trainspotting", Year=1996};
			yield return new Film { Link="http://www.imdb.com/title/tt0075686/", Title="Annie Hall", Year=1977};
			yield return new Film { Link="http://www.imdb.com/title/tt0112641/", Title="Casino", Year=1995};
			yield return new Film { Link="http://www.imdb.com/title/tt1504320/", Title="The King's Speech", Year=2010};
			yield return new Film { Link="http://www.imdb.com/title/tt1291584/", Title="Warrior", Year=2011};
			yield return new Film { Link="http://www.imdb.com/title/tt1305806/", Title="The Secret in Their Eyes", Year=2009};
			yield return new Film { Link="http://www.imdb.com/title/tt0032551/", Title="The Grapes of Wrath", Year=1940};
			yield return new Film { Link="http://www.imdb.com/title/tt0031381/", Title="Gone with the Wind", Year=1939};
			yield return new Film { Link="http://www.imdb.com/title/tt0758758/", Title="Into the Wild", Year=2007};
			yield return new Film { Link="http://www.imdb.com/title/tt0947798/", Title="Black Swan", Year=2010};
			yield return new Film { Link="http://www.imdb.com/title/tt0119217/", Title="Good Will Hunting", Year=1997};
			yield return new Film { Link="http://www.imdb.com/title/tt0079470/", Title="Life of Brian", Year=1979};
			yield return new Film { Link="http://www.imdb.com/title/tt0038355/", Title="The Big Sleep", Year=1946};
			yield return new Film { Link="http://www.imdb.com/title/tt0892769/", Title="How to Train Your Dragon", Year=2010};
			yield return new Film { Link="http://www.imdb.com/title/tt0266543/", Title="Finding Nemo", Year=2003};
			yield return new Film { Link="http://www.imdb.com/title/tt0434409/", Title="V for Vendetta", Year=2005};
			yield return new Film { Link="http://www.imdb.com/title/tt0246578/", Title="Donnie Darko", Year=2001};
			yield return new Film { Link="http://www.imdb.com/title/tt0074958/", Title="Network", Year=1976};
			yield return new Film { Link="http://www.imdb.com/title/tt0052618/", Title="Ben-Hur", Year=1959};
			yield return new Film { Link="http://www.imdb.com/title/tt0088247/", Title="The Terminator", Year=1984};
			yield return new Film { Link="http://www.imdb.com/title/tt0048424/", Title="The Night of the Hunter", Year=1955};
			yield return new Film { Link="http://www.imdb.com/title/tt0405159/", Title="Million Dollar Baby", Year=2004};
			yield return new Film { Link="http://www.imdb.com/title/tt0096283/", Title="My Neighbour Totoro", Year=1988};
			yield return new Film { Link="http://www.imdb.com/title/tt0046912/", Title="Dial M for Murder", Year=1954};
			yield return new Film { Link="http://www.imdb.com/title/tt0092005/", Title="Stand by Me", Year=1986};
			yield return new Film { Link="http://www.imdb.com/title/tt0469494/", Title="There Will Be Blood", Year=2007};
			yield return new Film { Link="http://www.imdb.com/title/tt0107048/", Title="Groundhog Day", Year=1993};
			yield return new Film { Link="http://www.imdb.com/title/tt1748122/", Title="Moonrise Kingdom", Year=2012};
			yield return new Film { Link="http://www.imdb.com/title/tt0072890/", Title="Dog Day Afternoon", Year=1975};
			yield return new Film { Link="http://www.imdb.com/title/tt1655442/", Title="The Artist", Year=2011};
			yield return new Film { Link="http://www.imdb.com/title/tt0114746/", Title="Twelve Monkeys", Year=1995};
			yield return new Film { Link="http://www.imdb.com/title/tt0245712/", Title="Amores Perros", Year=2000};
			yield return new Film { Link="http://www.imdb.com/title/tt0440963/", Title="The Bourne Ultimatum", Year=2007};
			yield return new Film { Link="http://www.imdb.com/title/tt0061722/", Title="The Graduate", Year=1967};
			yield return new Film { Link="http://www.imdb.com/title/tt0083987/", Title="Gandhi", Year=1982};
			yield return new Film { Link="http://www.imdb.com/title/tt0978762/", Title="Mary and Max", Year=2009};
			yield return new Film { Link="http://www.imdb.com/title/tt0053198/", Title="The 400 Blows", Year=1959};
			yield return new Film { Link="http://www.imdb.com/title/tt0049406/", Title="The Killing", Year=1956};
			yield return new Film { Link="http://www.imdb.com/title/tt0060827/", Title="Persona", Year=1966};
			yield return new Film { Link="http://www.imdb.com/title/tt1010048/", Title="Slumdog Millionaire", Year=2008};
			yield return new Film { Link="http://www.imdb.com/title/tt0056801/", Title="8½", Year=1963};
			yield return new Film { Link="http://www.imdb.com/title/tt0093779/", Title="The Princess Bride", Year=1987};
			yield return new Film { Link="http://www.imdb.com/title/tt0056218/", Title="The Manchurian Candidate", Year=1962};
			yield return new Film { Link="http://www.imdb.com/title/tt0061184/", Title="Who's Afraid of Virginia Woolf?", Year=1966};
			yield return new Film { Link="http://www.imdb.com/title/tt0347149/", Title="Howl's Moving Castle", Year=2004};
			yield return new Film { Link="http://www.imdb.com/title/tt0047528/", Title="La Strada", Year=1954};
			yield return new Film { Link="http://www.imdb.com/title/tt0054997/", Title="The Hustler", Year=1961};
			yield return new Film { Link="http://www.imdb.com/title/tt0065214/", Title="The Wild Bunch", Year=1969};
			yield return new Film { Link="http://www.imdb.com/title/tt0046359/", Title="Stalag 17", Year=1953};
			yield return new Film { Link="http://www.imdb.com/title/tt0075148/", Title="Rocky", Year=1976};
			yield return new Film { Link="http://www.imdb.com/title/tt1136608/", Title="District 9", Year=2009};
			yield return new Film { Link="http://www.imdb.com/title/tt0070047/", Title="The Exorcist", Year=1973};
			yield return new Film { Link="http://www.imdb.com/title/tt0268978/", Title="A Beautiful Mind", Year=2001};
			yield return new Film { Link="http://www.imdb.com/title/tt0040746/", Title="Rope", Year=1948};
			yield return new Film { Link="http://www.imdb.com/title/tt0072684/", Title="Barry Lyndon", Year=1975};
			yield return new Film { Link="http://www.imdb.com/title/tt0056217/", Title="The Man Who Shot Liberty Valance", Year=1962};
			yield return new Film { Link="http://www.imdb.com/title/tt0079944/", Title="Stalker", Year=1979};
			yield return new Film { Link="http://www.imdb.com/title/tt0382932/", Title="Ratatouille", Year=2007};
			yield return new Film { Link="http://www.imdb.com/title/tt0046250/", Title="Roman Holiday", Year=1953};
			yield return new Film { Link="http://www.imdb.com/title/tt0338564/", Title="Infernal Affairs", Year=2002};
			yield return new Film { Link="http://www.imdb.com/title/tt0401383/", Title="The Diving Bell and the Butterfly", Year=2007};
			yield return new Film { Link="http://www.imdb.com/title/tt0044081/", Title="A Streetcar Named Desire", Year=1951};
			yield return new Film { Link="http://www.imdb.com/title/tt0120382/", Title="The Truman Show", Year=1998};
			yield return new Film { Link="http://www.imdb.com/title/tt1201607/", Title="Harry Potter and the Deathly Hallows: Part 2", Year=2011};
			yield return new Film { Link="http://www.imdb.com/title/tt1220719/", Title="Ip Man", Year=2008};
			yield return new Film { Link="http://www.imdb.com/title/tt1125849/", Title="The Wrestler", Year=2008};
			yield return new Film { Link="http://www.imdb.com/title/tt0325980/", Title="Pirates of the Caribbean: The Curse of the Black Pearl", Year=2003};
			yield return new Film { Link="http://www.imdb.com/title/tt0796366/", Title="Star Trek", Year=2009};
			yield return new Film { Link="http://www.imdb.com/title/tt0058461/", Title="A Fistful of Dollars", Year=1964};
			yield return new Film { Link="http://www.imdb.com/title/tt0101414/", Title="Beauty and the Beast", Year=1991};
			yield return new Film { Link="http://www.imdb.com/title/tt0063522/", Title="Rosemary's Baby", Year=1968};
			yield return new Film { Link="http://www.imdb.com/title/tt0042546/", Title="Harvey", Year=1950};
			yield return new Film { Link="http://www.imdb.com/title/tt0198781/", Title="Monsters, Inc.", Year=2001};
			yield return new Film { Link="http://www.imdb.com/title/tt0029947/", Title="Bringing Up Baby", Year=1938};
			yield return new Film { Link="http://www.imdb.com/title/tt0107207/", Title="In the Name of the Father", Year=1993};
			yield return new Film { Link="http://www.imdb.com/title/tt0020629/", Title="All Quiet on the Western Front", Year=1930};
			yield return new Film { Link="http://www.imdb.com/title/tt0036342/", Title="Shadow of a Doubt", Year=1943};
			yield return new Film { Link="http://www.imdb.com/title/tt0087544/", Title="Nausicaä of the Valley of the Wind", Year=1984};
			yield return new Film { Link="http://www.imdb.com/title/tt0013442/", Title="Nosferatu", Year=1922};
			yield return new Film { Link="http://www.imdb.com/title/tt0079522/", Title="Manhattan", Year=1979};
			yield return new Film { Link="http://www.imdb.com/title/tt0374546/", Title="Spring, Summer, Autumn, Winter... and Spring", Year=2003};
			yield return new Film { Link="http://www.imdb.com/title/tt0095953/", Title="Rain Man", Year=1988};
			yield return new Film { Link="http://www.imdb.com/title/tt0113247/", Title="La Haine", Year=1995};
			yield return new Film { Link="http://www.imdb.com/title/tt0327056/", Title="Mystic River", Year=2003};
			yield return new Film { Link="http://www.imdb.com/title/tt1130884/", Title="Shutter Island", Year=2010};
			yield return new Film { Link="http://www.imdb.com/title/tt1139797/", Title="Let the Right One In", Year=2008};
			yield return new Film { Link="http://www.imdb.com/title/tt0319061/", Title="Big Fish", Year=2003};
			yield return new Film { Link="http://www.imdb.com/title/tt0036613/", Title="Arsenic and Old Lace", Year=1944};
			yield return new Film { Link="http://www.imdb.com/title/tt0053779/", Title="La Dolce Vita", Year=1960};
			yield return new Film { Link="http://www.imdb.com/title/tt0053221/", Title="Rio Bravo", Year=1959};
			yield return new Film { Link="http://www.imdb.com/title/tt0061811/", Title="In the Heat of the Night", Year=1967};
			yield return new Film { Link="http://www.imdb.com/title/tt0049730/", Title="The Searchers", Year=1956};
			yield return new Film { Link="http://www.imdb.com/title/tt0092067/", Title="Castle in the Sky", Year=1986};
			yield return new Film { Link="http://www.imdb.com/title/tt0094226/", Title="The Untouchables", Year=1987};
			yield return new Film { Link="http://www.imdb.com/title/tt0107688/", Title="The Nightmare Before Christmas", Year=1993};
			yield return new Film { Link="http://www.imdb.com/title/tt0109707/", Title="Ed Wood", Year=1994};
			yield return new Film { Link="http://www.imdb.com/title/tt0032599/", Title="His Girl Friday", Year=1940};
			yield return new Film { Link="http://www.imdb.com/title/tt0024216/", Title="King Kong", Year=1933};
			yield return new Film { Link="http://www.imdb.com/title/tt0066206/", Title="Patton", Year=1970};
			yield return new Film { Link="http://www.imdb.com/title/tt0070511/", Title="Papillon", Year=1973};
	    }




    }
}
