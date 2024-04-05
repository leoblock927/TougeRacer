using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailight : MonoBehaviour
{
    public Material[] materials = new Material[2]; //Array of the two materials: ON Tailight and OFF Tailight
    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>(); //Allows me to reference the meshRenderer, which changes the material of the tailight object.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) //GOING BACKWARDS
        {
            meshRenderer.material = materials[1]; // Sets the tailight material to ON when the key S or down arrow are pressed.
        }
        else if (Input.GetKeyUp(KeyCode.S)) //GOING FORWARDS
        {
            meshRenderer.material = materials[0]; // Sets the tailight material to ON when the key W or up arrow are pressed.
        }
    }
}