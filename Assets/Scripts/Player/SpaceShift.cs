using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Persona", menuName = "Emote/Head" )]
public class SpaceShift : ScriptableObject
{
    public GameObject charecter;
    public GameObject Weapon;
    public int attack;
    public float moveSpeed;
    public float jump;
    public int health;
    public float minRange;
    public float maxRange;

	public string collisionLayer;

    public Material background;

	public EnemyAttackRotation enemy;
    public EnemyAttackRotation enemy2;
    public Sprite uiImage;
	
	public Color colo;

    public Color vision;

    public Transform rotation;
    public Transform scale;

}
