using Bolt;

namespace Cognivive.Bolt.Events.Items
{
    [UnitTitle("On Grabbed")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class GrabbedEvent : VRTK_InteractableObjectEvent
    {
        public override string InteractingObjectLabel
        {
            get { return "Grabber"; }
        }

        protected override void SetupListener()
        {
            Component.InteractableObjectGrabbed += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.InteractableObjectGrabbed -= DoTrigger;
        }
    }
}