using System.Collections;
using UnityEngine;

namespace ItemTestMod
{
    public class LifespanProjectile : Projectile
    {
        public float lifespan;

        public LifespanProjectile() : base()
        {
            StartCoroutine(DoDeathTimer());
        }

        protected IEnumerator DoDeathTimer()
        {
            yield return new WaitForSeconds(lifespan);
            DieInAir();
        }

    }
}
