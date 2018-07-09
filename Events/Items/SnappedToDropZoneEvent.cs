using Bolt;

namespace Cognivive.Bolt.Events.Items
{
    [UnitTitle("On Snapped To Drop Zone")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class SnappedToDropZoneEvent : VRTK_InteractableObjectEvent
    {
        protected override void SetupListener()
        {
            Component.InteractableObjectSnappedToDropZone += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.InteractableObjectSnappedToDropZone -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Drop Zone"; }
        }
    }
}