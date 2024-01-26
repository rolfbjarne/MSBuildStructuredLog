﻿using Microsoft.Build.Logging.StructuredLogger;
using Xunit;

namespace StructuredLogger.Tests
{
    public class ResourceStringTests
    {
        [Fact]
        public void TestInitialize()
        {
            var resources = StringsSet.ResourcesCollection;
            var cultures = resources.Keys;

            foreach (var culture in cultures)
            {
                Strings.Initialize(culture);
            }
        }
    }
}