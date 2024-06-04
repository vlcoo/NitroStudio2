using System;
using System.IO;
using GotaSoundIO.Sound;
using NitroFileLoader;
using NitroStudio2.Properties;
using Stream = NitroFileLoader.Stream;

namespace NitroStudio2;

public partial class CreateStreamTool
{
    /// <summary>
    ///     Swav mode.
    /// </summary>
    private readonly bool SwavMode;

    public CreateStreamTool(bool swavMode)
    {
        InitializeComponent();
        SwavMode = swavMode;
        //if (SwavMode)
        //{
        //    Icon = Resources.Wav;
        //}
    }


    private void exportStream(string inFilePath, string outFilePath, int outputFormat)
    {
        //Test.
        if (inFilePath.Equals(""))
        {
            //MessageBox.Show("No Input File Selected!");
            Console.WriteLine("No Input File Selected!");
            return;
        }

        if (outFilePath.Equals(""))
        {
            //MessageBox.Show("No Output File Selected!");
            Console.WriteLine("No Output File Selected!");
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
        switch (Path.GetExtension(inFilePath))
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

        i.Read(inFilePath);

        //Get conversion type.
        Type convType;
        switch (outputFormat)
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
        s.Write(outFilePath);
    }
}