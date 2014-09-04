using UnityEngine;
using System.Collections;

public class ElasticCol : MonoBehaviour {

	public LayerMask enemyLayer;
	private string enemy;

	void Awake(){
		enemy = LayerMask.LayerToName(enemyLayer);
		}


	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.layer == 11 ){//LayerMask.NameToLayer(enemy)){
			LintExplosion.Instance.Explosion(col.gameObject.transform.position);
			Destroy(col.gameObject);
		}
		if (col.gameObject.layer != 8) {
						Destroy (gameObject);
						Shoot.elasticNum -= 1;
				}
	}
}
