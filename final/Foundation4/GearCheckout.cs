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

        
