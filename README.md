# ICPServer

This is a server client for the **[ICPApp](https://github.com/shanjii/ICPApp)** to communicate with your Windows computer.
<br/>
Uses **[ASP.NET Core and .NET Desktop 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**, the installer will automatically detect any missing dependencies and install them when needed.
<br/>
<br/>
**[Download the installer.](https://github.com/shanjii/ICPServer/releases/tag/v1.0.0)**

## How does it work

The application runs a WPF executable with a local server inside, it receives HTTP requests from the **[ICPApp](https://github.com/shanjii/ICPApp)** and applies the inputs given from the HTTP requests using the **[WindowsInput](https://www.nuget.org/packages/WindowsInput)** library.

## Advanced configuration

You can modify the default server port (5551) by changing the values inside the **ICPServer\settings.json** file
