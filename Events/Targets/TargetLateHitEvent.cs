using Bolt;
using Cognivive.Gameplay;
using Ludiq;

namespace Cognivive.Bolt.Events.Targets
{
    [TypeIcon(typeof(TargetLateHitEvent))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("On Late Hit")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("Events/Target")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class TargetLateHitEvent : CustomDelegateEvent<UsefulFieldOfViewTarget>
    {
        [DoNotSerialize]
        public ValueOutput UFoVTarget;

        protected override void Definition()
        {
            base.Definition();
            ArgumentCount(2);

            UFoVTarget = ValueOutput("UFoVTarget", delegate { return (UsefulFieldOfViewTarget)arguments[1]; });
        }

        private void DoTrigger(UsefulFieldOfViewTarget usefulFieldOfViewTarget)
        {
            Trigger(target, usefulFieldOfViewTarget);
        }

        protected override void SetupListener()
        {
            Component.OnLateHit += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.OnLateHit -= DoTrigger;
        }
    }
}