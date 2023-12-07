using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : BaseWeapon
{
    [SerializeField] private float spinDuration = 0.5f;
    public override void AttackReleased(float timeHeld)
    {
        if (timeHeld >= 3f)
        {
            StartCoroutine(SpinAttack());
        }
        else
        {
            StartCoroutine(NormalAttack());
        }
    }

    public override void Equip(WeaponData character)
    {
        base.Equip(character);
    }

    private IEnumerator HeavyAttack()
    {
        animator.speed = 3f;
        for(int i = 0; i < 3; i++)
        {
            Debug.Log("Heavy Attack");
            animator.Play("WeaponSlash", -1, 0f);
            yield return new WaitForSeconds(.5f);
        }

        animator.speed = 1f;
        yield return null;
    }

    private IEnumerator NormalAttack()
    {
        animator.speed = 1f;
        Debug.Log("Normal Attack");
        animator.Play("WeaponSlash");
        yield return null;
    }

    private IEnumerator SpinAttack()
    {
        animator.speed = 0.5f;

        Transform playerModel = player.GetChild(0);
        float time = 0f;
        animator.Play("WeaponSlash", -1, 0f);

        while (time < spinDuration)
        {
            time += Time.deltaTime;
            playerModel.localRotation = Quaternion.Euler(
                0, Mathf.Lerp(0f, -360f, time/spinDuration), 0f);
            Debug.Log("Heavy Attack");
            yield return new WaitForEndOfFrame();
        }

        animator.speed = 1f;
        yield return null;
    }
}
