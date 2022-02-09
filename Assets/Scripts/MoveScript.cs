using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

  public float speed = 10f;
  public float targetDistance = 5f;

  private Direction direction;
  private float remainingDistance;
  private bool moving = false;


  public enum Direction
  {
    FORWARD, BACK, LEFT, RIGHT
  }

  // Update is called once per frame
  void Update()
  {
    if (moving == true)
    {
      Move();
    }
  }

  public void Move(Direction dir)
  {
    if (moving == false)
    {
      if (dir == Direction.FORWARD)
      {
        direction = Direction.FORWARD;
        moving = true;
        remainingDistance = targetDistance;
      }
      if (dir == Direction.LEFT)
      {
        direction = Direction.LEFT;
        moving = true;
        remainingDistance = targetDistance;
      }
      if (dir == Direction.BACK)
      {
        direction = Direction.BACK;
        moving = true;
        remainingDistance = targetDistance;
      }
      if (dir == Direction.RIGHT)
      {
        direction = Direction.RIGHT;
        moving = true;
        remainingDistance = targetDistance;
      }
    }
  }

  private void Move()
  {
    float amount = 0f;
    switch (direction)
    {
      case Direction.FORWARD:
        amount = Time.deltaTime * speed;
        transform.Translate(Vector3.forward * amount);
        remainingDistance -= Mathf.Abs(amount);
        break;
      case Direction.BACK:
        amount = Time.deltaTime * speed;
        transform.Translate(Vector3.back * amount);
        remainingDistance -= Mathf.Abs(amount);
        break;
      case Direction.LEFT:
        amount = Time.deltaTime * speed;
        transform.Translate(Vector3.left * amount);
        remainingDistance -= Mathf.Abs(amount);
        break;
      case Direction.RIGHT:
        amount = Time.deltaTime * speed;
        transform.Translate(Vector3.right * amount);
        remainingDistance -= Mathf.Abs(amount);
        break;
    }
    if (remainingDistance <= 0)
    {
      moving = false;
    }
  }
}
