using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] lines; // Array of line positions (set these in the Inspector)
    private int currentLineIndex = 0; // Index of the current line the player is on
    private bool canMove = true; // Flag to ensure one movement per button press

    private void Start()
    {
        // Ensure the player starts at Line (2) 
        currentLineIndex = 2; //Line (2) is at index 2 in the lines array

        if (lines.Length > 0 && currentLineIndex < lines.Length)
        {
            // Set the player's position to the starting line's x and z, but force y to -3
            Vector3 startPosition = lines[currentLineIndex].position;
            transform.position = new Vector3(startPosition.x, -3, startPosition.z);
        }
        else
        {
            Debug.LogError("Invalid starting line index or no lines assigned to the PlayerMovement script.");
        }
    }

    private void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (canMove)
        {
            if (horizontalInput > 0) // Move right
            {
                MoveToLine(currentLineIndex + 1);
                canMove = false; // Disable movement until input is released
            }
            else if (horizontalInput < 0) // Move left
            {
                MoveToLine(currentLineIndex - 1);
                canMove = false; // Disable movement until input is released
            }
        }

        // Reset the movement flag when input is released
        if (horizontalInput == 0)
        {
            canMove = true;
        }
    }

    private void MoveToLine(int targetLineIndex)
    {
        // Ensure the target line index is within bounds
        if (targetLineIndex >= 0 && targetLineIndex < lines.Length)
        {
            currentLineIndex = targetLineIndex;

            // Move to the target line's x and z, but keep y at -3
            Vector3 targetPosition = lines[currentLineIndex].position;
            transform.position = new Vector3(targetPosition.x, -3, targetPosition.z);
        }
    }
}