using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnHealer;
    public GameObject spawnBoss;
    public GameObject spawnFollower;
    public GameObject spawnCaster;

    public Follower follower;
    public Healer healer;
    public Boss boss;
    public Caster caster;

    public int numberOfWaves;
    public int currentWaveNumber;

    float nextHealerSpawnTime;
    float nextBossSpawnTime;
    float nextFollowerSpawnTime;
    float nextCasterSpawnTime;

    float waitingTimeBetweenWaves;

    int numberOfHealersRemainingToSpawn;
    int numberOfFollowersRemainingToSpawn;
    int numberOfBossRemainingToSpawn;
    int numberOfCasterRemainingToSpawn;

    int numberOfEnemiesRemainingAlive;

    public Wave[] waves;
    Wave currentWave;

    void Start()
    {

        NextWave();
    }

    void NextWave()
    {

        currentWaveNumber++;
        print("Wave : " + currentWaveNumber);
        if (currentWaveNumber - 1 < waves.Length)
        {

            currentWave = waves[currentWaveNumber - 1];
            numberOfHealersRemainingToSpawn = currentWave.healerCount;
            numberOfFollowersRemainingToSpawn = currentWave.followerCount;
            numberOfBossRemainingToSpawn = currentWave.bossCount;
            numberOfCasterRemainingToSpawn = currentWave.casterCount;
            numberOfEnemiesRemainingAlive = numberOfBossRemainingToSpawn + numberOfFollowersRemainingToSpawn + numberOfHealersRemainingToSpawn + numberOfCasterRemainingToSpawn;
        }
    }

    void Update()
    {

        if (numberOfHealersRemainingToSpawn > 0 && Time.time > nextHealerSpawnTime)
        {

            numberOfHealersRemainingToSpawn--;
            print(numberOfHealersRemainingToSpawn);
            nextHealerSpawnTime = Time.time + currentWave.timeBetweenHealerSpawns;

            Healer spawnedHealer = Instantiate(healer, spawnHealer.transform.position, Quaternion.identity) as Healer;
            spawnedHealer.OnDeath += OnEnemyDeath;
        }

        if (numberOfFollowersRemainingToSpawn > 0 && Time.time > nextFollowerSpawnTime)
        {

            numberOfFollowersRemainingToSpawn--;
            print(numberOfFollowersRemainingToSpawn);
            nextFollowerSpawnTime = Time.time + currentWave.timeBetweenFollowerSpawns;

            Follower spawnedFollower = Instantiate(follower, spawnFollower.transform.position, Quaternion.identity) as Follower;
            spawnedFollower.OnDeath += OnEnemyDeath;
        }

        if (numberOfBossRemainingToSpawn > 0 && Time.time > nextBossSpawnTime)
        {

            numberOfBossRemainingToSpawn--;
            print(numberOfBossRemainingToSpawn);
            nextBossSpawnTime = Time.time + currentWave.timeBetweenBossSpawns;

            Boss spawnedBoss = Instantiate(boss, spawnBoss.transform.position, Quaternion.identity) as Boss;
            spawnedBoss.OnDeath += OnEnemyDeath;
        }

        if (numberOfCasterRemainingToSpawn > 0 && Time.time > nextCasterSpawnTime)
        {

            numberOfCasterRemainingToSpawn--;
            print(numberOfCasterRemainingToSpawn);
            nextCasterSpawnTime = Time.time + currentWave.timeBetweenCasterSpawns;

            Caster spawnedCaster = Instantiate(caster, spawnCaster.transform.position, Quaternion.identity) as Caster;
            spawnedCaster.OnDeath += OnEnemyDeath;

        }
    }

    void OnEnemyDeath()

    {

        numberOfEnemiesRemainingAlive--;

        if (numberOfEnemiesRemainingAlive == 0)
        {

            NextWave();
        }
    }

    [System.Serializable]
    public class Wave
    {

        public int followerCount;
        public int healerCount;
        public int bossCount;
        public int casterCount;

        public float timeBetweenHealerSpawns;
        public float timeBetweenBossSpawns;
        public float timeBetweenFollowerSpawns;
        public float timeBetweenCasterSpawns;
    }
}
