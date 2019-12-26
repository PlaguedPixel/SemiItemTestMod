using Semi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemTestMod {
	public class ShotgunCharm : ActiveGunVolleyModificationItem {
        private int ExtraBullets;

        public ShotgunCharm()
        {
            consumable = false;
            roomCooldown = 0;
            damageCooldown = 550f;
            timeCooldown = 0f;
            canStack = false;
            duration = 12f;
            ExtraBullets = 5;
        }
        protected override void DoEffect(PlayerController user)
        {
            AddModules(user);
            Audio.Play("Play_OBJ_power_up_01", user.gameObject);
            StartCoroutine(HandleDuration(user));
        }

        public void AddModules(PlayerController user)
        {
            var gun = user.CurrentGun;
            ProjectileVolleyData modifiedVolley = gun.modifiedVolley;
            gun.modifiedVolley = null;
            gun.modifiedFinalVolley = null;
            ProjectileVolleyData projectileVolleyData = ScriptableObject.CreateInstance<ProjectileVolleyData>();
            if (gun.Volley != null)
            {
                projectileVolleyData.InitializeFrom(gun.Volley);
            }
            else
            {
                projectileVolleyData.projectiles = new List<ProjectileModule>();
                projectileVolleyData.projectiles.Add(ProjectileModule.CreateClone(gun.singleModule, true, -1));
                projectileVolleyData.BeamRotationDegreesPerSecond = float.MaxValue;
            }

            ProjectileVolleyData volleyToModify = projectileVolleyData;
            ProjectileModule projectileModule = volleyToModify.projectiles[0];
            float num2 = (float)ExtraBullets * DuplicateAngleOffset * -1f / 2f;
            for (int k = 0; k < ExtraBullets; k++)
            {
                int sourceIndex = 0;
                if (projectileModule.CloneSourceIndex >= 0)
                {
                    sourceIndex = projectileModule.CloneSourceIndex;
                }
                ProjectileModule projectileModule2 = ProjectileModule.CreateClone(projectileModule, false, sourceIndex);
                float angleFromAim = num2 + DuplicateAngleOffset * (float)k;
                projectileModule2.angleFromAim = angleFromAim;
                projectileModule2.ignoredForReloadPurposes = true;
                projectileModule2.ammoCost = 0;
                volleyToModify.projectiles.Add(projectileModule2);
            }
            projectileVolleyData.UsesShotgunStyleVelocityRandomizer = true;
            gun.modifiedVolley = projectileVolleyData;
            gun.ReinitializeModuleData(modifiedVolley);
        }

        private IEnumerator HandleDuration(PlayerController user)
        {
            IsCurrentlyActive = true;
            m_activeElapsed = 0f;
            m_activeDuration = duration;
            while (m_activeElapsed < m_activeDuration && IsCurrentlyActive)
            {
                yield return null;
            }
            bool wasEndFiring = user.CurrentGun != null && user.CurrentGun.IsFiring;
            if (wasEndFiring)
            {
                user.CurrentGun.CeaseAttack(true, null);
            }
            IsCurrentlyActive = false;
            user.stats.RecalculateStats(user, false, false);
            yield break;
        }
    }
}
