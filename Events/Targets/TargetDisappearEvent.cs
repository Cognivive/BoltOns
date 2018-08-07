using Bolt;
using Core.Cognivive.Gameplay;
using Ludiq;

namespace Core.Cognivive.Bolt.Events.Targets
{
    [TypeIcon(typeof(TargetDisappearEvent))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("On Disappear")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("Events/Target")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class TargetDisappearEvent : CustomDelegateEvent<UsefulFieldOfViewTarget>
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
            Component.OnDisappear += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.OnDisappear -= DoTrigger;
        }
    }
}