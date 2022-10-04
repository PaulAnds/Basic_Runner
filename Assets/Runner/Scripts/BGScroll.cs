using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f; //Velociada de scrolling

    private MeshRenderer meshRenderer; // ref del componente mesh renderer del background

    private float yScroll; //valor del scrolling en el eje x en el unity

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        //Determinar el valor de scroll usando la velocidad y el tiempo
        yScroll = Time.time * scrollSpeed;
        Vector2 _offest = new Vector2(0.0f, yScroll);

        //Modificar Textura usando el offset
        //Aqui pasaremos el nombre generico de la textura y se agrega dicho offset
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", _offest);
    }//End scroll

}//Ends class
