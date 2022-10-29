using System.Collections;
using UnityEngine;
//tilemap manager
using UnityEngine.Tilemaps;
public class PacStudentController : MonoBehaviour
{
    private float moveSpeed = 0.166f;
    public bool isMoving;
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
        if (Input.GetKey(KeyCode.W))
        {
            lastInput = KeyCode.W;
        }
        if (Input.GetKey(KeyCode.A))
        {
            lastInput = KeyCode.A;
        }
        if (Input.GetKey(KeyCode.S))
        {
            lastInput = KeyCode.S;
        }
        if (Input.GetKey(KeyCode.D))
        {
            lastInput = KeyCode.D;
        }

        if (isMoving == false)
        {
            if (lastInput == KeyCode.W)
            {
                // Checking if we can move based on last input
                if (map.GetTile(map.WorldToCell(gameObject.transform.position + Vector3.up)) == null)
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.up));
                }
                else if (isNotWall(gameObject.transform.position, Vector3.up))
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.up));

                }
                // if not we try to move with current input
                else {
                    Vector3 currentDirection = getCurrentDirection();
                    if (map.GetTile(map.WorldToCell(gameObject.transform.position + currentDirection)) == null)
                    {
                        StartCoroutine(MoveGridPosition(currentDirection));
                    }
                    else if (isNotWall(gameObject.transform.position, currentDirection))
                    {
                        StartCoroutine(MoveGridPosition(currentDirection));
                    }
                }
            }
            if (lastInput == KeyCode.A)
            {
                if (map.GetTile(map.WorldToCell(gameObject.transform.position + Vector3.left)) == null)
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.left));
                }
                else if (isNotWall(gameObject.transform.position, Vector3.left))
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.left));

                }
                else
                {
                    
                    Vector3 currentDirection = getCurrentDirection();
                    // try to move in currentdirection
                    if (map.GetTile(map.WorldToCell(gameObject.transform.position + currentDirection)) == null)
                    {
                        StartCoroutine(MoveGridPosition(currentDirection));
                    }
                    else if (isNotWall(gameObject.transform.position, currentDirection))
                    {
                        StartCoroutine(MoveGridPosition(currentDirection));
                    }
                }
            }
            if (lastInput == KeyCode.S)
            {
                if (map.GetTile(map.WorldToCell(gameObject.transform.position + Vector3.down)) == null)
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.down));
                }
                else if (isNotWall(gameObject.transform.position, Vector3.down))
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.down));

                }
                else
                {
                    
                    Vector3 currentDirection = getCurrentDirection();
                    if (map.GetTile(map.WorldToCell(gameObject.transform.position + currentDirection)) == null)
                    {
                        StartCoroutine(MoveGridPosition(currentDirection));
                    }
                    else if (isNotWall(gameObject.transform.position, currentDirection))
                    {
                        StartCoroutine(MoveGridPosition(currentDirection));
                    }
                }
            }
            if (lastInput == KeyCode.D)
            {
                if (map.GetTile(map.WorldToCell(gameObject.transform.position + Vector3.right)) == null)
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.right));
                }
                else if (isNotWall(gameObject.transform.position, Vector3.right))
                {
                    currentInput = lastInput;
                    StartCoroutine(MoveGridPosition(Vector3.right));

                }
                else
                {
                    
                    Vector3 currentDirection = getCurrentDirection();
                    if (map.GetTile(map.WorldToCell(gameObject.transform.position + currentDirection)) == null)
                    {
                        StartCoroutine(MoveGridPosition(currentDirection));
                    }
                    else if (isNotWall(gameObject.transform.position, currentDirection))
                    {
                        StartCoroutine(MoveGridPosition(currentDirection));
                    }
                }
            }
        }
    }

    // getting current direction based on keycode and return a vector3
    public Vector3 getCurrentDirection()
    {
        if (currentInput == KeyCode.W)
        {
            return Vector3.up;
        }
        if (currentInput == KeyCode.A)
        {
            return Vector3.left;
        }
        if (currentInput == KeyCode.S)
        {
            return Vector3.down;
        }
        if (currentInput == KeyCode.D)
        {
            return Vector3.right;
        } 
        return Vector3.zero;
    }

    // checking if pacstudent.transform.position + direction.name == 1, 2, 3, 4, 7 
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

    private IEnumerator MoveGridPosition(Vector3 direction) {
        isMoving = true;
        float elapsed = 0;
        Vector3 startPos = gameObject.transform.position;
        // looping the lerp until time reaches movespeed (which is the time taken to reach the next grid)
        while (elapsed < moveSpeed)
        {
            gameObject.transform.position = Vector3.Lerp(startPos, startPos + direction, (elapsed / moveSpeed));
            elapsed += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
        yield return 0;
    }

    // function to grab next tile in direction
    private Tile GetNextTile(Vector3 direction)
    {
        Vector3Int nextTilePos = map.WorldToCell(gameObject.transform.position + direction);
        return map.GetTile<Tile>(nextTilePos);
    }


}
