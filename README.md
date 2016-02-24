ASP.NET MVC Final Project - BeerApp 
=======

Project Description
-------------------
**ASP.NET MVC application**

Containing:
 - public part (accessible without authentication)
 - public part (available for registered users)
 - administrative part (available for administrators only)

## Public Part##

Home page, containing cached 3 beer styles with 1 recipe and 2 beers
![enter image description here](http://s28.postimg.org/paea743hp/home.jpg)

## Private Part (Users only)##
/Available after Registration/
All Other pages, catalogues of beers, countries, beer styles, recipes, places

- route 
	- Beer/All
![enter image description here](http://s28.postimg.org/3y6s9fjjh/beers_all.jpg)
	- Beer/Add
![enter image description here](http://s28.postimg.org/6qzztgjvx/beer_add.jpg)
	- Beer/Details
![enter image description here](http://s28.postimg.org/plvqjvjxp/beer_details.jpg)
	- Place/All
![enter image description here](http://s8.postimg.org/51z4mi0ol/place_all.jpg)
	- Place/Add
![enter image description here](http://s8.postimg.org/wbai101rp/place_add.jpg)
	- Place/Details
![enter image description here](http://s30.postimg.org/cb4o4axbl/place_Det.jpg)
	- Recipe/All
![enter image description here](http://s8.postimg.org/yekx8o1kl/place_details.jpg)
	- Recipe/Add
![enter image description here](http://s30.postimg.org/n85zt2k35/add_recipe.jpg)
	- Recipe/Details
![enter image description here](http://s30.postimg.org/obq4514q9/recipe_Details.jpg)
	- BeerType/All
![enter image description here](http://s7.postimg.org/oil6d9zsb/beer_Type_al.jpg)
	- BeerType/Details
![enter image description here](http://s7.postimg.org/d8sgibuqz/beer_Type_det.jpg)
	- Country/All
![enter image description here](http://s12.postimg.org/4ryqrnsjh/cpountry_details.jpg)
	- Country/Details
![enter image description here](http://s7.postimg.org/4choee44r/coutry_details.jpg)

- controller - 13 controllers - 62 actions
	- AccountController - 21 actions
	- BaseController - 0 actions
	- BeerController - 4 actions
	- BeerController - 1 actions
	- BeerTypeController - 2 actions
	- BeerVotesController - 1 action - using AJAX
	- CountryController - 2 actions
	- ErrorController - 5 actions
	- HomeColtroller - 1 action
	- ManageController - 16 actions
	- PlaceController - 4 actions
	- PlacesController - 1 action
	- RecipeController - 4 actions
	
## Admin Part ##

All of the model in the database are shown in tables using Telerik Kendo grids. Information can be edited and exported to excel:
![enter image description here](http://s28.postimg.org/uycb99qy5/ADMIN.jpg)

- route 
	- AllBeers
	- AllPlaces
	- AllRecipes
	- AllBeerTypes
	- AllCountries
		
- controller - 7 controllers - 31 actions
	- AdminController - 1 child action
	- AllBeersController - 6 actions
	- AllBeerTypesController - 6 actions
	- AllCountriesController - 6 actions
	- AllPlacesController - 6 actions
	- AllRecipesController - 6 actions
	- BaseAdminController - 0 actions

General Requirements Fulfilled
--------------------
* Using **ASP.NET MVC** and **Visual Studio 2015** with Update 1
* Have at least **15 controllers** - 20 controllers implemented
* Have at least **40 actions** - 93 actions implemented
* You should use **Razor** template engine for generating the UI 
	* Kendo UI widgets (with the ASP.NET MVC Wrappers)
	* Use at least **3 sections** 
	*  **10 partial views**
		* 8 partials in `~/Views/Shared`
		* 2 partial in `~/Administration/Views/Shared`
		* 2 layouts used
	* Use at least **10 editor or display templates**
		* 5 editor templates - `~/Views/Shared/EditorTemplates`
		* 3 editor templates -  `~/Views`
		* 9 editor templates - `Account` and `Manage`
		* Many display templates for different models
* Using **MS SQL Server** as database back-end
	* Using **Entity Framework 6** to access your database
	* Using **repositories and service layer** 
* **2 areas** - one normal and one for administration
*  **Tables with data** with **server-side paging and sorting** 
	* for administrating models - using Kendo UI grids, 
	* and own generated listing for users
* Created **visual nice and responsive UI**  using **Bootstrap**
* Using the standard **ASP.NET Identity System** for managing users and roles
	* Registered admin with role **administrator**
* Using of **AJAX form** communication - Voting of beers
* Using **caching** of data in starting page and displaying of all entity models
* Use **Autofac** and **Automapper**
* Write at least **30 unit tests** for your logic, controllers, actions, helpers, routes, etc.
* Apply **error handling** - custom Errors added
*  **data validation** (both client-side and server-side) - for uploading .jpgs and for models' state
* **Security** holes - routes are encoded 
	* **special HTML characters** are escaped by default
* Using GitHub **branches** for writing the features.
	* [GitHub](https://github.com/ahansb/BeerApp)
* **Documentation** - reading it! (as `.md` file, including screenshots)
*  Uploaded on [The beer app](http://ahansbbeerapp.azurewebsites.net/)
> Written by ahansb (Andrej Boyadjiev) February 2016