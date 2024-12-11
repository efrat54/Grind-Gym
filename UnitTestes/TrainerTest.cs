//using Grind.Controllers;
//using Grind.Core.Entities;
//using Grind.Core.Enums;

//namespace UnitTestes.Test
//{
//    public class TrainerTest
//    {
//        FakeDataContext fakeDataContext;
//        [Fact]
//        public void ClassAddingTime()//-POST ����� ������ ����� ������ �"� �����
//        {
//            // Arrange
//            var trainer = new Trainer("111111111", "John", "Doe", new Address("jerusalem", "irmiau", "56"), "0444444444", GymClasses.Yoga, 3000);
//            var newClass = new Class(GymClasses.Yoga, "yu", new Time(DayOfWeekEnum.Sunday, 16, 30), DifficultyLevel.Hard);

//            // Act
//            trainer.ClassAdding(newClass);

//            // Assert
//            // Assert - ����� ������� �-Any ��-IsSameTime ��� ����� ����� ���� �����
//            Assert.True(trainer.classTimes.Any(time => time != null && time.IsSameTime(newClass.classTime)));
//        }
//        [Fact]
//        public void GetTrainerById()//GET
//        {
//            // Arrange
//            var trainerId = "999999999";  // ID �� ����

//            // Act
//            var result = fakeDataContext.TrainersLst.FirstOrDefault(t => t.Id == trainerId);

//            // Assert
//            Assert.Null(result);  // �� ������ �� ����, ������ ����� ����� null


//        }
//        //post
//        [Fact]
//        public void AddNewTrainer()
//        {
//            // Arrange
//            var newTrainer = new Trainer("123456789", "Jane", "Doe", new Address("Tel Aviv", "Main Street", "10"), "0501234567", GymClasses.Pilates, 2500);

//            // Act
//            new TrainersController(fakeDataContext).Post(newTrainer);  // ����� �������� POST �� ����� ���

//            // Assert
//            var addedTrainer = fakeDataContext.TrainersLst.FirstOrDefault(t => t.Id == newTrainer.Id);  // ������ �� ������ ������
//            Assert.NotNull(addedTrainer);  // �� ������ ����� �����, ��� �� ���� ����� null
//        }
//        //put
//        [Fact]
//        public void UpdateTrainerInfo()
//        {
//            // Arrange
//            var trainerToUpdate = new Trainer("111111111", "John", "Doe", new Address("Jerusalem", "Irmiya", "56"), "0444444444", GymClasses.Yoga, 3000);
//            fakeDataContext.TrainersLst.Add(trainerToUpdate);  // ������� �� ������ ��� ����� ����� ����
//            var updatedTrainer = new Trainer("111111111", "John", "Smith", new Address("Jerusalem", "King Street", "99"), "0505555555", GymClasses.Yoga, 3500);  // ������ ���� ������

//            // Act
//            new TrainersController(fakeDataContext).Put(updatedTrainer);  // ����� �������� PUT ������

//            // Assert
//            var result = fakeDataContext.TrainersLst.FirstOrDefault(t => t.Id == trainerToUpdate.Id);  // ������ �� ������ �������
//            Assert.NotNull(result);  // ������ �� ���� ����� null
//            Assert.Equal("John Smith", result.FirstName + " " + result.LastName);  // ���� ���� ����
//            Assert.Equal(3500, result.monthlySalary);  // ��� ����� ������
//        }
//        //DELETE
//        [Fact]
//        public void DeleteTrainer()
//        {
//            // Arrange
//            var trainerToDelete = new Trainer("222222222", "Mark", "Twain", new Address("New York", "5th Ave", "1"), "0533333333", GymClasses.Boxing, 4000);
//            fakeDataContext.TrainersLst.Add(trainerToDelete);  // ������� �� ������ ��� ����� ����� ����

//            // Act
//            new TrainersController(fakeDataContext).Delete("222222222");  // ����� �������� DELETE

//            // Assert
//            var deletedTrainer = fakeDataContext.TrainersLst.FirstOrDefault(t => t.Id == trainerToDelete.Id);  // ������ �� ������
//            Assert.Null(deletedTrainer);  // �� ������ ���� �����, ��� �� ���� ������� ������
//        }

//    }
//}