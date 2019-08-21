using UnityEngine;

public class CrossbarCollisionController : MonoBehaviour
{
    [SerializeField] private PlayerController playerC;

    private void GrappleCrossbar(Collision collision)
    {
        playerC.GrappleCrossbar(gameObject);
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