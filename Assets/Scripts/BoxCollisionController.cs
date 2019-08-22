using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollisionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "box" && collision.gameObject.tag != "ground")
        {
            UIController.AddSoresNum(5);
            Debug.Log("Box has kicked");
        }
    }
}
