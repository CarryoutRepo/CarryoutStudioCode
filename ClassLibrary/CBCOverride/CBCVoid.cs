using System;
namespace ClassLibrary.CBCOverride
{
    public static class CBCVoid //: Action
    {
        public static void Void(Action action)
        {
            action();
        }
    }
}

