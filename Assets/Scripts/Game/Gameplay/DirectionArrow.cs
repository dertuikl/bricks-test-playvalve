using System;
using Game.Core;
using UnityEngine;
using Zenject;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField]
    private RectTransform anchorRectTransform;
    
    private RectTransform rectTransform;
    private UserInputController inputController;
    private bool isEnabled;

    [Inject]
    public void Construct(UserInputController inputController)
    {
        this.inputController = inputController;
    }

    private void Awake()
    {
        rectTransform = transform as RectTransform;
        inputController.PointerDown += EnableArrow;
        inputController.PointerMove += RotateArrow;
        inputController.PointerUp += DisableArrow;
        
        DisableArrow();
    }

    private void EnableArrow(Vector2 direction)
    {
        gameObject.SetActive(true);
        isEnabled = true;
        
        RotateArrow(direction);
    }

    private void RotateArrow(Vector2 direction)
    {
        if (!isEnabled) {
            return;
        }
        
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void DisableArrow(Vector2 direction = default)
    {
        gameObject.SetActive(false);
        isEnabled = false;
    }

    private void OnDestroy()
    {
        inputController.PointerDown -= EnableArrow;
        inputController.PointerMove -= RotateArrow;
        inputController.PointerUp -= DisableArrow;
    }
}
