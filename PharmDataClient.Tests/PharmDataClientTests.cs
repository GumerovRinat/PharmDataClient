using FluentAssertions;
using PharmDataClient.Exceptions;
using PharmDataClient.Models.Departments;

namespace PharmDataClient.Tests
{
    public class PharmDataClientTests
    {
        [Fact]
        public async Task SaveAndReadGoodsFromFile_AuthInfo_OperationSuccess()
        {
            //Arrange
            PharmDataApiClient client = new PharmDataApiClient(new RestClient());

            var login = "demo";
            var password = "demo";
            var role = "Agent";

            List<Good> goodsFromApi = new List<Good>();
            List<Good> goodsFromFile = new List<Good>();

            //Act
            try
            {
                if (!await client.AuthenticateAsync(login, password, role))
                    throw new PharmDataApiException("Ошибка на этапе аутентификации");

                var userDepartments = await client.GetUserDepartmentsAsync();
                if (userDepartments.Count == 0)
                    throw new PharmDataApiException("Не найдены подразделения для выбранного пользователя");

                int indx = Random.Shared.Next(0, userDepartments.Count - 1);

                goodsFromApi = await client.GetGoodsByDepartmentId(userDepartments[indx].Department.Id);
                if (goodsFromApi.Count == 0)
                    throw new PharmDataApiException("Не найдена номенклатура по выбранному подразделению");

                string fileName = $"Goods_depId_{userDepartments[indx].Department.Id}.json";
                FileDataWorker worker = new FileDataWorker(fileName);
                await worker.SaveData(goodsFromApi);

                goodsFromFile = await worker.LoadData<List<Good>>();
            }
            catch (Exception ex)
            {

                throw;
            }


            //Assert
            goodsFromApi.Should().BeEquivalentTo(goodsFromFile);
        }


        [Fact]
        public async Task SaveAndReadGoodsFromFile_IncorrectAuthInfo_ThrowException()
        {
            //Arrange
            PharmDataApiClient client = new PharmDataApiClient(new RestClient());

            var login = "demo";
            var password = "";
            var role = "Agent";

            // Act & Assert
            await Assert.ThrowsAsync<PharmDataApiException>(async () =>
            {
                await client.AuthenticateAsync(login, password, role);
            });
        }
    }
}