using System.Collections.Generic;
using UnityEngine;

namespace EventBroadcastSystem
{
    /// <summary>
    /// ScriptableObject that works as the EventBroadcast. Any object could broadcast an object to any listener through the BroadcastEvent method or listen to it using a EventBroadcastListener
    /// </summary>
    [CreateAssetMenu(fileName = "EventBroadcast", menuName = "EventBroadcast")]
    public class EventBroadcast : ScriptableObject
    {
        public List<EventBroadcastListener> broadcastListeners = new List<EventBroadcastListener>();

        /// <summary>
        /// Method that broadcasts to every listener.
        /// </summary>
        /// <param name="broadcaster">Component who is broadcasting to the event</param>
        /// <param name="data">The data getting sent through the broadcast</param>
        public void BroadcastEvent(Component broadcaster, object data)
        {
            for (int i = 0; i < broadcastListeners.Count; i++)
                broadcastListeners[i].OnEventRaised(broadcaster, data);
        }

        /// <summary>
        /// Method that registers a listener to this broadcast (If it isn't already registered)
        /// </summary>
        /// <param name="listener">The EventBroadcastListener to register</param>
        public void RegisterListener(EventBroadcastListener listener)
        {
            if (!broadcastListeners.Contains(listener))
                broadcastListeners.Add(listener);
        }

        /// <summary>
        /// Method that unregisters a listener to this broadcast (If it's registered)
        /// </summary>
        /// <param name="listener">The EventBroadcastListener to unregister</param>
        public void UnregisterListener(EventBroadcastListener listener)
        {
            if (broadcastListeners.Contains(listener))
                broadcastListeners.Remove(listener);
        }
    }
}