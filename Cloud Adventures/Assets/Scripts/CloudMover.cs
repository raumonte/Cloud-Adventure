using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    private CharacterController cc;
    public CloudData data;
    public enum ControlType { WASD, ArrowKeys };
    public ControlType controlType;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 directionToMove = Vector3.zero;
        if (controlType == ControlType.WASD)
        {
            //When the player presses the W key it begins to move forward.
            if (Input.GetKey(KeyCode.W))
            {
                directionToMove = transform.forward;
            }
            //When the player presses the W key it begins to rotate to the
            if (Input.GetKey(KeyCode.A))
            {
             Rotation(false);

            }

            if (Input.GetKey(KeyCode.S))
            {
                directionToMove = -transform.forward;
            }

            if (Input.GetKey(KeyCode.D))
            {
              Rotation(true);
            }
            MoveStraight(directionToMove);
        }
        if (controlType == ControlType.ArrowKeys)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                directionToMove = transform.forward;

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Rotation(false);

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                Rotation(true);

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                directionToMove = -transform.forward;
            }
            MoveStraight(directionToMove);
        }
    }
    public void MoveStraight(Vector3 direction)
    {
        cc.SimpleMove(direction * data.speed);
    }
    public void Rotation(bool isClockwise)
    {
        if (isClockwise)
        {
            transform.Rotate(new Vector3(0, data.rotateSpeed * Time.deltaTime, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, -data.rotateSpeed * Time.deltaTime, 0));

        }
    }
    public void MoveTo(Transform targetTransform)
    {
        //TODO:Rotate towards the waypoint
        RotateTowards(targetTransform);
        //Move towards the waypoint aka moving forward
        cc.SimpleMove(transform.forward * data.speed);
    }
    public void RotateTowards(Transform targetTransform)
    {
        //Rotate towards the object. In this case the waypoint.
        Vector3 targetVector = targetTransform.position - transform.position;
        //Find the rotation to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(targetVector);
        //Find a rotatuin that partway closer to the rotation than we are right now
        Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, data.rotateSpeed * Time.deltaTime);
        //Change to that new rotation
        transform.rotation = newRotation;
    }
}
