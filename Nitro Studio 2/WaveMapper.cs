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
    ///     Wave to archive mapping.
    /// </summary>
    public List<ushort> WarMap;

    /// <summary>
    ///     Waves.
    /// </summary>
    private readonly List<RiffWave> wavs;

    /// <summary>
    ///     Wave archives.
    /// </summary>
    private readonly List<WaveArchiveInfo> wars;

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
        WarMap = new(wavs.Count);

        InitializeComponent();
    }

    public WaveMapper()
    {
        InitializeComponent();
    }

    /// <summary>
    ///     Play region button.
    /// </summary>
    public void PlayWave(RiffWave wave)
    {
        if (!wavs.Contains(wave)) return;
        Player.Stop();
        Player.LoadStream(wave);
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