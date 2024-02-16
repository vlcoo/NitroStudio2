using System;
using System.IO;
using System.Windows.Forms;
using GotaSoundIO.Sound;
using NitroFileLoader;
using NitroStudio2.Properties;
using Stream = NitroFileLoader.Stream;

namespace NitroStudio2;

public partial class CreateStreamTool : Form
{
    /// <summary>
    ///     Swav mode.
    /// </summary>
    private readonly bool SwavMode;

    public CreateStreamTool(bool swavMode)
    {
        InitializeComponent();
        outputFormat.SelectedIndex = 2;
        SwavMode = swavMode;
        if (SwavMode)
        {
            Text = "Create Wave";
            Icon = Resources.Wav;
        }
    }

    private void impFileButton_Click(object sender, EventArgs e)
    {
        var o = new OpenFileDialog();
        o.RestoreDirectory = true;
        o.Filter = "Supported Sound Files|*.wav;*.swav;*.strm";
        o.ShowDialog();
        if (o.FileName != "")
        {
            impFileBox.Text = o.FileName;
            impFileBox.SelectionStart = outFileBox.Text.Length;
            impFileBox.ScrollToCaret();
            impFileBox.Refresh();
        }
    }

    private void outFileButton_Click(object sender, EventArgs e)
    {
        var s = new SaveFileDialog();
        s.RestoreDirectory = true;
        s.Filter = SwavMode ? "Sound Wave|*.swav" : "Sound Stream|*.strm";
        s.ShowDialog();
        if (s.FileName != "")
        {
            outFileBox.Text = s.FileName;
            outFileBox.SelectionStart = outFileBox.Text.Length;
            outFileBox.ScrollToCaret();
            outFileBox.Refresh();
        }
    }

    private void exportButton_Click(object sender, EventArgs e)
    {
        //Test.
        if (impFileBox.Text.Equals(""))
        {
            MessageBox.Show("No Input File Selected!");
            return;
        }

        if (outFileBox.Text.Equals(""))
        {
            MessageBox.Show("No Output File Selected!");
            return;
        }

        //Sound file.
        SoundFile s;
        if (SwavMode)
            s = new Wave();
        else
            s = new Stream();

        //Switch input file.
        SoundFile i;
        switch (Path.GetExtension(impFileBox.Text))
        {
            case ".swav":
                i = new Wave();
                break;
            case ".strm":
                i = new Stream();
                break;
            default:
                i = new RiffWave();
                break;
        }

        i.Read(impFileBox.Text);

        //Get conversion type.
        Type convType;
        switch (outputFormat.SelectedIndex)
        {
            case 0:
                convType = typeof(PCM8Signed);
                break;
            case 1:
                convType = typeof(PCM16);
                break;
            default:
                convType = typeof(ImaAdpcm);
                break;
        }

        //Convert the file.
        s.FromOtherStreamFile(i, convType);

        //Save the file.
        s.Write(outFileBox.Text);
    }
}