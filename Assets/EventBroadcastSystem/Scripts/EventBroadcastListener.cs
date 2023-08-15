using UnityEngine;
using UnityEngine.Events;

namespace EventBroadcastSystem
{
    /// <summary>
    /// Custom UnityEvent for the EventBroadcastSystem. Allows to send a reference to the broadcasting component and any data.
    /// </summary>
    [System.Serializable]
    public class EventBroadcastEvent : UnityEvent<Component, object> { };

    /// <summary>
    /// Component to listen to a EventBroadcast. Listeners can be add to broadcastEvent to execute when data is received through the broadcast.
    /// </summary>
    public class EventBroadcastListener : MonoBehaviour
    {
        public EventBroadcast broadcast; //This is the broadcast to listen from.
        public EventBroadcastEvent broadcastEvent; //This is the event called when data is received through the broadcast.

        private void OnEnable() => broadcast.RegisterListener(this);
        private void OnDisable() => broadcast.UnregisterListener(this);

        public void OnEventRaised(Component broadcaster, object data)
        {
            broadcastEvent.Invoke(broadcaster, data);
        }
    }
}