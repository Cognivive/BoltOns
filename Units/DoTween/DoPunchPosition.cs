using Bolt;
using DG.Tweening;
using Ludiq;
using UnityEngine;

namespace Cognivive.Bolt.Units.DoTween
{
    /// <summary>Gets the item at the specified index of a list.</summary>
    [UnitCategory("Tweens")]
    [UnitShortTitle("Punch Position")]
    [TypeIcon(typeof(Animation))]
    public class DoPunchPosition : TweenTransformUnit
    {
        [DoNotSerialize] public ValueInput Value;

        protected override void Definition()
        {
            base.Definition();
            Value = ValueInput<Vector3>("Scale", Vector3.zero);
        }

        protected override Tweener GetTween()
        {
            return Transform.GetValue<Transform>().DOPunchPosition(Value.GetValue<Vector3>(), Duration.GetValue<float>());
        }
    }
}