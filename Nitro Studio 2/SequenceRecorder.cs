using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GotaSequenceLib;
using GotaSequenceLib.Playback;
using GotaSoundIO.Sound;

namespace NitroStudio2;

public partial class SequenceRecorder : Form
{
    /// <summary>
    ///     Commands.
    /// </summary>
    private readonly List<SequenceCommand> commands;

    /// <summary>
    ///     File path.
    /// </summary>
    private readonly string filePath;

    /// <summary>
    ///     Mixer.
    /// </summary>
    public Mixer Mixer = new();

    /// <summary>
    ///     Player.
    /// </summary>
    private readonly Player Player;

    /// <summary>
    ///     Sequence start.
    /// </summary>
    private readonly int seqStart;

    /// <summary>
    ///     Create a new sequence recorder.
    /// </summary>
    /// <param name="banks">The banks.</param>
    /// <param name="wars">Wave archives.</param>
    /// <param name="commands">Sequence commands.</param>
    /// <param name="startIndex">Start index.</param>
    public SequenceRecorder(PlayableBank[] banks, RiffWave[][] wars, List<SequenceCommand> commands, int startIndex,
        string filePath)
    {
        //Init.
        InitializeComponent();

        //Load stuff.
        Player = new Player(Mixer);
        Player.PrepareForSong(banks, wars);
        this.commands = commands;
        seqStart = startIndex;
        this.filePath = filePath;
    }

    /// <summary>
    ///     Record the sequence.
    /// </summary>
    private void exportButton_Click(object sender, EventArgs e)
    {
        //Save.
        Player.LoadSong(commands, seqStart);
        Player.NumLoops = (long)loopsBox.Value;
        Player.DontFadeSong = !fadeBox.Checked;
        Player.Record(filePath);
        Close();
    }
}