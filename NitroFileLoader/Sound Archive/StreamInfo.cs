using GotaSoundIO.IO;

namespace NitroFileLoader;

/// <summary>
///     Stream info.
/// </summary>
public class StreamInfo : IReadable, IWriteable
{
    /// <summary>
    ///     File.
    /// </summary>
    public Stream File;

    /// <summary>
    ///     Force the file to be individualized.
    /// </summary>
    public bool ForceIndividualFile;

    /// <summary>
    ///     Entry index.
    /// </summary>
    public int Index;

    /// <summary>
    ///     Mono to stereo.
    /// </summary>
    public bool MonoToStereo;

    /// <summary>
    ///     Name.
    /// </summary>
    public string Name;

    /// <summary>
    ///     Stream player.
    /// </summary>
    public StreamPlayerInfo Player;

    /// <summary>
    ///     Priority.
    /// </summary>
    public byte Priority = 0x40;

    /// <summary>
    ///     Reading file Id.
    /// </summary>
    public uint ReadingFileId;

    /// <summary>
    ///     Player Id.
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
        MonoToStereo = (ReadingFileId & 0xFF000000) > 0;
        ReadingFileId &= 0xFFFFFF;
        Volume = r.ReadByte();
        Priority = r.ReadByte();
        ReadingPlayerId = r.ReadByte();
        r.ReadBytes(5);
    }

    /// <summary>
    ///     Write the info.
    /// </summary>
    /// <param name="w">The writer.</param>
    public void Write(FileWriter w)
    {
        w.Write((uint)(ReadingFileId | (MonoToStereo ? 0x01000000 : 0)));
        w.Write(Volume);
        w.Write(Priority);
        w.Write((byte)(Player != null ? Player.Index : ReadingPlayerId));
        w.Write(new byte[5]);
    }
}