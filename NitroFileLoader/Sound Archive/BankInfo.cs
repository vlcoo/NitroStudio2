using System.Collections.Generic;
using System.Linq;
using GotaSequenceLib;
using GotaSoundIO.IO;
using GotaSoundIO.Sound;

namespace NitroFileLoader;

/// <summary>
///     Bank info.
/// </summary>
public class BankInfo : IReadable, IWriteable
{
    /// <summary>
    ///     File.
    /// </summary>
    public Bank File;

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
    ///     Reading file Id.
    /// </summary>
    public uint ReadingFileId;

    /// <summary>
    ///     Reading wave 0 Id.
    /// </summary>
    public ushort ReadingWave0Id = 0xFFFF;

    /// <summary>
    ///     Reading wave 1 Id.
    /// </summary>
    public ushort ReadingWave1Id = 0xFFFF;

    /// <summary>
    ///     Reading wave 2 Id.
    /// </summary>
    public ushort ReadingWave2Id = 0xFFFF;

    /// <summary>
    ///     Reading wave 3 Id.
    /// </summary>
    public ushort ReadingWave3Id = 0xFFFF;

    /// <summary>
    ///     Wave archives.
    /// </summary>
    public WaveArchiveInfo[] WaveArchives = { null, null, null, null };

    /// <summary>
    ///     Read the info.
    /// </summary>
    /// <param name="r">The reader.</param>
    public void Read(FileReader r)
    {
        ReadingFileId = r.ReadUInt32();
        ReadingWave0Id = r.ReadUInt16();
        ReadingWave1Id = r.ReadUInt16();
        ReadingWave2Id = r.ReadUInt16();
        ReadingWave3Id = r.ReadUInt16();
    }

    /// <summary>
    ///     Write the info.
    /// </summary>
    /// <param name="w">The writer.</param>
    public void Write(FileWriter w)
    {
        w.Write(ReadingFileId);
        w.Write((ushort)(WaveArchives[0] == null ? ReadingWave0Id : WaveArchives[0].Index));
        w.Write((ushort)(WaveArchives[1] == null ? ReadingWave1Id : WaveArchives[1].Index));
        w.Write((ushort)(WaveArchives[2] == null ? ReadingWave2Id : WaveArchives[2].Index));
        w.Write((ushort)(WaveArchives[3] == null ? ReadingWave3Id : WaveArchives[3].Index));
    }

    /// <summary>
    ///     Get the associated waves from the wave archives.
    /// </summary>
    /// <returns>The waves from the wave archives.</returns>
    public RiffWave[][] GetAssociatedWaves()
    {
        //Get waves.
        var waves = new RiffWave[4][];
        for (var i = 0; i < 4; i++)
            if (WaveArchives[i] != null)
                waves[i] = WaveArchives[i].File.GetWaves();
        return waves;
    }

    /// <summary>
    ///     Write the text format.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="name">The name.</param>
    public void WriteTextFormat(string path, string name)
    {
        //Return.
        var ret = new List<string>();

        //Path.
        ret.Add("@PATH \"../WaveArchives\"\n");

        //Instrument list.
        ret.Add("@INSTLIST");
        var lastGroup = -1;
        var keyNum = 0;
        var drumNum = 0;
        foreach (var e in File.Instruments.OrderBy(x => x.GetOrder))
            //Add the instrument header.
            switch (e.Type())
            {
                case InstrumentType.DrumSet:
                    ret.Add("\t" + e.Index + " : DRUM_SET, _DRUM" + drumNum.ToString("D3"));
                    drumNum++;
                    break;
                case InstrumentType.KeySplit:
                    ret.Add("\t" + e.Index + " : KEY_SPLIT, _KEY" + keyNum.ToString("D3"));
                    keyNum++;
                    break;
                default:
                    ret.Add(WriteNoteInfo(e.NoteInfo[0], e.Index.ToString()));
                    break;
            }

        //Drum sets.
        drumNum = 0;
        if (File.Instruments.Where(x => x.Type() == InstrumentType.DrumSet).Count() > 0) ret.Add("\n@DRUM_SET");
        foreach (var e in File.Instruments.OrderBy(x => x.GetOrder).Where(x => x.Type() == InstrumentType.DrumSet))
        {
            var regNum = 0;
            ret.Add("\n_DRUM" + drumNum.ToString("D3") + " =");
            Notes lastNote = 0;
            foreach (var n in e.NoteInfo)
            {
                var note = (Notes)(e as DrumSetInstrument).Min;
                if (regNum != 0) note = e.NoteInfo[regNum - 1].Key + 1;
                lastNote = note;
                ret.Add(WriteNoteInfo(n, note.ToString()));
                regNum++;
            }

            if (lastNote != e.NoteInfo.Last().Key)
                ret.Add(WriteNoteInfo(e.NoteInfo.Last(), e.NoteInfo.Last().Key.ToString()));
            drumNum++;
        }

        //Key splits.
        keyNum = 0;
        if (File.Instruments.Where(x => x.Type() == InstrumentType.KeySplit).Count() > 0) ret.Add("\n@KEY_SPLIT");
        foreach (var e in File.Instruments.OrderBy(x => x.GetOrder).Where(x => x.Type() == InstrumentType.KeySplit))
        {
            ret.Add("\n_KEY" + keyNum.ToString("D3") + " =");
            foreach (var n in e.NoteInfo) ret.Add(WriteNoteInfo(n, n.Key.ToString()));
            keyNum++;
        }

        //Write note info.
        string WriteNoteInfo(NoteInfo n, string ind)
        {
            switch (n.InstrumentType)
            {
                case InstrumentType.PSG:
                    return "\t" + ind + " : PSG, DUTY_" + (n.WaveId + 1) + "_8, " + (Notes)n.BaseNote + ", " +
                           n.Attack + ", " + n.Decay + ", " + n.Sustain + ", " + n.Release + ", " + n.Pan;
                case InstrumentType.Noise:
                    return "\t" + ind + " : NOISE, " + (Notes)n.BaseNote + ", " + n.Attack + ", " + n.Decay + ", " +
                           n.Sustain + ", " + n.Release + ", " + n.Pan;
                case InstrumentType.Null:
                    return "\t" + ind + " : NULL";
                default:
                    if (lastGroup != n.WarId)
                    {
                        ret.Add("@WGROUP " + n.WarId);
                        lastGroup = n.WarId;
                    }

                    return "\t" + ind + " : SWAV, \"" + WaveArchives[n.WarId].Name + "/" + n.WaveId.ToString("D4") +
                           ".adpcm.swav" + "\", " + (Notes)n.BaseNote + ", " + n.Attack + ", " + n.Decay + ", " +
                           n.Sustain + ", " + n.Release + ", " + n.Pan;
            }
        }

        //Write the file.
        System.IO.File.WriteAllLines(path + "/" + name + ".bnk", ret);
    }
}