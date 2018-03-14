using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TextureType
{
    air, grass, rock
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
        mesh = GetComponent <MeshFilter>().mesh;
        chunkCollider = GetComponent<MeshCollider>();

        CubeTop(0, 0, 0, (byte)TextureType.rock.GetHashCode());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CubeTop(int x, int y, int z, byte block)
    {
        //adding four points to the array

        newVertices.Add(new Vector3(x , y, z+1));
        newVertices.Add(new Vector3(x + 1, y, z + 1));
        newVertices.Add(new Vector3(x + 1, y, z));
        newVertices.Add(new Vector3(x, y, z));

        // points on the triangle
        newTriangles.Add(faceCount * 4); //1
        newTriangles.Add(faceCount * 4+1); //2
        newTriangles.Add(faceCount * 4+2); //3
        newTriangles.Add(faceCount * 4);//1
        newTriangles.Add(faceCount * 4+2);//3
        newTriangles.Add(faceCount * 4+3);//4

        Vector2 texturePos;
        texturePos = rock;

        newUV.Add(new Vector2(textureWidth * texturePos.x + textureWidth, textureWidth * texturePos.y));
        newUV.Add(new Vector2(textureWidth * texturePos.x + textureWidth, textureWidth * texturePos.y + textureWidth));
        newUV.Add(new Vector2(textureWidth * texturePos.x , textureWidth * texturePos.y + textureWidth));
        newUV.Add(new Vector2(textureWidth * texturePos.x, textureWidth * texturePos.y));
    }

    //Refreshes the display, clear out arrays,etc
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = newVertices.ToArray();
        mesh.uv = newUV.ToArray();
        mesh.triangles = newTriangles.ToArray();
        mesh.RecalculateNormals();

        //clear the lists we used
        newVertices.Clear();
        newUV.Clear();
        newTriangles.Clear();
        faceCount = 0;

    }

}
