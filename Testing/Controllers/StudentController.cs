using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet("Student/GetStudentDetails/{id}")]
        public JsonResult GetStudentDetails(int Id)
        {
            StudentRepository repository = new();
            Student studentDetails = repository.GetStudentById(Id);
            return Json(studentDetails);
        }
        [HttpGet("Student/GetStudentDetailsByBranch/{id}")]
        public JsonResult GetStudentDetailsByBranch(string Branch)
        {
            StudentRepository repository = new();
            IEnumerable<Student> studentDetails = repository.GetAllStudentByBranch(Branch);
            return Json(studentDetails);
        }

        [HttpPost("Student/CreateStudent")]
        public JsonResult CreateStudent([FromBody] CreateStudentRequest request)
        {
            StudentRepository repository = new();
            Student newStudent = repository.CreateStudent(request.Name, request.Branch, request.Section, request.Gender);

            if (newStudent != null)
            {
                return Json(new { Success = true, Student = newStudent });
            }

            return Json(new { Success = false, Message = "Failed to create student" });
        }


        [HttpPut("Student/UpdateStudentNameById/{id}")]
        public JsonResult UpdateStudentNameById(int id, [FromBody] UpdateStudentRequest request)
        {
            StudentRepository _repository = new();

            Student studentDetails = _repository.UpdateStudentNameById(id, request.NewName,request.NewBranch);
            if (studentDetails == null)
            {
                return Json(new { Success = false, Message = "Student not found" });
            }

            return Json(new { Success = true, Student = studentDetails });
        }

        [HttpDelete("Student/DeleteStudentById/{id}")]
        public JsonResult DeleteStudentById(int id)
        {
            StudentRepository repository = new StudentRepository();
            bool result = repository.DeleteStudentById(id);
            if (result)
            {
                return Json(new { Success = true, Message = "Student deleted successfully" });
            }
            return Json(new { Success = false, Message = "Student not found" });
        }

    }
}
