using UnityEngine;
using EventBroadcastSystem;

public class Cube : MonoBehaviour
{
    private EventBroadcastListener[] broadcastListeners; //We use an array since we have more than one broadcast listener
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        broadcastListeners = GetComponents<EventBroadcastListener>();
    }

    private void Start()
    {
        for (int i = 0; i < broadcastListeners.Length; i++)
        {
            int index = i; //Store the index on a new int variable because working with the for's i variable is problematic for listeners.
            broadcastListeners[index].broadcastEvent.AddListener((broadcaster, data) => ChangeColor(broadcaster, data));
        }
    }

    //This is the important method of the script, its the one that will be called by the broadcast
    public void ChangeColor(Component broadcaster, object data)
    {
        if (data is Color color) //We can check if the data is a color
        {
            Debug.Log(broadcaster.name + " sets " + gameObject.name + " color to " + data.ToString() + " (Event set programmatically).");
            meshRenderer.material.SetColor("_Color", color);
        }
    }
}
