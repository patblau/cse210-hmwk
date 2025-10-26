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
}
