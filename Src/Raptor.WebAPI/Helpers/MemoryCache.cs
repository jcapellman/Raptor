﻿using Microsoft.Extensions.Caching.Memory;

using Raptor.PCL.Common;
using Raptor.PCL.Enums;

namespace Raptor.WebAPI.Helpers {
    public class MemoryCacheHelper {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheHelper(IMemoryCache memoryCache) {
            _memoryCache = memoryCache;
        }

        public ReturnSet<T> GetCacheItem<T>(string key) {
            var item = _memoryCache.Get<T>(key);

            return item == null ? new ReturnSet<T>($"{key} was not found in cache") : new ReturnSet<T>(item);
        }

        public void AddCacheItem<T>(string key, T obj) {
            _memoryCache.Set(key, obj);
        }

        public void RemoveCacheItem(string key) {
            _memoryCache.Remove(key);
        }

        public bool ContainsKey(string key) => _memoryCache.Get(key) != null;

        public bool ContainsKey(WEBAPI_REQUESTS requestEnum) => ContainsKey(requestEnum.ToString());
    }
}