using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Terminal Program Code
/// </summary>
public class Program
{
    /// <summary>
    /// The main logic for the game
    /// </summary>

	enum CharacterClass {
		Cyborg,
		Technomage,
		WarpThief
	}

	string ReturnCharacterName(CharacterClass chosenClass) {
		switch (chosenClass) {
		case CharacterClass.Cyborg:
			return "Cyborg";
		case CharacterClass.Technomage:
			return "Technomage";
		case CharacterClass.WarpThief:
			return "Warp Thief";
		default:
			return null;
		}
	}

	bool BuildPlayer()
	{
		Terminal.WriteLine("What is your name?");
		string name = Terminal.ReadLine().ToLower();
		
		// Check for empty string.
		if (string.IsNullOrEmpty(name)) {
			Console.WriteLine("Why didn't you enter a name :/ Please do enter a name:");
			name = Console.ReadLine().ToLower();
		}
		// Return char and concat substring.
		name = char.ToUpper(name[0]) + name.Substring(1);
		
		Terminal.WriteLine("\n");
		Terminal.WriteLine("Nice to meet you, " + name);
		Terminal.WriteLine("\n");
		Terminal.WriteLine("What class number out of the below do you want to be:");
		Terminal.WriteLine("1: Cyborg");
		Terminal.WriteLine("2: Technomage");
		Terminal.WriteLine("3: Warp Thief");
		
		int cChoice;
		if (!int.TryParse(Terminal.ReadLine().Trim(), out cChoice))
		{
			Terminal.WriteLine("That is not a valid selection.");
			return false;
		}
		CharacterClass chosenClass;
		if (cChoice == 1) {
			chosenClass = CharacterClass.Cyborg;
		} else if (cChoice == 2) { 
			chosenClass = CharacterClass.Technomage;
		} else if (cChoice == 3) { 
			chosenClass = CharacterClass.WarpThief;
		} else {
			Terminal.WriteLine("That is not a valid selection.");
			return false;
		}
		
		Terminal.WriteLine("You have selected a " + ReturnCharacterName(chosenClass));
		Terminal.WriteLine("\n");
		int dexterity = Terminal.Random(5, 12);
		int stamina = Terminal.Random(5, 12);
		int energy = Terminal.Random(5, 12);
		int strength = Terminal.Random(5, 12);
		this.SetPlayerData(name, chosenClass, dexterity, strength, stamina, energy);
		return true;
	}

	void SetPlayerData(string name, CharacterClass chosenClass, int dexterity, int strength, int stamina, int energy)
	{
		this._player = new Character();
		this._player.characterType = characterType;
		this._player.xp = 0;
		this._player.name = name;
		this._player.dexterity = dexterity;
		this._player.strength = strength;
		this._player.stamina = stamina;
		this._player.energy = energy;
		this._player.minDamage = 1;
		this._player.maxDamage = 5;
	}

    public void Run()
    {
        Terminal.WriteLine("Welcome to Cyber Arena 20XX!");
        Terminal.WriteLine("\n");
			BuildPlayer();
    }
}
