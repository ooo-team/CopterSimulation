using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_generator : MonoBehaviour
{
    public int width = 256;
    public int hight = 256;
    public int depth = 32;
    public float scale = 1f;
    private Terrain terrain;
    public float xOffset = 0f;
    public float yOffset = 0f;

    private float detectChanges = 0;


    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    void Update()
    {
        if (detectChanges != width + hight + depth + scale + xOffset + yOffset) {
            detectChanges = width + hight + depth + scale + xOffset + yOffset;
            terrain.terrainData = GenerateTerrain(terrain.terrainData);
        }
    }

    private TerrainData GenerateTerrain(TerrainData terrainData) {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, hight);
        terrainData.SetHeights(0, 0, GenerateHigths());
        return terrainData; 
    }

    private float[,] GenerateHigths1() {
        float[,] higths = new float[width, hight];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < hight; y++) {
                higths[x,y] = CalculateHigths(x, y, 0, 0, scale);
            }
        }
        return higths;
    }

    private float[,] GenerateHigths() {
        float[,] higths = new float[width, hight];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < hight; y++) {
                higths[x,y] = .5f;
                for (int i = 0; i < 15; i++) {
                    higths[x,y] = (higths[x,y] + CalculateHigths(x, y, yOffset, xOffset, scale * Mathf.Pow(4, 15) / Mathf.Pow(4, i)) * 5)/ 6;
                }

                float thisDownBound = Mathf.Max( Mathf.Pow((float)x / width * 2 - 1f, 10f),
                                    Mathf.Pow((float)y / width * 2 - 1f, 10f)) * .9f + 0.1f;
                float thisUpBound = Mathf.Max( Mathf.Pow((float)x / width * 2 - 1f, 2f),
                                    Mathf.Pow((float)y / width * 2 - 1f, 2f)) * .4f + 0.6f;

                higths[x,y] *= thisUpBound - thisDownBound;
                higths[x,y] += thisDownBound;
            }
        }
        return higths;
    }

    private float CalculateHigths(int x, int y, float xOffset, float yOffset, float scale) {
        float xc = (float)x / width * scale + xOffset;
        float yc = (float)y / hight * scale + yOffset;
        return Mathf.PerlinNoise(xc, yc);
    }

}

