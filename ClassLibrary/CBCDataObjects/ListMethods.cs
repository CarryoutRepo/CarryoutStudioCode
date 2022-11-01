using System;
namespace ClassLibrary.CBCDataObjects
{
    public static class ListMethods
    {
        private static int id = 0;
        public static int NewID() { return id++; }
    }
}

