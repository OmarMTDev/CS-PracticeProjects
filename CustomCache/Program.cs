Downloader dw = new ();

Console.WriteLine(dw.CachedDownloadData("32da-224ef-124a-ab12"));
Console.WriteLine(dw.CachedDownloadData("ab12-32da-224ef-124a"));
Console.WriteLine(dw.CachedDownloadData("124a-32da-224ef-ab12"));

System.Console.WriteLine("CACHED");
Console.WriteLine(dw.CachedDownloadData("32da-224ef-124a-ab12"));
Console.WriteLine(dw.CachedDownloadData("ab12-32da-224ef-124a"));


public class Cache<TKey, TData>
{
    Dictionary<TKey, TData> _cachedData = new();

    public TData Get(TKey key, Func<TKey,TData> getInitialData)
    {
        if (!_cachedData.ContainsKey(key))
        {
            _cachedData[key] = getInitialData(key);
        }
        return _cachedData[key];
    }
}

public class Downloader
{
    private readonly Cache<string, string> _cachedData = new();

    public string CachedDownloadData(string id)
    {
    
       return _cachedData.Get(id, SlowDownloadData);

    }
    public string SlowDownloadData(string id)
    {
        Thread.Sleep(1000);
       return $"Returning data with id: {id}";

    }
}