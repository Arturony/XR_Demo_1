using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISelector : MonoBehaviour
{
    public GameObject leftHand;

    public GameObject rightHand;

    public RectTransform button;

    public Camera cam;

    public float timer = 2f;

    private float currentimer;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 leftScreenPoint = cam.WorldToScreenPoint(leftHand.transform.position);
        Vector3 rightScreenPoint = cam.WorldToScreenPoint(rightHand.transform.position);

        if (IsPointInRT(new Vector2(leftScreenPoint.z, leftScreenPoint.y), button) || IsPointInRT(new Vector2(rightScreenPoint.z, rightScreenPoint.y), button))
        {
            currentimer = Time.deltaTime;
        }
        else
            currentimer = 0f;

        if (currentimer >= timer)
        {
            LoadScener();   
        }
    }

    private bool IsPointInRT(Vector2 point, RectTransform rt)
    {
        // Get the rectangular bounding box of your UI element
        Rect rect = rt.rect;

        // Get the left, right, top, and bottom boundaries of the rect
        float leftSide = rt.anchoredPosition.x;
        // The below width is multiplied by 1.3f just to expand the width a slight bit, because it doesn't seem to measure properly (cuts short)
        float rightSide = rt.anchoredPosition.x + (rect.width * 1.3f);
        float topSide = rt.anchoredPosition.y + rect.height;
        float bottomSide = rt.anchoredPosition.y;

        //Debug.Log(leftSide + ", " + rightSide + ", " + topSide + ", " + bottomSide);

        // Check to see if the point is in the calculated bounds
        if (point.x >= leftSide &&
            point.x <= rightSide &&
            point.y >= bottomSide &&
            point.y <= topSide)
        {
            return true;
        }
        return false;
    }

    public void LoadScener()
    {
        SceneManager.LoadScene(0);
    }
}
