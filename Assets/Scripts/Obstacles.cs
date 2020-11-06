using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject TriangleObj;

    float xOffset;
    void Start()
    {
        if(gameObject.name == "Left")
        {
            xOffset = 0.5f;
        }
        else
        {
            xOffset = -0.5f;
        }
        initObstacles();
    }

    
    void initObstacles()
    {
        foreach(Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for(int i=0;i<12;i++)
        {
            int randomY = Random.Range(-6,7);
            GameObject tempObj = Instantiate(TriangleObj, new Vector2(transform.position.x + xOffset, randomY * 1.5f), transform.rotation);
            tempObj.transform.SetParent(transform);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("name : " + other.gameObject.name);
        initObstacles();
    }
}
