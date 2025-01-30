using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVLoader
{
   internal static class CSVConverter
    {
        public static string[]OutputCSV(ObservableCollection<Person> persons)
        {
            string[] tempArr = new string[persons.Count+1]; //+1 for header
            tempArr[0] = "Vorname;Nachname;Email;GebDat;ID";
            for (int count = 0; count < persons.Count; count++)
            {
                tempArr[count + 1] = $"{persons[count].Vorname};{persons[count].Nachname};{persons[count].Email};{persons[count].GebDat};{persons[count].ID}";

            }

            return tempArr;
        }
        public static ObservableCollection<Person> ImportCSV(string[] importText)
        {
            ObservableCollection<Person> tempList = new ObservableCollection<Person>();
            if (importText.Length > 1)
            {
                for (int count = 1; count< importText.Length; count++)
                {
                    string[] tempString = importText[count].Split(';');
                    Person tempPerson = new Person();
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
