using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Pexeso.Models;
using Pexeso.Views;

namespace Pexeso.ViewModels
{
    public static class PlayerPanel
    {
        private static Grid? generatedPlayerPanel = null;
        public static Grid GeneratePlayerPanel(Player p)
        {
            Grid panel = new Grid();

            panel.RowDefinitions.Add(new RowDefinition);

            TextBlock Name = new TextBlock();
            Name.Text = p.Name;

            TextBlock Score = new TextBlock();
            Score.Text = p.Score.ToString();

            panel.Children.Add(Name);   
            panel.Children.Add(Score);

            panel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            panel.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            generatedPlayerPanel = panel;
            
            return panel;
        }
    }
}
