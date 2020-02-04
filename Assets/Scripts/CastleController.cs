using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseOver()
    {
        Debug.Log(this.gameObject.name);
    }

    private void OnMouseEnter()
    {
        Debug.Log(this.gameObject.name + " ENTER");
    }

    private void OnMouseExit()
    {
        Debug.Log(this.gameObject.name +  " EXIT");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
