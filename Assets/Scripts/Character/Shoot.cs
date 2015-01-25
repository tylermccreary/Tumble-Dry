using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
		private bool shoot;
		public GameObject elasticPrefab;
		private static int elasticNum;
		public int maxElastic = 10;
		public GameObject shootPoint;
		private const string SHOOT_BUTTON = "Fire1";
		private const string FOREGROUND = "Foreground";
	
		void Start ()
		{
				elasticNum = 0;
		}

		void Update ()
		{
				shoot = Input.GetButtonDown (SHOOT_BUTTON);
				if (shoot) {
						shootElastic ();
				}
		}

		void shootElastic ()
		{
				if (elasticNum < maxElastic) {
						GameObject elastic = (GameObject)Instantiate (elasticPrefab, new Vector3 (shootPoint.transform.position.x, shootPoint.transform.position.y, 0), Quaternion.identity);
						elastic.renderer.sortingLayerName = FOREGROUND;
						elasticNum += 1;
				}
		}

		public static void changeElasticNum (int amount)
		{
				elasticNum = elasticNum + amount;
		}

		public static int getElasticNum ()
		{
				return elasticNum;
		}
}
