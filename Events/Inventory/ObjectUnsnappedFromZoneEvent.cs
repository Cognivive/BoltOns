using Bolt;

namespace Core.Cognivive.Bolt.Events.Inventory
{
    [UnitTitle("On Object Unsnapped")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class ObjectUnsnappedFromZoneEvent : VRTK_SnapDropZoneEvent
    {
        protected override void SetupListener()
        {
            Component.ObjectUnsnappedFromDropZone += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.ObjectUnsnappedFromDropZone -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Object"; }
        }
    }
}