using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
		public bool shoot;
		public GameObject elasticPic;
		private static int elasticNum;
		public bool facingRight;
		public int maxElastic = 10;
		public GameObject shootPoint;
	
		void Start ()
		{
				elasticNum = 0;
		}

		void Update ()
		{
				shoot = Input.GetButtonDown ("Fire1");
				if (shoot) {
						shootElastic ();
				}
		}

		void shootElastic ()
		{
				if (elasticNum < maxElastic) {
						GameObject elastic = (GameObject)Instantiate (elasticPic, new Vector3 (shootPoint.transform.position.x, shootPoint.transform.position.y, 0), Quaternion.identity);
						elastic.renderer.sortingLayerName = "Foreground";
						elasticNum += 1;
				}
		}

		public static void changeElasticNum (int amount)
		{
				elasticNum = elasticNum + amount;
		}
}
