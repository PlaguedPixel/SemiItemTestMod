using Logger = ModTheGungeon.Logger;
using Semi;

namespace ItemTestMod {
	public class ItemTestMod : Mod {
        public static new Logger Logger = new Logger("ItemTestMod");
        public static ItemTestMod Instance;

		public override void Loaded() {
            Logger.Info($"Hello world!");
            Instance = this;
        }

		public override void RegisterContent() {
			Logger.Debug($"Registering content.");

            // Localisations
            RegisterLocalization(
                "@:english_items",
                "english_items.txt",
                "gungeon:english",
                I18N.StringTable.Items
            );
            RegisterLocalization(
                "@:polish_items",
                "polish_items.txt",
                "gungeon:polish",
                I18N.StringTable.Items
            );

            // Lavender Ammolet
            var lavender_ammolet_def = RegisterEncounterIcon("@:lavender_ammolet_icon", "lavender_ammolet.png");
			RegisterSpriteCollection(
				"@:lavender_ammolet_coll",
				lavender_ammolet_def
			);
			RegisterSpriteTemplate(
				"@:lavender_ammolet_sprite",
				"@:lavender_ammolet_coll",
				"@:lavender_ammolet_icon"
			);

			RegisterItem<LavenderAmmolet>(
				"@:lavender_ammolet",
				"@:lavender_ammolet_icon",
				"@:lavender_ammolet_sprite",
				"#@:LAVENDER_AMMOLET_NAME",
				"#@:LAVENDER_AMMOLET_SHORT_DESC",
				"#@:LAVENDER_AMMOLET_LONG_DESC"
			);

            // Automaton's Soul
            var automatons_soul_def = RegisterEncounterIcon("@:automatons_soul_icon", "automatons_soul.png");
			RegisterSpriteCollection(
				"@:automatons_soul_coll",
				automatons_soul_def
			);
			RegisterSpriteTemplate(
				"@:automatons_soul_sprite",
				"@:automatons_soul_coll",
				"@:automatons_soul_icon"
			);

			RegisterItem<AutomatonsSoul>(
				"@:automatons_soul",
				"@:automatons_soul_icon",
				"@:automatons_soul_sprite",
				"#@:AUTOMATONS_SOUL_NAME",
				"#@:AUTOMATONS_SOUL_SHORT_DESC",
				"#@:AUTOMATONS_SOUL_LONG_DESC"
			);

            // Bashful Shot
            var bashful_shot_def = RegisterEncounterIcon("@:bashful_shot_icon", "bashful_shot.png");
            RegisterSpriteCollection(
                "@:bashful_shot_coll",
                bashful_shot_def
            );
            RegisterSpriteTemplate(
                "@:bashful_shot_sprite",
                "@:bashful_shot_coll",
                "@:bashful_shot_icon"
            );

            RegisterItem<BashfulShot>(
                "@:bashful_shot",
                "@:bashful_shot_icon",
                "@:bashful_shot_sprite",
                "#@:BASHFUL_SHOT_NAME",
                "#@:BASHFUL_SHOT_SHORT_DESC",
                "#@:BASHFUL_SHOT_LONG_DESC"
            );

            // Gorgun Head
            var gorgun_head_def = RegisterEncounterIcon("@:gorgun_head_icon", "gorgun_head.png");
            RegisterSpriteCollection(
                "@:gorgun_head_coll",
                gorgun_head_def
            );
            RegisterSpriteTemplate(
                "@:gorgun_head_sprite",
                "@:gorgun_head_coll",
                "@:gorgun_head_icon"
            );

            RegisterItem<GorgunHead>(
                "@:gorgun_head",
                "@:gorgun_head_icon",
                "@:gorgun_head_sprite",
                "#@:GORGUN_HEAD_NAME",
                "#@:GORGUN_HEAD_SHORT_DESC",
                "#@:GORGUN_HEAD_LONG_DESC"
            );

            // Carpet Bomb
            var carpet_bomb_def = RegisterEncounterIcon("@:carpet_bomb_icon", "carpet_bomb.png");
            RegisterSpriteCollection(
                "@:carpet_bomb_coll",
                carpet_bomb_def
            );
            RegisterSpriteTemplate(
                "@:carpet_bomb_sprite",
                "@:carpet_bomb_coll",
                "@:carpet_bomb_icon"
            );

            RegisterItem<CarpetBomb>(
                "@:carpet_bomb",
                "@:carpet_bomb_icon",
                "@:carpet_bomb_sprite",
                "#@:CARPET_BOMB_NAME",
                "#@:CARPET_BOMB_SHORT_DESC",
                "#@:CARPET_BOMB_LONG_DESC"
            );

            // Snail Bullets
            var snail_bullets_def = RegisterEncounterIcon("@:snail_bullets_icon", "snail_bullets.png");
            RegisterSpriteCollection(
                "@:snail_bullets_coll",
                snail_bullets_def
            );
            RegisterSpriteTemplate(
                "@:snail_bullets_sprite",
                "@:snail_bullets_coll",
                "@:snail_bullets_icon"
            );

            RegisterItem<SnailBullets>(
                "@:snail_bullets",
                "@:snail_bullets_icon",
                "@:snail_bullets_sprite",
                "#@:SNAIL_BULLETS_NAME",
                "#@:SNAIL_BULLETS_SHORT_DESC",
                "#@:SNAIL_BULLETS_LONG_DESC"
            );

            // Seventh Arm
            var seventh_arm_def = RegisterEncounterIcon("@:seventh_arm_icon", "seventh_arm.png");
            RegisterSpriteCollection(
                "@:seventh_arm_coll",
                seventh_arm_def
            );
            RegisterSpriteTemplate(
                "@:seventh_arm_sprite",
                "@:seventh_arm_coll",
                "@:seventh_arm_icon"
            );

            RegisterItem<SeventhArm>(
                "@:seventh_arm",
                "@:seventh_arm_icon",
                "@:seventh_arm_sprite",
                "#@:SEVENTH_ARM_NAME",
                "#@:SEVENTH_ARM_SHORT_DESC",
                "#@:SEVENTH_ARM_LONG_DESC"
            );

            // Spectre Bullets
            var spectre_bullets_def = RegisterEncounterIcon("@:spectre_bullets_icon", "spectre_bullets.png");
            RegisterSpriteCollection(
                "@:spectre_bullets_coll",
                spectre_bullets_def
            );
            RegisterSpriteTemplate(
                "@:spectre_bullets_sprite",
                "@:spectre_bullets_coll",
                "@:spectre_bullets_icon"
            );

            RegisterItem<SpectreBullets>(
                "@:spectre_bullets",
                "@:spectre_bullets_icon",
                "@:spectre_bullets_sprite",
                "#@:SPECTRE_BULLETS_NAME",
                "#@:SPECTRE_BULLETS_SHORT_DESC",
                "#@:SPECTRE_BULLETS_LONG_DESC"
            );

            // Shotgun Charm
            var shotgun_charm_def = RegisterEncounterIcon("@:shotgun_charm_icon", "shotgun_charm.png");
            RegisterSpriteCollection(
                "@:shotgun_charm_coll",
                shotgun_charm_def
            );
            RegisterSpriteTemplate(
                "@:shotgun_charm_sprite",
                "@:shotgun_charm_coll",
                "@:shotgun_charm_icon"
            );

            RegisterItem<ShotgunCharm>(
                "@:shotgun_charm",
                "@:shotgun_charm_icon",
                "@:shotgun_charm_sprite",
                "#@:SHOTGUN_CHARM_NAME",
                "#@:SHOTGUN_CHARM_SHORT_DESC",
                "#@:SHOTGUN_CHARM_LONG_DESC"
            );

            // Puffball
            var puffball_def = RegisterEncounterIcon("@:puffball_icon", "puffball_idle_001.png");
            
            SpriteDefinition[] puffball_anim_def = new SpriteDefinition[25];
            puffball_anim_def[0] = puffball_def;
            for (int i = 0; i < 7; i++)
            {
                puffball_anim_def[i+1] = RegisterEncounterIcon("@:puffball_activate_00"+(i+1).ToString(), "puffball_activate_00"+(i+1).ToString()+".png");
            }
            for (int i = 0; i < 12; i++)
            {
                string num = (i + 1).ToString();
                if (i + 1 < 10) num = "0" + num;
                puffball_anim_def[i+8] = RegisterEncounterIcon("@:puffball_snooze_0"+num, "puffball_snooze_0"+num+".png");
            }
            for (int i = 0; i < 5; i++)
            {
                puffball_anim_def[i+20] = RegisterEncounterIcon("@:puffball_idle_00"+(i+1).ToString(), "puffball_idle_00"+(i+1).ToString()+".png");
            }
            RegisterSpriteCollection(
                "@:puffball_coll",
                puffball_anim_def
            );
            LoadSpriteAnimation("puffball_anim.semi.anim");
            RegisterSpriteTemplate(
                "@:puffball_sprite",
                "@:puffball_coll",
                "@:puffball_icon"
            );

            for (int i = 0; i < 3; i++)
            {
                var puffball_spore_projectile_def = RegisterEncounterIcon("@:puffball_spore_projectile_00" + (i + 1).ToString() + "_icon", "puffball_spore_projectile_00" + (i + 1).ToString() + ".png");
                RegisterSpriteCollection(
                    "@:puffball_spore_projectile_00" + (i + 1).ToString() + "_coll",
                    puffball_spore_projectile_def
                );
                RegisterSpriteTemplate(
                    "@:puffball_spore_projectile_00" + (i + 1).ToString(),
                    "@:puffball_spore_projectile_00" + (i + 1).ToString() + "_coll",
                    "@:puffball_spore_projectile_00" + (i + 1).ToString() + "_icon"
                );
            }

            RegisterItem<Puffball>(
                "@:puffball",
                "@:puffball_icon",
                "@:puffball_sprite",
                "#@:PUFFBALL_NAME",
                "#@:PUFFBALL_SHORT_DESC",
                "#@:PUFFBALL_LONG_DESC"
            );

            // Dead Battery
            var dead_battery_def = RegisterEncounterIcon("@:dead_battery_icon", "shotgun_charm.png");
            RegisterSpriteCollection(
                "@:dead_battery_coll",
                dead_battery_def
            );
            RegisterSpriteTemplate(
                "@:dead_battery_sprite",
                "@:dead_battery_coll",
                "@:dead_battery_icon"
            );

            RegisterItem<DeadBattery>(
                "@:undead_battery",
                "@:dead_battery_icon",
                "@:dead_battery_sprite",
                "#@:DEAD_BATTERY_NAME",
                "#@:DEAD_BATTERY_SHORT_DESC",
                "#@:DEAD_BATTERY_LONG_DESC"
            );
        }

		public override void InitializeContent() {
			Logger.Debug($"Initializing content.");

            // Assign qualities to all items
            Gungeon.Items.Get("@:lavender_ammolet", Instance.ID).quality = PickupObject.ItemQuality.D;
            Gungeon.Items.Get("@:automatons_soul", Instance.ID).quality = PickupObject.ItemQuality.C;
            Gungeon.Items.Get("@:bashful_shot", Instance.ID).quality = PickupObject.ItemQuality.C;
            Gungeon.Items.Get("@:gorgun_head", Instance.ID).quality = PickupObject.ItemQuality.C;
            Gungeon.Items.Get("@:carpet_bomb", Instance.ID).quality = PickupObject.ItemQuality.B;
            Gungeon.Items.Get("@:snail_bullets", Instance.ID).quality = PickupObject.ItemQuality.A;
            Gungeon.Items.Get("@:seventh_arm", Instance.ID).quality = PickupObject.ItemQuality.A;
            Gungeon.Items.Get("@:spectre_bullets", Instance.ID).quality = PickupObject.ItemQuality.B;
            Gungeon.Items.Get("@:shotgun_charm", Instance.ID).quality = PickupObject.ItemQuality.S;
            Gungeon.Items.Get("@:puffball", Instance.ID).quality = PickupObject.ItemQuality.C;
            Gungeon.Items.Get("@:undead_battery", Instance.ID).quality = PickupObject.ItemQuality.A;

            // Add all items to the loot table
            WeightedGameObjectCollection weightedItemCollection = new WeightedGameObjectCollection();

            WeightedGameObject weightedLavenderAmmolet = new WeightedGameObject();
            weightedLavenderAmmolet.SetGameObject(Gungeon.Items.Get("@:lavender_ammolet", Instance.ID).gameObject);
            weightedLavenderAmmolet.weight = 1f;
            weightedLavenderAmmolet.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedLavenderAmmolet);

            WeightedGameObject weightedAutomatonsSoul = new WeightedGameObject();
            weightedAutomatonsSoul.SetGameObject(Gungeon.Items.Get("@:automatons_soul", Instance.ID).gameObject);
            weightedAutomatonsSoul.weight = 1;
            weightedAutomatonsSoul.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedAutomatonsSoul);

            WeightedGameObject weightedBashfulShot = new WeightedGameObject();
            weightedBashfulShot.SetGameObject(Gungeon.Items.Get("@:bashful_shot", Instance.ID).gameObject);
            weightedBashfulShot.weight = 1;
            weightedBashfulShot.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedBashfulShot);

            WeightedGameObject weightedGorgunHead = new WeightedGameObject();
            weightedGorgunHead.SetGameObject(Gungeon.Items.Get("@:gorgun_head", Instance.ID).gameObject);
            weightedGorgunHead.weight = 1;
            DungeonPrerequisite gorgunHeadPrereq = new DungeonPrerequisite();
            gorgunHeadPrereq.prerequisiteType = DungeonPrerequisite.PrerequisiteType.FLAG;
            gorgunHeadPrereq.requireFlag = true;
            gorgunHeadPrereq.saveFlagToCheck = GungeonFlags.BOSSKILLED_MEDUZI;
            weightedGorgunHead.additionalPrerequisites = new DungeonPrerequisite[] { gorgunHeadPrereq };
            weightedItemCollection.Add(weightedGorgunHead);

            WeightedGameObject weightedCarpetBomb = new WeightedGameObject();
            weightedCarpetBomb.SetGameObject(Gungeon.Items.Get("@:carpet_bomb", Instance.ID).gameObject);
            weightedCarpetBomb.weight = 1;
            weightedCarpetBomb.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedCarpetBomb);

            WeightedGameObject weightedSnailBullets = new WeightedGameObject();
            weightedSnailBullets.SetGameObject(Gungeon.Items.Get("@:snail_bullets", Instance.ID).gameObject);
            weightedSnailBullets.weight = 1;
            weightedSnailBullets.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedSnailBullets);

            WeightedGameObject weightedSeventhArm = new WeightedGameObject();
            weightedSeventhArm.SetGameObject(Gungeon.Items.Get("@:seventh_arm", Instance.ID).gameObject);
            weightedSeventhArm.weight = 1;
            weightedSeventhArm.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedSeventhArm);

            WeightedGameObject weightedSpectreBullets = new WeightedGameObject();
            weightedSpectreBullets.SetGameObject(Gungeon.Items.Get("@:spectre_bullets", Instance.ID).gameObject);
            weightedSpectreBullets.weight = 1;
            weightedSpectreBullets.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedSpectreBullets);

            WeightedGameObject weightedShotgunCharm = new WeightedGameObject();
            weightedShotgunCharm.SetGameObject(Gungeon.Items.Get("@:shotgun_charm", Instance.ID).gameObject);
            weightedShotgunCharm.weight = 1;
            weightedShotgunCharm.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedShotgunCharm);

            WeightedGameObject weightedPuffball = new WeightedGameObject();
            weightedPuffball.SetGameObject(Gungeon.Items.Get("@:puffball", Instance.ID).gameObject);
            weightedPuffball.weight = 1;
            weightedPuffball.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedPuffball);

            WeightedGameObject weightedDeadBattery = new WeightedGameObject();
            weightedDeadBattery.SetGameObject(Gungeon.Items.Get("@:undead_battery", Instance.ID).gameObject);
            weightedDeadBattery.weight = 1;
            weightedDeadBattery.additionalPrerequisites = new DungeonPrerequisite[0];
            weightedItemCollection.Add(weightedDeadBattery);

            AddToItemLootPools(weightedItemCollection);
        }

        private void AddToItemLootPools(WeightedGameObjectCollection coll)
        {
            foreach (WeightedGameObject obj in coll.elements)
            {
                AddToItemLootPools(obj);
            }
        }

        private void AddToItemLootPools(WeightedGameObject obj)
        {
            GameManager.Instance.RewardManager.ItemsLootTable.defaultItemDrops.Add(obj);
            GameManager.Instance.Dungeon.baseChestContents.defaultItemDrops.Add(obj);
        }
	}
}
