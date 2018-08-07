using Bolt;
using DG.Tweening;
using Ludiq;
using UnityEngine;

namespace Core.Cognivive.Bolt.Units.DoTween
{
    /// <summary>Gets the item at the specified index of a list.</summary>
    [UnitCategory("Tweens")]
    [UnitShortTitle("Punch Rotation")]
    [TypeIcon(typeof(Animation))]
    public class DoPunchRotation : TweenTransformUnit
    {
        [DoNotSerialize] public ValueInput Value;

        protected override void Definition()
        {
            base.Definition();
            Value = ValueInput<Vector3>("Scale", Vector3.zero);
        }

        protected override Tweener GetTween()
        {
            return Transform.GetValue<Transform>().DOPunchRotation(Value.GetValue<Vector3>(), Duration.GetValue<float>());
        }
    }
}