using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditTerrain : MonoBehaviour {
    public Terrain terrain;
    private TerrainData terrainData;
    Vector3 initPos;
    float sqLength = 30;
	// Use this for initialization

	void Start () {
        initPos = Vector3.zero;
        terrainData = terrain.terrainData;
        EditMe();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void EditMe() {
        int heightmapWidth = terrainData.heightmapWidth;
        int heightmapHeight = terrainData.heightmapHeight;
        Vector3 sizeT = GetWorldCoords(70, 40);

        //initPos = new Vector3(terrainData.heightmapWidth/2, terrainData.heightmapHeight/2);
        float[,] heights = terrainData.GetHeights(0,0,heightmapWidth,heightmapHeight);

        for (int i = 0; i < heightmapHeight; i++)
        {
            for (int j = 0; j < heightmapWidth; j++)
            {
                float cos = Mathf.Cos(j);
                float sin = -Mathf.Sin(i);
                heights[j, i] = 0;
            }
        }
        terrainData.SetHeights(0, 0, heights);
        for (int i = 0; i < heightmapHeight; i++)
        {
            for (int j = 0; j < heightmapWidth; j++)
            {
                float cos = Mathf.Cos(j);
                float sin = -Mathf.Sin(i);
                //if (InSquare(j, i))
                //    heights[j, i] = 0.01f;
                if (70 * sizeT.x == i && 40 * sizeT.y==j) {
                    heights[j, i] = 0.01f;
                }

            }
        }
        terrainData.SetHeights(0,0,heights);
    }

   private Vector3 GetWorldCoords(float worldX ,float worldZ) {
        Vector3 sizeT = terrainData.size;
        return new Vector3(terrainData.heightmapResolution / sizeT.x, terrainData.heightmapResolution / sizeT.z, 0);
 }

private bool InSquare( float x, float y) {

        if (x <= initPos.x + (sqLength / 2) && x >= initPos.x - (sqLength / 2) &&
           y <= initPos.y + sqLength / 2 && y >= initPos.y - sqLength / 2) {

            if (x == 16 || y==16)
                Debug.Log("ksss");

            return true;
        }
        return false;
    }

}
