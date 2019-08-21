using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "box")
        {
            UIController.AddSoresNum(5);
            Debug.Log("Box has destroyed");
        }

        Destroy(collision.gameObject);

        if (!menuPanel.activeSelf)
        {
            menuPanel.SetActive(true);
        }
    }
}
