using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CourseLibrary
{
    [ApiController]
    public class AuthorsController :Controller
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
        }

        [HttpGet("api/authors")]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo= _courseLibraryRepository.GetAuthors();
            return new JsonResult(authorsFromRepo);
        }
    }
}
