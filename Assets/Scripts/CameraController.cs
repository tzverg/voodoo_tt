using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camFollowingTarget;
    private Vector3 camOffset;

    void Start()
    {
        camOffset = transform.position - camFollowingTarget.transform.position;
    }

    void LateUpdate()
    {
        transform.position = camFollowingTarget.transform.position + camOffset;
    }
}