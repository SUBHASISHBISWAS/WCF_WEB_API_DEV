using AutoMapper;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Services;
using CourseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseLibrary
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();

            /*
            var authors = new List<AuthorDto>();

            authorsFromRepo.ToList().ForEach(author =>
            {

                authors.Add(new AuthorDto()
                {
                    Id = author.Id,
                    Name = $"{author.FirstName} {author.LastName}",
                    MainCategory = author.MainCategory,
                    Age = author.DateOfBirth.GetCurrentAge()
                });
            });

            */

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var authorsFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            
            return Ok(_mapper.Map<AuthorDto>(authorsFromRepo));
        }
    }
}
