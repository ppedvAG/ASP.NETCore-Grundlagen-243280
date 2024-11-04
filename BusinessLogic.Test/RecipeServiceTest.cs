using BusinessLogic.Data;
using BusinessLogic.Services;

namespace BusinessLogic.Test
{
    [TestClass]
    public class RecipeServiceTest
    {
        [TestMethod]
        public void FromJsonFile_ReadFromFile_ReturnsListOfRecipes()
        {
            var result = RecipeReader.FromJsonFile();

            // Assert
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Count > 0, "Die Liste mit Rezepten sollte nicht leer sein.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das Rezept sollte mindestens ein MealType besitzen.");
        }

        // Weiter TestMethoden denkbar welche den Fails Case betrachten
        // ...

        [TestMethod]
        public void GetRecipes_FromService_ReturnsListOfRecipes()
        {
            // Arrange
            var service = new RecipeService();

            // Act
            var result = service.GetRecipes();

            // Assert
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Count > 0, "Die Liste mit Rezepten sollte nicht leer sein.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das Rezept sollte mindestens ein MealType besitzen.");
        }
    }
}