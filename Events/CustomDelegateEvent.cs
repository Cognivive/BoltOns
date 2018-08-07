using Bolt;
using Ludiq;
using UnityEngine;

namespace Core.Cognivive.Bolt.Events
{
    public abstract class CustomDelegateEvent<T> : GameObjectEventUnit where T : Component
    {
        protected T Component
        {
            get { return target.GetComponent<T>(); }
        }

        public override void Update()
        {
            bool changingTarget = target != targetPort.GetValue<GameObject>();
            if (changingTarget && target && target.GetComponent<T>())
            {
                RemoveListener();
            }
            base.Update();
            if (changingTarget && target && target.GetComponent<T>())
            {
                SetupListener();
            }
        }

        public override void StartListening()
        {
            bool changingTarget = target != targetPort.GetValue<GameObject>();
            if (changingTarget && target && target.GetComponent<T>())
            {
                RemoveListener();
            }
            base.StartListening();
            if (changingTarget && target && target.GetComponent<T>())
            {
                SetupListener();
            }
        }

        public override void StopListening()
        {
            bool changingTarget = target != targetPort.GetValue<GameObject>();
            if (changingTarget && target && target.GetComponent<T>())
            {
                RemoveListener();
            }
            base.StopListening();
            if (changingTarget && target && target.GetComponent<T>())
            {
                SetupListener();
            }
        }

        protected abstract void SetupListener();
        protected abstract void RemoveListener();
    }
}