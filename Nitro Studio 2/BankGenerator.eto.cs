using Eto.Forms;
using Eto.Drawing;
using System;
using System.Linq;

namespace NitroStudio2
{
    partial class BankGenerator : Form
    {
        void InitializeComponent()
        {
            Title = "Bank Generator";
            Size = new Size(560, 360);
            Padding = 10;

            var bankDropdownOptions = SA.Banks.
                Where(b => b.File.Instruments.Count > 0).
                Select(b => $"[{b.Index}] - {b.Name}");

            Func<int, DropDown> bankDropdown = (index) =>
            {
                var e = new DropDown();
                e.DataStore = bankDropdownOptions;
                e.SelectedIndex = 0;
                e.SelectedIndexChanged += (s, ev) =>
                {
                    // ...
                };
                return e;
            };

            // ...

            var selectionTable = new TableLayout
            {
                Rows =
                {
                    new TableRow
                    {
                        Cells =
                        {
                            "Play", "Bank", "Instrument", "New ID", "Wave Archive Mode"
                        }
                    }
                }
            };

            var finishedButton = new Button((s, e) => Close())
            {
                Text = "Finished"
            };

            Closing += OnClosing;
        }
    }
}
