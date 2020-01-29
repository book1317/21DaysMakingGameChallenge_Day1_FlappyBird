using UnityEngine;
using UnityEngine.EventSystems;

public class TapScreenController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerController thePlayer;
    [SerializeField] LevelController theLevel;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (theLevel.gameState == LevelController.GameState.Playing)
        {
            thePlayer.Jump();
        }
        else if (theLevel.gameState == LevelController.GameState.MainMenu)
        {
            theLevel.StartGame();
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {

    }
}
