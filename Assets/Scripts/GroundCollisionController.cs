using UnityEngine;

public class GroundCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("ground collision with " + collision.gameObject.name);
        if (collision.gameObject.tag != "box")
        {
            if (!menuPanel.activeSelf)
            {
                switch (collision.gameObject.name)
                {
                    case "LeftLowerLeg":
                        UIController.AddSoresNum(20);
                        break;
                    case "RightLowerLeg":
                        UIController.AddSoresNum(20);
                        break;
                    case "LeftHand":
                        UIController.AddSoresNum(10);
                        break;
                    case "RightHand":
                        UIController.AddSoresNum(10);
                        break;
                    case "Hips":
                        UIController.AddSoresNum(5);
                        break;
                    default:
                        break;
                }
            }

            menuPanel.SetActive(true);
        }
    }
}