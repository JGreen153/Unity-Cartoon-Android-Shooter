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

    [SerializeField]
    private Text lockedText;

    public static int characterSelected; 

    void Start()
    {
        characterSelected = 0;

        lockedText.text = "";
    }

    public void ChangeToLeftCharacter()
    {
        Sprite playerShip = GetComponent<SpriteRenderer>().sprite;

        switch (ship)
        {
            case SHIP.SECOND:

                lockedText.text = "";

                characterSelected = 0;

                playerShip = firstShip;
                GetComponent<SpriteRenderer>().sprite = playerShip;

                ship = SHIP.FIRST;
                break;
            case SHIP.THIRD:

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount > 2)
                {
                    characterSelected = 1;
                    lockedText.text = "";
                }

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

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount > 2)
                {
                    characterSelected = 1;
                    lockedText.text = "";
                }
                    playerShip = secondShip;
                    GetComponent<SpriteRenderer>().sprite = playerShip;

                    ship = SHIP.SECOND;
                break;
            case SHIP.SECOND:

                lockedText.text = "Locked";

                if (TrophyCount.trophyCount > 5)
                {
                    characterSelected = 2;
                    lockedText.text = "";
                }
                    playerShip = thirdShip;
                    GetComponent<SpriteRenderer>().sprite = playerShip;

                    ship = SHIP.THIRD;
                break;
        }
    }

}