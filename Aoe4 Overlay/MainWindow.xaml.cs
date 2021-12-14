using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using IronOcr;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Interop;
using System.IO;

namespace Aoe4_Overlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IronOcr.Installation.LicenseKey = "IRONOCR.ALEXANDERKILIAN1.25780-678BD52A37-3IBFSQWIWZTREUPI-6OROQOY7XWEU-NFKDOAITURLJ-HQ6TQPKFHN3V-UXOFCVY3D2TR-UUIIDE-TIIYVXRH5F2DUA-DEPLOYMENT.TRIAL-4YFB7H.TRIAL.EXPIRES.11.JAN.2022";
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            Player[] players = await new PlayerCreator().GetPlayersAsync();
            FillBuildorder();
            FillPlayerNames(players);
            FillWinrates(players);
            FillRating(players);

            colourButtonBlue.Visibility = Visibility.Collapsed;
            colourButtonPink.Visibility = Visibility.Collapsed;
            colourButtonRed.Visibility = Visibility.Collapsed;
            startButton.Visibility = Visibility.Collapsed;
        }

        private void FillBuildorder()
        {
            string text = System.IO.File.ReadAllText("./Buildorder.txt");
            builorder.Content = text;
        }

        private void FillRating(Player[] players)
        {
            player1Rating.Content = players[0].rating;
            player2Rating.Content = players[1].rating;
            player3Rating.Content = players[2].rating;
            player4Rating.Content = players[3].rating;
        }

        private void FillWinrates(Player[] players)
        {
            player1Winrate.Content = players[0].winrate + "%";
            player2Winrate.Content = players[1].winrate + "%";
            player3Winrate.Content = players[2].winrate + "%";
            player4Winrate.Content = players[3].winrate + "%";
        }

        private void FillPlayerNames(Player[] players)
        {
            player1Name.Content = players[0].name;
            player2Name.Content = players[1].name;
            player3Name.Content = players[2].name;
            player4Name.Content = players[3].name;
        }

        private void colourButtonPink_Click(object sender, RoutedEventArgs e)
        {
            string colour = "#ffaacc";
            SetColour(colour);
        }

        private void colourButtonRed_Click(object sender, RoutedEventArgs e)
        {
            string colour = "#FF0000";
            SetColour(colour);
        }

        private void colourButtonBlue_Click(object sender, RoutedEventArgs e)
        {
            string colour = "#FF0004FF";
            SetColour(colour);
        }

        private void SetColour(string colour)
        {
            player1Name.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
            player2Name.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
            player3Name.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
            player4Name.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);

            player1Winrate.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
            player2Winrate.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
            player3Winrate.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
            player4Winrate.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);

            player1Rating.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
            player2Rating.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
            player3Rating.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
            player4Rating.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);

            builorder.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(colour);
        }
    }
}
