using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GotaSequenceLib;
using GotaSequenceLib.Playback;
using GotaSoundIO.Sound;
using NitroFileLoader;

namespace NitroStudio2;

public partial class InstrumentSelector : Form
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
    private readonly List<RiffWave> wavs = new();

    /// <summary>
    ///     Bank importer.
    /// </summary>
    /// <param name="waves">Waves.</param>
    /// <param name="insts">Ids.</param>
    /// <param name="insts">Names.</param>
    public InstrumentSelector(List<RiffWave> waves, List<int> insts, List<string> names)
    {
        //Init.
        InitializeComponent();
        instGrid.CellContentClick += PlayRegionButtonClick;
        wavs = waves;
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
        FormClosing += OnClosing;

        //Add instruments.
        var ind = 0;
        foreach (var inst in insts)
        {
            instGrid.Rows.Add(new DataGridViewRow());
            var v = instGrid.Rows[instGrid.Rows.Count - 1];
            ((DataGridViewTextBoxCell)v.Cells[1]).Value = inst;
            var name = "Instrument " + inst;
            try
            {
                name = names[ind];
            }
            catch
            {
            }

            ind++;
            ((DataGridViewTextBoxCell)v.Cells[2]).Value = name;
            ((DataGridViewCheckBoxCell)v.Cells[3]).Value = true;
        }
    }

    /// <summary>
    ///     Finished.
    /// </summary>
    private void finishedButton_Click(object sender, EventArgs e)
    {
        SelectedInstruments = new List<int>();
        foreach (DataGridViewRow r in instGrid.Rows)
            if ((bool)((DataGridViewCheckBoxCell)r.Cells[3]).Value)
                SelectedInstruments.Add(int.Parse(r.Cells[1].Value.ToString()));
        Close();
    }

    /// <summary>
    ///     Play region button.
    /// </summary>
    public void PlayRegionButtonClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != 0 || e.RowIndex < 0) return;
        Player.Stop();
        Player.WaveArchives[0][0] = wavs[e.RowIndex];
        Player.Play();
    }

    private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow r in instGrid.Rows) r.Cells[3].Value = true;
    }

    private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow r in instGrid.Rows) r.Cells[3].Value = false;
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