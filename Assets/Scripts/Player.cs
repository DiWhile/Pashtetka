using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;

    [SerializeField]private float playerMoveSpeed = 0.5f;
    [SerializeField]private float playerRotateSpeed = 10f;
    private bool buttonWalkIsPress;
    private bool isWalking;
    private void Awake()
    { 
        playerController = new PlayerController();
        playerController.Enable();
        animator = GetComponent<Animator>();
    }

    private Vector2 GetMovementVectorNormolized()
    {
        Vector2 inputVector = playerController.Player.PlayerMove.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }

    private void Update()
    {
        Vector2 inputVector = GetMovementVectorNormolized();
        if (inputVector != Vector2.zero)
        {
            buttonWalkIsPress = true;           
        }
        else
        { 
            isWalking = false;
            buttonWalkIsPress = false;
        }
        animator.SetBool("isWalking", buttonWalkIsPress);
        if (isWalking == true)
        {
            Move(inputVector);
        }
        
    }

    private void Move(Vector2 inputVector)
    {
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * Time.deltaTime * playerMoveSpeed;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, playerRotateSpeed * Time.deltaTime);
    }

    public void IsWalk()
    {
        isWalking = true;
    }
    public void NotIsWalk()
    {
        isWalking = false;
    }
}
