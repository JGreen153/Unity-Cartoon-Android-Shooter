using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    public enum SHIP
    {
        FIRST,
        SECOND,
        THIRD
    };

    private SHIP ship = SHIP.FIRST;

    [SerializeField]
    private Sprite firstShip, secondShip, thirdShip;

    [SerializeField]
    private Button leftButton, rightButton;

    public void ChangeToLeftCharacter()
    {
        Sprite playerShip = GetComponent<SpriteRenderer>().sprite;

        switch (ship)
        {
            case SHIP.SECOND:
                playerShip = firstShip;
                GetComponent<SpriteRenderer>().sprite = playerShip;
                ship = SHIP.FIRST;
                break;
            case SHIP.THIRD:
                playerShip = secondShip;
                GetComponent<SpriteRenderer>().sprite = playerShip;
                ship = SHIP.SECOND;
                break;
        }
    }

    public void ChangeToRightCharacter()
    {
        Sprite playerShip = GetComponent<SpriteRenderer>().sprite;

        switch (ship)
        {
            case SHIP.FIRST:
                playerShip = secondShip;
                GetComponent<SpriteRenderer>().sprite = playerShip;
                ship = SHIP.SECOND;
                break;
            case SHIP.SECOND:
                playerShip = thirdShip;
                GetComponent<SpriteRenderer>().sprite = playerShip;
                ship = SHIP.THIRD;
                break;
        }
    }

}