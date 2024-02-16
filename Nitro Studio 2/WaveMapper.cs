﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GotaSoundIO.Sound;
using NitroFileLoader;

namespace NitroStudio2;

public partial class WaveMapper : Form
{
    /// <summary>
    ///     Player.
    /// </summary>
    public GotaSoundIO.Sound.Playback.StreamPlayer Player = new();

    /// <summary>
    ///     Wave archives.
    /// </summary>
    public List<ushort> WarMap;

    /// <summary>
    ///     Waves.
    /// </summary>
    private readonly List<RiffWave> wavs = new();

    /// <summary>
    ///     Bank importer.
    /// </summary>
    /// <param name="waves">Waves.</param>
    /// <param name="wars">Wave archives.</param>
    public WaveMapper(List<RiffWave> waves, List<WaveArchiveInfo> wars, bool hideId = false)
    {
        //Check.
        if (wars.Count < 1)
        {
            MessageBox.Show("The target bank must be hooked up to at least one wave archive.");
            Close();
            return;
        }

        //Init.
        InitializeComponent();
        mapGrid.CellContentClick += PlayRegionButtonClick;
        if (hideId) mapGrid.Columns[1].Visible = false;
        FormClosing += OnClosing;

        //Wave archive index.
        foreach (var w in wars) waveArchive.Items.Add("[" + w.Index + "] " + w.Name);

        //Add waves.
        var num = 0;
        wavs = waves;
        foreach (var wav in waves)
        {
            mapGrid.Rows.Add(new DataGridViewRow());
            var v = mapGrid.Rows[mapGrid.Rows.Count - 1];
            ((DataGridViewTextBoxCell)v.Cells[1]).Value = num++;
            ((DataGridViewComboBoxCell)v.Cells[2]).Value = waveArchive.Items[0];
        }
    }

    /// <summary>
    ///     Finished.
    /// </summary>
    private void finishedButton_Click(object sender, EventArgs e)
    {
        WarMap = new List<ushort>();
        foreach (DataGridViewRow r in mapGrid.Rows)
        {
            var s = (string)((DataGridViewComboBoxCell)r.Cells[2]).Value;
            WarMap.Add(ushort.Parse(s.Split(']')[0].Split('[')[1]));
        }

        Close();
    }

    /// <summary>
    ///     Play region button.
    /// </summary>
    public void PlayRegionButtonClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != 0 || e.RowIndex < 0) return;
        Player.Stop();
        Player.LoadStream(wavs[e.RowIndex]);
        Player.Play();
    }

    /// <summary>
    ///     On closing.
    /// </summary>
    private void OnClosing(object sender, EventArgs e)
    {
        Player.Dispose();
    }
}