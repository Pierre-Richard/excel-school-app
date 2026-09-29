using System;
using excel_school_app.DTOs;
using excel_school_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace excel_school_app.Controllers
{
    [ApiController]
    [Route("api/student")] 

    // recevoir la requête, appeler le service, retourner la réponse.   
    public class StudentController:ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudents();
                return Ok(students);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPost]

        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto student)
        {
            try
            {
                var newStudent = await _studentService.CreateStudent(student);
                return Ok(newStudent);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent( int id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                return Ok();
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id,[FromBody]UpdateStudentDto student)
        {
            try
            {
                // recuperer ma methode UpdateStudent de mon service
                var newStudent = await _studentService.UpdateStudent(id, student);    
                //retourner mon StudentDto
                return Ok(newStudent);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                // recuperer ma methode GetStudentById de mon service
                var newStudent = await _studentService.GetStudentById(id);    
                //retourner mon StudentDto
                return Ok(newStudent);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

    }
}
