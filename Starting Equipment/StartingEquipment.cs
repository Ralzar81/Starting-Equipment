using DaggerfallConnect;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.MagicAndEffects;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Game.Utility.ModSupport.ModSettings;
using UnityEngine;
using DaggerfallWorkshop;
using DaggerfallConnect.Arena2;
using DaggerfallWorkshop.Utility;
using DaggerfallWorkshop.Game.MagicAndEffects.MagicEffects;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.UserInterfaceWindows;
using DaggerfallWorkshop.Game.Utility;
using DaggerfallWorkshop.Game.Serialization;
using System;
using System.Collections.Generic;
using DaggerfallWorkshop.Game.MagicAndEffects;


namespace StartingEquipment
{

    public class StartingEquipment : MonoBehaviour
    {


        static Mod mod;

        //[Invoke(StateManager.StateTypes.Game, 0)]
        //public static void Init(InitParams initParams)
        //{
        //    mod = initParams.Mod;
        //    var go = new GameObject(mod.Title);
        //    go.AddComponent<StartingEquipment>();
        //    StartGameBehaviour.OnStartGame += StartingEquipment_OnStartGame;
        //}


        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            var go = new GameObject(mod.Title);
            go.AddComponent<StartingEquipment>();
            StartGameBehaviour.OnStartGame += StartingEquipment_OnStartGame;

        }




        void Awake()
        {
            mod.IsReady = true;
            Debug.Log("Starting Equipment Ready");
        }


        


        static void StartingEquipment_OnStartGame(object sender, EventArgs e)
        {
            PlayerEntity playerEntity = GameManager.Instance.PlayerEntity;
            Debug.Log("Starting Equipment: Assigning Equipment");
            ItemAssigner(playerEntity.Career.PrimarySkill1);
            ItemAssigner(playerEntity.Career.PrimarySkill2);
            ItemAssigner(playerEntity.Career.PrimarySkill3);

            ItemAssigner(playerEntity.Career.MajorSkill1);
            ItemAssigner(playerEntity.Career.MajorSkill2);
            ItemAssigner(playerEntity.Career.MajorSkill3);
            Debug.Log("Starting Equipment: Assigning Equipment Finished");
            //if (playerEntity.Career.PrimarySkill1 == DFCareer.Skills.BluntWeapon || playerEntity.Career.PrimarySkill2 == DFCareer.Skills.BluntWeapon || playerEntity.Career.PrimarySkill3 == DFCareer.Skills.BluntWeapon)
            //{
            //Debug.Log("Starting Equipment: Assigning Equipment");
            //DaggerfallUnityItem new_item = ItemBuilder.CreateWeapon(Weapons.Mace, WeaponMaterialTypes.Iron);
            //playerEntity.Items.AddItem(new_item);
            //Debug.Log("Starting Equipment: Assigning Equipment Finished");
            //}
        }

        static void ItemAssigner(DFCareer.Skills skill)
        {
            DaggerfallUnityItem item = null;
            PlayerEntity playerEntity = GameManager.Instance.PlayerEntity;
            Genders gender = playerEntity.Gender;
            Races race = playerEntity.Race;

            switch (skill)
            {
                case DFCareer.Skills.Archery:
                    item = ItemBuilder.CreateWeapon(Weapons.Short_Bow, WeaponMaterialTypes.Iron);
                    break;
                case DFCareer.Skills.Axe:
                    item = ItemBuilder.CreateWeapon(Weapons.Battle_Axe, WeaponMaterialTypes.Iron);
                    break;
                case DFCareer.Skills.Backstabbing:
                    item = ItemBuilder.CreateArmor(gender, race, Armor.Right_Pauldron, ArmorMaterialTypes.Leather);
                    break;
                case DFCareer.Skills.BluntWeapon:
                    item = ItemBuilder.CreateWeapon(Weapons.Mace, WeaponMaterialTypes.Iron);
                    break;
                case DFCareer.Skills.Centaurian:
                    item = ItemBuilder.CreateRandomIngredient(ItemGroups.PlantIngredients1);
                    break;
                case DFCareer.Skills.Climbing:
                    item = ItemBuilder.CreateArmor(gender, race, Armor.Helm, ArmorMaterialTypes.Leather, -1);
                    break;
                case DFCareer.Skills.CriticalStrike:
                    item = ItemBuilder.CreateArmor(gender, race, Armor.Right_Pauldron, ArmorMaterialTypes.Leather);
                    break;
                case DFCareer.Skills.Daedric:
                    item = ItemBuilder.CreateRandomIngredient(ItemGroups.CreatureIngredients1);
                    break;
                case DFCareer.Skills.Dodging:
                    if (gender == (int)Genders.Male) { item = ItemBuilder.CreateMensClothing(MensClothing.Casual_cloak, race); }
                    else { item = ItemBuilder.CreateWomensClothing(WomensClothing.Casual_cloak, race); }
                    break;
                case DFCareer.Skills.Dragonish:
                    item = ItemBuilder.CreateRandomIngredient(ItemGroups.CreatureIngredients1);
                    break;
                case DFCareer.Skills.Etiquette:
                    if (gender == (int)Genders.Male) { item = ItemBuilder.CreateMensClothing(MensClothing.Formal_tunic, race); }
                    else { item = ItemBuilder.CreateWomensClothing(WomensClothing.Evening_gown, race); }
                    break;
                case DFCareer.Skills.Giantish:
                    item = ItemBuilder.CreateRandomIngredient(ItemGroups.CreatureIngredients1);
                    break;
                case DFCareer.Skills.HandToHand:
                    item = ItemBuilder.CreateArmor(gender, race, Armor.Gauntlets, ArmorMaterialTypes.Leather);
                    break;
                case DFCareer.Skills.Harpy:
                    item = ItemBuilder.CreateRandomIngredient(ItemGroups.CreatureIngredients1);
                    break;
                case DFCareer.Skills.Impish:
                    item = ItemBuilder.CreateRandomIngredient(ItemGroups.CreatureIngredients1);
                    break;
                case DFCareer.Skills.Jumping:
                    if (gender == (int)Genders.Male) { item = ItemBuilder.CreateMensClothing(MensClothing.Breeches, race); }
                    else { item = ItemBuilder.CreateWomensClothing(WomensClothing.Casual_pants, race); }
                    break;
                case DFCareer.Skills.Lockpicking:
                    item = ItemBuilder.CreateRandomPotion();
                    break;
                case DFCareer.Skills.LongBlade:
                    item = ItemBuilder.CreateWeapon(Weapons.Longsword, WeaponMaterialTypes.Iron);
                    break;
                case DFCareer.Skills.Medical:
                    item = ItemBuilder.CreateItem(ItemGroups.UselessItems2, 249);
                    break;
                case DFCareer.Skills.Mercantile:
                    item = ItemBuilder.CreateGoldPieces(UnityEngine.Random.Range(10, 500));
                    break;
                case DFCareer.Skills.Nymph:
                    item = ItemBuilder.CreateRandomIngredient(ItemGroups.PlantIngredients1);
                    break;
                case DFCareer.Skills.Orcish:
                    item = ItemBuilder.CreateRandomIngredient(ItemGroups.CreatureIngredients1);
                    break;
                case DFCareer.Skills.Pickpocket:
                    item = ItemBuilder.CreateGoldPieces(UnityEngine.Random.Range(10, 50));
                    break;
                case DFCareer.Skills.Running:
                    if (gender == (int)Genders.Male) { item = ItemBuilder.CreateMensClothing(MensClothing.Shoes, race); }
                    else { item = ItemBuilder.CreateWomensClothing(WomensClothing.Shoes, race); }
                    break;
                case DFCareer.Skills.ShortBlade:
                    item = ItemBuilder.CreateWeapon(Weapons.Dagger, WeaponMaterialTypes.Iron);
                    break;
                case DFCareer.Skills.Spriggan:
                    item = ItemBuilder.CreateRandomIngredient(ItemGroups.PlantIngredients1);
                    break;
                case DFCareer.Skills.Stealth:
                    if (gender == (int)Genders.Male) { item = ItemBuilder.CreateMensClothing(MensClothing.Khajiit_suit, race); }
                    else { item = ItemBuilder.CreateWomensClothing(WomensClothing.Khajiit_suit, race); }
                    break;
                case DFCareer.Skills.Streetwise:
                    item = ItemBuilder.CreateArmor(gender, race, Armor.Greaves, ArmorMaterialTypes.Leather);
                    break;
                case DFCareer.Skills.Swimming:
                    if (gender == (int)Genders.Male) { item = ItemBuilder.CreateMensClothing(MensClothing.Loincloth, race); }
                    else { item = ItemBuilder.CreateWomensClothing(WomensClothing.Loincloth, race); }
                    break;
            }
            playerEntity.Items.AddItem(item);
        }








        //void Start()
        //{
        //    StartGameBehaviour.OnNewGame += () =>
        //    {


        //        //if (playerEntity.Career.PrimarySkill1 == DFCareer.Skills.BluntWeapon || playerEntity.Career.PrimarySkill2 == DFCareer.Skills.BluntWeapon || playerEntity.Career.PrimarySkill3 == DFCareer.Skills.BluntWeapon)
        //        //{
        //        Debug.Log("Starting Equipment: Assigning Equipment");
        //        DaggerfallUnityItem new_item = ItemBuilder.CreateWeapon(Weapons.Mace, WeaponMaterialTypes.Daedric);
        //            playerEntity.Items.AddItem(new_item);
        //        Debug.Log("Starting Equipment: Assigning Equipment Finished");
        //        //}


        //    };


        //            //for (int i = 0; i < GameManager.Instance.PlayerEntity.Items.Count; i++)
        //            //{
        //            //    DaggerfallUnityItem item = GameManager.Instance.PlayerEntity.Items.GetItem(i);

        //            //if (item.nativeMaterialValue == (int)WeaponMaterialTypes.Ebony && item.TemplateIndex == (int)Weapons.Dagger)
        //            //{
        //            //    GameManager.Instance.PlayerEntity.Items.RemoveItem(item);
        //            //}

        //            //    GameManager.Instance.PlayerEntity.Items.RemoveItem(item);
        //            //}




        //            //DaggerfallUnityItem new_item = ItemBuilder.CreateArmor(playerEntity.Gender, playerEntity.Race, Armor.Boots, ArmorMaterialTypes.Adamantium);
        //            //playerEntity.Items.AddItem(new_item);
        //            //new_item = ItemBuilder.CreateWeapon(Weapons.Dagger, WeaponMaterialTypes.Silver);
        //            //playerEntity.Items.AddItem(new_item);
        //    };
        //}


        //protected static void StartingEquipment_OnStartGame(object sender, EventArgs e)
        //{
        //    Debug.Log("Starting Equipment: OnStartGame");
        //    for (int i = 0; i < GameManager.Instance.PlayerEntity.Items.Count; i++)
        //    {
        //        DaggerfallUnityItem item = GameManager.Instance.PlayerEntity.Items.GetItem(i);

        //        // Remove the ebony dagger, add a silver dagger.
        //        if (item.nativeMaterialValue == (int)WeaponMaterialTypes.Ebony &&
        //            item.TemplateIndex == (int)Weapons.Dagger)
        //        {
        //            GameManager.Instance.PlayerEntity.Items.RemoveItem(item);

        //            DaggerfallUnityItem new_item = ItemBuilder.CreateWeapon(Weapons.Dagger,
        //                                                                    WeaponMaterialTypes.Silver);

        //            GameManager.Instance.PlayerEntity.Items.AddItem(new_item);
        //        }
        //    }

        //}




    }
}
