using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_1Spawner : MonoBehaviour {

	public Spell spell;
	public Spell_1 spell_1;
	private Transform ThisTransform;


	void Start () {

		ThisTransform = transform;
		spell = GetComponent<Spell>();
		
		Spell_1 newspell0 = Instantiate (spell_1, ThisTransform.position, Quaternion.identity);
		newspell0.Direction = new Vector2 (spell.Direction.x, spell.Direction.y);
		newspell0.spell = spell;
		newspell0.Speed += spell.SpeedUp;

		Spell_1 newspell1 = Instantiate (spell_1, ThisTransform.position, Quaternion.identity);
		newspell1.Direction = new Vector2 (-spell.Direction.x, -spell.Direction.y);
		newspell1.spell = spell;
		newspell1.Speed += spell.SpeedUp;

		Spell_1 newspell2 = Instantiate (spell_1, ThisTransform.position, Quaternion.identity);
		newspell2.Direction = new Vector2 (-spell.Direction.y, spell.Direction.x);
		newspell2.spell = spell;
		newspell2.Speed += spell.SpeedUp;

		Spell_1 newspell3 = Instantiate (spell_1, ThisTransform.position, Quaternion.identity);
		newspell3.Direction = new Vector2 (spell.Direction.y, -spell.Direction.x);
		newspell3.spell = spell;
		newspell3.Speed += spell.SpeedUp;

}

}