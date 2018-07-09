using Bolt;

namespace Cognivive.Bolt.Events.Inventory
{
    [UnitTitle("On Object Enter Snap Zone")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class ObjectEnteredSnapZoneEvent : VRTK_SnapDropZoneEvent
    {
        protected override void SetupListener()
        {
            Component.ObjectEnteredSnapDropZone += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.ObjectEnteredSnapDropZone -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Object"; }
        }
    }
}