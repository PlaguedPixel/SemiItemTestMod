using System;

namespace ItemTestMod {
    public class BashfulShot : PassiveItem {
        public StatModifier ReloadSpeedModifier;
        public StatModifier FireRateModifier;
        public StatModifier AccuracyModifier;
        public float StatIncrease;

        public BashfulShot() {
            RecalculateStatIncrease();
            ReloadSpeedModifier = new StatModifier
            {
                statToBoost = PlayerStats.StatType.ReloadSpeed,
                amount = 1f/StatIncrease,
                modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
            };
            FireRateModifier = new StatModifier
            {
                statToBoost = PlayerStats.StatType.RateOfFire,
                amount = StatIncrease,
                modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
            };
            AccuracyModifier = new StatModifier
            {
                statToBoost = PlayerStats.StatType.Accuracy,
                amount = 1f/StatIncrease,
                modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
            };
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            RecalculateStatIncrease();
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.ownerlessStatModifiers.Remove(ReloadSpeedModifier);
            player.ownerlessStatModifiers.Remove(FireRateModifier);
            player.ownerlessStatModifiers.Remove(AccuracyModifier);
            player.stats.RecalculateStats(player);
            RecalculateStatIncrease();
            return base.Drop(player);
        }

        protected override void Update()
        {
            base.Update();
            RecalculateStatIncrease();
            if (FireRateModifier.amount != StatIncrease)
            {
                this.Owner.ownerlessStatModifiers.Remove(ReloadSpeedModifier);
                this.Owner.ownerlessStatModifiers.Remove(FireRateModifier);
                this.Owner.ownerlessStatModifiers.Remove(AccuracyModifier);
                this.Owner.stats.RecalculateStats(this.Owner);
                ReloadSpeedModifier = new StatModifier
                {
                    statToBoost = PlayerStats.StatType.ReloadSpeed,
                    amount = 1f / StatIncrease,
                    modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
                };
                FireRateModifier = new StatModifier
                {
                    statToBoost = PlayerStats.StatType.RateOfFire,
                    amount = StatIncrease,
                    modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
                };
                AccuracyModifier = new StatModifier
                {
                    statToBoost = PlayerStats.StatType.Accuracy,
                    amount = 1f / StatIncrease,
                    modifyType = StatModifier.ModifyMethod.MULTIPLICATIVE
                };
                this.Owner.ownerlessStatModifiers.Add(ReloadSpeedModifier);
                this.Owner.ownerlessStatModifiers.Add(FireRateModifier);
                this.Owner.ownerlessStatModifiers.Add(AccuracyModifier);
                this.Owner.stats.RecalculateStats(this.Owner);
            }
        }

        private void RecalculateStatIncrease()
        {
            if (Owner)
            {
                StatIncrease = 10.0f - (1f * (Owner.inventory.AllGuns.Count - Owner.startingGunIds.Count + Owner.passiveItems.Count - Owner.startingPassiveItemIds.Count + Owner.activeItems.Count - Owner.startingActiveItemIds.Count - 1));
                StatIncrease = StatIncrease < 1.0f ? 1.0f : StatIncrease;
            }
        }
    }
}
