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

        // ============================
        // Book of Mormon
        // Mosiah 4:10–11
        // Verse 10 is exactly as you provided. Add your preferred verse 11 wording below where marked.
        // ============================
        Add(StandardWork.BookOfMormon,
            new ScriptureInfo(
                new Reference("Mosiah", 4, 10, 11),
                "10 And again, believe that ye must repent of your sins and forsake them, and humble yourselves before God; " +
                "and ask in sincerity of heart that he would forgive you; and now, if you believe all these things see that ye do them. " +
                "11 [Paste your preferred Mosiah 4:11 wording here.]"
            )
        );

        // ============================
        // Doctrine and Covenants
        // D&C 8:2–4 (exact text you gave)
        // ============================
        Add(StandardWork.DoctrineAndCovenants,
            new ScriptureInfo(
                new Reference("Doctrine and Covenants", 8, 2, 4),
                "2 Yea, behold, I will tell you in your mind and in your heart, by the Holy Ghost, which shall come upon you and which shall dwell in your heart. " +
                "3 Now, behold, this is the spirit of revelation; behold, this is the spirit by which Moses brought the children of Israel through the Red Sea on dry ground. " +
                "4 Therefore this is thy gift; apply unto it, and blessed art thou, for it shall deliver you out of the hands of your enemies, " +
                "when, if it were not so, they would slay you and bring your soul to destruction."
            )
        );// ============================
        // Pearl of Great Price
        // Moses 7:10–11
        // Verse 10 as you provided. Add your verse 11 wording where marked.
        // ============================
        Add(StandardWork.PearlOfGreatPrice,
            new ScriptureInfo(
                new Reference("Moses", 7, 10, 11),
                "10 And the Lord said unto me: Go to this people, and say unto them—Repent, lest I come out and smite them with a curse, and they die. " +
                "11 [Paste your preferred Moses 7:11 wording here (and any extra lines you want).]"
            )
        );
    }
}





