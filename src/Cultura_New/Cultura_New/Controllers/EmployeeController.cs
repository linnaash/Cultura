using BusinessLogic.Authorization;
using BusinessLogic.Models.Accounts;
using BusinessLogic.Services;
using Cultura_New.Authorization;
using Cultura_New.Contracts.Employee;                                                                                                                                                                                                                                                                                                                 
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Cultura_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// Получить список всех пользователей
        /// </summary>
        /// <returns>Список всех пользователей</returns>
        [Authorize(Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var emplyees = await _employeeService.GetAll();
            //var response = employee.Adapt<IEnumerable<GetEmployeeResponse>>();
            //return Ok(response);
            return Ok(await _employeeService.GetAll());
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
            if (id != employee.EmployeeId && employee.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var result = await _employeeService.GetById(id);

            var response = result.Adapt<GetEmployeeResponse>();
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
        public async Task<IActionResult> Add(CreateEmployeeRequest request)
        {
            var userDto = request.Adapt<Employee>();
            await _employeeService.Create(userDto);
            return Ok(new { message = "Пользователь успешно создан" });
        }
        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     PUT /Employee
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
        public async Task<IActionResult> Update(int id, UpdateEmployeeRequest request) 
        {
            if (id != request.EmployeeId && !User.IsInRole("Admin"))
                return Unauthorized(new { message = "Unauthorized" });

            var existingUser = await _employeeService.GetById(id);
            if (existingUser == null)
                return NotFound(new { message = "Пользователь не найден" });

            var updatedUser = request.Adapt(existingUser);
            await _employeeService.Update(updatedUser);

            var response = updatedUser.Adapt<GetEmployeeResponse>();
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
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            await _employeeService.Delete(id);
            return Ok(new { message = "Пользователь успешно удален" });



        }
    }
}
