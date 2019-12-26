using UnityEngine;

namespace ItemTestMod
{
    public class PuffballSporeProjectile : LifespanProjectile
    {
        public bool IsBrownianDrifting;
        public Vector2 AssignedDir;

        public PuffballSporeProjectile() : base()
        {
            IsBrownianDrifting = false;
            AssignedDir = new Vector2(UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1);
        }

        public override void Update()
        {
            base.Update();
            if (m_currentSpeed <= 0.5 && !IsBrownianDrifting)
            {
                IsBrownianDrifting = true;
                baseData.damping = 0;
                baseData.speed = 0.3f - UnityEngine.Random.value / 5;
                UpdateSpeed();
                SendInDirection(AssignedDir, false, false);
            }

        }
    }
}
