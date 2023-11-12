
namespace HundeKennelTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CreatDogWithTwoParameter()
        {
            // Arrange
            string pedigreeNr = "123456";
            string name = "Buddy";

            // Create an instance of the DogRepository class (assuming you have one).
            DogRepo dogRepository = new DogRepo();

            // Act
            string result = dogRepository.CreateDog(pedigreeNr, name);

            // Assert
            // You can add assertion code to verify the result, such as checking if the result is as expected or if there are no exceptions thrown during the execution.
            // For example:
            Assert.AreEqual("Dog record inserted successfully.", result);
        }
    }
}