using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{

		public bool shoot;
		public GameObject elasticPic;
		static public int elasticNum;
		public bool facingRight;
		public int maxElastic = 10;
		public GameObject shootPoint;

		// Use this for initialization
		void Start ()
		{
				elasticNum = 0;
		}
	
		// Update is called once per frame
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
}
