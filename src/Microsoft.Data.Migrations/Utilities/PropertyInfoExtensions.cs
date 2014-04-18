﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;

namespace Microsoft.Data.Migrations.Utilities
{
    internal static class PropertyInfoExtensions
    {
        public static bool IsPublic(this PropertyInfo property)
        {
            var getter = property.GetMethod;
            var getterAccess = getter == null ? MethodAttributes.Private : (getter.Attributes & MethodAttributes.MemberAccessMask);

            var setter = property.SetMethod;
            var setterAccess = setter == null ? MethodAttributes.Private : (setter.Attributes & MethodAttributes.MemberAccessMask);

            var propertyAccess = getterAccess > setterAccess ? getterAccess : setterAccess;

            return propertyAccess == MethodAttributes.Public;
        }
    }
}