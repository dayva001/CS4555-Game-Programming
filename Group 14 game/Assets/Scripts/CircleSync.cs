using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public enum PlayerID
    {
        solo, player1, player2, player3
    }
    public static int PosID1= Shader.PropertyToID("_Player_Position_1");
    public static int PosID2 = Shader.PropertyToID("_Player_Position_2");
    public static int PosID3 = Shader.PropertyToID("_Player_Position_3");
    public static int SizeID1 = Shader.PropertyToID("_Player_Size_1");
    public static int SizeID2 = Shader.PropertyToID("_Player_Size_2");
    public static int SizeID3 = Shader.PropertyToID("_Player_Size_3");
    public static int OpaID1 = Shader.PropertyToID("_Player_Opacity_1");
    public static int OpaID2 = Shader.PropertyToID("_Player_Opacity_2");
    public static int OpaID3 = Shader.PropertyToID("_Player_Opacity_3");

    public Camera mainCamera;
    public LayerMask layerMask;
    public Shader shader;
    private RaycastHit hit;
    private Material wallMat;
    public float holeSize = 20f;
    private int playerPosID, playerOpaID, playerSizeID;
#pragma warning disable 0649
    public PlayerID playerId;
#pragma warning disable 0649
    // Update is called once per frame
    private void Start()
    {
        switch (playerId)
        {
            case PlayerID.solo:
                playerPosID = PosID1;
                playerOpaID = OpaID1;
                playerSizeID = SizeID1;
                break;
            case PlayerID.player1:
                playerPosID = PosID1;
                playerOpaID = OpaID1;
                playerSizeID = SizeID1;
                break;
            case PlayerID.player2:
                playerPosID = PosID2;
                playerOpaID = OpaID2;
                playerSizeID = SizeID2;
                break;
            case PlayerID.player3:
                playerPosID = PosID3;
                playerOpaID = OpaID3;
                playerSizeID = SizeID3;
                break;
        }
    }
    void Update()
    {
        var dir = mainCamera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);
        var view = mainCamera.WorldToViewportPoint(transform.position);
        if (Physics.Raycast(ray,out hit, 3000, layerMask))
        {
            if(hit.collider.gameObject.GetComponent<Renderer>().material.shader.name == shader.name)
            {
                wallMat = hit.collider.gameObject.GetComponent<Renderer>().material;
                wallMat.SetFloat(playerSizeID, holeSize/Vector3.Distance(transform.position, mainCamera.transform.position));
                wallMat.SetVector(playerPosID, view);
                wallMat.SetFloat(playerOpaID, 1);
            }
        }
        else if(wallMat != null)
        {
            wallMat.SetFloat(playerSizeID, 0);
            wallMat.SetFloat(playerOpaID, 0);
        }
    }
}
