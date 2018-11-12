using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyState", menuName = "Enemy/Head")]
public class EnemyAttackRotation : ScriptableObject {

    public GameObject charecter;
    public GameObject Weapon;
    public int attackMinDamage;
    public int attackMaxDamage;
    public float attackCooldown;
    public float moveSpeed;
    public float bulletSpeed;
    public float axeSpeed;

    public Transform rotation;
    public Transform scale;
    public int health;
    public float followDistance;
    public float fireDistance;
    public float stopDistance;
}
