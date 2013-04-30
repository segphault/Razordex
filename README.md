# Razordex

Razordex is a simple Pokedex application for iOS that was built with Xamarin to demonstrate the use of Razor. It displays the names of the all the Pokémon in a native list view. When the user taps a Pokémon in the list, the application will display detailed information about that Pokémon in an embedded UIWebView.

The Pokémon data is all pulled from an embedded SQLite database inside of the application using SQLite-NET. The HTML content for the detail view is generated on the device at runtime using a Razor template that is compiled into the application.

Razor is a template engine that Microsoft originally developed for ASP.NET applications, but it's possible to use Razor for stand-alone templating inside of a mobile Xamarin application. I presented this demo at Xamarin Evolve 2013 in a talk about hybrid app development.

I borrowed the embedded SQLite database with Pokemon data from this project by [DavidYKay](https://github.com/DavidYKay): https://github.com/DavidYKay/Pokedex
