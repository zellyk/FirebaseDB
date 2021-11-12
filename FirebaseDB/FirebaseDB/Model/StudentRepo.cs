using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;

namespace FirebaseDB.Model
{
    public class StudentRepo
    {
        //Add base url, your database url from Firebase website
        FirebaseClient firebaseClient =
        new FirebaseClient
        ("https://pet-clinic-62464-default-rtdb.firebaseio.com/");
        public async Task<bool> Save(Student student)
        {
            //Save student data to the Student node in the Firebase
            //Create a new one if it does not exist
            var data = await firebaseClient.Child(nameof(Student)).
            PostAsync(JsonConvert.SerializeObject(student));

            return !string.IsNullOrEmpty(data.Key);

            //if (!String.IsNullOrEmpty(data.Key))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public async Task<List<Student>> GetAll()
        {
            //reading the firebaseClient.Child to fill/create the list
            return (await firebaseClient.
            Child(nameof(Student)).OnceAsync<Student>()).Select(
            item => new Student
            {
                LastName = item.Object.LastName,
                FirstName = item.Object.FirstName,
                Email = item.Object.Email,
                Phone = item.Object.Phone,
                SID = item.Object.SID
            }).ToList();
        }
    }
}