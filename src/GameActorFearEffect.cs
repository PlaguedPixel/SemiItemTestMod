namespace ItemTestMod
{
    public class GameActorFearEffect : GameActorEffect
    {
        public FleePlayerData FearEffect;
        public float FearApplyChance;

        public GameActorFearEffect()
        {
            AffectsPlayers = false;
            duration = 10f;
            stackMode = EffectStackingMode.Ignore;
            AppliesTint = false;
        }

        public override void OnEffectApplied(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1)
        {
            if (UnityEngine.Random.value < FearApplyChance)
            {
                AIActor aiactor = actor.aiActor;
                aiactor.behaviorSpeculator.FleePlayerData = FearEffect;
            }
            base.OnEffectApplied(actor, effectData, partialAmount);
        }

        public override void OnEffectRemoved(GameActor actor, RuntimeGameActorEffectData effectData)
        {
            AIActor aiactor = actor.aiActor;
            aiactor.behaviorSpeculator.FleePlayerData = null;
            base.OnEffectRemoved(actor, effectData);
        }
    }
}
