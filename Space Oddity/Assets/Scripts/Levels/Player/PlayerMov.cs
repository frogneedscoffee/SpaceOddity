using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using Leap.Unity;

public class PlayerMov : MonoBehaviour
{
    public SerialPort puerto2 = new SerialPort("COM6", 9600);

    public Camera mainCamera;

    public CapsuleHand L;

    private float offsetY = 20.0f;
    private float offsetX = 40.0f;

    public bool canMove = true;

    private void FixedUpdate()
    {
        if (!canMove)
            return;
        if (L.GetLeapHand() != null)
        {
            Vector3 newpos = new Vector3(L.GetLeapHand().PalmPosition.x * offsetX, L.GetLeapHand().PalmPosition.z * offsetY, 0);
            transform.position = newpos;
        }

        Debug.Log("Puerto");
    }
}