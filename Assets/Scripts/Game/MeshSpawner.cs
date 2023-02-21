using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSpawner : MonoBehaviour
{
    public List<GameObject> objects;

    private GameObject activeObject;

    private List<GameObject> objects2Spawn;

    public Transform target;

    private void Start()
    {
        objects2Spawn = new List<GameObject>(objects);

        SpawnObject();
    }

    public void SpawnObject()
    {
        
        int randIndx = Random.Range(0, objects2Spawn.Count);
        GameObject g = Instantiate(objects2Spawn[randIndx]);
        g.transform.position = transform.position;
        g.GetComponent<MovingWall>().MoveToPoint(target);
        objects2Spawn.RemoveAt(randIndx);

        if (objects2Spawn.Count <= 0)
            objects2Spawn = new List<GameObject>(objects);
        
    }

    private void OnEnable()
    {
        DisableWall.disableWall += SpawnObject;
    }

    private void OnDisable()
    {
        DisableWall.disableWall -= SpawnObject;
    }
}
