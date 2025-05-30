﻿// Forked from http://weblogs.asp.net/pglavich/archive/2011/07/04/cacheadapter-v2-now-with-memcached-support.aspx
// https://bitbucket.org/glav/cacheadapter
// License: Ms-Pl http://www.opensource.org/licenses/MS-PL
// Forked on 2011-08-03 by 
// Changed namespaces and modified for easier use in mojoPortal
//
// Change history for this file since original fork:
// 
//

using System;

namespace mojoPortal.Web.Caching;


public delegate T GetDataToCacheDelegate<T>();

public interface ICacheProvider
{
	public T GetOrSetItem<T>(string cacheKey, Func<T> fetch, DateTime? expires = null);
	T Get<T>(string cacheKey, DateTime absoluteExpiryDate, GetDataToCacheDelegate<T> getData, bool addToPerRequestCache = false) where T : class;
	T Get<T>(string cacheKey, TimeSpan slidingExpiryWindow, GetDataToCacheDelegate<T> getData, bool addToPerRequestCache = false) where T : class;
	object GetObject(string cacheKey);
	void InvalidateCacheItem(string cacheKey);
	void Add(string cacheKey, DateTime absoluteExpiryDate, object dataToAdd);
	void Add(string cacheKey, TimeSpan slidingExpiryWindow, object dataToAdd);
	void AddToPerRequestCache(string cacheKey, object dataToAdd);
}
