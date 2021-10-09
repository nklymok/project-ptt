﻿using UnityEngine;

public class Player : MonoBehaviour
{
    private const float Tolerance = 0.1f;
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform movePoint;
    
    // Start is called before the first frame update
    private void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= Tolerance)
        {
            if (Mathf.Abs(Input.GetAxisRaw(HorizontalAxisName)) != 0f &&
                Mathf.Abs(Input.GetAxisRaw(VerticalAxisName)) != 0f) {
                return;
            }

            if (Mathf.Abs(Input.GetAxisRaw(HorizontalAxisName) - 1f) < Tolerance)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0f, 0f);
            }
            if (Mathf.Abs(Input.GetAxisRaw(VerticalAxisName) - 1f) < Tolerance)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw(VerticalAxisName), 0f);
            }
        }
    }
}
