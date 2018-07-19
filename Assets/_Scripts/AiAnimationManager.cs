using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAnimationManager : MonoBehaviour
{
    public AiMonsterController Controller;

    public GameObject hitBox;

    public void StartAttack() {
        hitBox.SetActive(true);
    }
    public void EndDamage() {
        hitBox.SetActive(false);
    }
    public void EndAttack()
    {
        Controller.SetAttackCooldown = Controller.AttackCooldown;
    }
}
