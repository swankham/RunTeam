using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunTeam.Api.Models;
using RunTeam.Application.Features.PersonalDetails.Commands.Create;
using RunTeam.Application.Features.PersonalDetails.Commands.DeleteById;
using RunTeam.Application.Features.PersonalDetails.Commands.Update;
using RunTeam.Application.Features.PersonalDetails.Queries.GetAll;
using RunTeam.Application.Features.PersonalDetails.Queries.GetById;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RunTeam.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonalDetailController : BaseApiController
    {
        IWebHostEnvironment _hostEnvironment;
        public PersonalDetailController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPersonalDetailsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllPersonalDetailsQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPersonalDetailByIdQuery { Id = id }));
        }

        // GET api/<controller>/GetBySrm/3
        [HttpGet("GetByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            return Ok(await Mediator.Send(new GetPersonalDetailByUserIdQuery { UserId = userId }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreatePersornalDetailCommand command)
        {
            var result = Ok(await Mediator.Send(command));
            return result;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id,[FromForm] UpdatePersonalDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            if (command.ImageFile != null)
                command.ImageName = await SaveImage(command.ImageFile, command.UserId);
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePersonalDetailByIdCommand { Id = id }));
        }

        [HttpGet("GetProfileImage/{fileName}")]
        public IActionResult GetProfileImage(string fileName)
        {
            Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(_hostEnvironment.ContentRootPath, "Images\\avatars", fileName));   //You can use your own method over here.         
            return File(b, "image/jpeg");
        }

        [HttpPost("Upload")]
        public async Task<string> Upload([FromForm] UploadFile obj)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(obj.Files.FileName).Take(10).ToArray()).Replace(' ', '-');
            if (obj.Files.Length > 0)
            {
                imageName = obj.FileName + "_" + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(obj.Files.FileName);
                var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\avatars", imageName);

                try
                {
                    if (!Directory.Exists(Path.Combine(_hostEnvironment.ContentRootPath, "Images\\avatars\\")))
                        Directory.CreateDirectory(Path.Combine(_hostEnvironment.ContentRootPath, "Images\\avatars\\"));

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        await obj.Files.CopyToAsync(fileStream);
                        fileStream.Flush();

                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return imageName;
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile, string userId)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');

            imageName = userId + "_" + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\avatars", imageName);

            try
            {
                if(!Directory.Exists(Path.Combine(_hostEnvironment.ContentRootPath, "Images\\avatars\\")))
                    Directory.CreateDirectory(Path.Combine(_hostEnvironment.ContentRootPath, "Images\\avatars\\"));

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                    fileStream.Flush();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return imageName;
        }
    }
}
