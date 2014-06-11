using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	string stringToEdit="";	//Variable pour le texte saisie sur le clavier
	public string textADeviner; //Variable qui contient le texte a deviner

	public string NomDuNiveauSuivant=""; //Mettre le nom du niveau suivant

	public bool estCorrecte=false;	//Variable pour afficher les différentes fenetre succé
	public bool popUp=false;		//ou echec
	public int tailleLabelFont;
	public int tailleFieldFont;
	public GUISkin guiSkin;		//Déclaration de notre guiskin	

	// Use this for initialization
	void Start () {
		stringToEdit = textADeviner.Substring (0,1);
	}
	
	// Update is called once per frame
	void Update () {
	
		/* -- Dans cette partie nous allons tout d'abord comparer le texte saisie 
		 * --la premiere chose a faire c'est nous allons comparer les longeurs des textes
		 * si ils sont égaux, donc nous comparerons ensuite les termes, s'il sont correcte
		 * on va passer au niveau suivant, sinon une fenetre sera affiché pour lui
		 * demander de recommencer

		*/
		if (stringToEdit.Length == textADeviner.Length) {

			string trimString = stringToEdit.Trim().ToUpper(); //Enlever les espace et mettre en maj
			string trimADeviner	=textADeviner.Trim().ToUpper(); //pour mieux comparer

			if (trimString == trimADeviner) {				
			
					estCorrecte=true;
					Debug.Log("Bravo");
					popUp=false;	
					Application.LoadLevel(NomDuNiveauSuivant);
	
				}
			else
				{
					estCorrecte=false;
					Debug.Log("Reessayer");
					popUp=true;
				}
				
			}
	}
		

	void OnMouseDown()
	{
		Debug.Log ("test");
		TouchScreenKeyboard.Open ("", TouchScreenKeyboardType.Default, false, false, true);
		//tester l'ouverture du clavier 

	}

	void OnGUI()
	{
		/*
		 * Interface de l'utilisateur 
		 * */
		guiSkin.label.fontSize =  tailleLabelFont;
		guiSkin.textField.fontSize = tailleFieldFont;

		GUI.skin = guiSkin; // GUI.skin permet d'appliquer notre gui skin sur la scéne

		stringToEdit = GUI.TextField(new Rect(170, 1060, 300, 50), stringToEdit, 25); //Zone de saisie du texte
	
		Debug.Log (stringToEdit);

		if (!estCorrecte && popUp) {// Si ce les termes ne sont pas correcte il affiche un bouton de rejouer

			if(	GUI.Button(new Rect(Screen.width*0.23f,Screen.height*0.05f,350,100),"INCORRECT. PLEASE TRY AGAIN"))
			{
				popUp=false;
				estCorrecte=false;
				stringToEdit="";
			}
				}

		}
}
