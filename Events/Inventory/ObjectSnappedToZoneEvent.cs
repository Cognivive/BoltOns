using Bolt;

namespace Cognivive.Bolt.Events.Inventory
{
    [UnitTitle("On Object Snap")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class ObjectSnappedToZoneEvent : VRTK_SnapDropZoneEvent
    {
        protected override void SetupListener()
        {
            Component.ObjectSnappedToDropZone += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.ObjectSnappedToDropZone -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Object"; }
        }
    }
}