using GanoHesaplama.Models;
using GanoHesaplama.Services;

namespace GanoHesaplama;

public partial class MainPage : ContentPage
{
    DatabaseService service = new();

    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var dersler = await service.GetDersler();

        dersListesi.ItemsSource = dersler;

        double toplamPuan = 0;
        double toplamAkts = 0;

        foreach (var ders in dersler)
        {
            if (!ders.OrtalamayaKatilir)
                continue;

            toplamPuan += Katsayi(ders.HarfNotu) * ders.AKTS;
            toplamAkts += ders.AKTS;
        }

        double gano = toplamAkts > 0
            ? toplamPuan / toplamAkts
            : 0;

        ganoLabel.Text = $"GANO : {gano:F2}";
    }

    double Katsayi(string harf)
    {
        return harf switch
        {
            "AA" => 4.0,
            "BA" => 3.5,
            "BB" => 3.0,
            "CB" => 2.5,
            "CC" => 2.0,
            "DC" => 1.5,
            "DD" => 1.0,
            _ => 0
        };
    }
}