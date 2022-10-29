using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86;
using Unity.VisualScripting;
//tilemap manager
using UnityEngine.Tilemaps;
public class PacStudentController : MonoBehaviour
{
    public GameObject PacStudent;
    private float moveSpeed = 0.2f;
    bool isMoving;
    private KeyCode lastInput;
    public KeyCode currentInput;
    public Tilemap map;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            lastInput = KeyCode.W;
        }
        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            lastInput = KeyCode.A;
        }
        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            lastInput = KeyCode.S;
        }
        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            lastInput = KeyCode.D;
        }

        if (isMoving == false)
        {
            if (lastInput == KeyCode.W)
            {
                if (map.GetTile(map.WorldToCell(PacStudent.transform.position + Vector3.up)) == null)
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.up));
                }
                else if (isNotWall(PacStudent.transform.position, Vector3.up))
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.up));

                }
                else {
                    // Vector3 currentDirection = getCurrentDirection();
                    
                }
            }
            if (lastInput == KeyCode.A)
            {
                if (map.GetTile(map.WorldToCell(PacStudent.transform.position + Vector3.left)) == null)
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.left));
                }
                else if (isNotWall(PacStudent.transform.position, Vector3.left))
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.left));

                }
            }
            if (lastInput == KeyCode.S)
            {
                if (map.GetTile(map.WorldToCell(PacStudent.transform.position + Vector3.down)) == null)
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.down));
                }
                else if (isNotWall(PacStudent.transform.position, Vector3.down))
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.down));

                }
            }
            if (lastInput == KeyCode.D)
            {
                if (map.GetTile(map.WorldToCell(PacStudent.transform.position + Vector3.right)) == null)
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.right));
                }
                else if (isNotWall(PacStudent.transform.position, Vector3.right))
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.right));

                }
            }
        }
    }


    // check if pacstudent.transform.position + direction.name == 1, 2, 3, 4, 7 
    private bool isNotWall(Vector3 position, Vector3 direction) {
        if (map.GetTile(map.WorldToCell(position + direction)).name == "1" ||
            map.GetTile(map.WorldToCell(position + direction)).name == "2" ||
            map.GetTile(map.WorldToCell(position + direction)).name == "3" ||
            map.GetTile(map.WorldToCell(position + direction)).name == "4" ||
            map.GetTile(map.WorldToCell(position + direction)).name == "7")
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    // Credit: Author: Comp-3 Interactive. Date: Sep 12, 2020. Link: https://www.youtube.com/watch?v=AiZ4z4qKy44
    private IEnumerator MoveGridPosition(Vector3 direction) {
        isMoving = true;
        float elapsed = 0;
        Vector3 startPos = PacStudent.transform.position;
        // looping the lerp until time reaches movespeed (which is the time taken to reach the next grid)
        while (elapsed < moveSpeed)
        {
            PacStudent.transform.position = Vector3.Lerp(startPos, startPos + direction, (elapsed / moveSpeed));
            elapsed += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
        yield return 0;
    }

    // function to grab next tile in direction
    private Tile GetNextTile(Vector3 direction)
    {
        Vector3Int nextTilePos = map.WorldToCell(PacStudent.transform.position + direction);
        return map.GetTile<Tile>(nextTilePos);
    }


}
