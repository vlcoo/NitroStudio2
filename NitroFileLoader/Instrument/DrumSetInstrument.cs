using System.Linq;
using GotaSequenceLib;
using GotaSoundIO.IO;

namespace NitroFileLoader;

/// <summary>
///     A drum set instrument.
/// </summary>
public class DrumSetInstrument : Instrument
{
    /// <summary>
    ///     Minimum instrument.
    /// </summary>
    public byte Min;

    /// <summary>
    ///     Read the instrument.
    /// </summary>
    /// <param name="r">The reader.</param>
    public override void Read(FileReader r)
    {
        //Get indices.
        var min = r.ReadByte();
        var max = r.ReadByte();
        var numInsts = max - min + 1;
        Min = min;

        //Read note parameters.
        NoteInfo lastInst = null;
        var ind = min;
        for (var i = 0; i < numInsts; i++)
        {
            //Get the instrument type.
            var t = (InstrumentType)r.ReadUInt16();
            var n = r.Read<NoteInfo>();
            if (lastInst == null)
            {
                lastInst = n;
            }
            else
            {
                if (!n.Equals(lastInst))
                {
                    NoteInfo.Add(lastInst);
                    NoteInfo.Last().Key = (Notes)(ind - 1);
                    lastInst = n;
                }
            }

            //If last instrument.
            if (ind == max)
            {
                NoteInfo.Add(n);
                NoteInfo.Last().Key = (Notes)ind;
            }

            //Increment index.
            ind++;
        }
    }

    /// <summary>
    ///     Write the intrument.
    /// </summary>
    /// <param name="w">The writer.</param>
    public override void Write(FileWriter w)
    {
        //Write data.
        var indices = NoteInfo.Select(x => x.Key).ToArray();
        w.Write(Min);
        w.Write((byte)indices.Last());
        for (int i = Min; i <= (byte)indices.Last(); i++)
        {
            var ind = 0;
            for (var j = indices.Count() - 1; j >= 0; j--)
                if (i <= (byte)indices[j])
                    ind = j;
            w.Write((ushort)NoteInfo.Where(x => x.Key == indices[ind]).FirstOrDefault().InstrumentType);
            w.Write(NoteInfo.Where(x => x.Key == indices[ind]).FirstOrDefault());
        }
    }

    /// <summary>
    ///     The instrument type.
    /// </summary>
    /// <returns>The instrument type.</returns>
    public override InstrumentType Type()
    {
        return InstrumentType.DrumSet;
    }

    /// <summary>
    ///     Max instruments.
    /// </summary>
    /// <returns>The max instruments.</returns>
    public override uint MaxInstruments()
    {
        return 0x80;
    }
}