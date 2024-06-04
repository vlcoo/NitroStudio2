using Eto.Forms;
using Eto.Drawing;
using Eto.Wpf.Forms;

namespace NitroStudio2
{
    partial class SaveCloseDialog : Form 
    {
        void InitializeComponent()
        {
            Title = "Warning";
            Size = new Size(320, 120);
            Padding = 10;

            var cancelButton = new Button
            {
                Text = "Cancel"
            };
            cancelButton.Click += CancelButton_Click;
            var noButton = new Button
            {
                Text = "Don't save"
            };
            noButton.Click += NoButton_Click;
            var yesButton = new Button
            {
                Text = "Save and Close"
            };
            yesButton.Click += YesButton_Click;

            Content = new StackLayout
            {
                Items =
                {
                    "Do you want to save before you close the file?",
                    new StackLayout
                    {
                        Items =
                        {
                            cancelButton, noButton, yesButton
                        },
                        Orientation = Orientation.Horizontal
                    }
                }
            };
        }
    }
}
