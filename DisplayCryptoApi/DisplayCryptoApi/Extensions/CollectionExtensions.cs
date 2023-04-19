﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCryptoApi.Extensions
{
    static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            return new ObservableCollection<T>(coll);
        }
    }
}
