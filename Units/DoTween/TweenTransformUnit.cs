using Bolt;
using Ludiq;
using UnityEngine;

namespace Core.Cognivive.Bolt.Units.DoTween
{
    public abstract class TweenTransformUnit : DOTweenUnit
    {
        [DoNotSerialize] public ValueInput Transform;

        protected override void Definition()
        {
            base.Definition();
            Transform = ValueInput<Transform>("Transform", null);
        }
    }
}