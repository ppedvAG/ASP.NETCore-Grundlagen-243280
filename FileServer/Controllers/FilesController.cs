﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FileServer.Controllers
{
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet]
        [Route("download/{fileName}")]
        public IResult Download(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), Program.FILE_PATH, fileName);
            if (System.IO.File.Exists(path))
            {
                return Results.File(path, MediaTypeNames.Application.Octet, fileName);
            }
            return Results.NotFound("File not found");
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IResult> Upload()
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (file != null && file.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), Program.FILE_PATH, file.FileName);
                using var stream = System.IO.File.Create(path);
                await file.CopyToAsync(stream);

                var url = $"{Request.Scheme}://{Request.Host}/{Program.FILE_PATH}/{file.FileName}";
                return Results.Content(url);
            }

            return Results.BadRequest("No files were uploaded.");
        }
    }
}