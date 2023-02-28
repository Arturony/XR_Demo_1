using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRagdoll : MonoBehaviour
{

    private List<Rigidbody> rbs = new List<Rigidbody>();

    private bool acting = false;

    private Vector3 initialPos;
    private Quaternion initialRot;

    public Transform charact;

    private KinectManager manager;

    void Start()
    {
        rbs = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        initialPos = charact.position;
        initialRot = charact.rotation;
        manager = FindObjectOfType<KinectManager>();
    }

    public void SetToNonKinematic()
    {

        if(!acting)
        {
            acting = true;
            foreach (Rigidbody r in rbs)
            {
                r.isKinematic = false;
                r.useGravity = true;
            }
            manager.enabled = false;
            StartCoroutine(WaitSeconds(2f));
        }
    }

    private IEnumerator WaitSeconds(float secs)
    {
        yield return new WaitForSeconds(secs);

        foreach (Rigidbody r in rbs)
        {
            r.isKinematic = true;
            r.useGravity = false; 
        }

        charact.position = initialPos;
        charact.rotation = initialRot;
        manager.enabled = true;
        acting = false;
    }

    private void OnEnable()
    {
        MovingWall.setKinematic += SetToNonKinematic;
    }

    private void OnDisable()
    {
        MovingWall.setKinematic -= SetToNonKinematic;
    }
}
