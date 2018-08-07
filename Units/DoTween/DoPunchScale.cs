using Bolt;
using DG.Tweening;
using Ludiq;
using UnityEngine;

namespace Core.Cognivive.Bolt.Units.DoTween
{
    /// <summary>Gets the item at the specified index of a list.</summary>
    [UnitCategory("Tweens")]
    [UnitShortTitle("Punch Scale")]
    [TypeIcon(typeof(Animation))]
    public class DoPunchScale : TweenTransformUnit
    {
        [DoNotSerialize] public ValueInput Value;

        protected override void Definition()
        {
            base.Definition();
            Value = ValueInput<Vector3>("Scale", Vector3.one);
        }

        protected override Tweener GetTween()
        {
            return Transform.GetValue<Transform>().DOPunchScale(Value.GetValue<Vector3>(), Duration.GetValue<float>());
        }
    }
}