using Bolt;
using DG.Tweening;
using Ludiq;
using UnityEngine;

namespace Core.Cognivive.Bolt.Units.DoTween
{
    /// <summary>Gets the item at the specified index of a list.</summary>
    [UnitCategory("Tweens")]
    [UnitShortTitle("Do Scale")]
    [TypeIcon(typeof(Animation))]
    public class DoLocalScaleUnit : TweenTransformUnit
    {
        [DoNotSerialize] public ValueInput Value;

        protected override void Definition()
        {
            base.Definition();
            Value = ValueInput("Scale", Vector3.one);
        }

        protected override Tweener GetTween()
        {
            return Transform.GetValue<Transform>().DOScale(Value.GetValue<Vector3>(), Duration.GetValue<float>());
        }
    }
}