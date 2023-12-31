﻿using System.Collections.Generic;
using System.Linq;

namespace ShopEcommerce.Web.Infrastructure.Core
{
    public class Pagination<T>
    {
        public int Page { get; set; }

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public int MaxPage { set; get; }
        public IEnumerable<T> Items { get; set; }
    }
}