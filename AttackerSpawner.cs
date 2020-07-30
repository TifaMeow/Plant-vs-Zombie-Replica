using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] public float minSpawsnDelay = 50f;
    [SerializeField] public float maxSpawnDelay = 100f;
    [SerializeField] public Attacker[] attackerPrefabArray;


    IEnumerator Start() {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawsnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
    private void SpawnAttacker()
    {
        if (attackerPrefabArray.Length > 1) {
            int randomIndex = Random.Range(0, 5);
            int attackerIndex = randomIndex <= 2 ? 0 : 1;
            Spawn(attackerPrefabArray[attackerIndex]);
        }
        else
        {
            Spawn(attackerPrefabArray[0]);
        }
        
       
    }

    private void Spawn(Attacker myAttacker) {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning() {
        spawn = false;
    }
}
