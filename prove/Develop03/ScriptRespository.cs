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

    /// <summary>Get all scriptures in a given collection (never null).</summary>
    public List<ScriptureInfo> GetByStandardWork(StandardWork work)
    {
        if (_data.TryGetValue(work, out var list)) return list;
        return new List<ScriptureInfo>();
    }

    /// <summary>Get a random scripture from a collection (or null if none).</summary>
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
        _data[work].Add(info); // NOTE: capital A
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

        Add(StandardWork.OldTestament,
            new ScriptureInfo(
                new Reference("Jeremiah", 10, 6, 7),
                "6 Forasmuch as there is none like unto thee, O LORD; thou art great, and thy name is great in might. " +
                "7 Who would not fear thee, O thou King of nations? for to thee doth it appertain: forasmuch as among " +
                "all the wise men of the nations, and in all their kingdoms, there is none like unto thee."
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

        Add(StandardWork.NewTestament,
            new ScriptureInfo(
                new Reference("Matthew", 18, 10, 11),
                "10 Take heed that ye despise not one of these little ones; for I say unto you, " +
                "That in heaven their angels do always behold the face of my Father which is in heaven. " +
                "11 For the Son of man is come to save that which was lost."
            )
        );

        // ============================
        // Book of Mormon
        // ============================
        Add(StandardWork.BookOfMormon,
            new ScriptureInfo(
                new Reference("Mosiah", 4, 10, 11),
                "10 And again, believe that ye must repent of your sins and forsake them, and humble yourselves before God; " +
                "and ask in sincerity of heart that he would forgive you; and now, if you believe all these things see that ye do them. " +
                "11 [Paste your preferred Mosiah 4:11 wording here.]"
            )
        );

        Add(StandardWork.BookOfMormon,
            new ScriptureInfo(
                new Reference("Alma", 10, 16),
                "I say unto you, can you imagine to yourselves that ye hear the voice of the Lord, saying unto you, in that day: " +
                "Come unto me ye blessed, for behold, your works have been the works of righteousness upon the face of the earth?"
            )
        );

        // ============================
        // Doctrine and Covenants
        // ============================
        Add(StandardWork.DoctrineAndCovenants,
            new ScriptureInfo(
                new Reference("Doctrine and Covenants", 8, 2, 4),
                "2 Yea, behold, I will tell you in your mind and in your heart, by the Holy Ghost, which shall come upon you and which shall dwell in your heart. " +
                "3 Now, behold, this is the spirit of revelation; behold, this is the spirit by which Moses brought the children of Israel through the Red Sea on dry ground. " +
                "4 Therefore this is thy gift; apply unto it, and blessed art thou, for it shall deliver you out of the hands of your enemies, " +
                "when, if it were not so, they would slay you and bring your soul to destruction."
            )
        );

        Add(StandardWork.DoctrineAndCovenants,
            new ScriptureInfo(
                new Reference("Doctrine and Covenants", 58, 26, 28),
                "26 For behold, it is not meet that I should command in all things; for he that is compelled in all things, " +
                "the same is a slothful and not a wise servant; wherefore he receiveth no reward. " +
                "27 Verily I say, men should be anxiously engaged in a good cause, and do many things of their own free will, and bring to pass much righteousness; " +
                "28 For the power is in them, wherein they are agents unto themselves. And inasmuch as they do good they shall in nowise lose their reward."
            )
        );

        // ============================
        // Pearl of Great Price
        // ============================
        Add(StandardWork.PearlOfGreatPrice,
            new ScriptureInfo(
                new Reference("Moses", 7, 10, 11),
                "10 And the Lord said unto me: Go to this people, and say unto them—Repent, lest I come out and smite them with a curse, and they die. " +
                "11 [Paste your preferred Moses 7:11 wording here.]"
            )
        );

        Add(StandardWork.PearlOfGreatPrice,
            new ScriptureInfo(
                new Reference("Abraham", 2, 8),
                "8 My name is Jehovah, and I know the end from the beginning; therefore my hand shall be over thee."
            )
        );
    }
}}