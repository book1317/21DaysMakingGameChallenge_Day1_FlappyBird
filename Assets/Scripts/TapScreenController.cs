using UnityEngine;
using UnityEngine.EventSystems;

public class TapScreenController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerController thePlayer;
    [SerializeField] LevelController theLevel;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (theLevel.isStart)
        {
            thePlayer.Jump();
        }
        else if (!theLevel.isStart)
        {
            theLevel.StartGame();
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {

    }
}
