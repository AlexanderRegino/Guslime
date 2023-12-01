using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private GameObject parentObj;
    private Vector3 originalScale;

    // Unity Event for the normal hit action
    public UnityEvent onNormalHit;
    public UnityEvent onCriticalHit;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the parent GameObject to parentObj
        parentObj = transform.gameObject;

        // Store the original scale for later restoration
        originalScale = parentObj.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (parentObj != null)
        {
            // Grow the panel by 25%
            parentObj.transform.localScale = originalScale * 1.25f;

            // Invoke the Unity Event for normal hit on pointer enter
            if (onNormalHit != null)
            {
                onNormalHit.Invoke();
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (parentObj != null)
        {
            // Restore the original scale
            parentObj.transform.localScale = originalScale;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Handle the click event
        if (onCriticalHit != null)
        {
            // Invoke the Unity Event for critical hit on click
            onCriticalHit.Invoke();
        }
    }
}
