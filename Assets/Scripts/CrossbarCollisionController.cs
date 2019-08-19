using UnityEngine;

public class CrossbarCollisionController : MonoBehaviour
{
    private PlayerController playerC;

    private void Start()
    {
        playerC = GetComponentInParent<PlayerController>();

        if (playerC == null)
        {
            Debug.LogError("playerC not exist");
        }
    }

    private void GrappleCrossbar(Collision collision)
    {
        if (collision.gameObject.tag == "crossbar")
        {
            Debug.Log("collision with " + collision.gameObject.tag);
            playerC.crossbar = collision.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetKey(KeyCode.Space))
        {
            GrappleCrossbar(collision);
        }
        #endif

        #if UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Stationary)
                {
                    GrappleCrossbar(collision);
                }
            }
        }
        #endif
    }
}