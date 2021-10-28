using Business.Repository.IRepository;
using DatabaseAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kindergarten_Api.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var allComments = await _commentRepository.GetAllKidComments();
            return Ok(allComments);
        }

        // Get single comment
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleComment(int id)
        {
            var comment = await _commentRepository.GetKidComment(id);
            if (comment == null)
            {
                return NotFound("There are NO comments for this kid");
            }
            return Ok(comment);
        }


        // Create (Add) comment
        [HttpPost]

        public async Task<IActionResult> CreateComment([FromBody] KidCommentDTO comment)
        {
            await _commentRepository.CreateKidComment(comment);

            //return Ok(await GetComments());
            return Ok();
        }


        // Update comment
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] KidCommentDTO comment)
        {
            //comment.KidId = 5;
            var updComment = await _commentRepository.UpdateKidComment(id, comment);
            if (updComment == null)
                return NotFound("Kid Comment wasn't found.");

            return Ok(await GetComments());
        }


        // Delete comment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var dbComment = await _commentRepository.GetKidComment(id);
            if (dbComment == null)
                return NotFound("Comment wasn't found.");

            await _commentRepository.DeleteKidComment(id);


            return Ok(await GetComments());
        }


    }
}
