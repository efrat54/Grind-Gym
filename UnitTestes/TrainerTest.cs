using Grind.Entities;
using Grind.Enums;

namespace UnitTestes
{
    public class TrainerTest
    {
        [Fact]
        public void ClassAddingTime()
        {
            // Arrange
            var trainer = new Trainer("111111111", "John", "Doe", new Address("jerusalem","irmiau","56"), "0444444444", GymClasses.Yoga, 3000);
            var newClass = new Class(GymClasses.Yoga, "yu", new Time(DayOfWeekEnum.Sunday,16,30), DifficultyLevel.Hard);

            // Act
            trainer.ClassAdding(newClass);

            // Assert
            // Assert - אנחנו משתמשים ב-Any וב-IsSameTime כדי לוודא שהזמן הוסף למערך
            Assert.True(trainer.classTimes.Any(time => time != null && time.IsSameTime(newClass.classTime)));
        }
        [Fact]
        public void GetTrainerById()
        {
            // Arrange
            var trainerId = "999999999";  // ID לא קיים

            // Act
            var result = DataContext.TrainersLst.FirstOrDefault(t => t.Id == trainerId);

            // Assert
            Assert.Null(result);  // אם המדריך לא נמצא, התוצאה צריכה להיות null
        }
        
    }
}