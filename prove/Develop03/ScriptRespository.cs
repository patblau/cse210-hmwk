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
    private void Add(StandardWork work, ScriptureInfo info)
    {
        if (!_data.ContainsKey(work))
        {
            _data[work] = new List<ScriptureInfo>();
        }
        _data[work].Add(info); 
    }

    private void SeedDefaults()
    {
        // ============================
        // Old Testament
        // ============================
        Add(StandardWork.OldTestament,
            new ScriptureInfo(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the LORD with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."
            )
        );

        // ============================
        // New Testament
        // ============================
        Add(StandardWork.NewTestament,
            new ScriptureInfo(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."
            )
        );

