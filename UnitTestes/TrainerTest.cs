//using Grind.Controllers;
//using Grind.Core.Entities;
//using Grind.Core.Enums;

//namespace UnitTestes.Test
//{
//    public class TrainerTest
//    {
//        FakeDataContext fakeDataContext;
//        [Fact]
//        public void ClassAddingTime()//-POST בדיקה להוספת שיעור למדריך ע"פ זמנים
//        {
//            // Arrange
//            var trainer = new Trainer("111111111", "John", "Doe", new Address("jerusalem", "irmiau", "56"), "0444444444", GymClasses.Yoga, 3000);
//            var newClass = new Class(GymClasses.Yoga, "yu", new Time(DayOfWeekEnum.Sunday, 16, 30), DifficultyLevel.Hard);

//            // Act
//            trainer.ClassAdding(newClass);

//            // Assert
//            // Assert - אנחנו משתמשים ב-Any וב-IsSameTime כדי לוודא שהזמן הוסף למערך
//            Assert.True(trainer.classTimes.Any(time => time != null && time.IsSameTime(newClass.classTime)));
//        }
//        [Fact]
//        public void GetTrainerById()//GET
//        {
//            // Arrange
//            var trainerId = "999999999";  // ID לא קיים

//            // Act
//            var result = fakeDataContext.TrainersLst.FirstOrDefault(t => t.Id == trainerId);

//            // Assert
//            Assert.Null(result);  // אם המדריך לא נמצא, התוצאה צריכה להיות null


//        }
//        //post
//        [Fact]
//        public void AddNewTrainer()
//        {
//            // Arrange
//            var newTrainer = new Trainer("123456789", "Jane", "Doe", new Address("Tel Aviv", "Main Street", "10"), "0501234567", GymClasses.Pilates, 2500);

//            // Act
//            new TrainersController(fakeDataContext).Post(newTrainer);  // קריאה לפונקציה POST עם מדריך חדש

//            // Assert
//            var addedTrainer = fakeDataContext.TrainersLst.FirstOrDefault(t => t.Id == newTrainer.Id);  // מחפשים אם המדריך התווסף
//            Assert.NotNull(addedTrainer);  // אם המדריך נוסיף כראוי, הוא לא אמור להיות null
//        }
//        //put
//        [Fact]
//        public void UpdateTrainerInfo()
//        {
//            // Arrange
//            var trainerToUpdate = new Trainer("111111111", "John", "Doe", new Address("Jerusalem", "Irmiya", "56"), "0444444444", GymClasses.Yoga, 3000);
//            fakeDataContext.TrainersLst.Add(trainerToUpdate);  // מוסיפים את המדריך כדי שנוכל לעדכן אותו
//            var updatedTrainer = new Trainer("111111111", "John", "Smith", new Address("Jerusalem", "King Street", "99"), "0505555555", GymClasses.Yoga, 3500);  // המדריך לאחר העדכון

//            // Act
//            new TrainersController(fakeDataContext).Put(updatedTrainer);  // קריאה לפונקציה PUT לעדכון

//            // Assert
//            var result = fakeDataContext.TrainersLst.FirstOrDefault(t => t.Id == trainerToUpdate.Id);  // מחפשים את המדריך המעודכן
//            Assert.NotNull(result);  // המדריך לא אמור להיות null
//            Assert.Equal("John Smith", result.FirstName + " " + result.LastName);  // וודא שהשם שונה
//            Assert.Equal(3500, result.monthlySalary);  // שכר חודשי מעודכן
//        }
//        //DELETE
//        [Fact]
//        public void DeleteTrainer()
//        {
//            // Arrange
//            var trainerToDelete = new Trainer("222222222", "Mark", "Twain", new Address("New York", "5th Ave", "1"), "0533333333", GymClasses.Boxing, 4000);
//            fakeDataContext.TrainersLst.Add(trainerToDelete);  // מוסיפים את המדריך כדי שנוכל למחוק אותו

//            // Act
//            new TrainersController(fakeDataContext).Delete("222222222");  // קריאה לפונקציה DELETE

//            // Assert
//            var deletedTrainer = fakeDataContext.TrainersLst.FirstOrDefault(t => t.Id == trainerToDelete.Id);  // מחפשים את המדריך
//            Assert.Null(deletedTrainer);  // אם המדריך נמחק כראוי, הוא לא אמור להתקיים ברשימה
//        }

//    }
//}