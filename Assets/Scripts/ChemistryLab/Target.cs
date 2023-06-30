using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
       
        foreach(Material m in renderer.materials)
       {
            m.color = Color.red;
        }
    }
    private void OnMouseExit()
    {
        foreach (Material m in renderer.materials)
        {
            m.color = Color.white;
        }
    }

}
