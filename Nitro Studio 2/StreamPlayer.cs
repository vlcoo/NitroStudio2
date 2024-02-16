using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace NitroStudio2;

public partial class StreamPlayer : Form
{
    public MainWindow MainWindow;
    public string Path;

    public StreamPlayer(MainWindow m, string path, string name)
    {
        InitializeComponent();
        Text = "Stream Player - " + name + ".strm";
        // wmp.URL = path;
        Path = path;
        MainWindow = m;
    }

    private void onClose(object sender, EventArgs e)
    {
        var t = new Thread(delete);
        t.Start();
    }

    private void delete()
    {
        File.Delete(Path);
        try
        {
            MainWindow.StreamTempCount--;
        }
        catch
        {
        }
    }
}