using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField]private float playerMoveSpeed = 0.5f;
    [SerializeField]private float playerRotateSpeed = 10f;

    private void Awake()
    { 
        playerController = new PlayerController();
        playerController.Enable();
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
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * Time.deltaTime * playerMoveSpeed;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, playerRotateSpeed * Time.deltaTime);
    }
}
