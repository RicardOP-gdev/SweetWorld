using UnityEngine;
using System.Collections;

public class DragRotate : MonoBehaviour
{
    //public GameObject worlds;
    [SerializeField] float rotationSpeed = 100f;
    public bool dragging = false;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMouseDrag()
    {
        dragging = true;
    }
    public void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
        
    }
    private void FixedUpdate()
    {
        if(dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;

            rb.AddTorque(Vector3.down * x);
        }
    }
}