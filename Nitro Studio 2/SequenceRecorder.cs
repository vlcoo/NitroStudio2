using System;
using System.Collections.Generic;
using GotaSequenceLib;
using GotaSequenceLib.Playback;
using GotaSoundIO.Sound;

namespace NitroStudio2;

public partial class SequenceRecorder
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

    public SequenceRecorder()
    {
        InitializeComponent();
    }

    /// <summary>
    ///     Record the sequence.
    /// </summary>
    private void exportSequence(double numLoops, bool? fade = false)
    {
        //Save.
        Player.LoadSong(commands, seqStart);
        Player.NumLoops = (long)numLoops;
        Player.DontFadeSong = (bool)!fade;
        Player.Record(filePath);
        Close();
    }
}