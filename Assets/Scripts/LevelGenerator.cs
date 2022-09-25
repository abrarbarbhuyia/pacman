using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3}, 
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    private int[] xCoordLeft = { -34, -33, -32, -31, -30, -29, -28, -27, -26, -25, -24, -23, -22, -21 };
    private int[] yCoordTop = { 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5 };
    private int[] xCoordRight = { -20, -19, -18, -17, -16, -15, -14, -13, -12, -11, -10, -9, -8, -7 };
    private int[] yCoordBottom = { 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
    public GameObject outsideCorner;
    public GameObject outsideWall;
    public GameObject insideCorner;
    public GameObject insideWall;
    public GameObject standardPellet;
    public GameObject powerPellet;
    public GameObject junctionPiece;

    // Start is called before the first frame update
    void Start()
    {
        GameObject currLevel = GameObject.FindWithTag("Level01");
        currLevel.SetActive(false);
        CreateMap();
    }

    void CreateMap() {
        for (int col = 0; col < levelMap.GetLength(0) - 1; col++) {
            for (int row = 0; row < levelMap.GetLength(1) - 1; row++) {
                Vector3 position = new Vector3(xCoordLeft[col] -0.5f, yCoordTop[row] + 1.4f, 0);
                Vector3 positionTopRight = new Vector3(xCoordRight[col], yCoordTop[row], 0);
                Vector3 positionBottomRight = new Vector3(xCoordRight[col], yCoordBottom[row], 0);
                Vector3 positionBottomLeft = new Vector3(xCoordLeft[col], yCoordBottom[row], 0);

                // Finding appropriate rotation


                Quaternion rotation = new Quaternion(0, 90f, 0, 0);
                if (levelMap[col, row] == 1)
                {
                    // Top left
                    Instantiate(outsideCorner, position, rotation);
                    // Top right
                    Instantiate(outsideCorner, positionTopRight, rotation);
                    // Bottom right
                    Instantiate(outsideCorner, positionBottomRight, rotation);
                    // Bottom left
                    Instantiate(outsideCorner, positionBottomLeft, rotation);
                }
                else if (levelMap[col, row] == 2)
                {
                    // Top left
                    Instantiate(outsideWall, position, rotation);
                    // Top right
                    Instantiate(outsideWall, positionTopRight, rotation);
                    // Bottom right
                    Instantiate(outsideWall, positionBottomRight, rotation);
                    // Bottom left
                    Instantiate(outsideWall, positionBottomLeft, rotation);
                }
                else if (levelMap[col, row] == 3)
                {
                    // Top left
                    Instantiate(insideCorner, position, rotation);
                    // Top right
                    Instantiate(insideCorner, positionTopRight, rotation);
                    // Bottom right
                    Instantiate(insideCorner, positionBottomRight, rotation);
                    // Bottom left
                    Instantiate(insideCorner, positionBottomLeft, rotation);
                }
                else if (levelMap[col, row] == 4)
                {
                    // Top left
                    Instantiate(insideWall, position, rotation);
                    // Top right
                    Instantiate(insideWall, positionTopRight, rotation);
                    // Bottom right
                    Instantiate(insideWall, positionBottomRight, rotation);
                    // Bottom left
                    Instantiate(insideWall, positionBottomLeft, rotation);
                }
                else if (levelMap[col, row] == 5)
                {
                    // Top left
                    Instantiate(standardPellet, position, rotation);
                    // Top right
                    Instantiate(standardPellet, positionTopRight, rotation);
                    // Bottom right
                    Instantiate(standardPellet, positionBottomRight, rotation);
                    // Bottom left
                    Instantiate(standardPellet, positionBottomLeft, rotation);
                }
                else if (levelMap[col, row] == 6) {
                    // Top left
                    Instantiate(powerPellet, position, rotation);
                    // Top right
                    Instantiate(powerPellet, positionTopRight, rotation);
                    // Bottom right
                    Instantiate(powerPellet, positionBottomRight, rotation);
                    // Bottom left
                    Instantiate(powerPellet, positionBottomLeft, rotation);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
