using Eto.Forms;
using Eto.Drawing;
using System.Linq;
using System;
using NitroFileLoader;

namespace NitroStudio2
{
    partial class WaveMapper : Form
    {
        void InitializeComponent()
        {
            Title = "Wave Mapper";
            Size = new Size(570, 340);
            Padding = 10;
            Icon = Icon.FromResource("NitroStudio2.Resources.wave.ico");
            
            var mapGrid = new GridView
            {
                Columns =
                {
                    new GridColumn
                    {
                        HeaderText = "Play Sample",
                        DataCell = new CustomCell 
                        {
                            CreateCell = c =>
                            {
                                var e = new Button
                                {
                                    Text = "Play"
                                };
                                e.Click += (s, e) => PlayWave(c.Row);
                                return e;
                            }
                        }
                    },
                    new GridColumn
                    {
                        HeaderText = "Wave ID",
                        DataCell = new TextBoxCell
                        {
                            Binding = Binding.Property<string>("wavID")
                        }
                    },
                    new GridColumn
                    {
                        HeaderText = "Wave Archive",
                        DataCell = new CustomCell()
                        {
                            CreateCell = c =>
                            {
                                var e = new ComboBox();
                                foreach (var war in wars) 
                                    e.Items.Add($"[{war.Index}] {war.Name}");
                                e.SelectedIndex = 0;
                                e.SelectedIndexBinding.BindDataContext("warID");
                                return e;
                            }
                        }
                    }
                }
            };

            var num = 0;
            foreach (var wav in wavs)
            {
                mapGrid.DataStore.Append(new { ID = num++, WaveArchive = wav });
            }

            var finishedButton = new Button
            {
                Text = "Finished"
            };
            finishedButton.Click += (s, e) =>
            {
                //foreach (DataGridViewRow r in mapGrid.Rows)
                //{
                //    var s = (string)((DataGridViewComboBoxCell)r.Cells[2]).Value;
                //    WarMap.Add(ushort.Parse(s.Split(']')[0].Split('[')[1]));
                //}
                foreach (var row in mapGrid.DataStore)
                {
                    // ...
                }
            };

            Content = new StackLayout
            {
                Items =
                {
                    mapGrid,
                    finishedButton
                }
            };

            Closing += OnClosing;
        }
    }
}
