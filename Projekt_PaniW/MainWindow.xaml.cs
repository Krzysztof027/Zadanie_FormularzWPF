using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
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
using Microsoft.Win32;

namespace Projekt_PaniW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int V = 14;
        private string path;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zapisz(object sender, RoutedEventArgs e)
        {
            SaveFileDialog oknoZapisu = new SaveFileDialog(); //Zapisz
            oknoZapisu.Filter = "PlainText | *.txt"; //Rozszerzenie
            oknoZapisu.Title = "zapisywanie"; //Tytuł

            if (oknoZapisu.ShowDialog() == true) //Pokaz_plik->Tak
            {
                File.WriteAllText(oknoZapisu.FileName, tekstDoZapisu.Text);
                //is an inbuilt
                //File class method that is used to create a new file,
                //writes the specified string to the file, and then closes the file.
                //If the target file already exists, it is overwritten.
            }
        }

        private void Nowe_Okno(object sender, RoutedEventArgs e)
        {
            //File.CreateText(path).Dispose();
            liczba1.Clear();
            liczba2.Clear();
        }

        private void Oblicz(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(liczba1.Text, out int a) && int.TryParse(liczba2.Text, out int b))
            {
                int wynik1 = NWD(a, b);
                int wynik2 = nww(a, b);
                MessageBox.Show("Największy wspólny dzielnik i Największa wspólna wielokrotność liczb " + a + " i " + b + " wynosi: NWD -> " + wynik1 + " / " + wynik2 + "<-NWW", "NWD / NWW", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Zmien_czcionke(System.Object sender, System.EventArgs e)
        {

        }
        private void Oprogramie(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wersja programu 6.0 Autor: Krzysztof Szczerkowski");
        }
        private void Instrukcja(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Największy wspólny dzielnik, największy wspólny podzielnik dla danych dwóch liczb całkowitych największa liczba naturalna dzieląca każdą z nich. "
                + "Najmniejsza wspólna wielokrotność dwóch lub więcej liczb naturalnych a₁,a₂,…,aₙ");
        }

        private void NWD(object sender, RoutedEventArgs e)
        {
            //Słowo out kluczowe powoduje przekazanie argumentów przez odwołanie
            if (int.TryParse(liczba1.Text, out int a) && int.TryParse(liczba2.Text, out int b))
            {
                int wynik = NWD(a, b); //podanie zmiennych 
                MessageBox.Show("Największy wspólny dzielnik " + a + " i " + b + " wynosi " + wynik, "NWD", MessageBoxButton.OK, MessageBoxImage.Information); // Wyświetla przycisk i informację
            }
            /*
             if (int.TryParse(liczba1.Text, out int a) && int.TryParse(liczba2.Text, out int b))
            {
                //MessageBox.Show(a.ToString());
                //Obliczanie NWD
                int wynik = nwd(a, b);
                MessageBox.Show("Największy wspólny dzielnik " + a + " i " + b +  " wynosi " + wynik, "NWD", MessageBoxButton.OK, MessageBoxImage.Information);
            }
             */
        }
        private int NWD(int a, int b)
        {
            while (b != 0)
            {
                int reszta = a % b;
                a = b;
                b = reszta;
            }
            return a;
        }

        private void NWW(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(liczba1.Text, out int a) && int.TryParse(liczba2.Text, out int b))
            {
                int wynik = nww(a, b);
                MessageBox.Show("Największa wspólna wielokrotność liczb " + a + " i " + b + "wynosi: " + wynik, "NWW", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        static int nww(int a, int b)
        {
            if (a < b)
                return nww(b, a);
            //Podajemy zmienną k
            int k = a; //k=a
            while (k % b != 0) //reszta = 0
                //The addition assignment operator, +=, is a shorthand way to add a value to a variable. (Skrócony zapis dodanie wartości do zmiennej->+=a);
                k += a;
            return k;
        }

        private void Zielony(object sender, RoutedEventArgs e)
        {
            App.Background = new SolidColorBrush(Colors.Green);
        }
        private void Niebieski(object sender, RoutedEventArgs e)
        {
            App.Background = new SolidColorBrush(Colors.Blue);
        }

        private void mala(object sender, RoutedEventArgs e)
        {
            liczba1.FontSize = 14;
            liczba2.FontSize = 14;
        }

        private void duza(object sender, RoutedEventArgs e)
        {
            liczba1.FontSize = 24;
            liczba2.FontSize = 24;
            
        }
    }
}
   
