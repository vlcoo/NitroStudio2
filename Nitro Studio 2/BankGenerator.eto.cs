using Eto.Forms;
using Eto.Drawing;
using System;
using System.Linq;
using System.Collections.Generic;

namespace NitroStudio2
{
    partial class BankGenerator : Form
    {
        IEnumerable<string> bankDropdownOptions;

        DropDown bankDropdown(int index)
        {
            var e = new DropDown();
            e.DataStore = bankDropdownOptions;
            e.SelectedIndex = 0;
            e.SelectedIndexChanged += (s, ev) =>
            {
                // ...
            };
            return e;
        }

        DropDown instrumentDropdown(int index, int bankID)
        {
            var e = new DropDown();
            e.DataStore = SA.Banks.Where(b => b.Index == index).FirstOrDefault().File.Instruments.Select(i => $"[{i.Index}] - {i.Type()}");
            e.SelectedIndex = 0;
            e.SelectedIndexChanged += (s, ev) =>
            {
                // ...
            };
            return e;
        }

        TableRow NewRow(int num)
        {
            var row = new TableRow
            {
                Cells =
                    {
                        new Button((s, e) => /* ... */)
                        {
                            Text = "Play",
                        },
                        bankDropdown(num),
                        instrumentDropdown(num, /* ... */),
                        new TextBox
                        {

                        },
                        new DropDown
                        {
                            Items = { "Use Generated Wave Archive", "Reference Original Wave Archive" }
                        },
                        new Button((s, e) => /* ... */)
                        {
                            Text = "Remove"
                        }
                    }
            };
            return row;
        }

        void InitializeComponent()
        {
            Title = "Bank Generator";
            Size = new Size(560, 360);
            Padding = 10;

            bankDropdownOptions = SA.Banks.
                Where(b => b.File.Instruments.Count > 0).
                Select(b => $"[{b.Index}] - {b.Name}");

            // ...

            var selectionTable = new TableLayout
            {
                Rows =
                {
                    new TableRow
                    {
                        Cells =
                        {
                            "Play", "Bank", "Instrument", "New ID", "Wave Archive Mode", "Remove"
                            // they're a button, a dropdown, a dropdown, a textbox, a dropdown, a button
                        }
                    }
                }
            };

            var finishedButton = new Button((s, e) => Close())
            {
                Text = "Finished"
            };

            var addButton = new Button((s, e) => selectionTable.Rows.Add(NewRow(selectionTable.Rows.Count)))
            {
                Text = "Add"
            };

            Closing += OnClosing;
        }
    }
}
