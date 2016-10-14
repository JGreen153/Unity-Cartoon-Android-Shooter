using UnityEngine;
using System.Collections;

public interface IPowerup {

    //interface that gives methods allowing the powerups to apply their effect and then destroy themselves
    void ApplyPowerup();
    void DestroyPowerup();

}