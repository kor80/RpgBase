using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationHandler : MonoBehaviour
{
    Animator buttonAnimator;
    [SerializeField] Image border;

    public void Start() 
    {   buttonAnimator = GetComponent<Animator>();
    }

    public void ToggleAnimation()
    {   
        bool state = !buttonAnimator.GetBool("isAnimating");
        border.gameObject.SetActive(state);
        buttonAnimator.SetBool("isAnimating", state);
    }
}
