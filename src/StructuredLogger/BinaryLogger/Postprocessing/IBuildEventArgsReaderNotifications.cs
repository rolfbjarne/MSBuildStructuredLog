﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.Build.Logging.StructuredLogger
{
    /// <summary>
    /// An interface for notifications from BuildEventArgsReader
    /// </summary>
    public interface IBuildEventArgsReaderNotifications :
        IBuildEventStringsReader,
        IBuildFileReader
    { }
}
