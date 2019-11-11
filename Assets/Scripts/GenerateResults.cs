using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class GenerateResults : MonoBehaviour {

    public GameObject resultsObject;
    public GameObject playerNameObject;
    public GameObject ethosObject;
    public GameObject civicObject;
    public GameObject traitContainer;
    public GameObject traitObject;

    public GameObject resultsWindow;
    public InputField textInput;
    public Transform canvas;
    public Transform resultsTransform;
    public List<string> playerNames;
    public List<string> addedPlayerNames;
    public List<Ethos> ethosList;
    public List<Civic> civicList;
    public List<Traits> traitList;
    public int ethosID;
    public int civicID;
    public int firstTraitID;
    public int secondTraitID;

    public ToolTip toolTip;

    public List<int> genocidalIDs;

    GameObject tempTraitContainer;
    GameObject tempEthosObj;
    GameObject tempCivicObj;
    GameObject tempResultsObj;
    GameObject tempNameObj;
    Ethos tempEthos;
    int aTrait, bTrait;

    // Use this for initialization
    void Start () {

        if (resultsWindow.activeInHierarchy) {

            resultsWindow.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //function used to start the random generation process based on list of names that have been input
    public void GenerateButton() {

        if (textInput.GetComponent<InputField>().text.Length != 0) {

            playerNames = new List<string>();
            playerNames.AddRange(textInput.GetComponent<InputField>().text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));

            if (resultsTransform.childCount > 0)
            {
                ClearChildren();
            }

            RaceGeneration(playerNames);

            //playerNames = new List<string>();
            //playerNames.AddRange(textInput.GetComponent<InputField>().text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));

            //if (!resultsWindow.activeInHierarchy) {

            //    resultsWindow.SetActive(true);

            //}

            //if (resultsTransform.childCount > 0)
            //{
            //    ClearChildren();
            //}

            //foreach (var name in playerNames)
            //{

            //    tempResultsObj = Instantiate(resultsObject);
            //    tempResultsObj.transform.SetParent(resultsTransform, false);

            //    tempNameObj = Instantiate(playerNameObject);
            //    tempNameObj.GetComponentInChildren<Text>().text = name.ToString();
            //    tempNameObj.transform.SetParent(tempResultsObj.transform, false);

            //    tempEthos = RandomGeneration(ethosList);

            //    civicID = RandomGeneration(tempEthos.civicIDs);
            //    Debug.Log("Civic ID: " + civicID);

            //    GetTraitID(tempEthos.traitIDs, out aTrait, out bTrait);

            //    tempEthosObj = Instantiate(ethosObject);
            //    tempEthosObj.GetComponentInChildren<GovernmentHolderScript>().gov = tempEthos;
            //    tempEthosObj.transform.SetParent(tempResultsObj.transform, false);


            //    tempCivicObj = Instantiate(civicObject);
            //    tempCivicObj.GetComponentInChildren<GovernmentHolderScript>().gov = SelectCivic(civicID);
            //    tempCivicObj.transform.SetParent(tempResultsObj.transform, false);

            //    tempTraitContainer = Instantiate(traitContainer);
            //    tempTraitContainer.transform.SetParent(tempResultsObj.transform, false);

            //    CreateTrait(aTrait);
            //    CreateTrait(bTrait);

            //}
        }
        
    }

    //function used if names are added to the list after the first list of results has already been generated
    public void GenerateAdditional()
    {
        List<string> tempPlayerNames = new List<string>(); ;

        if (textInput.GetComponent<InputField>().text.Length != 0)
        {
            addedPlayerNames = new List<string>();
            addedPlayerNames.AddRange(textInput.GetComponent<InputField>().text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));

            foreach (string name in addedPlayerNames)
            {
                if (!playerNames.Contains(name)) {

                    tempPlayerNames.Add(name);

                }
            }
        }

        playerNames = addedPlayerNames;

        RaceGeneration(tempPlayerNames);
    }

    //function used to randomly select ethos, civics and negative traits
    private void RaceGeneration(List<string> newNames) {

        if (!resultsWindow.activeInHierarchy)
        {

            resultsWindow.SetActive(true);

        }

        foreach (var name in newNames)
        {

            tempResultsObj = Instantiate(resultsObject);
            tempResultsObj.transform.SetParent(resultsTransform, false);

            tempNameObj = Instantiate(playerNameObject);
            tempNameObj.GetComponentInChildren<Text>().text = name.ToString();
            tempNameObj.transform.SetParent(tempResultsObj.transform, false);

            tempEthos = RandomGeneration(ethosList);

            civicID = RandomGeneration(tempEthos.civicIDs);
            Debug.Log("Civic ID: " + civicID);

            GetTraitID(tempEthos.traitIDs, out aTrait, out bTrait);

            tempEthosObj = Instantiate(ethosObject);
            tempEthosObj.GetComponentInChildren<GovernmentHolderScript>().gov = tempEthos;
            tempEthosObj.transform.SetParent(tempResultsObj.transform, false);


            tempCivicObj = Instantiate(civicObject);
            tempCivicObj.GetComponentInChildren<GovernmentHolderScript>().gov = SelectCivic(civicID);
            tempCivicObj.transform.SetParent(tempResultsObj.transform, false);

            tempTraitContainer = Instantiate(traitContainer);
            tempTraitContainer.transform.SetParent(tempResultsObj.transform, false);

            CreateTrait(aTrait);
            CreateTrait(bTrait);

        }

    }

    private void CreateTrait(int id) {

        GameObject tempTraitObj = Instantiate(traitObject);
        tempTraitObj.GetComponentInChildren<GovernmentHolderScript>().gov = SelectTrait(id);
        tempTraitObj.transform.SetParent(tempTraitContainer.transform, false);

    }

    //private void GenocidalCheck(int civicID, Ethos tempEthos)
    //{
    //    if (genocidalIDs.Contains(civicID)) {

    //        while (genocidalIDs.Contains(civicID)) {

    //            civicID = RandomGeneration(tempEthos.civicIDs);
    //            Debug.Log("Rerolled civic.");
    //            Debug.Log("Civic ID: " + civicID);
    //        }
    //    }
    //}

    //clears the UI list
    void ClearChildren() {

        List<GameObject> childs = new List<GameObject>();

        foreach (Transform child in resultsTransform)
        {
            childs.Add(child.gameObject);
        }

        foreach (GameObject result in childs)
        {
            Destroy(result);
        }

    }

    //random generation function that has an unspecified/generic return type and input List type
    //return type and input List type is specified when a specified list type is given to this function
    private Item RandomGeneration<Item>(List<Item> picked) {

        return picked[UnityEngine.Random.Range(0, picked.Count)];

    }

    private Civic SelectCivic(int id) {

        Civic selectedCivic = null;

        foreach (var civic in civicList)
        {
            if (civic.id == id) {
                selectedCivic = civic;
                break;
            }
        }

        return selectedCivic;

    }

    //function to generate 2 unique traits based on their ID's
    private void GetTraitID(List<int> ids, out int firstID, out int secondID) {

        int a, b;
        a = UnityEngine.Random.Range(0, ids.Count);
        b = UnityEngine.Random.Range(0, ids.Count);
        if (b == a)
        {
            while (b == a)
            {
                b = UnityEngine.Random.Range(1, ids.Count);
            }
        }

        firstID = ids[a];
        secondID = ids[b];
    }

    private Traits SelectTrait(int id)
    {

        Traits selectedTrait = null;

        foreach (var trait in traitList)
        {
            if (trait.id == id)
            {
                selectedTrait = trait;
                break;
            }
        }

        return selectedTrait;

    }
}
