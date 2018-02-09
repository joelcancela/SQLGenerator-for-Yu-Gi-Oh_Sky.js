using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using SQLGenerator_for_Yu_Gi_Oh_Sky.js.controller;

namespace SQLGenerator_for_Yu_Gi_Oh_Sky.js
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string hint = "Entrez vos cartes une par ligne en anglais, ex: <nom_carte>:<quantité>";
        private Controller controller = new Controller();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cardsTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (cardsTextBox.Text == "")
            {
                cardsTextBox.Text = hint;
                cardsTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cardsTextBox.Text = hint;
            cardsTextBox.Foreground = new SolidColorBrush(Colors.Gray);
        }


        private void cardsTextBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (cardsTextBox.Text == hint)
            {
                cardsTextBox.Text = "";
                cardsTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void requestButton_Click(object sender, RoutedEventArgs e)
        {
            requestsTextBox.Text = controller.getRequests(cardsTextBox.Text);
        }
    }
}
