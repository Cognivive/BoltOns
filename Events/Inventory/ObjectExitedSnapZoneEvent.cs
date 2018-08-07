using Bolt;

namespace Core.Cognivive.Bolt.Events.Inventory
{
    [UnitTitle("On Object Exit Snap Zone")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class ObjectExitedSnapZoneEvent : VRTK_SnapDropZoneEvent
    {
        protected override void SetupListener()
        {
            Component.ObjectExitedSnapDropZone += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.ObjectExitedSnapDropZone -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Object"; }
        }
    }
}