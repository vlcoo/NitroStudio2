﻿using System.Collections.Generic;
using System.Linq;
using GotaSoundIO.IO;

namespace NitroFileLoader;

/// <summary>
///     Group info.
/// </summary>
public class GroupInfo : IReadable, IWriteable
{
    /// <summary>
    ///     Entries.
    /// </summary>
    public List<GroupEntry> Entries = new();

    /// <summary>
    ///     Entry index.
    /// </summary>
    public int Index;

    /// <summary>
    ///     Name.
    /// </summary>
    public string Name;

    /// <summary>
    ///     Read the info.
    /// </summary>
    /// <param name="r">The reader.</param>
    public void Read(FileReader r)
    {
        Entries = new List<GroupEntry>();
        var numEntries = r.ReadUInt32();
        for (uint i = 0; i < numEntries; i++) Entries.Add(r.Read<GroupEntry>());
    }

    /// <summary>
    ///     Write the info.
    /// </summary>
    /// <param name="w">The writer.</param>
    public void Write(FileWriter w)
    {
        Entries = Entries.Where(x => x.Entry != null).ToList();
        w.Write((uint)Entries.Count);
        foreach (var e in Entries) w.Write(e);
    }
}