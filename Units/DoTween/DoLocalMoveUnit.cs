using Bolt;
using DG.Tweening;
using Ludiq;
using UnityEngine;

namespace Core.Cognivive.Bolt.Units.DoTween
{
    /// <summary>Gets the item at the specified index of a list.</summary>
    [UnitCategory("Tweens")]
    [UnitShortTitle("Local Move")]
    [TypeIcon(typeof(Animation))]
    public class DoLocalMoveUnit : TweenTransformUnit
    {
        [DoNotSerialize] public ValueInput Value;

        protected override void Definition()
        {
            base.Definition();
            Value = ValueInput<Vector3>("Value", Vector3.zero);
        }

        protected override Tweener GetTween()
        {
            return Transform.GetValue<Transform>().DOLocalMove(Value.GetValue<Vector3>(), Duration.GetValue<float>());
        }
    }
}