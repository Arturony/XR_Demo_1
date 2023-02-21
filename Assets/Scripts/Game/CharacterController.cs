using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class CharacterController : MonoBehaviour
{
    public BodySourceManager bodySourceManager;

    private Dictionary<ulong, GameObject> bodies = new Dictionary<ulong, GameObject>();

    private List<JointType> joints = new List<JointType>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
