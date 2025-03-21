using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public float minHeight = -2f;
    public float maxHeight = 2f;
    public float maxTime = 2f;
    public float timer = 0;
    public GameObject arrow;


    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)
        {
            GameObject newArrow = Instantiate(arrow);
            newArrow.transform.position = transform.position + new Vector3(0, Random.Range(minHeight, maxHeight), 0);
            Destroy(newArrow,12);
            timer = 0;
        }
        timer += Time.deltaTime;
        
    }
}
