# [C#/MVC/SQL](https://www.tutorialspoint.com/mvc_framework/mvc_framework_introduction.htm)-Band Tracker

## **`[WARNING]:`** **`Some aspects of this README.md file are only viewable when rendering this Markdown file in your editor-of-choice and may not display the formatting properly if viewed via GitHub.`**
* An alternative method to view this README.md file with its formatting intact is for example, use of the [Atom](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&cad=rja&uact=8&ved=0ahUKEwjyvuTvvL7XAhUR8WMKHcNoA2YQFggmMAA&url=https%3A%2F%2Fatom.io%2F&usg=AOvVaw2f1xmShfpKULMHZBtecYLV) editor based on your OS:
    * Install Atom
    * Go into Atom's Preferences
    * Click on Packages and Search for keyword "markdown"
    * Click on the "settings" button for markdown-preview
    * Select the box "Use GitHub style".

#### This is code for Project#4 of the C Sharp Course

#### By **Alan Falcon**

## Description

This website is our fourth project in the C# course and incorporates MVC and SQL concepts. This site tracks bands and the venues where they've played concerts.

## Setup/Installation Requirements

| Preparation |
|:---|
|• You may view this project at: https://falconswoosh.github.io/BandTracker.Solution<br/>• This project may be [cloned](https://help.github.com/articles/cloning-a-repository/) or [downloaded](https://www.infragistics.com/community/cfs-filesystemfile.ashx/__key/CommunityServer.Blogs.Components.WeblogFiles/dhananjay_5F00_kumar.visualstudiogithib/0285.img3.png) as a .ZIP file from:  https://github.com/falconswoosh/BandTracker.Solution.git<br/>• Install .NET SDK, .NET Runtime, Git, [MAMP](https://techterms.com/definition/mamp), and Mono (refer to links in **Technologies Used** section below). Once MAMP (which installs [mySQL](https://docs.oracle.com/database/121/SQLRF/toc.htm)) is installed, you verify or customize the [port](https://www.pcdailytips.com/wp-content/uploads/2017/01/ports-setweb-mysql.png) configuration based on your system, you have clicked on [Start Servers](https://img.webnots.com/2014/10/MAMP-Apache-Server-Not-Started-with-Mac-Yosemite.png), and the servers show they [are running](https://img.webnots.com/2014/10/MAMP-Apache-Server-Not-Started-with-Mac-Yosemite.png), continue with the steps below for configuration and finally to interact with this project...|

| Database schema for this project: |
|:---:|
|![Database Schema1](https://github.com/falconswoosh/BandTracker.Solution2/blob/master/BandTracker/wwwroot/img/schema.PNG?raw=true "This displays the database schema for this project")|
<table style="background-color: #000;" style="color:#0000ff;" border=2 cellspacing=2 cellpadding=2>
  <tr>
    <td colspan="2" bgcolor="white;" style="text-align:center;"><font color=#fff;" font-family: Babas; font-size: 6em;">Launching MAMP and Creating mySQL databases for this project<br>(ensure you verify installation location and adjust to your particular installation and OS.)</font></td>
  </tr>
  <tr>
    <td bgcolor="#3B9FF;" style="text-align:center;"><font color=#ffff00;" font-family: Babas; font-size: 4em;">Windows</font></td>
    <td bgcolor="#3B9FF;" style="text-align:center;"><font color=#ffff00;" font-family: Babas; font-size: 4em;">MAC</font></td>
  </tr>
  <tr>
    <td>C:\MAMP\bin\mysql\bin -uroot -proot</td>
    <td>/Applications/MAMP/Library/bin/mysql --host=localhost -uroot -proot</td>
  </tr>  
  <tr>
    <td colspan="2">`mysql>` CREATE DATABASE band_tracker;<br/>`mysql>` USE band_tracker;<br/>`mysql>` CREATE TABLE `band_tracker`.`bands` ( `id` INT NOT NULL AUTO_INCREMENT , `name`VARCHAR(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;<br/>`mysql>` CREATE TABLE `band_tracker`.`venues` ( `id` INT NOT NULL AUTO_INCREMENT , `name`VARCHAR(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;<br/>`mysql>` ALTER TABLE `bands` ADD `venue_id` INT NOT NULL AFTER `name`, ADD INDEX`venue_id` (`venue_id`);<br/>`mysql>` ALTER TABLE `venues` ADD `band_id` INT NOT NULL AFTER `name`, ADD INDEX`band_id` (`band_id`);<br/>`If wishing to modify the code`, you may also need to create the test database to verify changes don't negatively affect the project. If so, repeat the mysql steps above by replacing 'band_tracker' with 'band_tracker_test'. This will effectively create a clone of the main database structure for testing purposes allowing you to interact with the test database exclusively.<br/>&nbsp;&nbsp;&nbsp;&nbsp;• An alternative to interfacing with mySQL in a terminal is with the use of myphpAdmin that is GUI-based. [MyPhPAdmin](https://i.ytimg.com/vi/EwuL2WaPXXM/maxresdefault.jpg) is launched from within the [MAMP application](https://documentation-3.mamp.info/img/en/MAMP/windows/MainView.jpg?id=167), which brings up the MAMP website, where you may [launch myphpAdmin](https://forums.macrumors.com/attachments/screen-shot-2017-02-22-at-1-53-47-pm-png.689731/). Click [here](https://docs.phpmyadmin.net/en/latest/) for further information on myphpAdmin.</td>
  </tr>
  <tr>
    <td colspan="2" style="text-align:center;" bgcolor="red"><font color="#000" size="3.5">**Choose One Column Below**<br/></font><font color="#fff" size="2">(__certain__ commands are the same for both columns)</font></td>
  </tr>
  <tr>
  <td colspan="2" style="text-align:center;" bgcolor=";"><font style="color: #f2cf4a; font-family: Babas; font-size: 1em;">NOTE: </font>Unless you have done otherwise, this downloaded project is compressed as a .Zip file from GitHub and would be uncompressed into the folder "BandTracker.Solution". <font style="color: #f2cf4a; font-family: Babas; font-size: 1em;"><br/>Presuming you are at your Desktop folder you cloned this project to, issue the following commands in sequence within your Terminal:</font></td>
  </tr>  
  <tr>
  <td bgcolor="#3B9FF;" style="text-align:center;"><font color=#ffff00;" font-family: Babas; font-size: 4em;">`Interact with the UI Database` <br/> (default usage)</font></td>
  <td bgcolor="#3B9FF;" style="text-align:center;"><font color=#ffff00;" font-family: Babas; font-size: 4em;">`Interact with the Test Database` </font><br/> <font color=#ffff00;" font-family: Babas; font-size: 4em;">•••If you are modifying or testing the backend, then issue commands in both columns starting with the UI first. However, for the UI, skip "dotnet run" and "...//localhost..")</font></td>
  </tr>
  </tr>
  <tr>  
  <td colspan="2" style="text-align:center;">cd BandTracker.Solution</td>
  </tr>
  <tr>  
  <td colspan="2" style="text-align:center;">cd BandTracker.Solution</td>   
  </tr>
  <tr>  
  <td style="text-align:center;">cd BandTracker</td>
  <td style="text-align:center;">cd BandTracker.Tests</td>    
  </tr>
  <tr>  
  <td colspan="2" style="text-align:center;">[dotnet restore](https://bertt.files.wordpress.com/2016/09/image8.png) <br/>[dotnet build](https://offering.solutions/blog/assets/articles/wp-content/uploads/2016/11/BuildaWebAPIwithVSCodeandtheDotNetCLI_04.jpg)</td>      
  </tr>
  <td style="text-align:center;">[dotnet run](https://social.technet.microsoft.com/wiki/cfs-filesystemfile.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/5722.ASP.NET-Core-HelloWorld5.png)</td>      
  <td style="text-align:center;">[dotnet test](http://developers.de/cfs-filesystemfile.ashx/__key/CommunityServer.Blogs.Components.WeblogFiles/damir_5F00_dobric/image_5F00_0CCC2E6F.png)</td>    
  </tr>
  <tr>  
  <td>Open a browser and navigate to http://localhost:5000 to interact with this project as a user.</td>     
  <td>Interaction is mainly within the Terminal view and using your preferred editor to modify code to  <br/>address errors that either exist or introduced as part of your interaction with this project.</td>  
  </tr>  
  <tr>  
  <td colspan="2" style="text-align:center;"><font style="color: #FF9F33; font-family: Babas; font-size: 1em;">(**NOTE**: When done, [CTRL-C](http://sheepdogguides.com/srv/gra/msqclc1.png) to stop the server within Terminal as well as `in MAMP` click on [Stop Servers](https://www.mamp.info/en/images/screenshots/en_mamp-start.jpg).)</font></td>   
  </tr>
  <td></td>
  <td colspan="2" style="text-align:left;"><font style="color: #fff; font-family: Babas; font-size: 1em;">**Further Exploration**:<br/></font> If not already and if you choose to, you may use your editor-of-choice to edit and modify this project.<br/>• For example, if your editor is [Atom](https://flight-manual.atom.io/getting-started/sections/installing-atom/), issue the following in your bash if wishing to edit the Index.cshtml<br/> file from within the ...Views/Home directory for this project:
    $ [Atom Index.cshtml](http://127.0.0.1)</td>
  </tr>              
</table>

---

## Specifications    
| Implemented [X] |Item |Focus | Behavior | Input | Output | Comments |
|:--:|:---:|---|---|---|---|---|
|[&nbsp;&nbsp;&nbsp;]|1|*`User`*|Be able to create a band that have played at a Venue. | *`Select Venue:`*VenueA <br/>*`Select Band:`*Band1 | Band1 has played at VenueA | Selected this example for simplicity.
|[&nbsp;&nbsp;&nbsp;]|2| *`User`*| When viewing a single Band, list out all of the Venues that have hosted that band. | *`Select Band:`*<br />Band1| ** Band1 Venues Played: ** <br/>VenueA<br/>VenueB<br/>VenueC<br/>| Selected examples are for simplicity.|
|[&nbsp;&nbsp;&nbsp;]|3| *`User`*| (Continued from above):<br/> Have an option to add a Venue to the Band viewed. | **(Output from previous)** <br/>VenueA<br/>VenueB<br/>VenueC <br/>[Add a Venue] | (clicking on the previous link will bring up a page to add a Venue to the band)|Selected examples are for simplicity.|
|[&nbsp;&nbsp;&nbsp;]|4| *`User`*| When viewing a single concert venue, list out all of the bands that have played at that venue so far. |*`Select Venue:`*<br/> VenueA<br/>| ** Bands This Venue Has Hosted: **<br/>Band1<br/>Band2<br/>Band3  | Selected examples are for simplicity.|
|[&nbsp;&nbsp;&nbsp;]|5| *`User`*| (Continued from above):<br/> Be able to add a band to the venue.  |**(Output from previous)**<br/>  ** Bands This Venue Has Hosted: **<br/>Band1<br/>Band2<br/>Band3 <br/>[Add a Band]  | (clicking on the previous link will bring up a page to add a Band to the Venue) |Selected examples are for simplicity.|
|[&nbsp;&nbsp;&nbsp;]|6| *`User`*| Be able to enter details of a stylist. |Name: Susan<br />Work Days: Mon-Fri<br />Hours: 12pm-8pm | Name: Susan<br />Work Days: Mon-Fri<br />Hours: 12pm-8pm  | Chose minimal list to create first revision of app for look-and-feel.|
|[&nbsp;&nbsp;&nbsp;]|7| *`User`*| Be able to enter details of a client. |Name: Margaret<br />Last cut: 2017-10-19<br />Cut Style: Bob <br />Length: Short<br />Comments: Likes to have a little bit of bangs | Name: Margaret<br />Last cut: 2017-10-19<br />Cut Style: Bob <br />Length: Short<br />Comments: Likes to have a little 3-inch bangs  | Chose minimal list to create first revision of app for look-and-feel. Date format is YYYY-MM-DD.|
|[&nbsp;&nbsp;&nbsp;]|8| *`User`*| Be able to update details of a client. |*`FROM`*<br />Name: Margaret<br />Last cut: 2017-10-19<br />Cut Style: Bob <br />Length: Short<br />Comments: Likes to have a little bit of bangs <br /><br/>*`To`*<br />Name: Margaret<br />Last cut: `2017-12-15`<br />Cut Style: Bob <br />Length: Short<br />Comments: Likes to have a little bit of bangs| Name: Margaret<br />Last cut: `2017-12-15`<br />Cut Style: Bob <br />Length: Short<br />Comments: Likes to have a little bit of bangs  | If modifying Last Cut date.|
|[&nbsp;&nbsp;&nbsp;]|9| *`User`*| Be able to update details of a stylist. |*`FROM`*<br />Name: Susan<br />Work Days: `Mon-Fri`<br />Hours: 12pm-8pm <br /><br/>*`To`*<br />Name: Susan<br />Work Days: `Mon-Thu`<br />Hours: 12pm-8pm |Name: Susan<br />Work Days: `Mon-Thu`<br />Hours: 12pm-8pm | If Work Days is modified.|
|[&nbsp;&nbsp;&nbsp;]|10| *`User`*| Be able to delete a client. |Name: Margaret<br />Last cut: 2017-10-19<br />Cut Style: Bob <br />Length: Short<br />Comments: Likes to have a little bit of bangs<br/><br/>`<Delete This Client>`| (client record deleted from database) | When "Delete This Client" is clicked. |


## Known Bugs

* If viewing this project's README.md via GitHub, some formatting may not display properly.
  * An alternative method to view this README.md file with its formatting intact is for example, use of the [Atom](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&cad=rja&uact=8&ved=0ahUKEwjyvuTvvL7XAhUR8WMKHcNoA2YQFggmMAA&url=https%3A%2F%2Fatom.io%2F&usg=AOvVaw2f1xmShfpKULMHZBtecYLV) editor based on your OS:
  * Install Atom
  * Go into Atom's Preferences
  * Click on Packages and Search for keyword "markdown"
  * Click on the "settings" button for markdown-preview
  * Select the box "Use GitHub style".
* If running in Windows 10 and within Git Bash, the "dotnet build" and "dotnet run" commands may sometimes fail indicating certain files are already running or unable to bind...
  * Solution is to run CMD and do a netstat -ano | findstr 5000 and to taskkill the PID associated with port 5000. You need to reissue the netstat command until port 5000 no longer displays in the results prior to reissuing dotnet commands in Bash.

## Support and contact details

Alan Falcon email: [falconswoosh@gmail.com](falconswoosh@gmail.com)

## Technologies Used

| Technology | Windows | MAC |
|---|:---|:---|
| C# .NET Core 1.1 SDK (Software Development Kit) |  [Link too long (hover here to view link detail or right-click to copy HTML)](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe/ "https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe") | [Link too long (hover here to view link detail or right-click to copy HTML)](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-osx-x64.1.1.4.pkg/ "https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-osx-x64.1.1.4.pkg") |
| .NET Runtime |[Link too long (hover here to view link detail or right-click to copy HTML)](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe/ "https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe") | [Link too long (hover here to view link detail or right-click to copy HTML)](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-osx-x64.1.1.4.pkg/ "https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-osx-x64.1.1.4.pkg") |
| Atom | http://flight-manual.atom.io/getting-started/sections/why-atom/ | https://github.com/atom/atom/releases/download/v1.21.1/atom-mac.zip |
| CSS <td colspan=2>[Link too long (hover here to view link detail or right-click to copy HTML)](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&cad=rja&uact=8&ved=0ahUKEwjswubPlLnWAhVGVRQKHaRLBkgQFggmMAA&url=https%3A%2F%2Fgetbootstrap.com%2Fcss%2F&usg=AFQjCNFpcAPIPLCu0F7w2NDTOafHdV8Pkw/ "https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&cad=rja&uact=8&ved=0ahUKEwjswubPlLnWAhVGVRQKHaRLBkgQFggmMAA&url=https%3A%2F%2Fgetbootstrap.com%2Fcss%2F&usg=AFQjCNFpcAPIPLCu0F7w2NDTOafHdV8Pkw")  </td>|
| CSS Materialize <td colspan=2> http://materializecss.com/forms.html  </td>|
| Git | https://git-for-windows.github.io/ | [Paste the following into Bash]:<br />$ /usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"<br />$ echo 'export PATH=/usr/local/bin:$PATH' >> ~/.bash_profile<br />$ brew install git |
| GitHub<td colspan=2> https://github.com/  </td>|
| Google Chrome browser:<td colspan=2> https://www.google.com/chrome/browser/desktop/index.html <br/>  Once installed and when using Google Chrome, Ctrl-Shift-I to bring up Developer Mode as a troubleshooting tool. </td>|
| HTML<td colspan=2> http://htmlreference.io  </td>|
| Javascript<td colspan=2> https://www.javascript.com/  </td>|
| Javascript Jquery<td colspan=2> [Link too long (hover here to view link detail or right-click to copy HTML)](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&cad=rja&uact=8&ved=0ahUKEwiBj_WJlbnWAhWBLhQKHfHUAQEQFggmMAA&url=https%3A%2F%2Fjquery.com%2F&usg=AFQjCNFnz7C6MAXGLm7pVcOD_LrOjJUUiA/ "https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&cad=rja&uact=8&ved=0ahUKEwiBj_WJlbnWAhWBLhQKHfHUAQEQFggmMAA&url=https%3A%2F%2Fjquery.com%2F&usg=AFQjCNFnz7C6MAXGLm7pVcOD_LrOjJUUiA") </td> |
| MAMP (contains Apache server, [MySQL](http://www.sqlcommands.net/), [phpMyAdmin](https://www.siteground.com/tutorials/phpmyadmin/database-management/), etc.)<td colspan=2> https://en.wikipedia.org/wiki/Markdown<br>• Select either Windows or MAC<br/>• Once installed, click on [Preferences](https://img.webnots.com/2014/11/MAMP-Preferences-Settings.png) &#124; click on [Set Web & MySQL ports to 80 & 3306](https://www.pcdailytips.com/wp-content/uploads/2017/01/ports-setweb-mysql.png). &#124; Click on [Start Servers](https://img.webnots.com/2014/10/MAMP-Apache-Server-Not-Started-with-Mac-Yosemite.png)...when the servers are up, the "button" toggles to "Stop Servers"<br/>&nbsp;&nbsp;**WARNING:**&nbsp; Otherwise, for the port - you may choose to identify certain ports yourself based on your system configuration (e.g., in class it may be ports 8888/8889). If doing this however, every line in the code referring to port `3306` will need to be modified with the port you specify for mySQL. Stated another way, the code in this project may use port 80 for the Apache server and port 3306 for the mySQL server depending on which point in time and place I uploaded an update.  </td>|
| Markdown<td colspan=2> https://www.mamp.info/en/downloads/  </td>|
| Mono (Note: contains CSharp. Launch by typing [csharp](https://itech.folderit.net/wp-content/uploads/2014/06/csharp.png) within the Mono prompt. csharp is included and is a [REPL](http://www.mono-project.com/docs/tools+libraries/tools/repl/) for [testing C# commands](http://lh4.ggpht.com/__Mw4iY-4nuY/TJ8yMvRqQ9I/AAAAAAAAA7I/8_Jy51UGFkI/image_thumb%5B48%5D.png?imgmax=800)) |http://www.mono-project.com/download/#download-win | http://www.mono-project.com/download/#download-mac |
| SQL Designer<td colspan=2> (Try one of these in this order. I found the second one worked in my Windows 10 configuration via Google Chrome.) http://ondras.zarovi.cz/sql/demo/<br/>https://ondras.zarovi.cz/old/sqlold/demo/  </td>|



### License
* All rights reserved for technologies utilized.

Copyright (c) 2017 **_{MIT}_**
