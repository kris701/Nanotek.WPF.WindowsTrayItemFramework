# Windows Tray Item Framework
A simplified and small framework to make WPF apps that run from the windows tray.
I have used this style of applications in a few of my projects, so i thought i might as well make a common package for it.
![image](https://user-images.githubusercontent.com/22596587/204892613-de669625-cda6-49fb-915e-d41d08b8a98c.png)
![image](https://user-images.githubusercontent.com/22596587/204892676-2c4c7b2b-15dc-45ce-bf44-e9edb52947b5.png)

To use it, either use the template attached, or make a WPF Window and Inherit it from the `TrayWindow` from the package.
You can then add as many `UserControls` as you want.
You can jump between views by calling the `ViewSwitcher` static class.