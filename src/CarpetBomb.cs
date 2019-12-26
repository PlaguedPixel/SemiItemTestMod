using Semi;
using System.Collections;
using UnityEngine;

namespace ItemTestMod {
	public class CarpetBomb : PlayerItem {
        public int Rounds;
        public int BombsPerRound;

        public CarpetBomb() {
            consumable = false;
            roomCooldown = 6;
            damageCooldown = 0f;
            timeCooldown = 0f;
            canStack = false;
            Rounds = 10;
            BombsPerRound = 7;
        }

        protected override void DoEffect(PlayerController user)
        {
            Audio.Play("Play_OBJ_supplydrop_activate_01", user.gameObject);
            StartCoroutine(Bombard(user));
        }

        public IEnumerator Bombard(PlayerController user)
        {
            for (int i = 0; i < Rounds; i++)
            {
                for (int j = 0; j < BombsPerRound; j++)
                {
                    yield return new WaitForSeconds(0.1f*UnityEngine.Random.value+0.05f);
                    SpawnEmergencyCrate(user, 1.0f);
                }
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }

        public IntVector2 SpawnEmergencyCrate(PlayerController player, float chanceToExplode = 0f, GenericLootTable overrideTable = null)
        {
            GameObject original = (GameObject)BraveResources.Load("EmergencyCrate", ".prefab");
            GameObject gameObject = Instantiate(original);
            EmergencyCrateController component = gameObject.GetComponent<EmergencyCrateController>();
            component.ChanceToExplode = chanceToExplode;
            if (overrideTable != null)
            {
                component.gunTable = overrideTable;
            }
            IntVector2 bestRewardLocation = player.CurrentRoom.GetRandomAvailableCellDumb();
            component.Trigger(new Vector3(-5f, -5f, -5f), bestRewardLocation.ToVector3() + new Vector3(15f, 15f, 15f), player.CurrentRoom, overrideTable == null);
            player.CurrentRoom.ExtantEmergencyCrate = gameObject;
            return bestRewardLocation;
        }
    }
}
