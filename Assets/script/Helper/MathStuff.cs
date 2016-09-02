﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public static class MathStuff
    {

        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                && Comparer<T>.Default.Compare(item, end) <= 0;
        }
    }

