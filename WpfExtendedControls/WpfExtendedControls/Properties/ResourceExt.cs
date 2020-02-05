﻿/*
 *  Wpf extended user controls for using it in WPF applications
 *  Copyright (C) 2020  Yugov V. Maxim
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
using System;
using System.Reflection;

namespace WpfExtendedControls.Properties
{
    public static class ResourcesSearcher
    {
        public static string GetString(Type resourceType, string resourceName)
        {
            if (resourceType == null)
                throw new ArgumentNullException(nameof(resourceType));
            if (string.IsNullOrEmpty(resourceName))
                throw new ArgumentNullException(nameof(resourceName));

            PropertyInfo property = resourceType.GetProperty(resourceName, BindingFlags.Static | BindingFlags.NonPublic);
            if (property == null)
                return $"No found: [{resourceName}] in [{resourceType.FullName}]";
            return property.GetValue(null, null).ToString();
        }
        internal static string GetString(string resourceName)
        {
            Type type = typeof(Resources);
            return GetString(type, resourceName);
        }
    }
}
