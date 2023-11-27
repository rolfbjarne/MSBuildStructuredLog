﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Microsoft.Build.Logging.StructuredLogger;

public interface IBuildFileReader
{
    /// <summary>
    /// An event that allows the caller to be notified when an embedded file is encountered in the binary log.
    /// Subscribing to this event obligates the subscriber to read the file content and set the resulting content
    ///  via <see cref="ArchiveFileEventArgs.SetResult(string,System.IO.Stream)"/> or <see cref="ArchiveFileEventArgs.SetResult(string,string)"/>.
    /// When subscriber is OK with greedy reading entire content of the file, it can simplify subscribing to this event,
    /// by using handler with same signature as handler for <see cref="IBuildEventStringsReader.StringReadDone"/> and wrapping it via
    /// <see cref="ArchiveFileEventArgsExtensions.ToArchiveFileHandler"/> extension.
    ///
    /// <example>
    /// <code>
    /// private void OnStringReadDone(StringReadEventArgs e)
    /// {
    ///     e.StringToBeUsed = e.StringToBeUsed.Replace("foo", "bar");
    /// }
    ///
    /// private void SubscribeToEvents()
    /// {
    ///     reader.StringReadDone += OnStringReadDone;
    ///     reader.ArchiveFileEncountered += ((Action&lt;StringReadEventArgs&gt;)OnStringReadDone).ToArchiveFileHandler();
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public event Action<ArchiveFileEventArgs>? ArchiveFileEncountered;
}
