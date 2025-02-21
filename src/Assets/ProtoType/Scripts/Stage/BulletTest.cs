using UnityEngine;

public class BulletTest : MonoBehaviour
{
    [SerializeField]
    float time = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    float timeCount = 0;
    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > time)
            Destroy(gameObject);
    }
}
