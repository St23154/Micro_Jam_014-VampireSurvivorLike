using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TravisGameAssets
{
	
	public class HitImpactEffectsPreview : MonoBehaviour
	{

		//public Collider floorCollider;
		public Transform particlesPool;

		
		private GameObject[] hitEffects;

		private int hitIndex;
		
		void Start()
		{
			hitIndex = 0;		
			hitEffects = new GameObject[particlesPool.childCount];
			
			for(int i = 0; i < particlesPool.childCount; i++)
			{
				hitEffects[i] = particlesPool.GetChild(4).gameObject;
			}
		}

		void Update()
		{
			if(Input.GetMouseButtonDown(0))
			{
					RaycastHit hit = new RaycastHit();
					GameObject newHits = SpawnHit();
					newHits.transform.position = hit.point + newHits.transform.position;
					
			}
		}
			
	//Spawn Hit
		
		private GameObject SpawnHit()
		{
			GameObject spawnedHit = Instantiate(hitEffects[hitIndex]);
			spawnedHit.transform.LookAt(Camera.main.transform);
			return spawnedHit;
		}

	}
}