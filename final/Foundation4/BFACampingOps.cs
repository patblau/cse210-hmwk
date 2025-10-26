using System;

// CampActivity.cs
// Base class: shared state + virtual scoring/summary

public class CampActivity
{
    // Core shared state (encapsulated)
    public string Name { get; }
    public string Notes { get; private set; }
    public int Minutes { get; private set; }
    public int StaffAssigned { get; private set; }
    public int GuestsAffected { get; private set; }
    public DateTime? StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }

    // Constructor (validation + defaults)
        public CampActivity(string name, string notes = "", int minutes = 0, int staffAssigned = 0, int guestsAffected = 0)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Activity" : name.Trim();
            Notes = notes?.Trim() ?? string.Empty;
            Minutes = Math.Max(0, minutes);
            StaffAssigned = Math.Max(0, staffAssigned);
            GuestsAffected = Math.Max(0, guestsAffected);
        }


}

