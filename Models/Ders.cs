using SQLite;

namespace GanoHesaplama.Models;

public class Ders
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string DersKodu { get; set; } = string.Empty;

    public string DersAdi { get; set; } = string.Empty;

    public int HaftalikSaat { get; set; }

    public int AKTS { get; set; }

    public bool OrtalamayaKatilir { get; set; }

    public string Donem { get; set; } = string.Empty;

    public string HarfNotu { get; set; } = string.Empty;
}