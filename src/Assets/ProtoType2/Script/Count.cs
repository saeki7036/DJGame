using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Count : MonoBehaviour
{
    [SerializeField] Text _text;

    static int count;
    static Text text;
   public static void AddCount()
   {
    text.text = (++count).ToString();
   }



    // Start is called before the first frame update
    void Start()
    {
        count = -1;
        text = _text;
        AddCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
