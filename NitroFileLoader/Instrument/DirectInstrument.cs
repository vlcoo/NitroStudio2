using System.Linq;
using GotaSequenceLib;
using GotaSoundIO.IO;

namespace NitroFileLoader;

/// <summary>
///     Direct instrument.
/// </summary>
public class DirectInstrument : Instrument
{
    /// <summary>
    ///     Get the instrument type.
    /// </summary>
    /// <returns>The instrument type.</returns>
    public override InstrumentType Type()
    {
        return NoteInfo[0].InstrumentType;
    }

    /// <summary>
    ///     Max instruments.
    /// </summary>
    /// <returns>The max instruments.</returns>
    public override uint MaxInstruments()
    {
        return 1;
    }

    /// <summary>
    ///     Read the instrument.
    /// </summary>
    /// <param name="r">The reader.</param>
    public override void Read(FileReader r)
    {
        NoteInfo.Add(r.Read<NoteInfo>());
        NoteInfo.Last().Key = Notes.gn9;
    }

    /// <summary>
    ///     Write the instrument.
    /// </summary>
    /// <param name="w">The writer.</param>
    public override void Write(FileWriter w)
    {
        w.Write(NoteInfo[0]);
    }
}