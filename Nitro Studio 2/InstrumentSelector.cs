using System;
using System.Collections.Generic;
using System.Linq;

//using System.Windows.Forms;
using GotaSequenceLib;
using GotaSequenceLib.Playback;
using GotaSoundIO.Sound;
using NitroFileLoader;

namespace NitroStudio2;

public partial class InstrumentSelector
{
    /// <summary>
    ///     Mixer.
    /// </summary>
    public Mixer Mixer = new();

    /// <summary>
    ///     Player.
    /// </summary>
    public Player Player;

    /// <summary>
    ///     Selected instruments.
    /// </summary>
    public List<int> SelectedInstruments;

    /// <summary>
    ///     Waves.
    /// </summary>
    private readonly List<RiffWave> waves = new();

    private readonly Dictionary<int, string> instruments = new();

    /// <summary>
    ///     Bank importer.
    /// </summary>
    /// <param name="waves">Waves.</param>
    /// <param name="instIDs">Ids.</param>
    /// <param name="instIDs">Names.</param>
    public InstrumentSelector(List<RiffWave> waves, List<int> instIDs, List<string> instNames)
    {
        //Init.
        this.waves = waves;
        instruments = instIDs.Zip(instNames, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
        SelectedInstruments = instIDs;
        InitializeComponent();
        Player = new Player(Mixer);
        Player.PrepareForSong(
            new Bank[]
            {
                new()
                {
                    Instruments = new List<Instrument>
                    {
                        new DirectInstrument { Index = 0, NoteInfo = new List<NoteInfo> { new() { Key = Notes.gn9 } } }
                    }
                }
            }, new[] { new RiffWave[1] });
        Player.LoadSong(new List<SequenceCommand>
        {
            new() { CommandType = SequenceCommands.ProgramChange, Parameter = (uint)0 },
            new()
            {
                CommandType = SequenceCommands.Note,
                Parameter = new NoteParameter { Note = Notes.cn4, Length = 48 * 2, Velocity = 127 }
            },
            new() { CommandType = SequenceCommands.Fin }
        });
    }

    public InstrumentSelector() {
        var waves = new List<RiffWave>();
        var instIDs = new List<int>();
        var instNames = new List<string>();
        waves = [new RiffWave(), new RiffWave()];
        instIDs = [0, 1];
        instNames = ["abcd", "qwerty"];
        this.waves = waves;
        instruments = instIDs.Zip(instNames, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
        SelectedInstruments = instIDs;
        Player = new Player(Mixer);
        Player.PrepareForSong(
            new Bank[]
            {
                new()
                {
                    Instruments = new List<Instrument>
                    {
                        new DirectInstrument { Index = 0, NoteInfo = new List<NoteInfo> { new() { Key = Notes.gn9 } } }
                    }
                }
            }, new[] { new RiffWave[1] });
        Player.LoadSong(new List<SequenceCommand>
        {
            new() { CommandType = SequenceCommands.ProgramChange, Parameter = (uint)0 },
            new()
            {
                CommandType = SequenceCommands.Note,
                Parameter = new NoteParameter { Note = Notes.cn4, Length = 48 * 2, Velocity = 127 }
            },
            new() { CommandType = SequenceCommands.Fin }
        });
        InitializeComponent();
    }

    /// <summary>
    ///     Play region button.
    /// </summary>
    public void PlayWave(RiffWave wave)
    {
        if (!waves.Contains(wave)) return;
        Player.Stop();
        Player.WaveArchives[0][0] = wave;
        Player.Play();
    }

    /// <summary>
    ///     On closing.
    /// </summary>
    private void OnClosing(object sender, EventArgs e)
    {
        Mixer.Dispose();
        Player.Dispose();
    }
}