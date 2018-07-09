using Bolt;
using Ludiq;
using VRTK;
using UnityEngine;

namespace Cognivive.Bolt.Events.Items
{
    [TypeIcon(typeof(VRTK_InteractableObject))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitCategory("Events/Items")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public abstract class VRTK_InteractableObjectEvent : CustomDelegateEvent<VRTK_InteractableObject>
    {
        [DoNotSerialize] public ValueOutput InteractingObject;

        [DoNotSerialize] public ValueOutput Object;

        public abstract string InteractingObjectLabel { get; }

        protected override void Definition()
        {
            base.Definition();
            ArgumentCount(3);

            Object = ValueOutput("InteractableObject", delegate { return (VRTK_InteractableObject)arguments[1]; });
            InteractingObject = ValueOutput(InteractingObjectLabel, delegate { return (GameObject)arguments[2]; });
        }

        protected void DoTrigger(object sender, InteractableObjectEventArgs e)
        {
            Trigger(this, sender, e.interactingObject);
        }
        
    }
}