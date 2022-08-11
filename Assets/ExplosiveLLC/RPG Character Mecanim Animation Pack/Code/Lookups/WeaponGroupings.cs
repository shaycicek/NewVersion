using System;

namespace RPGCharacterAnims.Lookups
{
    public class WeaponGroupings
    {
        public static Weaponn[] LeftHandedWeapons = new Weaponn[] {
            Weaponn.Shield,
            Weaponn.LeftSword,
            Weaponn.LeftMace,
            Weaponn.LeftDagger,
            Weaponn.LeftItem,
            Weaponn.LeftPistol,
        };

        public static Weaponn[] RightHandedWeapons = new Weaponn[] {
            Weaponn.Unarmed,
            Weaponn.RightSword,
            Weaponn.RightMace,
            Weaponn.RightDagger,
            Weaponn.RightItem,
            Weaponn.RightPistol,
            Weaponn.RightSpear,
        };

        public static Weaponn[] TwoHandedWeapons = new Weaponn[] {
            Weaponn.TwoHandSword,
            Weaponn.TwoHandSpear,
            Weaponn.TwoHandAxe,
            Weaponn.TwoHandStaff,
            Weaponn.TwoHandBow,
            Weaponn.TwoHandCrossbow,
            Weaponn.Rifle,
        };

        public static Tuple<Weaponn, Weaponn>[] LeftRightWeaponPairs = new Tuple<Weaponn, Weaponn>[] {
            Tuple.Create(Weaponn.LeftSword, Weaponn.RightSword),
            Tuple.Create(Weaponn.LeftMace, Weaponn.RightMace),
            Tuple.Create(Weaponn.LeftDagger, Weaponn.RightDagger),
            Tuple.Create(Weaponn.LeftItem, Weaponn.RightItem),
            Tuple.Create(Weaponn.LeftPistol, Weaponn.RightPistol),
            Tuple.Create(Weaponn.Shield, Weaponn.RightSpear),
        };
    }
}