using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using Leap.Unity;

public class Level_0Mov : MonoBehaviour
{
    SerialPort puertoExtras;

    public Camera mainCamera;

    public CapsuleHand L;

    private float offsetY = 20.0f;
    private float offsetX = 40.0f;

    private void Start()
    {
        puertoExtras = FindObjectOfType<PlayerMov>().puerto2;

        puertoExtras.ReadTimeout = 40;
        if (puertoExtras.IsOpen) { }
        else
        {
            puertoExtras.Open();
        }
    }

    private void FixedUpdate()
    {
        if (L.GetLeapHand() != null)
        {
            Vector3 newpos = new Vector3(L.GetLeapHand().PalmPosition.x * offsetX, L.GetLeapHand().PalmPosition.z * offsetY, 0);
            transform.position = newpos;
        }
    }
}