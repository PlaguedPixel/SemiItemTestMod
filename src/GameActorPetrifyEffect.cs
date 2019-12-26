using UnityEngine;

namespace ItemTestMod
{
    public class GameActorPetrifyEffect : GameActorEffect
    {
        private bool prev = true;
        public PlayerController Owner;

        public GameActorPetrifyEffect(PlayerController owner)
        {
            AffectsPlayers = false;            // Use the already in place methods for player petrification.
            duration = 10f;
            AppliesTint = true;
            TintColor = new Color(0.2f, 0.2f, 0.2f, Mathf.Clamp01(duration));
            Owner = owner;
        }

        public override void OnEffectApplied(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1)
        {
            AIActor aiactor = actor.aiActor;
            prev = aiactor.CanTargetPlayers;
            aiactor.CanTargetPlayers = false;
            base.OnEffectApplied(actor, effectData, partialAmount);
        }

        public override void OnEffectRemoved(GameActor actor, RuntimeGameActorEffectData effectData)
        {
            AIActor aiactor = actor.aiActor;
            aiactor.CanTargetPlayers = prev;
            base.OnEffectRemoved(actor, effectData);
        }
    }
}
