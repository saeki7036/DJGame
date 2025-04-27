using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHIt : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit!");
        Destroy(gameObject);
        Count.AddCount();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
