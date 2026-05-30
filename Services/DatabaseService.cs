using SQLite;
using System.IO;
using Microsoft.Maui.Storage;
using GanoHesaplama.Models;

namespace GanoHesaplama.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection db;

    public DatabaseService()
    {
        var path = Path.Combine(FileSystem.AppDataDirectory, "gano.db");
        db = new SQLiteAsyncConnection(path);
    }

    public async Task Init()
    {
        await db.CreateTableAsync<Ders>();
    }

    public async Task AddDers(Ders ders)
    {
        await Init();
        await db.InsertAsync(ders);
    }

    public async Task<List<Ders>> GetDersler()
    {
        await Init();
        return await db.Table<Ders>().ToListAsync();
    }

    public async Task UpdateDers(Ders ders)
    {
        await Init();
        await db.UpdateAsync(ders);
    }

    public async Task DeleteDers(Ders ders)
    {
        await Init();
        await db.DeleteAsync(ders);
    }
}