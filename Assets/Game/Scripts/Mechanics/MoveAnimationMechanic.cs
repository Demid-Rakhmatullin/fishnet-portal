using UnityEngine;

namespace Assets.Game.Scripts.Mechanics
{
    class MoveAnimationMechanic
    {
        private static readonly int RUN_PARAM = Animator.StringToHash("run");

        private readonly Animator _moveAnimator;

        public MoveAnimationMechanic(Animator moveAnimator)
        {
            _moveAnimator = moveAnimator;
        }

        public void StartRun()
            => _moveAnimator.SetBool(RUN_PARAM, true);

        public void StopRun()
            => _moveAnimator.SetBool(RUN_PARAM, false);
    }
}
