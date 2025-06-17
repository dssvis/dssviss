using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ekzamen
{
    public partial class Form1 : Form
    {
        private Stack<Panel>[] towers = new Stack<Panel>[3];
        private int diskCount;
        private int moveCount = 0;
        private List<Panel> diskPanels = new List<Panel>();

        private readonly Color[] diskColors = new Color[]
        {
            Color.Red, Color.Orange, Color.Gold, Color.Green, Color.Cyan,
            Color.Blue, Color.MediumPurple, Color.Magenta, Color.Gray, Color.Brown
        };

        public Form1()
        {
            InitializeComponent();
            Text = "Ханойские башни";
            MaximizeBox = false;

            panel1.AllowDrop = panel2.AllowDrop = panel3.AllowDrop = true;

            panel1.DragEnter += Panel_DragEnter;
            panel2.DragEnter += Panel_DragEnter;
            panel3.DragEnter += Panel_DragEnter;

            panel1.DragDrop += Panel_DragDrop;
            panel2.DragDrop += Panel_DragDrop;
            panel3.DragDrop += Panel_DragDrop;
        }

        private void InitializeDisks()
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Clear();

            for (int i = 0; i < 3; i++)
                towers[i] = new Stack<Panel>();

            diskPanels.Clear();
            diskCount = (int)numericUpDown1.Value;
            moveCount = 0;
            label2.Text = "Число сделанных ходов: 0";
            label3.Text = $"Минимальное число ходов: {Math.Pow(2, diskCount) - 1}";

            int diskHeight = 20;
            int maxWidth = panel1.Width - 40;

            for (int i = diskCount; i >= 1; i--)
            {
                int diskWidth = maxWidth * i / diskCount;
                Panel disk = new Panel
                {
                    Height = diskHeight,
                    Width = diskWidth,
                    BackColor = diskColors[(i - 1) % diskColors.Length],
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point((panel1.Width - diskWidth) / 2, panel1.Height - diskHeight * (diskCount - i + 1)),
                    Tag = i
                };

                disk.MouseDown += Disk_MouseDown;

                panel1.Controls.Add(disk);
                towers[0].Push(disk);
                diskPanels.Add(disk);
            }
        }

        private void Disk_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is not Panel disk || disk.Parent is null) return;

            var parent = disk.Parent;
            if (parent.Controls[parent.Controls.Count - 1] != disk) return;

            DoDragDrop(disk, DragDropEffects.Move);
        }

        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(Panel))
                ? DragDropEffects.Move
                : DragDropEffects.None;
        }

        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            if (sender is not Panel targetPanel) return;
            if (e.Data.GetData(typeof(Panel)) is not Panel disk) return;

            var fromStack = GetTowerByPanel((Panel)disk.Parent);
            var toStack = GetTowerByPanel(targetPanel);

            if (toStack.Count == 0 || (int)toStack.Peek().Tag > (int)disk.Tag)
            {
                fromStack.Pop();
                toStack.Push(disk);

                disk.Parent.Controls.Remove(disk);
                targetPanel.Controls.Add(disk);

                disk.Location = new Point((targetPanel.Width - disk.Width) / 2,
                                          targetPanel.Height - disk.Height * toStack.Count);

                moveCount++;
                label2.Text = $"Число сделанных ходов: {moveCount}";
                CheckWin();
            }
        }

        private void CheckWin()
        {
            if (towers[2].Count == diskCount)
            {
                MessageBox.Show("Головоломка решена!", "Поздравляем", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Stack<Panel> GetTowerByPanel(Panel panel)
        {
            if (panel == panel1) return towers[0];
            if (panel == panel2) return towers[1];
            if (panel == panel3) return towers[2];
            throw new Exception("Unknown panel");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeDisks();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            InitializeDisks();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDisks();
        }
    }
}
