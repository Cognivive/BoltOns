using Bolt;
using Ludiq;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Cognivive.Bolt.Events.Unity
{
    [TypeIcon(typeof(OnUnityEvent))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("On UnityEvent")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("Events")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class OnUnityEvent : ManualEventUnit, IUnityUpdateLoop
    {
        protected UnityEvent _eventCache;
        [DoNotSerialize] public ValueInput UnityEvent;

        public void Update()
        {
            UnityEvent e = UnityEvent.GetValue<UnityEvent>();
            if (e != _eventCache)
            {
                Debug.Log("changing event listener");
                if (_eventCache != null)
                {
                    _eventCache.RemoveListener(Trigger);
                }
                _eventCache = e;
                if (_eventCache != null)
                {
                    _eventCache.AddListener(Trigger);
                }
            }
        }

        protected override void Definition()
        {
            base.Definition();
            UnityEvent = ValueInput<UnityEvent>("UnityEvent");
        }
    }
}