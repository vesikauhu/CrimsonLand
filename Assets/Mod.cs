using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod : MonoBehaviour
{

    public enum ModType
    {
        Damage,
        Firerate,
        ClipSize,
    }

    public ModType _modtype;

    public void ModifyWeapon(Weapon weapon)
    {
        switch (_modtype)
        {
            case (ModType.Damage):
                weapon.damage *= 2;
                return;
            case (ModType.Firerate):
                weapon.firerate /= 2;
                return;
            case (ModType.ClipSize):
                weapon.clipSize *= 2;
                return;
        }
    }
}
