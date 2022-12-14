using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims.Actions
{
    public class Shoot : InstantActionHandler<EmptyContext>
    {
        public override bool CanStartAction(RPGCharacterController controller)
        { return controller.isAiming; }

        protected override void _StartAction(RPGCharacterController controller, EmptyContext context)
        {
            var attackNumber = 1;
            if (controller.rightWeapon == Weaponn.Rifle && controller.isHipShooting) { attackNumber = 2; }
            controller.Shoot(attackNumber);
        }
    }
}