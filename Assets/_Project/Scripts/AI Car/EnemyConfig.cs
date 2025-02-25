using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Scriptable Objects/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{

    public int score;
    public int health;
    public int damage;
    public float speed;
}
