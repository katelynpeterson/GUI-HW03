using Ooui;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using ViewModel;

namespace MyOoui
{
    class Program
    {
        static void Main(string[] args)
        {
            Forms.Init();
            UI.Port = 12345;
            UI.Host = "localhost";
            UI.Publish("/", new Page1() { BindingContext=new ViewModel_Project()}.GetOouiElement());
            Process.Start("explorer", $"http://{UI.Host}:{UI.Port}");
            Console.ReadLine();
        }
    }
}
