using System;
using UnityEngine;

namespace ItemTestMod
{
    public class SeventhArm : PassiveItem
    {
        private PlayerController m_player;
        public float TriggerChance;
        public GameObject WeaknessVFX;
        private StatModifier TemporaryCurse;
        public StatModifier PermanentCurse;

        public SeventhArm()
        {
            TriggerChance = 0.5f;
            WeaknessVFX = ResourceCache.Acquire("Global VFX/VFX_Debuff_Status") as GameObject;
            TemporaryCurse = new StatModifier
            {
                statToBoost = PlayerStats.StatType.Curse,
                amount = 2f,
                modifyType = StatModifier.ModifyMethod.ADDITIVE
            };
            PermanentCurse = new StatModifier
            {
                statToBoost = PlayerStats.StatType.Curse,
                amount = 1f,
                modifyType = StatModifier.ModifyMethod.ADDITIVE
            };
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.ownerlessStatModifiers.Add(TemporaryCurse);
            if (!player.ownerlessStatModifiers.Contains(PermanentCurse))
            {
                player.ownerlessStatModifiers.Add(PermanentCurse);
            }
            player.stats.RecalculateStats(player);
            m_player = player;
            player.OnEnteredCombat = (Action)Delegate.Combine(player.OnEnteredCombat, new Action(OnEnteredCombat));
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.ownerlessStatModifiers.Remove(TemporaryCurse);
            player.stats.RecalculateStats(player);
            m_player = null;
            player.OnEnteredCombat = (Action)Delegate.Remove(player.OnEnteredCombat, new Action(OnEnteredCombat));
            return base.Drop(player);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (m_player)
            {
                m_player.OnEnteredCombat = (Action)Delegate.Remove(m_player.OnEnteredCombat, new Action(OnEnteredCombat));
            }
        }

        private void OnEnteredCombat()
        {
            GameActorWeaknessEffect weaknessEffect = new GameActorWeaknessEffect
            {
                OverheadVFX = WeaknessVFX,
                duration = float.MaxValue
            };
            foreach (AIActor enemy in m_player.CurrentRoom.GetActiveEnemies(Dungeonator.RoomHandler.ActiveEnemyType.All))
            {
                if (UnityEngine.Random.value < TriggerChance)
                {
                    enemy.ApplyEffect(weaknessEffect);
                }
            }
        }

        protected new void HandlePickupCurseParticles()
        {
            var targetSprite = sprite;
            var zOffset = 0f;
            if (targetSprite)
            {
                Vector3 vector = targetSprite.WorldBottomLeft.ToVector3ZisY(zOffset);
                Vector3 vector2 = targetSprite.WorldTopRight.ToVector3ZisY(zOffset);
                float num = (vector2.y - vector.y) * (vector2.x - vector.x);
                float num2 = 25f * num;
                int num3 = Mathf.CeilToInt(Mathf.Max(1f, num2 * BraveTime.DeltaTime));
                int num4 = num3;
                Vector3 minPosition = vector;
                Vector3 maxPosition = vector2;
                Vector3 direction = Vector3.up / 2f;
                float angleVariance = 120f;
                float magnitudeVariance = 0.2f;
                float? startLifetime = new float?(UnityEngine.Random.Range(0.8f, 1.25f));
                GlobalSparksDoer.DoRandomParticleBurst(num4, minPosition, maxPosition, direction, angleVariance, magnitudeVariance, null, startLifetime, null, GlobalSparksDoer.SparksType.BLACK_PHANTOM_SMOKE);
            }
        }

        protected override void Update()
        {
            if (!m_pickedUp && m_owner == null)
            {
                HandlePickupCurseParticles();
            }
            base.Update();
        }
    }
}
