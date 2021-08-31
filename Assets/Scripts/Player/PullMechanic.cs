using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullMechanic : MonoBehaviour
{
   
    
    [SerializeField]
    private bool isAiming = false;
    private LineRenderer lr;
    private bool moving = false;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void OnMouseDown()
    {
        if(isAiming && !moving)
        {
            StartCoroutine(Click_CoolDown(false));
        }
        else
        {
            StartCoroutine(Click_CoolDown(true));
        }
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(pos);
        if (isAiming && !moving)
        {
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, pos);

        }
        else if(!isAiming)
        {
            lr.enabled = false;
        }
        MovePlayer();

    }

    private void FixedUpdate()
    {
        if(GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }
    IEnumerator Click_CoolDown(bool setActive)
    {
        if(!setActive)
        {
            isAiming = false;
        }
        yield return new WaitForSeconds(.2f);
        if(setActive)
        {
            isAiming = true;
        }
    }

    private void MovePlayer()
    {
        if(isAiming && Input.GetMouseButtonDown(0) && !moving)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
            float distance = Vector3.Distance(pos, transform.position);
            Vector3 direction = transform.position - pos;
            direction.Normalize();
            GetComponent<Rigidbody>().AddForce(direction * distance * 100);
            isAiming = false;
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
