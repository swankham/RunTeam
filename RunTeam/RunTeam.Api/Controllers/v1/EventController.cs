using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunTeam.Application.Features.Events.Commands.Create;
using RunTeam.Application.Features.Events.Commands.DeleteById;
using RunTeam.Application.Features.Events.Commands.Update;
using RunTeam.Application.Features.Events.Queries.GetAll;
using RunTeam.Application.Features.Events.Queries.GetById;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RunTeam.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EventController : BaseApiController
    {
        IWebHostEnvironment _hostEnvironment;
        public EventController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllEventsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllEventsQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetEventByIdQuery { Id = id }));
        }

        [HttpGet("GetEventImage")]
        public IActionResult GetEventImage(string eventCode, string fileName)
        {
            Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(_hostEnvironment.ContentRootPath, "Images\\events", eventCode, fileName));   //You can use your own method over here.         
            return File(b, "image/jpeg");
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateEventCommand command)
        {
            var result = Ok(await Mediator.Send(command));
            return result;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromForm] UpdateEventCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            if (command.ImageFile != null)
                command.ImageName = await SaveImage(command.ImageFile, command.EventCode);

            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteEventByIdCommand { Id = id }));
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile, string eventCode)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');

            imageName = eventCode + "_" + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\events", eventCode, imageName);

            try
            {
                if (!Directory.Exists(Path.Combine(_hostEnvironment.ContentRootPath, "Images\\events\\", eventCode)))
                    Directory.CreateDirectory(Path.Combine(_hostEnvironment.ContentRootPath, "Images\\events\\", eventCode));

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
