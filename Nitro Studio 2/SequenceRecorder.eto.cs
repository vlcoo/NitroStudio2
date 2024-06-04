using Eto.Forms;
using Eto.Drawing;

namespace NitroStudio2
{
    partial class SequenceRecorder : Form
    {
        void InitializeComponent()
        {
            Title = "Sequence Recorder";
            Size = new Size(368, 120);
            Padding = 10;

            var loopsBox = new NumericUpDown
            {
                MinValue = 1
            };
            var fadeBox = new CheckBox
            {
                Checked = false,
                ThreeState = false,
            };
            var exportButton = new Button
            {
                Text = "Export"
            };
            exportButton.Click += (s, e) => { exportSequence(loopsBox.Value, fadeBox.Checked); };

            Content = new StackLayout
            {
                Items =
                {
                    new TableLayout
                    {
                        Rows =
                        {
                            new TableRow(
                                "Number of Loops:",
                                "Fade Out:"
                            ),
                            new TableRow(
                                loopsBox,
                                fadeBox
                            )
                        }
                    },
                    exportButton
                }
            };
        }
    }
}
