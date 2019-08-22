using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float tumble;

    private bool paid; // fix multiple collision

    void Start()
    {
        paid = false;

        var targetRB = GetComponent<Rigidbody>();

        if (targetRB != null)
        {
            targetRB.angularVelocity = Vector3.up * tumble;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!paid)
        {
            paid = true;
            UIController.AddSoresNum(15);
            Destroy(gameObject);
        }
    }
}