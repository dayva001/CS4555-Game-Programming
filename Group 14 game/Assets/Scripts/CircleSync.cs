using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Player_Position");
    public static int SizeID = Shader.PropertyToID("_Size");
    public Camera mainCamera;
    public LayerMask layerMask;
    public Shader shader;
    private RaycastHit hit;
    private Material wallMat;
    public float holeSize = 20f;
    // Update is called once per frame
    void Update()
    {
        var dir = mainCamera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);
        var view = mainCamera.WorldToViewportPoint(transform.position);
        if (Physics.Raycast(ray,out hit, 3000, layerMask))
        {
            print("Hit");
            if(hit.collider.gameObject.GetComponent<Renderer>().material.shader.name == shader.name)
            {
                print(shader.name);
                wallMat = hit.collider.gameObject.GetComponent<Renderer>().material;
                wallMat.SetFloat(SizeID, holeSize/Vector3.Distance(transform.position, mainCamera.transform.position));
            }
        }
        else if(wallMat != null)
        {
            wallMat.SetFloat(SizeID, 0);
        }
    }
}
