using UnityEngine;

public class Character
{
	CharacterClass chosenClass;
	int xp;
	string name;
	int dexterity;
	int energy;
	int stamina;
	int strength;
	int minDamage = 1;
	int maxDamage = 8;
	int damageTaken;

	int level = 1 + (this.xp / 100);

	int maxHealth = this.level + this.stamina;

	//value between a minimum float and maximum float? Mathf.Clamp?
	//float dodgeChance = Mathf.Clamp((0.05f + (this.level - 1) * 0.02f), 0.0f, 0.75f);

	int damageBonus {
		int classStat = 0;
		switch (this.chosenClass) {
			case CharacterClass.Cyborg:
				classStat = this.strength;
				break;
			case CharacterClass.Technomage:
				classStat = this.energy;
				break;
			case CharacterClass.WarpThief:
				classStat = this.dexterity;
				break;
		} return classStat * this.level; //WHY ISN'T THIS WORKING
	}

	bool isDead = this.damageTaken >= this.maxHealth;

	void ApplyDamage(int damageAmount) {
		this.damageTaken += damageAmount;
	}

	void GiveXp(int xpAmount) {
		this.xp += xpAmount;
	}

	//Parse error?
	int RollDamage() = Terminal.Random(this.minDamage, (this.maxDamage + 1)) + this.damageBonus;
}

/*Questions to ask Tutor:
 * Am I meant to be using "this.whatever" because you haven't taught it. Good luck explaining it to the class, it took me a while to understand it haha.
 * Am I meant to be using Mathf.Clamp for dodgeChance? It seems like the only option after some research on the internet.
 * Am I meant to be using a get or set for some of these, Unity asks for one of the two but we haven't learnt these.
 * ERRORS (unfortunately) especially lines 35 and 49.
 */