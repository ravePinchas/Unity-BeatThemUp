using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDeleget : MonoBehaviour
{

    public GameObject left_Arm_Attack_Point, right_Arm_Attack_Point, left_Leg_Attack_Point, right_Leg_Attack_Point;


    public float stand_Up_Timer = 2f;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whoosh_Sound, fall_Sound, ground_hit_Sound, dead_Sound;

    private EnemyMovment enemy_Movment;

    private ShakeCamera shakeCamera;

    private void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemy_Movment = GetComponentInParent<EnemyMovment>();
        }

        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();

    }

    void LeftArmAttackOn()
    {
        left_Arm_Attack_Point.SetActive(true);
    }

    void LeftArmAttackOff()
    {
        if (left_Arm_Attack_Point.activeInHierarchy)
        {
            left_Arm_Attack_Point.SetActive(false);
        }
        
    }

    void RighttArmAttackOn()
    {
        right_Arm_Attack_Point.SetActive(true);
    }
    void RighttArmAttackOff()
    {
        if (right_Arm_Attack_Point.activeInHierarchy)
        {
            right_Arm_Attack_Point.SetActive(false);
        }
    }
    void LeftLegAttackOn()
    {
        left_Leg_Attack_Point.SetActive(true);
    }
    void LeftLegAttackOff()
    {
        if (left_Leg_Attack_Point.activeInHierarchy)
        {
            left_Leg_Attack_Point.SetActive(false);
        }
    }
    void RightLegAttackOn()
    {
        right_Leg_Attack_Point.SetActive(true);
    }

    void RightLegAttackOff()
    {
        if (right_Leg_Attack_Point.activeInHierarchy)
        {
            right_Leg_Attack_Point.SetActive(false);
        }
    }


    void TagLeft_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }

    void UnTagLeft_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void TagLeft_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }

    void UnTagLeft_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }


    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(stand_Up_Timer);
        animationScript.StandUp();
    }

    public void Attck_Fx_Sound()
    {
        audioSource.volume = 1f;
        audioSource.clip = whoosh_Sound;
        audioSource.Play();
    }

    void EnemyKnockDown()
    {
        audioSource.clip = fall_Sound;
        audioSource.Play();
    }

    void EnemyHitGround()
    {
        audioSource.clip = ground_hit_Sound;
        audioSource.Play();
    }

    void DisableMovment()
    {
        enemy_Movment.enabled = false;

        transform.parent.gameObject.layer = 0;
    }
    void EnableMovment()
    {
        enemy_Movment.enabled = true;

        transform.parent.gameObject.layer = 10;
    }

    void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    void CharacterDied()
    {
        Invoke("DeactivateGameObject", 2f);
    }
    void DeactivateGameObject()
    {

        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }
}
