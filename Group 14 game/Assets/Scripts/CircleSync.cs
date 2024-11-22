using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Player_Position");
    public static int SizeID = Shader.PropertyToID("_Size");
    public Material wallMaterial;
    public Camera mainCamera;
    public LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
        var dir = mainCamera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray,3000, layerMask))
        {
            print("Hit");
            wallMaterial.SetFloat(SizeID, 1);
        }
        else
        {
            wallMaterial.SetFloat(SizeID, 0);
        }
        var view = mainCamera.WorldToViewportPoint(transform.position);
        wallMaterial.SetVector(PosID, view);
    }
}
