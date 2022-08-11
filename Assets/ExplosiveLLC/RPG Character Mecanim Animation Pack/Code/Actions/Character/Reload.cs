using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims.Actions
{
    public class Reload : InstantActionHandler<EmptyContext>
    {
        public override bool CanStartAction(RPGCharacterController controller)
        {
            return !controller.isRelaxed &&
                   (controller.rightWeapon == Weaponn.TwoHandCrossbow ||
                    controller.rightWeapon == Weaponn.Rifle ||
                    controller.rightWeapon == Weaponn.RightPistol ||
                    controller.leftWeapon == Weaponn.LeftPistol);
        }

        protected override void _StartAction(RPGCharacterController controller, EmptyContext context)
        { controller.Reload(); }
    }
}