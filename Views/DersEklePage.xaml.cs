using GanoHesaplama.Models;
using GanoHesaplama.Services;

namespace GanoHesaplama.Views;

public partial class DersEklePage : ContentPage
{
    private readonly DatabaseService service = new();

    public DersEklePage()
    {
        InitializeComponent();
    }

    private async void Kaydet_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(kod.Text) ||
            string.IsNullOrWhiteSpace(ad.Text) ||
            string.IsNullOrWhiteSpace(saat.Text) ||
            string.IsNullOrWhiteSpace(akts.Text) ||
            string.IsNullOrWhiteSpace(donem.Text) ||
            harfNotu.SelectedItem == null)
        {
            await DisplayAlert("Uyarı", "Tüm alanları doldurmalısın", "Tamam");
            return;
        }

        if (!int.TryParse(saat.Text, out int saatValue) ||
            !int.TryParse(akts.Text, out int aktsValue))
        {
            await DisplayAlert("Hata", "Saat ve AKTS sayı olmalı", "Tamam");
            return;
        }

        var ders = new Ders
        {
            DersKodu = kod.Text.Trim(),
            DersAdi = ad.Text.Trim(),
            HaftalikSaat = saatValue,
            AKTS = aktsValue,
            Donem = donem.Text.Trim(),
            HarfNotu = harfNotu.SelectedItem?.ToString() ?? "",
            OrtalamayaKatilir = ortalama.IsToggled
        };

        await service.AddDers(ders);

        await DisplayAlert("Başarılı", "Ders eklendi", "Tamam");

        kod.Text = "";
        ad.Text = "";
        saat.Text = "";
        akts.Text = "";
        donem.Text = "";
        harfNotu.SelectedItem = null;
        ortalama.IsToggled = false;
    }
}