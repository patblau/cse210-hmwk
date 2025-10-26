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


    // Mutators for shared state
    public void Start() { } /* set StartTime, clear EndTime */
    public void Stop() { } /* set EndTime, compute Minutes from Start/End */
    public void SetMinutes(int minutes) => Minutes = Math.Max(0, minutes);
    public void SetStaff(int staff) => StaffAssigned = Math.Max(0, staff);
    public void SetGuests(int guests) => GuestsAffected = Math.Max(0, guests);
    public void UpdateNotes(string notes) => Notes = notes?.Trim() ?? string.Empty;


    //Polymorphic override in derived classes
    public virtual int PointsEarned()
    {    
        return (int)Math.Round(Minutes * 0.2) + GuestsAffected * 1; // time value + guest impact
    }
    




