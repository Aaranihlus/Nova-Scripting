using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customisation : MonoBehaviour {

    public static Customisation instance;
    public GameObject Screen;
    public List<CustomisationOption> Options = new();

    public CustomisationOption OptionPrefab;

    public Transform OptionsContainer;

    public Transform CharacterModel;
    public Player Player;

    public Transform SkinOptionsContainer;
    public Transform HeadOptionsContainer;
    public Transform ShirtOptionsContainer;
    public Transform PantsOptionsContainer;
    public Transform BootsOptionsContainer;

    private void Awake() {
        instance = this;
    }

    public void SetupCustomisation (CustomisationOptionData[] CustomisationOptions) {
        foreach (CustomisationOptionData Data in CustomisationOptions) {

            CustomisationOption instance = null;

            switch (Data.type) {
                case "skin": instance = Instantiate(OptionPrefab, SkinOptionsContainer); break;
                case "head": instance = Instantiate(OptionPrefab, HeadOptionsContainer); break;
                case "shirt": instance = Instantiate(OptionPrefab, ShirtOptionsContainer); break;
                case "pants": instance = Instantiate(OptionPrefab, PantsOptionsContainer); break;
                case "boots": instance = Instantiate(OptionPrefab, BootsOptionsContainer); break;
            }

            instance.id = Data.id;
            instance.name = Data.name;
            instance.type = Data.type;
            instance.level = int.Parse(Data.level);
            instance.image.sprite = ItemManager.instance.GetSprite(instance.name);

            Options.Add(instance);

        }

        UpdateCharacterModel();
    }

    public void Equip(string name) {
        Debug.Log(name);
        UpdateCharacterModel();
    }

    public void UpdateCharacterModel() {

        switch (Player.data.char_skin) {
            case "head1": CharacterModel.Find("CHR1_Head").gameObject.SetActive(true); break;
            case "head2": CharacterModel.Find("CHR2_Head").gameObject.SetActive(true); break;
            case "head3": CharacterModel.Find("CHR3_Head").gameObject.SetActive(true); break;
            case "head4": CharacterModel.Find("CHR4_Head").gameObject.SetActive(true); break;
            case "head5": CharacterModel.Find("CHR5_Head").gameObject.SetActive(true); break;
            case "head6": CharacterModel.Find("CHR6_Head").gameObject.SetActive(true); break;
            case "head7": CharacterModel.Find("CHR7_Head").gameObject.SetActive(true); break;
            case "head8": CharacterModel.Find("CHR8_Head").gameObject.SetActive(true); break;
        }

        switch (Player.data.char_shirt) {
            case "tshirt1": CharacterModel.Find("tshirt1").gameObject.SetActive(true); break;
            case "tshirt2": CharacterModel.Find("tshirt2").gameObject.SetActive(true); break;
            case "tshirt3": CharacterModel.Find("tshirt3").gameObject.SetActive(true); break;
            case "tshirt4": CharacterModel.Find("tshirt4").gameObject.SetActive(true); break;
            case "jacket1": CharacterModel.Find("jacket1").gameObject.SetActive(true); break;
            case "jacket2": CharacterModel.Find("jacket2").gameObject.SetActive(true); break;
            case "jacket3": CharacterModel.Find("jacket3").gameObject.SetActive(true); break;
            case "jacket4": CharacterModel.Find("jacket4").gameObject.SetActive(true); break;
            case "bdu1": CharacterModel.Find("bdu1").gameObject.SetActive(true); break;
            case "bdu2": CharacterModel.Find("bdu2").gameObject.SetActive(true); break;
            case "bdu3": CharacterModel.Find("bdu3").gameObject.SetActive(true); break;
        }

    }

}

