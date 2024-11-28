using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Cultura_New.Contracts.User;
using Domain.Models;
using Mapster;

namespace Cultura_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Получить список всех пользователей
        /// </summary>
        /// <returns>Список всех пользователей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            var response = users.Adapt<IEnumerable<GetUserResponse>>();
            return Ok(response);
        }
        /// <summary>
        /// Получить данные пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Данные пользователя</returns>
        /// <response code="200">Пользователь найден</response>
        /// <response code="404">Пользователь с указанным идентификатором не найден</response>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);

            var response = result.Adapt<GetUserResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Users
        ///     {
        ///         "username": "example_user",
        ///         "passwordHash": "hashed_password",
        ///         "role": "Admin",
        ///         "employeeId": null
        ///     }
        /// Поле "employeeId" является необязательным. Если не указано, значение будет null.
        /// </remarks>
        /// <param name="request">Данные для создания пользователя</param>
        /// <returns>Результат выполнения операции</returns>
        /// <response code="201">Пользователь успешно создан</response>
        /// <response code="400">Ошибка в данных запроса</response>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Create(userDto);
            return Ok(new { message = "Пользователь успешно создан" });
        }
        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     PUT /Users
        ///     {
        ///         "userId": 1,
        ///         "username": "updated_user",
        ///         "passwordHash": "updated_hashed_password",
        ///         "role": "User",
        ///         "employeeId": 2
        ///     }
        /// Поле "employeeId" является необязательным. Если не указано, значение останется null.
        /// </remarks>
        /// <param name="request">Обновленные данные пользователя</param>
        /// <returns>Результат выполнения операции</returns>
        /// <response code="200">Данные пользователя успешно обновлены</response>
        /// <response code="400">Ошибка в данных запроса</response>
        /// <response code="404">Пользователь с указанным идентификатором не найден</response>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var existingUser = await _userService.GetById(request.UserId);
            var userDto = request.Adapt(existingUser);
            await _userService.Update(userDto);
            return Ok(new { message = "Данные пользователя успешно обновлены" });
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Результат выполнения операции</returns>
        /// <response code="200">Пользователь успешно удален</response>
        /// <response code="404">Пользователь с указанным идентификатором не найден</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok(new { message = "Пользователь успешно удален" });
        }
    }
}
