using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    
    [SerializeField]
    private Color[] states;
    
    public int Health { get; private set; }

    private void Start()
    {
        Health = states.Length;
        RefreshVisualState();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            ProcessHit();
        }
    }

    private void ProcessHit()
    {
        Health--;
        RefreshVisualState();
        
        if (Health <= 0) {
            DestroyBrick();
        }
    }

    private void RefreshVisualState()
    {
        var index = Math.Clamp(Health - 1, 0, states.Length - 1);
        spriteRenderer.color = states[index];
    }

    private void DestroyBrick()
    {
        // TODO: implement pooling
        Destroy(gameObject);
    }
}
