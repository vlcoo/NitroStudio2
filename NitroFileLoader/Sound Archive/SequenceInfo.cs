﻿using GotaSoundIO.IO;

namespace NitroFileLoader;

/// <summary>
///     Sequence info.
/// </summary>
public class SequenceInfo : IReadable, IWriteable
{
    /// <summary>
    ///     Bank.
    /// </summary>
    public BankInfo Bank;

    /// <summary>
    ///     Channel priority.
    /// </summary>
    public byte ChannelPriority = 0x40;

    /// <summary>
    ///     File.
    /// </summary>
    public Sequence File;

    /// <summary>
    ///     Force the file to be individualized.
    /// </summary>
    public bool ForceIndividualFile;

    /// <summary>
    ///     Entry index.
    /// </summary>
    public int Index;

    /// <summary>
    ///     Name.
    /// </summary>
    public string Name;

    /// <summary>
    ///     Player.
    /// </summary>
    public PlayerInfo Player;

    /// <summary>
    ///     Player priority.
    /// </summary>
    public byte PlayerPriority = 0x40;

    /// <summary>
    ///     Reading bank Id.
    /// </summary>
    public ushort ReadingBankId;

    /// <summary>
    ///     Reading file Id.
    /// </summary>
    public uint ReadingFileId;

    /// <summary>
    ///     Reading player Id.
    /// </summary>
    public byte ReadingPlayerId;

    /// <summary>
    ///     Volume.
    /// </summary>
    public byte Volume = 100;

    /// <summary>
    ///     Read the info.
    /// </summary>
    /// <param name="r">The reader.</param>
    public void Read(FileReader r)
    {
        ReadingFileId = r.ReadUInt32();
        ReadingBankId = r.ReadUInt16();
        Volume = r.ReadByte();
        ChannelPriority = r.ReadByte();
        PlayerPriority = r.ReadByte();
        ReadingPlayerId = r.ReadByte();
        r.ReadUInt16();
    }

    /// <summary>
    ///     Write the info.
    /// </summary>
    /// <param name="w">The writer.</param>
    public void Write(FileWriter w)
    {
        w.Write(ReadingFileId);
        w.Write((ushort)(Bank != null ? Bank.Index : ReadingBankId));
        w.Write(Volume);
        w.Write(ChannelPriority);
        w.Write(PlayerPriority);
        w.Write((byte)(Player != null ? Player.Index : ReadingPlayerId));
        w.Write((ushort)0);
    }
}