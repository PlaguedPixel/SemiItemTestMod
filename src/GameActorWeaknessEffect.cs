namespace ItemTestMod
{
    public class GameActorWeaknessEffect : GameActorEffect
    {
        public GameActorWeaknessEffect()
        {
            AffectsPlayers = false;
            AppliesTint = false;
        }

        public override void OnEffectApplied(GameActor actor, RuntimeGameActorEffectData effectData, float partialAmount = 1)
        {
            actor.healthHaver.SetHealthMaximum(actor.healthHaver.GetMaxHealth()/2);
            base.OnEffectApplied(actor, effectData, partialAmount);
        }
    }
}
