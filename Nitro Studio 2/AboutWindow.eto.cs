using Eto.Forms;
using Eto.Drawing;

namespace NitroStudio2
{
    partial class AboutWindow : Form
    {
        void InitializeComponent()
        {
            Title = "About";
            Size = new Size(400, 400);
            Padding = 10;

            Content = new StackLayout
            {
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Items =
                {
                    new Label
                    {
                        Text = "About Nitro Studio 2",
                        Font = new Font(SystemFont.Bold, 18),
                        VerticalAlignment = VerticalAlignment.Center
                    },
                    new TextArea
                    {
                        Text = "An editor for SDAT.\r\n\r\nCredits:\r\nNintendo, Images, SDAT Info.\r\nKermalis, Sequence Player Base\r\nEugene, Testing, Suggestions.\r\nGoji Goodra, Testing, Suggestions.\r\nJosh, SDAT Research.\r\nCrystal, SDAT Research.\r\nNintendon, SDAT Research.\r\nDJ Bouche, SDAT Research.\r\nVGMTrans, SDAT Research.\r\nLoveEmu, SDAT Research, Tools.\r\nGota7, Nitro Studio.\r\n\r\n©2020 Gota7\n\nThis is a fork by vlco_o of the original project.",
                        ReadOnly = true,
                        Wrap = true,
                        Size = new Size(300, 300)
                    }
                }
            };
        }
    }
}
