IDataDownloader dw = new CachingDownloader(new Downloader());

Console.WriteLine(dw.SlowDownloadData("32da-224ef-124a-ab12"));
Console.WriteLine(dw.SlowDownloadData("ab12-32da-224ef-124a"));
Console.WriteLine(dw.SlowDownloadData("124a-32da-224ef-ab12"));

System.Console.WriteLine("CACHED");
Console.WriteLine(dw.SlowDownloadData("32da-224ef-124a-ab12"));
Console.WriteLine(dw.SlowDownloadData("ab12-32da-224ef-124a"));


public class Cache<TKey, TData>
{
    Dictionary<TKey, TData> _cachedData = new();

    public TData Get(TKey key, Func<TKey, TData> getInitialData)
    {
        if (!_cachedData.ContainsKey(key))
        {
            _cachedData[key] = getInitialData(key);
        }
        return _cachedData[key];
    }
}

public interface IDataDownloader
{
    public string SlowDownloadData(string id);
}

public class CachingDownloader : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;
    private readonly Cache<string, string> _cache = new();

    public CachingDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string SlowDownloadData(string id)
    {
        return _cache.Get(id, _dataDownloader.SlowDownloadData);
    }
}

public class Downloader : IDataDownloader
{
    public string SlowDownloadData(string id)
    {
        Thread.Sleep(1000);
        return $"Returning data with id: {id}";

    }
}