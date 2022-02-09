using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateOnKeyPress : MonoBehaviour{

  public int totalOfDices = 0;
  private bool moveFlag = false;
  
  public float speed;
  public float targetDistance;
  private float remainingDistance;
  private bool moving = false;

  public float rotationSpeed;
  public float remainingAngle;
  private bool rotating = false;


  void Start(){
    Debug.Log("Merhaba!");
    Rigidbody rigidBody = GetComponent<Rigidbody>();
  }

  void Update(){
    if(DiceRollButtonScript.diceResultTotal > 0){
      if(totalOfDices % 8 == 0 && moveFlag){
        if (rotating == false){
          Debug.Log("Rotate COUNTERCLOCKWISE");
          rotating = true;
          remainingAngle = 90;
        }
        if (rotating == true) Rotate();
      }
      else{
        if (moving == false){
          Debug.Log("Back Move");
          moving = true;
          remainingDistance = targetDistance;
        }
        if (moving == true) Move();
      }
    }
  }

  private void Move(){
    float amount = Time.deltaTime * speed;
    transform.Translate(Vector3.back * amount);
    remainingDistance -= Mathf.Abs(amount);
    if (remainingDistance <= 0){
      moving = false;
      DiceRollButtonScript.diceResultTotal -= 1;
      totalOfDices += 1;
      moveFlag = true;
      totalOfDices %= 32;
    } 
  }

  private void Rotate(){
    float amount = Time.deltaTime * rotationSpeed;
    transform.Rotate(0f, amount, 0f);
    remainingAngle -= Mathf.Abs(amount);
    if (remainingAngle <= 0){
      rotating = false;
    } 
  }
}
