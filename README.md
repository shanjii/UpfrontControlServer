# Upfront Control Server

This is a server client for **[Upfront Control](https://github.com/shanjii/UpfrontControl)** to communicate with your Windows computer.
<br/>
Uses **[ASP.NET Core and .NET Desktop 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**, the installer will automatically detect any missing dependencies and install them when needed.
<br/>
<br/>
**[Download the installer.](https://github.com/shanjii/ICPServer/releases/tag/v1.0.0)**

## How does it work

The application runs a WPF executable with a local server inside, it receives HTTP requests from the **[Upfront Control](https://github.com/shanjii/UpfrontControl)** and applies the inputs given from the HTTP requests.

## Advanced configuration

You can modify the default server port (5551) by changing the values inside **C:\Program Files\ICPServer\settings.json**
