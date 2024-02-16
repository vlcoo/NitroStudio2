using System.Windows.Forms;
using GotaSoundIO.IO;
using NitroFileLoader;

namespace NitroStudio2;

/// <summary>
///     Nitro Studio Instrument.
/// </summary>
public class NitroStudioInstrument : IOFile
{
    /// <summary>
    ///     Instrument.
    /// </summary>
    public Instrument Inst;

    /// <summary>
    ///     Read the file.
    /// </summary>
    /// <param name="r">The reader.</param>
    public override void Read(FileReader r)
    {
        //Skip header.
        r.ReadUInt32();

        //Get type.
        var type = r.ReadByte();
        switch ((InstrumentType)type)
        {
            case InstrumentType.Blank:
                break;
            case InstrumentType.DrumSet:
                Inst = new DrumSetInstrument();
                break;
            case InstrumentType.KeySplit:
                Inst = new KeySplitInstrument();
                break;
            default:
                Inst = new DirectInstrument();
                break;
        }

        //Placeholder.
        if (r.ReadBoolean())
        {
            MessageBox.Show("An empty instrument cannot be used!");
            return;
        }

        //Read data.
        Inst.Read(r);
        if (Inst as DirectInstrument != null) Inst.NoteInfo[0].InstrumentType = (InstrumentType)type;
    }

    /// <summary>
    ///     Write the file.
    /// </summary>
    /// <param name="w">The writer.</param>
    public override void Write(FileWriter w)
    {
        //Write header.
        w.Write("NIST".ToCharArray());
        w.Write((byte)(Inst == null ? 0 : Inst.Type()));
        w.Write(Inst == null);
        if (Inst != null) w.Write(Inst);
    }
}