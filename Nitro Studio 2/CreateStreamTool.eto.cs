using Eto.Forms;
using Eto.Drawing;

namespace NitroStudio2
{
    partial class CreateStreamTool : Form
    {
        void InitializeComponent()
        {
            Title = SwavMode ? "Create Wave" : "Create Stream";
            Size = new Size(430, 250);
            Padding = 10;

            var inFileBox = new TextBox();
            var inFileButton = new Button
            {
                Text = "..."
            };
            inFileButton.Click += (s, e) =>
            {
                var o = new OpenFileDialog
                {
                    Filters =
                    {
                        "Supported Sound Files|*.*,*.swav,*.strm"
                    }
                };
                o.ShowDialog(this);
                if (o.FileName != "")
                {
                    inFileBox.Text = o.FileName;
                }
            };
            var outFileBox = new TextBox();
            var outFileButton = new Button
            {
                Text = "..."
            };
            outFileButton.Click += (s, e) =>
            {
                var o = new SaveFileDialog
                {
                    Filters =
                    {
                        SwavMode ? "Sound Wave|*.*" : "Sound Stream|*.strm"
                    }
                };
                o.ShowDialog(this);
                if (o.FileName != "")
                {
                    outFileBox.Text = o.FileName;
                }
            };
            var formatBox = new ComboBox
            {
                Items =
                {
                    "PCM8", "PCM16", "IMA-ADPCM"
                },
                SelectedIndex = 2,
            };
            var exportButton = new Button
            {
                Text = "Export"
            };
            exportButton.Click += (s, e) => { exportStream(inFileBox.Text, outFileBox.Text, formatBox.SelectedIndex); };

            Content = new StackLayout
            {
                Items =
                {
                    "Input file:",
                    new StackLayout
                    {
                        Items =
                        {
                            inFileBox, inFileButton
                        },
                        Orientation = Orientation.Horizontal,
                    },
                    "Output file:",
                    new StackLayout
                    {
                        Items =
                        {
                            outFileBox, outFileButton
                        },
                        Orientation = Orientation.Horizontal,
                    },
                    formatBox,
                    exportButton
                }
            };
        }
    }
}
