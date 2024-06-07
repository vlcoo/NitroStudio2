using System;
using System.IO;
//using System.Windows.Forms;
using Eto.Forms;
using GotaSoundIO.Sound;
using Stream = NitroFileLoader.Stream;

namespace NitroStudio2;

internal static class Program
{
    /// <summary>
    ///     Path.
    /// </summary>
    public static string NitroPath = "";

    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        //Start.
        //Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);

        //Argument mode.
        if (args.Length > 0)
            //Switch type.
            switch (Path.GetExtension(args[0]))
            {
                //Sound archive.
                case ".sdat":
                    //Application.Run(new MainWindow(args[0]));
                    break;

                //Sound sequence.
                case ".sseq":
                    // Application.Run(new SequenceEditor(args[0]));
                    break;

                //Sound archive.
                case ".ssar":
                    // Application.Run(new SequenceArchiveEditor(args[0]));
                    break;

                //Sound bank.
                case ".sbnk":
                    //Application.Run(new BankEditor(args[0]));
                    break;

                //Sound wave archive.
                case ".swar":
                    //Application.Run(new WaveArchiveEditor(args[0]));
                    break;

                //Stream.
                case ".strm":
                    var r = new RiffWave();
                    var s = new Stream();
                    s.Read(args[0]);
                    r.FromOtherStreamFile(s);
                    r.Write(MainWindow.NitroPath + "/" + "tmpStream" + 0 + ".wav");
                    //Application.Run(new StreamPlayer(null, MainWindow.NitroPath + "/" + "tmpStream" + 0 + ".wav",
                        //Path.GetFileNameWithoutExtension(args[0])));
                    break;
            }
        else
            //Start the editor.
            //Application.Run(new MainWindow());
            new Application(Eto.Platform.Detect).Run(new InstrumentSelector());
    }
}