using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forceStaticValue;
    [SerializeField] private float forceRandomModifier;

    [SerializeField] private Rigidbody hips;
    [SerializeField] private Rigidbody leftFeet;
    [SerializeField] private Rigidbody rightFeet;

    public GameObject crossbar;

    private void TryFlip()
    {
        float randomModifier = Random.value * forceRandomModifier;

        hips.AddRelativeForce(0F, 0F, forceStaticValue + randomModifier, ForceMode.Force);
        leftFeet.AddRelativeForce(0F, 0F, forceStaticValue + randomModifier, ForceMode.Force);
        rightFeet.AddRelativeForce(0F, 0F, forceStaticValue + randomModifier, ForceMode.Force);
    }

    private void ReleaseCrossbar()
    {
        if (crossbar != null)
        {
            var armJoints = crossbar.GetComponentsInChildren<HingeJoint>();

            foreach (HingeJoint armJoint in armJoints)
            {
                armJoint.connectedBody = null;
            }

            crossbar = null;
        }
    }

    void Update()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetKey(KeyCode.Space))
        {
            TryFlip();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ReleaseCrossbar();
        }
        #endif

        #if UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Stationary)
                {
                    TryFlip();
                }
                if (Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    ReleaseCrossbar();
                }
            }
        }
        #endif
    }
}
