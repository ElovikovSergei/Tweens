using UnityEngine;

namespace Tween
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class DoAnchoredPositionTween : DoTween<RectTransform, Vector3>
    {
        protected override Vector3 TargetValue
        {
            get => TargetComponent.anchoredPosition3D;
            set => TargetComponent.anchoredPosition3D = value;
        }

        protected override void StartLoop(float delay)
        {
            TargetValue = startValue;
            tweenCase = TargetComponent.DOAnchoredPosition(endValue, duration);

            base.StartLoop(delay);
        }

        protected override void IncrementLoopChangeValues()
        {
            var difference = endValue - startValue;

            startValue = endValue;
            endValue += difference;
        }
    }
}
