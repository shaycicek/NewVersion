using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims.Extensions
{
	public static class WeaponExtensions
	{
		/// <summary>
		/// Checks if the weapon is a right handed weapon.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True if right handed, false if not.</returns>
		public static bool IsRightHandedWeapon(this Weaponn weapon)
		{
			return weapon == Weaponn.RightSword || weapon == Weaponn.RightMace || weapon == Weaponn.RightDagger ||
				   weapon == Weaponn.RightItem || weapon == Weaponn.RightPistol || weapon == Weaponn.RightSpear;
		}

		/// <summary>
		/// Checks if the weapon is a left handed weapon.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True if left handed, false if not.</returns>
		public static bool IsLeftHandedWeapon(this Weaponn weapon)
		{
			return weapon == Weaponn.LeftSword || weapon == Weaponn.LeftMace || weapon == Weaponn.LeftDagger ||
				   weapon == Weaponn.LeftItem || weapon == Weaponn.LeftPistol || weapon == Weaponn.Shield;
		}

		/// <summary>
		/// Checks if the weapon is a 2 Handed weapon.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True if 2 Handed, false if not.</returns>
		public static bool Is2HandedWeapon(this Weaponn weapon)
		{
			return weapon == Weaponn.Rifle || weapon == Weaponn.TwoHandStaff || weapon == Weaponn.TwoHandCrossbow ||
				   weapon == Weaponn.TwoHandBow || weapon == Weaponn.TwoHandAxe || weapon == Weaponn.TwoHandSpear ||
				   weapon == Weaponn.TwoHandSword;
		}

		/// <summary>
		/// Checks if the weapon is aimable.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True if aimable, false if not.</returns>
		public static bool IsAimedWeapon(this Weaponn weapon)
		{ return weapon == Weaponn.Rifle || weapon == Weaponn.TwoHandBow || weapon == Weaponn.TwoHandCrossbow; }

		/// <summary>
		/// Checks if the weapon is equipped, i.e not Relaxing, or Unarmed.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True or false.</returns>
		public static bool HasEquippedWeapon(this Weaponn weapon)
		{ return weapon != Weaponn.Relax && weapon != Weaponn.Unarmed; }

		/// <summary>
		/// Checks if the weapon is empty, i.e Relaxing, or Unarmed.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True or false.</returns>
		public static bool HasNoWeapon(this Weaponn weapon)
		{ return weapon == Weaponn.Relax || weapon == Weaponn.Unarmed; }

		/// <summary>
		/// Checks if the weapon is a 1 Handed weapon.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True if 1 Handed, false if not.</returns>
		public static bool Is1HandedWeapon(this Weaponn weapon)
		{ return IsLeftHandedWeapon(weapon) || IsRightHandedWeapon(weapon); }

		/// <summary>
		/// Checks if the weapon is a castable weapon.
		/// </summary>
		/// <param name="weapon">Weapon value to check</param>
		/// <returns>True if castable, false if not</returns>
		public static bool IsCastableWeapon(this Weaponn weapon)
		{
			return weapon != Weaponn.Rifle && weapon != Weaponn.TwoHandAxe && weapon != Weaponn.TwoHandBow &&
				   weapon != Weaponn.TwoHandCrossbow && weapon != Weaponn.TwoHandSpear && weapon != Weaponn.TwoHandSword;
		}

		/// <summary>
		/// Returns true if the weapon number can use IKHands.
		/// </summary>
		/// <param name="weapon">Weapon to test.</param>
		public static bool IsIKWeapon(this Weaponn weapon)
		{
			return weapon == Weaponn.TwoHandSword
				   || weapon == Weaponn.TwoHandSpear
				   || weapon == Weaponn.TwoHandAxe
				   || weapon == Weaponn.TwoHandCrossbow
				   || weapon == Weaponn.Rifle;
		}

		/// <summary>
		/// This converts the Weapon into AnimatorWeapon, which is used in the Animator component to determine the
		/// proper state to set the character into, because all 1 Handed weapons use the ARMED state. 2 Handed weapons,
		/// Unarmed, and Relax map directly from Weapon to AnimatorWeapon.
		/// </summary>
		/// <param name="weapon">Weapon to convert.</param>
		/// <returns></returns>
		public static AnimatorWeapon ToAnimatorWeapon(this Weaponn weapon)
		{
			if (weapon == Weaponn.Unarmed || weapon == Weaponn.TwoHandAxe || weapon == Weaponn.TwoHandBow
				|| weapon == Weaponn.TwoHandCrossbow || weapon == Weaponn.TwoHandSpear
				|| weapon == Weaponn.TwoHandStaff  || weapon == Weaponn.TwoHandSword || weapon == Weaponn.Rifle)
			{ return ( AnimatorWeapon )weapon; }

			if (weapon == Weaponn.Relax) { return AnimatorWeapon.RELAX; }

			return AnimatorWeapon.ARMED;
		}

		/// <summary>
		/// Checks if the animator weapon is a 1 Handed weapon.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True if 1 Handed, false if not.</returns>
		public static bool Is1HandedAnimWeapon(this AnimatorWeapon weapon)
		{ return weapon == AnimatorWeapon.ARMED; }

		/// <summary>
		/// Checks if the animator weapon is a 2 Handed weapon.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True if 1 Handed, false if not.</returns>
		public static bool Is2HandedAnimWeapon(this AnimatorWeapon weapon)
		{
			return weapon == AnimatorWeapon.RIFLE || weapon == AnimatorWeapon.STAFF ||
				 weapon == AnimatorWeapon.TWOHANDAXE || weapon == AnimatorWeapon.TWOHANDBOW ||
				 weapon == AnimatorWeapon.TWOHANDSPEAR || weapon == AnimatorWeapon.TWOHANDSWORD ||
				 weapon == AnimatorWeapon.TWOHANDCROSSBOW;
		}

		/// <summary>
		/// Checks if the animator weapon is Unarmed or Relaxed.
		/// </summary>
		/// <param name="weapon">Weapon value to check.</param>
		/// <returns>True if 1 Handed, false if not.</returns>
		public static bool HasNoAnimWeapon(this AnimatorWeapon weapon)
		{ return weapon == AnimatorWeapon.UNARMED || weapon == AnimatorWeapon.RELAX; }
	}
}