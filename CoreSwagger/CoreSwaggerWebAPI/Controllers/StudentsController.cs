using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSwaggerWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreSwaggerWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //https://www.mediaclick.com.tr/blog/http-server-durum-hata-kodlari-ve-anlamlari
        //https://docs.microsoft.com/tr-tr/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.0&tabs=visual-studio


        /// <summary>
        /// Listeleme İşlemi.
        /// </summary>
        /// <returns>Tüm listeyi geri döndürü</returns>
        /// <response code="201">Returns List of Student </response>
        /// <response code="400">If the item is null</response>  
        [HttpGet("list")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult GetList()
        {
            return Ok(Student.GetList());

        }

        /// <summary>
        /// Student arama yapar Id ye göre boş gönderilme durumunda null değer döner
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}",Name= "Find")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public Student GetStudent(int id)
        {
            if (id != 0)
                return Student.GetList().FirstOrDefault(c => c.Id == id);
            return null;
        }

        /// <summary>
        /// ekleme yapar
        /// </summary>
        /// <param name="student"></param>
        [HttpPost("{Student}",Name="Add")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void AddStudent(Student student)
        {
            Student.GetList().Add(student);
        }

        [HttpDelete(template:"{Student}",Name="Remove")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void RemoveStudent(Student student)
        {
            Student.GetList().Remove(student);
        }

        [HttpDelete(template:"{id}",Name ="Delete")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void DeleteStudent(int id)
        {
            Student.GetList().Remove(GetStudent(id));
        }


        [HttpPut("{Student}", Name="Update")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Put(Student updateStudent)
        {
        }
    }
}