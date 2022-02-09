using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
  public float speed = 100f;

  private Rotation rotation;
  private float remainingAngle;
  private bool rotating = false;


  public enum Rotation
  {
    COUNTERCLOCKWISE, CLOCKWISE
  }

  // Update is called once per frame
  void Update()
  {
    if (rotating == true)
    {
      Rotate();
    }
  }

  public void Rotate(Rotation rot)
  {
    if (rotating == false)
    {
      if (rot == Rotation.CLOCKWISE)
      {
        rotation = Rotation.CLOCKWISE;
        rotating = true;
        remainingAngle = 90;
      }
      if (rot == Rotation.COUNTERCLOCKWISE)
      {
        rotation = Rotation.COUNTERCLOCKWISE;
        rotating = true;
        remainingAngle = 90;
      }
    }
  }

  private void Rotate()
  {
    float amount = 0f;
    switch (rotation)
    {
      case Rotation.COUNTERCLOCKWISE:
        amount = Time.deltaTime * speed;
        transform.Rotate(0, amount, 0);
        remainingAngle -= Mathf.Abs(amount);
        break;
      case Rotation.CLOCKWISE:
        amount = Time.deltaTime * (-speed);
        transform.Rotate(0, amount, 0);
        remainingAngle -= Mathf.Abs(amount);
        break;
    }
    if (remainingAngle <= 0)
    {
      rotating = false;
    }
  }
}
