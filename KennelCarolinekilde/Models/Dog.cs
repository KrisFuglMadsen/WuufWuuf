﻿using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KennelCarolinekilde.Models
{
    public class Dog
    {
        //----------------Fields-------------------------------------
        public string Name { get; set; }
        public string PedigreeNr { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Father { get; set; }
        public string  Mother { get; set; }
        public decimal HDIndex { get; set; }
        public string Sex { get; set; } = string.Empty;
        public string Color { get; set; }
        public bool Dead { get; set; }
        public bool BreedStatus { get; set; }
        public Owner Owner { get; set; } = new Owner();
        public string Image { get; set; }
        public string HD { get; set; }
        public string AD { get; set; }
        public string HZ { get; set; }
        public string SP { get; set; }

        public List<Title> Titles { get; set; } = new List<Title>();
        public List<DKK_Title> DKK_Titles { get; set; } = new List<DKK_Title>();

        //---------------------Constructor-----------------------

        public Dog() { }
        public Dog(string name, string pedigreeNr, DateOnly dateOfBirth, string father, string mother, decimal HDIndex, string sex, string color, bool alive, bool breedStatus, int ownerId, string image, string hd, string ad, string hz, string sp ) 
        {
            Name = name;
            PedigreeNr = pedigreeNr;
            DateOfBirth = dateOfBirth;
            Father = father;
            Mother = mother;
            this.HDIndex = HDIndex;
            Sex = sex;
            Color = color;
            Dead = alive;
            BreedStatus = breedStatus;
            Owner.OwnerId = ownerId;
            Image = image;
            HD = hd;
            AD = ad;
            HZ = hz;
            SP = sp;
        }

        //------------------------Methods-------------------------
       
        //TODO write the logic to UpdateDog
        public void UpdateDog(string name, string pedigreeNr, DateOnly dateOfBirth, string father, string mother, decimal HDIndex, string sex, string color, bool alive, bool breedStatus, int ownerId, string image, string hd, string ad, string hz, string sp)
        {
            Name = name;
            PedigreeNr = pedigreeNr;
            DateOfBirth = dateOfBirth;
            Father = father;
            Mother = mother;
            this.HDIndex = HDIndex;
            Sex = sex;
            Color = color;
            Dead = alive;
            BreedStatus = breedStatus;
            Owner.OwnerId = ownerId;
            Image = image;
            HD = hd;
            AD = ad;
            HZ = hz;
            SP = sp;
        }

        //TODO write the logic to UpdatTitles
        public void UpdateTiltes()
        {

        }

        //TODO write the logic to UpdateDKKTiltles
        public void UpdateDKK_Titles()
        {

        }

        //TODO write the logic for AddTitle
        public void AddTitle()
        {

        }

        //TODO write the logic to AddDKK_Titles
        public void AddDKK_Titles()
        {

        }

        //TODO write the logic to DeleteTitle
        public void DeleteTitle() { }

        //TODO write the logic to DeleteDKK_Titles
        public void DeleteDKK_Titles() { }

        public override string ToString()
        {
            string titles = "";
            foreach (Title title in Titles)
            {
                titles += title.ToString() + "\n";
            }

            foreach (DKK_Title title in DKK_Titles)
            {
                titles += title.ToString() + "\n";
            }

            return $"Navn: {this.Name} \n Stambogsnummer: {this.PedigreeNr} \n Køn: {this.Sex} \n Fødselsdato: {this.DateOfBirth}\n Farve: {this.Color}\n HD: {this.HD}, AD: {this.AD}, HZ: {this.HZ}, SP: {this.SP} \n Titler: {titles}";


        }
    }
}
