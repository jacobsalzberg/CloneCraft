using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TextureType
{
    air, grass, rock;
}

public class Chunk : MonoBehaviour {


    private List<Vector3> newVertices = new List<Vector3>();
    //guarda as coordenadas dos triangulos
    private List<int> newTriangles = new List<int>();
    private List<Vector2> newUV = new List<Vector2>();

    private Mesh mesh;
    private MeshCollider chunkCollider;

    // 1/12 =0.083f
    private float textureWidth = 0.083f; 
    private int faceCount = 0;

    //Textures
    private Vector2 grassTop = new Vector2(1,11);
    private Vector2 grassSide = new Vector2(0, 10);
    private Vector2 rock = new Vector2(7, 8);


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CubeTop(int x, int y, int z, byte block)
    {

    }

    //Refreshes the display, clear out arrays,etc
    void UpdateMesh()
    {

    }
}
