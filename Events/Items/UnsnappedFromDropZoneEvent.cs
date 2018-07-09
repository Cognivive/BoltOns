using Bolt;

namespace Cognivive.Bolt.Events.Items
{
    [UnitTitle("On Unsnapped From Drop Zone")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class UnsnappedFromDropZoneEvent : VRTK_InteractableObjectEvent
    {
        protected override void SetupListener()
        {
            Component.InteractableObjectUnsnappedFromDropZone += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.InteractableObjectUnsnappedFromDropZone -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Drop Zone"; }
        }
    }
}