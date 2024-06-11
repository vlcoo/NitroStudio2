using Eto.Forms;
using Eto.Drawing;
using System.Collections.Generic;
using System;

namespace NitroStudio2
{
    partial class InstrumentSelector : Form
    {
        CheckBox selectedCheckbox(int index)
        {
            var e = new CheckBox();
            e.Checked = true;
            e.ThreeState = false;
            e.ID = $"check{index}";
            e.CheckedChanged += (s, ev) =>
            {
                if ((bool)e.Checked && !SelectedInstruments.Contains(index))
                    SelectedInstruments.Add(index);
                else if (!(bool)e.Checked && SelectedInstruments.Contains(index))
                    SelectedInstruments.Remove(index);
            };
            return e;
        }

        void InitializeComponent()
        {
            Title = "Instrument Selector";
            Size = new Size(632, 420);
            Padding = 10;

            var selectionTable = new TableLayout
            {
                Rows =
                {
                    new TableRow
                    {
                        Cells =
                        {
                            "Play Sample", "Instrument ID", "Instrument Name", "Use Instrument"
                        }
                    }
                }
            };

            var finishedButton = new Button((s, e) => Close())
            {
                Text = "Finished",
            };
            var selectAllButton = new Button
            {
                Text = "Select All"
            };
            var selectNoneButton = new Button
            {
                Text = "Select None"
            };
            selectAllButton.Click += (s, e) =>
            {
                foreach (int inst in instruments.Keys)
                    selectionTable.FindChild<CheckBox>($"check{inst}").Checked = true;
            };
            selectNoneButton.Click += (s, e) =>
            {
                foreach (int inst in instruments.Keys)
                    selectionTable.FindChild<CheckBox>($"check{inst}").Checked = false;
            };

            var num = 0;
            foreach (KeyValuePair<int, string> inst in instruments)
            {
                selectionTable.Rows.Add(new TableRow
                {
                    Cells =
                    {
                        new Button((s, e) => PlayWave(waves[num++]))
                        {
                            Text = "Play",
                        },
                        $"{inst.Key}",
                        $"{inst.Value}",
                        selectedCheckbox(inst.Key)
                    }
                });
            }

            Content = new Scrollable
            {
                Content = new StackLayout
                {
                    Items =
                    {
                        new StackLayout
                        {
                            Items =
                            {
                                selectAllButton, selectNoneButton
                            },
                            Orientation = Orientation.Horizontal
                        },
                        selectionTable,
                        finishedButton
                    }
                }
            };

            Closing += OnClosing;
        }
    }
}
