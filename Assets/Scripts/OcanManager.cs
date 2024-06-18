using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcanManager : MonoBehaviour
{
    public Transform ocean;

    public Material oceanMat;

    public float waterDisplacement;

    public Texture2D texture;
    public Texture2D texture2;

    void Start()
    {
        setValue();
    }

    void setValue()
    {
        oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        waterDisplacement = oceanMat.GetFloat("Vector1_WaterDisplacement");
        texture = (Texture2D)oceanMat.GetTexture("Texture2D_6d0f902902b04ba687ee00a51db7ba6d");
        texture2 = (Texture2D)oceanMat.GetTexture("Texture2D_786b67b3efe14204b2f06f9afb9d8cf1"); 
    }

    public float WaterHeightAtPosition(Vector3 position)
    {
   
        return (texture.GetPixelBilinear(position.x , position.z * Time.deltaTime /100).grayscale + texture2.GetPixelBilinear(position.x, position.z * Time.deltaTime / -50).grayscale ) * waterDisplacement;
    }

    private void OnValidate()
    {
        if (!oceanMat)
        {
            setValue();
        }
        updateMaterial();
    }

    private void updateMaterial()
    {
        oceanMat.SetFloat("Vector1_WaterDisplacement", waterDisplacement);
    }
}
