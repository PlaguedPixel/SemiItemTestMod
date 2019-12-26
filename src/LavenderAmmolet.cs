namespace ItemTestMod {
	public class LavenderAmmolet : BlankModificationItem {

        public LavenderAmmolet() {
            BlankStunTime = 0.0f;
            BlankPoisonChance = 1.0f;
            BlankPoisonEffect = new LavenderAmmoletCharmEffect();
        }
	}
}
