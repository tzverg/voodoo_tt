using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

        if (!menuPanel.activeSelf)
        {
            menuPanel.SetActive(true);
        }
    }
}
