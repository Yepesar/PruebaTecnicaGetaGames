using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMovemnt : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private Transform rightRail;
    [SerializeField] private Transform leftRail;
    [SerializeField] private float changeDistance = 1;
    [SerializeField] private Rigidbody rb;

    private Transform selectedRail;
    private int index = 0;
    private bool canmove = false;

    public bool Canmove { get => canmove; set => canmove = value; }

    // Start is called before the first frame update
    void Start()
    {
        selectedRail = rightRail;       
    }

    private void Update()
    {
        //RightSwitch
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (selectedRail == leftRail)
            {
                selectedRail = rightRail;
            }
        }
        //LeftSwitch
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (selectedRail == rightRail)
            {
                selectedRail = leftRail;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Canmove)
        {
            Move();
        }        
    }

    private void Move()
    {
        if (index >= selectedRail.childCount - 1)
        {
            index = 0;
        }

        Vector3 target = selectedRail.GetChild(index).gameObject.transform.position;

        Vector3 dir = target - transform.position;
        dir.Normalize();

        float rotY = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;       
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, rotY, 0f), Time.deltaTime * 4);

        rb.velocity = dir * speed;
                       
        if (Vector3.Distance(transform.position,target) <= changeDistance)
        {
            index += 1;
        }
        
    }   
}
