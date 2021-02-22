using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Wave Config")]
    public class WaveConfig : ScriptableObject
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private Path path;
        [SerializeField] private float timeBetweenSpawns = 0.5f;
        [SerializeField] private float spawnRandomFactor = 0.3f;
        [SerializeField] private int numberOfEnemies = 5;
        [SerializeField] private float moveSpeed = 1f;

        public GameObject Enemy => enemy;
        public Path Path => path;
        public float TimeBetweenSpawns => timeBetweenSpawns;
        public float SpawnRandomFactor => spawnRandomFactor;
        public int NumberOfEnemies => numberOfEnemies;
        public float MoveSpeed => moveSpeed;
    }
}
