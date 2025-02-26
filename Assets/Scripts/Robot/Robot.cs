using UnityEngine;

public class Robot : MonoBehaviour
{
    public Vector3 destination;
    public bool isMoving = false;
    public float movementSpeed = 2.0f;
    
    void Update()
    {
        if (isMoving == false)
            return;
        if (Vector3.Distance(destination, transform.position) < 0.1f)
        {
            isMoving = false;
            return;
        }
        this.transform.LookAt(destination);
        this.transform.position += this.transform.forward * Time.deltaTime * movementSpeed;
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
        isMoving = true;
    }
}
