using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Core.Screens
{
    public abstract class AnimatedScreen : BaseScreen
    {
        private const string OpenAnimatorParamKey = "Open";
        private const string CloseAnimatorParamKey = "Close";
        
        private Animator animator;
        
        private TaskCompletionSource<bool> openAnimationTcs;
        private TaskCompletionSource<bool> closeAnimationTcs;

        public async override Task OpenScreen()
        {
            if (animator == null) {
                animator = GetComponent<Animator>();
            }
            openAnimationTcs = new TaskCompletionSource<bool>();
            animator.SetBool(OpenAnimatorParamKey, true);
            await openAnimationTcs.Task;
            if (gameObject != null && gameObject.activeInHierarchy) {
                OnScreenOpen();
            }
        }

        // called by animation
        public void OpenAnimationFinished()
        {
            openAnimationTcs.TrySetResult(true);
        }
        
        // called by animation
        public void CloseAnimationFinished()
        {
            closeAnimationTcs.TrySetResult(true);
        }

        public async override Task CloseScreen()
        {
            if (animator == null) {
                animator = GetComponent<Animator>();
            }
            closeAnimationTcs = new TaskCompletionSource<bool>();
            animator.SetBool(CloseAnimatorParamKey, true);
            await closeAnimationTcs.Task;
            if (gameObject != null && gameObject.activeInHierarchy) {
                OnScreenClose();
            }
        }

        protected virtual void OnScreenOpen()
        {
            
        }

        protected virtual void OnScreenClose()
        {
            
        }
    }
}