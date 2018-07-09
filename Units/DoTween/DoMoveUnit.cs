using Bolt;
using DG.Tweening;
using Ludiq;
using UnityEngine;

namespace Cognivive.Bolt.Units.DoTween
{
    /// <summary>Gets the item at the specified index of a list.</summary>
    [UnitCategory("Tweens")]
    [UnitShortTitle("Move")]
    [TypeIcon(typeof(Animation))]
    public class DoMoveUnit : TweenTransformUnit
    {
        [DoNotSerialize] public ValueInput Value;

        protected override void Definition()
        {
            base.Definition();
            Value = ValueInput<Vector3>("Value", Vector3.zero);
        }

        protected override Tweener GetTween()
        {
            return Transform.GetValue<Transform>().DOMove(Value.GetValue<Vector3>(), Duration.GetValue<float>());
        }
    }
}