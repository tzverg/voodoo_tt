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
        if (PlayerController.mouseButtonDown)
        {
            GrappleCrossbar(collision);
        }
    }
}