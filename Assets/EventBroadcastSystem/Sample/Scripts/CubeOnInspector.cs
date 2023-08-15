using EventBroadcastSystem;
using UnityEngine;

public class CubeOnInspector : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    //This is the important method of the script, its the one that will be called by the broadcast
    public void ChangeColor(Component broadcaster, object data)
    {
        if (data is Color color) //We can check if the data is a color
        {
            Debug.Log(broadcaster.name + " sets " + gameObject.name + " color to " + data.ToString() + " (Event set on inspector).");
            meshRenderer.material.SetColor("_Color", color);
        }
    }
}
