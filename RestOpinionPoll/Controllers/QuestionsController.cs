using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestOpinionPoll.Models;
using RestOpinionPoll.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestOpinionPoll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private QuestionsRepos repos;

        public QuestionsController(QuestionsRepos repository)
        {
            repos = repository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Question>> Get([FromQuery] string? searchQuery)
        {
            var questions = repos.GetQuestions(searchQuery);

            if (questions == null || !questions.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(questions);
            }
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Question question)
        {

            try
            {
                Question createdQuestion = repos.AddQuestion(question);
                return Created("/" + createdQuestion.QuestionId, createdQuestion);
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id , [FromBody] Question question)
        {
            var updatedQuestion = repos.UpdateQuestion(id, question);
            if (updatedQuestion == null)
            {
                return NotFound();
            }
            else
            { 
                return Accepted();
            }
        }        

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedQuestion = repos.DeleteQuestion(id);
            if (deletedQuestion == null)
            {
                return NotFound();
            }
            
            return NoContent();
            
        }

        [HttpPost("SubmitAnswer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SubmitAnswer([FromBody] AnswerSubmission submission)
        {
            var question = repos.SubmitAnswer(submission.QuestionId, submission.Option);
            if (question == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(question);
            }
            
        }

        [HttpGet("GetActiveQuestions")]
        public IEnumerable<Question> GetActiveQuestions()
        {
            return repos.GetActiveQuestions();
        }



    }
}
