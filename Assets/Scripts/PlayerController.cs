using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forceY;
    [SerializeField] private float forceZ;

    private float resultForceY;
    private float resultForceZ;

    private float halfForceY;
    private float halfForceZ;

    public static bool mouseButtonDown = false;

    [SerializeField] private Joystick mainJoy;

    [SerializeField] private Rigidbody hips;
    [SerializeField] private Rigidbody leftHand;
    [SerializeField] private Rigidbody rightHand;
    [SerializeField] private Rigidbody leftUpperLeg;
    [SerializeField] private Rigidbody rightUpperLeg;

    private Vector3 leftHandCA;
    private Vector3 rightHandCA;

    private Transform leftHandDefaultTR;
    private Transform rightHandDefaultTR;

    private GameObject crossbar = null;

    private void Start()
    {
        leftHandCA = new Vector3(-0.08F, -0.06F, 0F);
        rightHandCA = new Vector3(0.08F, -0.06F, 0F);
    }

    public void GrappleCrossbar(GameObject targetCrossbar)
    {
        if (crossbar == null)
        {
            foreach (HingeJoint targetJoint in targetCrossbar.GetComponents<HingeJoint>())
            {
                if (targetJoint.axis.y == 1)
                {
                    targetJoint.connectedBody = leftHand;
                    targetJoint.connectedAnchor = leftHandCA;
                }
                else if (targetJoint.axis.y == -1)
                {
                    targetJoint.connectedBody = rightHand;
                    targetJoint.connectedAnchor = rightHandCA;
                }
            }

            UIController.AddSoresNum(10);

            crossbar = targetCrossbar;
        }
    }

    private void TryFlip()
    {
        if (crossbar != null)
        {
            resultForceY = mainJoy.Horizontal * forceY;
            resultForceZ = mainJoy.Vertical * forceZ;

            halfForceY = resultForceY * 0.5F;
            halfForceZ = resultForceZ * 0.5F;

            hips.AddRelativeForce(0F, halfForceY, halfForceZ, ForceMode.Force);

            leftUpperLeg.AddRelativeForce(0F, resultForceY, resultForceZ, ForceMode.Force);
            rightUpperLeg.AddRelativeForce(0F, resultForceY, resultForceZ, ForceMode.Force);
        }
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

    void FixedUpdate()
    {
        //#if UNITY_STANDALONE || UNITY_EDITOR
        //if (Input.GetKey(KeyCode.Space))
        if (mouseButtonDown)
        {
            TryFlip();
        }
        //if (Input.GetKeyUp(KeyCode.Space))
        if (!mouseButtonDown)
        {
            ReleaseCrossbar();
        }
        //#endif

        //#if UNITY_IOS || UNITY_ANDROID
        //if (Input.touchCount > 0)
        //{
        //    for (int i = 0; i < Input.touchCount; ++i)
        //    {
        //        var currentTouch = Input.GetTouch(i);
        //        if (currentTouch.phase == TouchPhase.Stationary)
        //        {
        //            TryFlip();
        //        }
        //        if (currentTouch.phase == TouchPhase.Ended)
        //        {
        //            ReleaseCrossbar();
        //        }
        //    }
        //}
        //#endif
    }
}
