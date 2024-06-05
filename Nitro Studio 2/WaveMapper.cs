using System;
using System.Collections.Generic;
using GotaSoundIO.Sound;
using NitroFileLoader;

namespace NitroStudio2;

public partial class WaveMapper
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

    private readonly List<WaveArchiveInfo> wars = new();

    /// <summary>
    ///     Bank importer.
    /// </summary>
    /// <param name="wavs">Waves.</param>
    /// <param name="wars">Wave archives.</param>
    public WaveMapper(List<RiffWave> wavs, List<WaveArchiveInfo> wars, bool hideId = false)
    {
        //Check.
        if (wars.Count < 1)
        {
            //MessageBox.Show("The target bank must be hooked up to at least one wave archive.");
            Console.WriteLine("The target bank must be hooked up to at least one wave archive.");
            Close();
            return;
        }

        //if (hideId) mapGrid.Columns[1].Visible = false;

        //Add waves.
        this.wavs = wavs;
        this.wars = wars;

        InitializeComponent();
    }

    public WaveMapper()
    {
        InitializeComponent();
    }

    /// <summary>
    ///     Finished.
    /// </summary>
    private void SetWarMap(List<ushort> map)
    {
        WarMap = map;
        Close();
    }

    /// <summary>
    ///     Play region button.
    /// </summary>
    public void PlayWave(int id)
    {
        if (id < 0) return;
        Player.Stop();
        Player.LoadStream(wavs[id]);
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