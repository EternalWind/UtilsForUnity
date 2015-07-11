using System;

namespace Utils
{
    public static class FunctionHelpers
    {
        public static TResult Call<TResult>(this Func<TResult> func)
        {
            if (func != null)
                return func();

            return default(TResult);
        }

        public static TResult Call<T, TResult>(this Func<T, TResult> func, T arg)
        {
            if (func != null)
                return func(arg);

            return default(TResult);
        }

        public static TResult Call<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
        {
            if (func != null)
                return func(arg1, arg2);

            return default(TResult);
        }

        public static TResult Call<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3)
        {
            if (func != null)
                return func(arg1, arg2, arg3);

            return default(TResult);
        }

        public static TResult Call<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (func != null)
                return func(arg1, arg2, arg3, arg4);

            return default(TResult);
        }
    }
}