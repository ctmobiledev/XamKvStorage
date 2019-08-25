# XamKvStorage

Xamarin Key/Value Storage


Author: 

Charles Tatum II


Version: 

1.0.0



Summary:

Local key-value storage option for Xamarin.



Description:

XamKvStorage emulates the localStorage (Web storage) feature found in the JavaScript language.  Its intended use is the storage of simple local variables such as user settings, preferences, etc.  It is not intended to replace any kind of database functionality such as is found with SQLite.  

XamKvStorage stores all key-value pairs using the user settings object particular to each platform:

- For Android, SharedPreferences
- For iOS, NSUserDefaults
- For Windows/UWP, LocalSettings

The main methods are as follows:

    GetValue(key) - Returns the value of a key-value pair as a string.  If the key doesn't exist, 
    return a null string.

    SetValue(key, value) - Inserts a key-value pair to local storage.

    DeleteValue(key) - Removes the key-value pair.


**********
IMPORTANT!
**********

All values associated with this product MUST BE STRINGS.  If the storage of Booleans, numerical values, dates, or other non-string values are desired, ALL such values MUST be converted to strings FIRST.  Upon retrieval using GetData, such values can be restored to their original data types using an appropriate "Parse" method/function.


**********
Best Way To Consume/Use
**********

This solution, like many others in Xamarin.Forms, is reliant on the DependencyService, which acts as a sort of three-prong traffic manager.  Based on the Interface associated with a particular instance of the service, one of the three versions of a method will be utilized when called - for Windows, iOS, or Android. 

There really isn't that much to using XamKvStorage. Here are the basic steps to incorporating it into a project:

1. Copy the IXamKvStorage into the common part of the Xamarin.Forms project. This is usually at the very top of the Visual Studio solution in the explorer at screen right.

2. Copy XamKvStorage.cs from the XamKvStorage.Android project into the ".Android" solution in your target Visual Studio project.

3. Copy XamKvStorage.cs from the XamKvStorage.iOS project into the ".iOS" solution in your target Visual Studio project.

4. Copy XamKvStorage.cs from the XamKvStorage.UWP project into the ".UWP" solution in your target Visual Studio project.

NOTE: Be sure to make appropriate adjustments to the "using" statements at the top of file for the three namespaces - XamKvStorage.UWP, XamKvStorage.iOS and XamKvStorage.Android. Look at the three "XamKvStorage.cs" files at the top of each folder.

5. Wherever use of the three methods - SetValue, GetValue, DeleteValue - is needed, simply include a declaration for the DependencyService that references Interface IXamKvStorage.  In the MainPage file, for example, this is assigned to an object called "localSettings".

6. Use the method calls, qualified by the object name from #5 (e.g., "localSettings.GetValue('Name')"). See examples of this in the event handler for the Button in MainPage.cs.

In this way, the quick and simple saving of small amounts of local data for an app can be implemented easily, without having to resort to a SQLite table or convoluted binary-based solution.  
