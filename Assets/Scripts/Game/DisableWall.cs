using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWall : MonoBehaviour
{
    public static Action disableWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovingWall>())
        {
            Destroy(other.gameObject);
            disableWall?.Invoke();
        }
    }
}
