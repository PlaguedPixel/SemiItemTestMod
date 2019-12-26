using System;

namespace ItemTestMod {
    public class AutomatonsSoul : PassiveItem {
        public StatModifier CoolnessModifier;
        public float StatIncrease;

        public AutomatonsSoul() {
            RecalculateStatIncrease();
            ArmorToGainOnInitialPickup = 3;
            CoolnessModifier = new StatModifier
            {
                statToBoost = PlayerStats.StatType.Coolness,
                amount = StatIncrease,
                modifyType = StatModifier.ModifyMethod.ADDITIVE
            };
        }

		public override void Pickup(PlayerController player) {
			base.Pickup(player);
            RecalculateStatIncrease();
            Owner.ownerlessStatModifiers.Add(CoolnessModifier);
            Owner.stats.RecalculateStats(Owner);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.ownerlessStatModifiers.Remove(CoolnessModifier);
            player.stats.RecalculateStats(player);
            RecalculateStatIncrease();
            return base.Drop(player);
        }

        protected override void Update()
        {
            base.Update();
            RecalculateStatIncrease();
            if (CoolnessModifier.amount != StatIncrease)
            {
                Owner.ownerlessStatModifiers.Remove(CoolnessModifier);
                Owner.stats.RecalculateStats(Owner);
                CoolnessModifier = new StatModifier
                {
                    statToBoost = PlayerStats.StatType.Coolness,
                    amount = StatIncrease,
                    modifyType = StatModifier.ModifyMethod.ADDITIVE
                };
                Owner.ownerlessStatModifiers.Add(CoolnessModifier);
                Owner.stats.RecalculateStats(Owner);
            }
        }

        private void RecalculateStatIncrease()
        {
            if (Owner)
            {
                StatIncrease = Owner.healthHaver.Armor + (Owner.healthHaver.HasCrest ? 9 : 0);
            }
        }
    }
}
