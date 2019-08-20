using UnityEngine;

public class GroundCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("ground collision with " + collision.gameObject.name);

        menuPanel.SetActive(true);
    }
}