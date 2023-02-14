using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePicture : MonoBehaviour
{
    public Material Picture2;
    public Material newWallTexture;
    public GameObject obj;
    public GameObject groundWall;
    public GameObject saide1Wall;
    public GameObject side2Wall;
    public GameObject frontWall;
    public GameObject backWall;
    public GameObject topWall;


    public GameObject box;

    public void turnOffPics()
    {
        obj.GetComponent<MeshRenderer>().material = Picture2;
    }


    public void changeWallTextures()
    {
        groundWall.GetComponent<MeshRenderer>().material = newWallTexture;
        saide1Wall.GetComponent<MeshRenderer>().material = newWallTexture;
        side2Wall.GetComponent<MeshRenderer>().material = newWallTexture;
        frontWall.GetComponent<MeshRenderer>().material = newWallTexture;
        backWall.GetComponent<MeshRenderer>().material = newWallTexture;
        topWall.GetComponent<MeshRenderer>().material = newWallTexture;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
