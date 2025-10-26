using System;

//GearCheckout.cs
// Derived: equipment type + volume modifiers + damage penalty

namespace BFACampingOps
{
    // Enum for gear categories 
    public enum EquipmentType { Kayak, SUP, Canoe, Tent, Stove, PFD, Oars, Helmet, Wetsuit, Other }
        
        //Specific fields
        public EquipmentType Type { get; private set; }
        public int VolumeCheckedOut { get; private set; }
        public int DamageIncidents { get; private set; }

    // Constructor
    public GearCheckout(EquipmentType type, string notes = "", int minutes = 0, int staff = 0, int guests = 0,
                        int volume = 0, int damage = 0)
        : base("Gear Checkout", notes, minutes, staff, guests)
    {
        Type = type;
        VolumeCheckedOut = Math.Max(0, volume);
        DamageIncidents = Math.Max(0, damage);
    }
        
        // Polymorphic scoring + summary
        public override int PointsEarned()
        {
            // Outline: time value + volume*type multiplier − damage penalties
            return base.PointsEarned(); // placeholder
        }
    }


}
    
