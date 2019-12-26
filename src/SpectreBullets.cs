namespace ItemTestMod
{
    public class SpectreBullets : GunVolleyModificationItem
    {
        public FleePlayerData FearEffect;
        public SpectreBullets()
        {
            FearEffect = new FleePlayerData();
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            FearEffect.Player = player;
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
            GameActorFearEffect fearEffect = new GameActorFearEffect();
            fearEffect.FearEffect = FearEffect;
            fearEffect.FearApplyChance = 0.5f;
            proj.statusEffectsToApply.Add(fearEffect);
        }
    }
}
