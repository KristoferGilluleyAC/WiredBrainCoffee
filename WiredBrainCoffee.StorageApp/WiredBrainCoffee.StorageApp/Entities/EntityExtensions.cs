﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WiredBrainCoffee.StorageApp.Entities
{
    public static class EntityExtensions
    {
        public static T Copy<T>(this T itemToCopy) where T : IEntity
        {
            var json = JsonSerializer.Serialize<T>(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
