using Semi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemTestMod {
	public class Puffball : PlayerItem {
        public VFXPool DeathVFX;
        public string DeathVFXName = "Global VFX/VFX_Dust_Impact_Enemy";
        public SpriteCollection[] SpriteList;

        public Puffball() {
            consumable = false;
            roomCooldown = 0;
            damageCooldown = 0f;
            timeCooldown = 60f;
            canStack = false;
            SetupVFXPool();
            InitializeSprites();
            useAnimation = "activate";
        }

        public override void Pickup(PlayerController player)
        {
            spriteAnimator = gameObject.GetOrAddComponent<tk2dSpriteAnimator>();
            spriteAnimator.Library = Gungeon.AnimationTemplates.Get("@:puffball_anim", ItemTestMod.Instance.ID);
            base.Pickup(player);
        }

        protected override void DoEffect(PlayerController user)
        {
            StartCoroutine(SporeCloud(user));
        }

        private IEnumerator SporeCloud(PlayerController user)
        {
            yield return new WaitForSeconds(0.5f);
            Audio.Play("Play_ENM_mushroom_cloud_01", user.gameObject);
            for (int i = 0; i < 120; i++)
            {
                GameObject projObject = new GameObject();
                DontDestroyOnLoad(projObject);

                PuffballSporeProjectile proj = projObject.AddComponent<PuffballSporeProjectile>();

                SpeculativeRigidbody projrigidbody = projObject.AddComponent<SpeculativeRigidbody>();
                projrigidbody.PixelColliders = new List<PixelCollider>();
                PixelCollider collider = new PixelCollider();
                collider.CollisionLayer = CollisionLayer.Projectile;
                collider.ColliderGenerationMode = PixelCollider.PixelColliderGeneration.Tk2dPolygon;
                collider.Enabled = true;
                projrigidbody.PixelColliders.Add(collider);

                int rand = 3;
                do rand = (int)(UnityEngine.Random.value * 3); while (rand == 3);
                Semi.Sprite.Construct(projObject, SpriteList[rand], 0);

                proj.RegenerateCache();
                var bounds = proj.sprite.GetBounds();
                proj.sprite.GetTrueCurrentSpriteDef().colliderVertices = new Vector3[] { bounds.center - bounds.extents, bounds.center + bounds.extents };
                projrigidbody.ForceRegenerate();
                projrigidbody.RegenerateCache();
                proj.specRigidbody = projrigidbody;
                proj.collidesWithPlayer = false;
                proj.collidesWithEnemies = true;
                proj.persistTime = 0f;
                proj.lifespan = 30 + UnityEngine.Random.value * 10 - 5;
                proj.HasDefaultTint = false;

                proj.hitEffects = new ProjectileImpactVFXPool();
                proj.hitEffects.HasProjectileDeathVFX = true;
                proj.hitEffects.CenterDeathVFXOnProjectile = true;
                proj.hitEffects.deathAny = DeathVFX;

                proj.baseData = new ProjectileData();
                proj.baseData.force = 10f;

                if (i < 30)
                {
                    proj.baseData.damage = 5f;
                    proj.baseData.damping = 2f - UnityEngine.Random.value * 1.25f;
                    proj.baseData.speed = 16f + UnityEngine.Random.value * 10 - 5f;
                }
                else if (i < 60)
                {
                    proj.baseData.damage = 6f;
                    proj.baseData.damping = 2f - UnityEngine.Random.value * 2;
                    proj.baseData.speed = 16f + UnityEngine.Random.value * 10 - 5f;
                }
                else
                {
                    proj.baseData.damage = 4f;
                    proj.baseData.damping = 2f - UnityEngine.Random.value;
                    proj.baseData.speed = UnityEngine.Random.value * 16;
                }

                Projectile spawnedProj = SpawnManager.SpawnProjectile(proj.gameObject, user.CenterPosition, Quaternion.Euler(0f, 0f, UnityEngine.Random.value * 360)).GetComponent<Projectile>();
                spawnedProj.ImmuneToBlanks = true;
            }
            yield return null;
        }

        public override void Update()
        {
            base.Update();
            if (CurrentTimeCooldown > 0 && !spriteAnimator.IsPlaying("snooze") && !spriteAnimator.IsPlaying("activate"))
            {
                spriteAnimator.PlayForDurationForceLoop(spriteAnimator.GetClipByName("snooze"), CurrentTimeCooldown);
            }
            else if (CurrentTimeCooldown <= 0 && !spriteAnimator.IsPlaying("idle"))
            {
                spriteAnimator.Play("idle");
            }
        }

        private void SetupVFXPool()
        {
            VFXObject deathVFXObject = new VFXObject();
            deathVFXObject.effect = ResourceCache.Acquire(DeathVFXName) as GameObject;
            deathVFXObject.alignment = VFXAlignment.NormalAligned;
            VFXComplex deathVFXComplex = new VFXComplex();
            deathVFXComplex.effects = new VFXObject[] { deathVFXObject };
            DeathVFX = new VFXPool();
            DeathVFX.effects = new VFXComplex[] { deathVFXComplex };
            DeathVFX.type = VFXPoolType.All;
        }

        public void InitializeSprites() {
            SpriteList = new SpriteCollection[3];
            for (int i = 0; i < 3; i++)
            {
                SpriteList[i] = Gungeon.SpriteCollections.Get("@:puffball_spore_projectile_00" + (i + 1).ToString() + "_coll", ItemTestMod.Instance.ID);
            }
        }
    }
}
