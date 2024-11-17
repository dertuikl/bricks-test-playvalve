using System;
using Game.Core;
using UnityEngine;
using Zenject;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 500f;

    private UserInputController inputController;
    private IBallAnchorPointProvider anchorPointProvider;
    public Rigidbody2D Rigidbody { get; private set; }

    [Inject]
    public void Construct(UserInputController inputController,
        IBallAnchorPointProvider anchorPointProvider)
    {
        this.inputController = inputController;
        this.anchorPointProvider = anchorPointProvider;
    }
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        inputController.PointerUp += StartMovement;
        
        SetupStartPosition();
    }

    private void SetupStartPosition()
    {
        if (anchorPointProvider.BallAnchorPoint != null) {
            transform.position = anchorPointProvider.BallAnchorPoint.WorldPosition;
        }
    }

    private void StartMovement(Vector2 direction)
    {
        Rigidbody.AddForce(direction.normalized * speed);
    }

    private void OnDestroy()
    {
        inputController.PointerUp -= StartMovement;
    }
}
