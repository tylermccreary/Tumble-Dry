using UnityEngine;
using System.Collections;

public interface IEnemy {

	void takeDamage(int amount);

	void die();

	void doDamage();
}
