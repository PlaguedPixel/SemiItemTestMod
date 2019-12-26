using Semi;
using System.Collections;
using UnityEngine;

namespace ItemTestMod
{
    public class DeadBattery : PlayerItem
    {
        public float Duration;
        public float Charge;
        public StatModifier SpeedModifier;
        public StatModifier DamageModifier;
        public RedMatterParticleController RedMatterController;

        public DeadBattery() : base()
        {
            consumable = false;
            canStack = false;
            roomCooldown = 0;
            damageCooldown = 0f;
            timeCooldown = 100f;
            Duration = 15f;
            Charge = 100f;
            SpeedModifier = new StatModifier()
            {
                statToBoost = PlayerStats.StatType.MovementSpeed,
                amount = 1f,
                modifyType = StatModifier.ModifyMethod.ADDITIVE
            };
            DamageModifier = new StatModifier()
            {
                statToBoost = PlayerStats.StatType.Damage,
                amount = 0.4f,
                modifyType = StatModifier.ModifyMethod.ADDITIVE
            };
        }

        protected override void DoOnCooldownEffect(PlayerController user)
        {
            base.DoOnCooldownEffect(user);
            if (Charge.RoundToNearest(1) >= 20)
            {
                Charge = Mathf.Max(0f, Charge - 20f);
            }
            else
            {
                return;
            }
            user.ownerlessStatModifiers.Add(SpeedModifier);
            user.ownerlessStatModifiers.Add(DamageModifier);
            user.stats.RecalculateStats(user);
            StartCoroutine(HandleDuration(user));
        }

        private IEnumerator HandleDuration(PlayerController user)
        {
            float statBonusElapsed = 0f;
            while (statBonusElapsed < Duration)
            {
                statBonusElapsed += BraveTime.DeltaTime * m_adjustedTimeScale;
                yield return null;
            }
            user.ownerlessStatModifiers.Remove(SpeedModifier);
            user.ownerlessStatModifiers.Remove(DamageModifier);
            user.stats.RecalculateStats(user);
            yield break;
        }

        public override void Update()
        {
            if (m_pickedUp)
            {
                if (LastOwner == null)
                {
                    LastOwner = base.GetComponentInParent<PlayerController>();
                }

                // Update CurrentTimeCooldown here
                if (Charge == 100f) Charge = 99.999f;
                CurrentTimeCooldown = 100 - Charge;
                if (Charge == 99.9999f) Charge = 100f;
            }
            else
            {
                base.HandlePickupCurseParticles();
                if (!m_isBeingEyedByRat && Time.frameCount % 47 == 0 && ShouldBeTakenByRat(sprite.WorldCenter))
                {
                    GameManager.Instance.Dungeon.StartCoroutine(HandleRatTheft());
                }
            }
            if (RedMatterController == null)
            {
                RedMatterController = GlobalSparksDoer.GetRedMatterController();
            }
            RedMatterController.target.position = LastOwner.CenterPosition;
            RedMatterController.ProcessParticles();
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.OnKilledEnemyContext += Recharge;
        }

        protected override void OnPreDrop(PlayerController player)
        {
            player.OnKilledEnemyContext -= Recharge;
            base.OnPreDrop(player);
        }

        protected override void OnDestroy()
        {
            LastOwner.OnKilledEnemyContext -= Recharge;
            base.OnDestroy();
        }

        public void Recharge(PlayerController player, HealthHaver enemy)
        {
            Charge = Mathf.Min(100, Charge + (enemy.GetMaxHealth()/10));
            Audio.Play("Play_ENM_electric_charge_01", player.gameObject);
            StartCoroutine(StealSoul(enemy));
        }

        private IEnumerator StealSoul(HealthHaver enemy)
        {
            for (int i = 0; i < 20; i++)
            {
                GlobalSparksDoer.DoRadialParticleBurst(3, enemy.specRigidbody.HitboxPixelCollider.UnitBottomLeft, enemy.specRigidbody.HitboxPixelCollider.UnitTopRight, 90f, 4f, 0f, null, 10, new Color(1, 1, 250 / 255), GlobalSparksDoer.SparksType.RED_MATTER);
                yield return new WaitForSeconds(0.05f);
            }
            // TODO: maybe add VFX in the future?
            yield break;
        }
    }
}
