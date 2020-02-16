using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed;
    private Renderer renderer;
    
    //Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("MoveBg", 0.5f, 0.5f);
    }
    private void MoveBg()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(GetComponent<Renderer>().material.mainTextureOffset.x + 0.50f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        //GetCompone nt<Renderer>().material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0);
    }
}
