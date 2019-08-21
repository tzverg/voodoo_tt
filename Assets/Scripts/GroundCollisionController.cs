using UnityEngine;

public class GroundCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("ground collision with " + collision.gameObject.name);

        if (!menuPanel.activeSelf && collision.gameObject.name == "LeftFoot")
        {
            UIController.AddSoresNum(20);
        }

        menuPanel.SetActive(true);
    }
}