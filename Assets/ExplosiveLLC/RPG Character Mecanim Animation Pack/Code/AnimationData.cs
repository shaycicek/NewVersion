using RPGCharacterAnims.Extensions;
using RPGCharacterAnims.Lookups;
using UnityEngine;

namespace RPGCharacterAnims
{
	/// <summary>
	/// Static class which contains hardcoded animation constants and helper functions.
	/// </summary>
	public class AnimationData
	{
		/// <summary>
		/// Converts left and right-hand weapon numbers into the legacy weapon number usable by the
		/// animator's "Weapon" parameter.
		/// </summary>
		/// <param name="leftWeapon">Left-hand weapon.</param>
		/// <param name="rightWeapon">Right-hand weapon.</param>
		public static AnimatorWeapon ConvertToAnimatorWeapon(Weaponn leftWeapon, Weaponn rightWeapon)
		{
			// 2-handed weapon.
			if (rightWeapon.Is2HandedWeapon()) { return ( AnimatorWeapon )rightWeapon; }

			// Unarmed or Relax.
			if (rightWeapon.HasNoWeapon() && leftWeapon.HasNoWeapon()) { return ( AnimatorWeapon )rightWeapon; }

			// Armed.
			return AnimatorWeapon.ARMED;
		}

		/// <summary>
		/// Returns the duration of an attack animation. Use side 0 (none) for two-handed weapons.
		/// </summary>
		/// <param name="attackSide">Side of the attack: 0- None, 1- Left, 2- Right, 3- Dual.</param>
		/// <param name="weapon">Weapon that's attacking.</param>
		/// <param name="attackNumber">Attack animation number.</param>
		/// <returns>Duration in seconds of attack animation.</returns>
		public static float AttackDuration(Side attackSide, Weaponn weapon, int attackNumber)
		{
			var duration = 1f;

			switch (attackSide) {
				case Side.None:						// Unspecified (2-Handed Weapons)
					switch (weapon) {
						case Weaponn.TwoHandSword:
							duration = 1.1f;
							break;
						case Weaponn.TwoHandSpear:
							duration = 1.1f;
							break;
						case Weaponn.TwoHandAxe:
							duration = 1.5f;
							break;
						case Weaponn.TwoHandBow:
							duration = 0.75f;
							break;
						case Weaponn.TwoHandCrossbow:
							duration = 0.75f;
							break;
						case Weaponn.TwoHandStaff:
							duration = 1f;
							break;
						case Weaponn.Rifle:
							duration = 1.1f;
							break;
						default:
							Debug.LogError("RPG Character: no weapon number " + weapon + " for Side 0");
							break;
					}
					break;

				case Side.Left:						// Left Side
					switch (weapon) {
						case Weaponn.Unarmed:
							duration = 0.75f;
							break;					// Unarmed  (1-3)
						case Weaponn.Shield:
							duration = 1.1f;
							break;					// Shield   (1-1)
						case Weaponn.LeftSword:
							duration = 0.75f;
							break;					// L Sword  (1-7)
						case Weaponn.LeftMace:
							duration = 0.75f;
							break;					// L Mace   (1-3)
						case Weaponn.LeftDagger:
							duration = 1f;
							break;					// L Dagger (1-3)
						case Weaponn.LeftItem:
							duration = 1f;
							break;					// L Item   (1-4)
						case Weaponn.LeftPistol:
							duration = 0.75f;
							break;					// L Pistol (1-3)
						default:
							Debug.LogError("RPG Character: no weapon number " + weapon + " for Side 1 (Left)");
							break;
					}
					break;
				case Side.Right:					// Right Side
					switch (weapon) {
						case Weaponn.Unarmed:
							duration = 0.75f;
							break;					// Unarmed  (4-6)
						case Weaponn.RightSword:
							duration = 0.75f;
							break;					// R Sword  (8-14)
						case Weaponn.RightMace:
							duration = 0.75f;
							break;					// R Mace   (4-6)
						case Weaponn.RightDagger:
							duration = 1f;
							break;					// R Dagger (4-6)
						case Weaponn.RightItem:
							duration = 1f;
							break;					// R Item   (5-8)
						case Weaponn.RightPistol:
							duration = 0.75f;
							break;					// R Pistol (4-6)
						case Weaponn.RightSpear:
							duration = 0.75f;
							break;					// R Spear  (1-7)
						default:
							Debug.LogError("RPG Character: no weapon number " + weapon + " for Side 2 (Right)");
							break;
					}
					break;
				case Side.Dual:
					duration = 0.75f;
					break;							// Dual Attacks (1-3)
			}

			return duration;
		}

		/// <summary>
		/// Returns the duration of the weapon sheath animation.
		/// </summary>
		/// <param name="attackSide">Side of the attack: 0- None, 1- Left, 2- Right, 3- Dual.</param>
		/// <param name="weaponNumber">Weapon being sheathed.</param>
		/// <returns>Duration in seconds of sheath animation.</returns>
		public static float SheathDuration(Side attackSide, Weaponn weapon)
		{
			var duration = 1f;

			if (weapon.HasNoWeapon()) { duration = 0f; }
			else if (weapon.Is2HandedWeapon()) { duration = 1.2f; }
			else if (attackSide == Side.Dual) { duration = 1f; }
			else { duration = 1.05f; }

			return duration;
		}

		/// <summary>
		/// Returns a random attack number usable as the animator's Action parameter.
		/// </summary>
		/// <param name="sideType">Side of the attack: 0- None, 1- Left, 2- Right, 3- Dual.</param>
		/// <param name="weapon">Weapon attacking.</param>
		/// <returns>Attack animation number.</returns>
		public static int RandomAttackNumber(Side sideType, Weaponn weapon)
		{
			switch (sideType) {
				case Side.None:
					switch (weapon) {
						case Weaponn.TwoHandSword:
							return ( int )AnimationVariations.TwoHandedSwordAttacks.TakeRandom();
						case Weaponn.TwoHandSpear:
							return ( int )AnimationVariations.TwoHandedSpearAttacks.TakeRandom();
						case Weaponn.TwoHandAxe:
							return ( int )AnimationVariations.TwoHandedAxeAttacks.TakeRandom();
						case Weaponn.TwoHandBow:
							return ( int )AnimationVariations.TwoHandedBowAttacks.TakeRandom();
						case Weaponn.TwoHandCrossbow:
							return ( int )AnimationVariations.TwoHandedCrossbowAttacks.TakeRandom();
						case Weaponn.TwoHandStaff:
							return ( int )AnimationVariations.TwoHandedStaffAttacks.TakeRandom();
						case Weaponn.Rifle:
							return ( int )AnimationVariations.ShootingAttacks.TakeRandom();
						default:
							Debug.LogError($"RPG Character: no weapon number {weapon} for Side 0");
							break;
					}
					break;

				case Side.Left:
					switch (weapon) {
						case Weaponn.Unarmed:
							return ( int )AnimationVariations.UnarmedLeftAttacks.TakeRandom();
						case Weaponn.Shield:
							return ( int )AnimationVariations.ShieldAttacks.TakeRandom();
						case Weaponn.LeftSword:
							return ( int )AnimationVariations.LeftSwordAttacks.TakeRandom();
						case Weaponn.LeftMace:
							return ( int )AnimationVariations.LeftMaceAttacks.TakeRandom();
						case Weaponn.LeftDagger:
							return ( int )AnimationVariations.LeftDaggerAttacks.TakeRandom();
						case Weaponn.LeftItem:
							return ( int )AnimationVariations.LeftItemAttacks.TakeRandom();
						case Weaponn.LeftPistol:
							return ( int )AnimationVariations.LeftPistolAttacks.TakeRandom();
						default:
							Debug.LogError($"RPG Character: no weapon number {weapon} for Side 1 (Left)");
							break;
					}
					break;
				case Side.Right:
					switch (weapon) {
						case Weaponn.Unarmed:
							return ( int )AnimationVariations.UnarmedRightAttacks.TakeRandom();
						case Weaponn.RightSword:
							return ( int )AnimationVariations.RightSwordAttacks.TakeRandom();
						case Weaponn.RightMace:
							return ( int )AnimationVariations.RightMaceAttacks.TakeRandom();
						case Weaponn.RightDagger:
							return ( int )AnimationVariations.RightDaggerAttacks.TakeRandom();
						case Weaponn.RightItem:
							return ( int )AnimationVariations.RightItemAttacks.TakeRandom();
						case Weaponn.RightPistol:
							return ( int )AnimationVariations.RightPistolAttacks.TakeRandom();
						case Weaponn.RightSpear:
							return ( int )AnimationVariations.RightSpearAttacks.TakeRandom();
						default:
							Debug.LogError($"RPG Character: no weapon number {weapon} for Side 2 (Right)");
							break;
					}
					break;
				case Side.Dual:
					return ( int )AnimationVariations.DualAttacks.TakeRandom();
			}

			return 1;
		}

		public static EmoteType RandomBow()
		{ return AnimationVariations.Bow.TakeRandom(); }

		public static Vector3 HitDirection(HitType hitType)
		{
			switch (hitType) {
				case HitType.Back1:
					return Vector3.forward;
				case HitType.Left1:
					return Vector3.right;
				case HitType.Right1:
					return Vector3.left;
				case HitType.Forward1:
				case HitType.Forward2:
				default:
					return Vector3.back;
			}
		}

		public static Vector3 HitDirection(KnockbackType hitType)
		{
			switch (hitType) {
				case KnockbackType.Knockback1:
				case KnockbackType.Knockback2:
				default:
					return Vector3.back;
			}
		}

		public static Vector3 HitDirection(BlockedHitType hitType)
		{ return Vector3.back; }

		public static Vector3 HitDirection(KnockdownType hitType)
		{ return Vector3.back; }
	}
}