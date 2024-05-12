using System;
using System.IO;
using Npgsql;
using Microsoft.Maui.Controls;
namespace english;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}

