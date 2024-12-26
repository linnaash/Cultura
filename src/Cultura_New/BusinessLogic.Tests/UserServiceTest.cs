using BusinessLogic.Services;
using Domain.Interfaces;
using Moq;
using Domain.Models;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly EmployeeService service;
        private readonly Mock<IEmployeeRepository> userRepositoryMock;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMock = new Mock<IEmployeeRepository>();

            repositoryWrapperMoq.Setup(x => x.Employee)
                .Returns(userRepositoryMock.Object);

            service = new EmployeeService(repositoryWrapperMoq.Object);
        }
        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgument()
        {
            //act
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Employee>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(Employee employee)
        {
            //arrange
            var newEmployee = employee;

            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newEmployee));

            //assert
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Employee>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new Employee()
            {
                Firstname = "Test",
                Lastname = "Test",
                Middlename = "Test",
                BirthDate = DateTime.Now,
                Login = "Test",
                Email = "test@test.com",
                Password = ""
            };
            //act
            await service.Create(newUser);

            //assert
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Employee>()), Times.Once);

        }
        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] {new Employee() { Firstname="",Lastname="",Middlename="",BirthDate=DateTime.MaxValue,Login="",Email="",Password=""} },
                new object[] {new Employee() { Firstname="Test",Lastname="",Middlename="",BirthDate=DateTime.MaxValue,Login="",Email="",Password=""} },
                new object[] {new Employee() { Firstname="Test",Lastname="Test",Middlename="",BirthDate=DateTime.MaxValue,Login="",Email="",Password=""} }

            };
        }
    }
}
