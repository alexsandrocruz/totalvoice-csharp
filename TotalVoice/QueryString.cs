﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalVoice
{
    public class QueryString
    {
        private Dictionary<string, Object> Query;

        public QueryString()
        {
            Query = new Dictionary<string, Object>();
        }

        public void Add(string Key, Object Value)
        {
            Query.Add(Key, Value);
        }

        public bool IsEmpty()
        {
            return Query.Count() == 0;
        }

        public string Build()
        {
            return "?" + HttpUtility.UrlEncode(string.Join("&", Query.Select(Item => string.Format("{0}={1}", Item.Key, Item.Value))));
        }
    }
}
