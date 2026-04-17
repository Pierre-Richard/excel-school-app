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
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentService.GetAllStudents();
                return Ok(students);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPost]

        public IActionResult CreateStudent([FromBody] CreateStudentDto student)
        {
            try
            {
                var newStudent = _studentService.CreateStudent(student);
                return Ok(newStudent);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent( int id)
        {
            try
            {
                _studentService.DeleteStudent(id);
                return Ok();
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id,[FromBody]UpdateStudentDto student)
        {
            try
            {
                // recuperer ma methode UpdateStudent de mon service
                var newStudent = _studentService.UpdateStudent(id, student);    
                //retourner mon StudentDto
                return Ok(newStudent);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                // recuperer ma methode GetStudentById de mon service
                var newStudent = _studentService.GetStudentById(id);    
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
