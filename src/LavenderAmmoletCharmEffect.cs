using Semi;
using System;

[Serializable]
public class LavenderAmmoletCharmEffect : GameActorHealthEffect
{   
    public LavenderAmmoletCharmEffect()
    {
        DamagePerSecondToEnemies = 0f;
        duration = 4.0f;
        TintColor = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect.TintColor;
        AppliesTint = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect.AppliesTint;
        OutlineTintColor = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect.OutlineTintColor;
        OverheadVFX = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect.OverheadVFX;
        DeathTintColor = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect.DeathTintColor;
        AppliesDeathTint = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPermanentCharmEffect.AppliesDeathTint;
    }

    public override void OnEffectApplied(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1f)
    {
        if (actor is AIActor)
        {
            Audio.Play("Play_OBJ_enemy_charmed_01", GameManager.Instance.gameObject);
            AIActor aiactor = actor as AIActor;
            aiactor.CanTargetEnemies = true;
            aiactor.CanTargetPlayers = false;
        }
    }

    public override void OnEffectRemoved(GameActor actor, RuntimeGameActorEffectData effectData)
    {
        if (actor is AIActor)
        {
            AIActor aiactor = actor as AIActor;
            aiactor.CanTargetEnemies = false;
            aiactor.CanTargetPlayers = true;
        }
    }
}
