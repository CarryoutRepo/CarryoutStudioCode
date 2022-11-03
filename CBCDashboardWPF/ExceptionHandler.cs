using System.Windows;
using System;

namespace ClassLibrary
{
    internal static class ExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            MessageBox.Show(ex.Message, "Carryout by Chrislyn Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
