using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Animator anim;

    [Header("Animation Settings")]
    public float movementThreshold = 0.1f; // Speed required to trigger run anim

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Ensure cursor is visible for click-to-move
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // 1. Handle Input
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        // 2. Handle Animation Logic
        // We check the magnitude (length) of the agent's current velocity
        if (agent.velocity.magnitude > movementThreshold)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

            // Rotate the player to face the direction of movement
        if (agent.velocity.sqrMagnitude > 0.1f) // Only rotate if we are actually moving
        {
            // Calculate the direction the agent is moving
            Quaternion lookRotation = Quaternion.LookRotation(agent.velocity.normalized);
            
            // Smoothly rotate toward that direction over time
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
    }
}