using UnityEngine;

public class Camera3rdPersonController : MonoBehaviour
{
    private Vector3 offset;
    public GameObject player;
    void Start()
    {
        offset = new Vector3(0.0f, 1.81f ,-3f);
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
