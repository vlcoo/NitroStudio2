using Eto.Forms;
using Eto.Drawing;
using System.Linq;
using GotaSoundIO.Sound;
using System;
using System.Collections.Generic;

namespace NitroStudio2
{
    partial class WaveMapper : Form
    {
        IEnumerable<string> warDropdownOptions;

        DropDown warDropdown(int index)
        {
            var e = new DropDown();
            e.DataStore = warDropdownOptions;
            e.SelectedIndex = 0;
            e.SelectedIndexChanged += (s, ev) =>
            {
                WarMap[index] = (ushort)e.SelectedIndex;
            };
            return e;
        }

        void InitializeComponent()
        {
            Title = "Wave Mapper";
            Size = new Size(570, 340);
            Padding = 10;
            Icon = Icon.FromResource("NitroStudio2.Resources.wave.ico");

            warDropdownOptions = wars.Select(w => $"[{w.Index}] {w.Name}").ToList();

            // Had to use a TableLayout because the more appropriate GridView was
            // way too cumbersome to set up (I couldn't figure it out unfortunately).
            var mapTable = new TableLayout
            {
                Rows =
                {
                    new TableRow
                    {
                        Cells =
                        {
                            "Play Sample", "Wave ID", "Wave Archive"
                        }
                    }
                }
            };

            var finishedButton = new Button((s, e) => Close())
            {
                Text = "Finished"
            };

            var num = 0;
            foreach (RiffWave wav in wavs)
            {
                mapTable.Rows.Add(new TableRow
                {
                    Cells =
                    {
                        new Button((s, e) => PlayWave(wav))
                        {
                            Text = "Play",
                        },
                        $"{num}",
                        warDropdown(num++)
                    }
                });
            }

            Content = new Scrollable
            {
                Content = new StackLayout
                {
                    Items =
                    {
                        mapTable, 
                        finishedButton
                    }
                }
            };

            Closing += OnClosing;
        }
    }
}
