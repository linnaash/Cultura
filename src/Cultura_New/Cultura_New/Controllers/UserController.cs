using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Cultura_New.Contracts.User;
using BusinessLogic.Models.Accounts;
using Cultura_New.Authorization;
using BusinessLogic.Authorization;
using Domain.Models;
using Mapster;
using Domain.Entities;
using BusinessLogic.Services;

namespace Cultura_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
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
        [Authorize(Role.Admin)]
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
            if (id != user.UserId && user.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

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
        ///         "login": "Alina Eeeee Krut",
        ///         "password": "passw167",
        ///         "firstname" : "Петров",
        ///         "lastname" : "Петров",
        ///         "middlename" : "Петрович"
        ///     }
        ///     
        /// </remarks>
        /// <param name="request">Данные для создания пользователя</param>
        /// <returns>Результат выполнения операции</returns>
        /// <response code="201">Пользователь успешно создан</response>
        /// <response code="400">Ошибка в данных запроса</response>
        [AllowAnonymous]
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
        ///         "login": "Alina Eeeee Krut",
        ///         "password": "passw167",
        ///         "firstname" : "Петров",
        ///         "lastname" : "Петров",
        ///         "middlename" : "Петрович"
        ///     }
        /// 
        /// </remarks>
        /// <param name="request">Обновленные данные пользователя</param>
        /// <returns>Результат выполнения операции</returns>
        /// <response code="200">Данные пользователя успешно обновлены</response>
        /// <response code="400">Ошибка в данных запроса</response>
        /// <response code="404">Пользователь с указанным идентификатором не найден</response>
        //public async Task<IActionResult> Update(UpdateUserRequest request)
        //{
        //    var existingUser = await _userService.GetById(request.UserId);
        //    var userDto = request.Adapt(existingUser);
        //    await _userService.Update(userDto);
        //    return Ok(new { message = "Данные пользователя успешно обновлены" });

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateUserRequest request)
        {
            if (id != request.UserId && !User.IsInRole("Admin"))
                return Unauthorized(new { message = "Unauthorized" });

            var existingUser = await _userService.GetById(id);
            if (existingUser == null)
                return NotFound(new { message = "Пользователь не найден" });

            var updatedUser = request.Adapt(existingUser);
            await _userService.Update(updatedUser);

            var response = updatedUser.Adapt<GetUserResponse>();
            return Ok(response);
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Результат выполнения операции</returns>
        /// <response code="200">Пользователь успешно удален</response>
        /// <response code="404">Пользователь с указанным идентификатором не найден</response>
        [Authorize(Role.Admin)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {

            await _userService.Delete(id);
            return Ok(new { message = "Пользователь успешно удален" });


        }
    }
}