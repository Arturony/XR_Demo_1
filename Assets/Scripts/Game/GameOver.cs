using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<KinectManager>().enabled = false;
            Destroy(other.gameObject.GetComponentInParent<AvatarController>());
            other.gameObject.GetComponentInParent<EnableRagdoll>().StopAllCoroutines();
            other.gameObject.GetComponentInParent<EnableRagdoll>().enabled = false;
            
            panel.SetActive(true);
        }
    }
}
