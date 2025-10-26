using System;

//GearCheckout.cs
// Derived: equipment type + volume modifiers + damage penalty

namespace BFACampingOps
{
    // 0) Enum for gear categories (expand later as needed)
    public enum EquipmentType { Kayak, SUP, Canoe, Tent, Stove, PFD, Oars, Helmet, Wetsuit, Other }

    public class GearCheckout : CampActivity
    {
        // 1) Specific fields
        public EquipmentType Type { get; private set; }
        public int VolumeCheckedOut { get; private set; }
        public int DamageIncidents  { get; private set; }

    // 2) Constructor
    public GearCheckout(EquipmentType type, string notes = "", int minutes = 0, int staff = 0, int guests = 0,
                        int volume = 0, int damage = 0)
        : base("Gear Checkout", notes, minutes, staff, guests)
    {
        Type = type;
        VolumeCheckedOut = Math.Max(0, volume);
        DamageIncidents = Math.Max(0, damage);
    }
        
        //Mutators
        public void AddVolume(int qty)       => VolumeCheckedOut += Math.Max(0, qty);
        public void ReportDamage(int count)  => DamageIncidents  += Math.Max(0, count);

        // 4) Polymorphic scoring + summary
        public override int PointsEarned()
        {
            // Outline: time value + volume*type multiplier − damage penalties
            return base.PointsEarned(); // placeholder
        }

        public override string Summary()
        {
            // Outline: show type, volume, damage, minutes, points
            return $"{Name} — [Type/Vol/Dmg] | Points: {PointsEarned()}";
        }
    }
}