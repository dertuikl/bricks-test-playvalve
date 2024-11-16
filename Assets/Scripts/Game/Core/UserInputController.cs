using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Core
{
    public class UserInputController : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler
    {
        [SerializeField]
        private RectTransform anchorRectTransform;
        
        /// <summary>
        /// Returns direction vector in relation to anchor point.
        /// </summary>
        public event Action<Vector2> PointerDown;
        /// <summary>
        /// Returns direction vector in relation to anchor point.
        /// </summary>
        public event Action<Vector2> PointerMove;
        /// <summary>
        /// Returns direction vector in relation to anchor point.
        /// </summary>
        public event Action<Vector2> PointerUp;
        
        private Vector2 GetDirection(PointerEventData eventData) => 
            (eventData.position - (Vector2)anchorRectTransform.position).normalized;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDown?.Invoke(GetDirection(eventData));
        }
        
        public void OnPointerMove(PointerEventData eventData)
        {
            PointerMove?.Invoke(GetDirection(eventData));
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            PointerUp?.Invoke(GetDirection(eventData));
        }
    }
}