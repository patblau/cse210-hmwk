using System;
using System.Collections.Generic;

public class ScriptureRepository
{
    // Collection -> list of scriptures
    private readonly Dictionary<StandardWork, List<ScriptureInfo>> _data
        = new Dictionary<StandardWork, List<ScriptureInfo>>();

    public ScriptureRepository()
    {
        SeedDefaults();
    }

    /// <summary>
    /// Get all scriptures in a given collection (never null).
    /// </summary>
    public List<ScriptureInfo> GetByStandardWork(StandardWork work)
    {
        if (_data.TryGetValue(work, out var list)) return list;
        return new List<ScriptureInfo>();
    }
    
    /// <summary>
    /// Get a random scripture from a collection (or null if none).
    /// </summary>
    public ScriptureInfo? GetRandom(StandardWork work)
    {
        var list = GetByStandardWork(work);
        if (list.Count == 0) return null;
        var rng = new Random();
        return list[rng.Next(list.Count)];
    }