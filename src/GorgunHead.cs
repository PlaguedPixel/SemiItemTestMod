using Dungeonator;
using Semi;
using System.Collections;
using UnityEngine;

namespace ItemTestMod {
	public class GorgunHead : PlayerItem {
        public float PetrifyChance;
        public GameActorEffect PetrifyEffect;
        protected float ShockwaveDuration;

        public GorgunHead() {
            consumable = false;
            canStack = false;
            roomCooldown = 0;
            damageCooldown = 250f;
            timeCooldown = 0f;
            PetrifyChance = 0.65f;
            PetrifyEffect = new GameActorPetrifyEffect(LastOwner);
            ShockwaveDuration = 1.0f;
        }

        protected override void DoEffect(PlayerController user)
        {
            Exploder.DoDistortionWave(user.transform.position, 1f, 0.04f, 20f, ShockwaveDuration);
            Audio.Play("Play_ENM_gorgun_gaze_01", user.gameObject);
            if (user.CurrentRoom.GetActiveEnemiesCount(RoomHandler.ActiveEnemyType.All) > 0)
            {
                foreach (AIActor enemy in user.CurrentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All))
                {
                    StartCoroutine(Petrify(enemy));
                }
            }
        }

        private IEnumerator Petrify(AIActor enemy)
        {
            float i = Vector2.Distance(LastOwner.transform.PositionVector2(), enemy.transform.PositionVector2()) / (ShockwaveDuration * 30);
            while (i > 0.0f)
            {
                yield return new WaitForSeconds(0.05f);
                i -= 0.05f;
            }
            if (PetrifyChance > 0f && UnityEngine.Random.value < PetrifyChance)
            {
                enemy.ApplyEffect(PetrifyEffect);
            }
            yield break;
        }
    }
}
