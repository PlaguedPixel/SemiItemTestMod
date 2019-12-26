using UnityEngine;

namespace ItemTestMod
{
    public class SnailBullets : GunVolleyModificationItem
    {
        public GameObject SnailVFX;

        public SnailBullets()
        {
            SnailVFX = ResourceCache.Acquire("Global VFX/VFX_Speed_Status") as GameObject;
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.PostProcessProjectile += PostProcessProjectile;
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.PostProcessProjectile -= PostProcessProjectile;
            return base.Drop(player);
        }

        protected override void OnDestroy()
        {
            Owner.PostProcessProjectile -= PostProcessProjectile;
            base.OnDestroy();
        }

        private void PostProcessProjectile(Projectile proj, float effectChanceScalar)
        {
            proj.baseData.speed *= 0.7f;
            GameActorSpeedEffect slowEffect = new GameActorSpeedEffect
            {
                OverheadVFX = SnailVFX
            };
            slowEffect.SpeedMultiplier = 0.25f;
            slowEffect.duration = 5f;
            proj.SpeedApplyChance = 0.8f;
            proj.speedEffect = slowEffect;
            proj.statusEffectsToApply.Add(slowEffect);

        }
    }
}
