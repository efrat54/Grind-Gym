using System.Net;
using System.Security.Claims;

namespace TrainerTest
{
    public class TrainerTest
    {
        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public void ClassAdding_ShouldAddClass_WhenClassIsValid()
        {
            // Arrange
            var trainer = new Trainer("1", "John", "Doe", new Address("Main St", "City", "12345"), "555-1234", GymClasses.Yoga, 3000);
            var newClass = new Class { className = GymClasses.Yoga, classTime = new Time(10, new TimeSpan(14, 30, 0)), cost = 50, numOfParticipants = 10 };

            // Act
            trainer.ClassAdding(newClass);

            // Assert
            Assert.Contains(newClass.classTime, trainer.classTimes);
        }
    }
}