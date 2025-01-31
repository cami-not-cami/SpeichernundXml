using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CSVLoader
{
   internal static class CSVConverter
    {
        public static string[]OutputCSV(ObservableCollection<Person> persons,string separator)
        {
            
            
            string[] tempArr = new string[persons.Count+1]; //+1 for header
            tempArr[0] = $"Vorname{separator}Nachname{separator}Email{separator}GebDat{separator}ID";
            for (int count = 0; count < persons.Count; count++)
            {
                tempArr[count + 1] = $"{persons[count].Vorname}{separator}" +
                             $"{persons[count].Nachname}{separator}" +
                             $"{persons[count].Email}{separator}" +
                             $"{persons[count].GebDat}{separator}" +
                             $"{persons[count].ID}";

            }

            return tempArr;
        }
        public static ObservableCollection<Person> ImportCSV(string[] importText,string separator)
        {
            
            ObservableCollection<Person> tempList = new ObservableCollection<Person>();
            if (importText.Length > 1)
            {
                for (int count = 1; count< importText.Length; count++)
                {
                    //out of bounds error only if separator isnt chosen at load because substring doesnt exist 
                    Person tempPerson = new Person();
                    string[] tempString = importText[count].Split(separator);
                    if (tempString.Length != 5)
                    {
                        throw new FormatException("CSV im falschen Format oder Leer");
                    }

                        tempPerson.Vorname = tempString[0];
                        tempPerson.Nachname = tempString[1];
                        tempPerson.Email = tempString[2];
                        tempPerson.GebDat = DateTime.Parse(tempString[3]);
                        int.TryParse(tempString[4], out int result);
                        tempPerson.ID = result;
                        tempList.Add(tempPerson);
                    
                }
                
            }
            return tempList;
        }
    }
}
