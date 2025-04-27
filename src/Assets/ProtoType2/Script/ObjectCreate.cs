using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    [SerializeField] GameObject Blocks;
    [SerializeField] int GameObjectValue = 100;
    [SerializeField] float Max_x = 500;
    [SerializeField] float Min_x = -500;
    [SerializeField] float Max_z = 500;
    [SerializeField] float Min_z = -500;
    [SerializeField] float Y_pos = 5f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < GameObjectValue; i++)
        {
            Instantiate(Blocks, new Vector3(Random.Range(Min_x,Max_x), Y_pos, Random.Range(Min_z, Max_z)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
