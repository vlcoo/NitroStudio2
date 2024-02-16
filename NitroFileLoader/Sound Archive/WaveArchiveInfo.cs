using System.Collections.Generic;
using System.IO;
using GotaSoundIO.IO;
using GotaSoundIO.Sound;

namespace NitroFileLoader;

/// <summary>
///     Wave archive info.
/// </summary>
public class WaveArchiveInfo : IReadable, IWriteable
{
    /// <summary>
    ///     File.
    /// </summary>
    public WaveArchive File;

    /// <summary>
    ///     Force the file to be individualized.
    /// </summary>
    public bool ForceIndividualFile;

    /// <summary>
    ///     Entry index.
    /// </summary>
    public int Index;

    /// <summary>
    ///     Load wave archive individually.
    /// </summary>
    public bool LoadIndividually;

    /// <summary>
    ///     Name.
    /// </summary>
    public string Name;

    /// <summary>
    ///     Reading file Id.
    /// </summary>
    public uint ReadingFileId;

    /// <summary>
    ///     Read the info.
    /// </summary>
    /// <param name="r">The reader.</param>
    public void Read(FileReader r)
    {
        ReadingFileId = r.ReadUInt32();
        LoadIndividually = (ReadingFileId & 0xFF000000) > 0;
        ReadingFileId &= 0xFFFFFF;
    }

    /// <summary>
    ///     Write the info.
    /// </summary>
    /// <param name="w">The writer.</param>
    public void Write(FileWriter w)
    {
        w.Write((uint)(ReadingFileId | (LoadIndividually ? 0x01000000 : 0)));
    }

    /// <summary>
    ///     Write the text format, and dump files.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="name">The name.</param>
    public void WriteTextFormat(string path, string name)
    {
        //SWLS.
        var swls = new List<string>();
        var ind = 0;
        Directory.CreateDirectory(path + "/" + name);
        foreach (var w in File.Waves)
        {
            swls.Add(name + "/" + ind.ToString("D4") + ".adpcm.swav");
            w.Write(path + "/" + name + "/" + ind.ToString("D4") + ".adpcm.swav");
            var r = new RiffWave();
            r.FromOtherStreamFile(w);
            r.Write(path + "/" + name + "/" + ind.ToString("D4") + ".wav");
            ind++;
        }

        System.IO.File.WriteAllLines(path + "/" + name + ".swls", swls);
    }
}