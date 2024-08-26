using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCardBoard : MonoBehaviour
{
    public RenderTexture ren;
    // Start is called before the first frame update

    private void Awake()
    {
        ren.width = Screen.width / 2;
        ren.height = Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
