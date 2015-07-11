﻿using System;

namespace Utils
{
    public static class ActionHelpers
    {
        public static void Call(this Action action)
        {
            if (action != null)
                action();
        }

        public static void Call<T>(this Action<T> action, T arg)
        {
            if (action != null)
                action(arg);
        }

        public static void Call<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
        {
            if (action != null)
                action(arg1, arg2);
        }

        public static void Call<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            if (action != null)
                action(arg1, arg2, arg3);
        }

        public static void Call<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (action != null)
                action(arg1, arg2, arg3, arg4);
        }
    }
}