﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Extensions
{
    public static class TaskExtension
    {
        public static Task WhenAny(this IEnumerable<Task> tasks) => Task.WhenAny(tasks);

        public static Task<Task<TResult>> WhenAny<TResult>(this IEnumerable<Task<TResult>> tasks)
            => Task.WhenAny(tasks);

        public static Task WhenAll(this IEnumerable<Task> tasks) => Task.WhenAll(tasks);

        public static Task<TResult[]> WhenAll<TResult>(this IEnumerable<Task<TResult>> tasks)
            => Task.WhenAll(tasks);

        public static Task<T> FromDefault<T>() => Task.FromResult(default(T));
    }
}
