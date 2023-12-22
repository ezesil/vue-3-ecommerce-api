using BlazorNet8Test.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorNet8Test.Controllers
{
    [Route("api/[controller]")]
    [RequireAntiforgeryToken]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<Movie> Values { get; set; } = new List<Movie>();
        public static Stopwatch sw = new Stopwatch();
        // GET: api/<ValuesController>
        [HttpGet]
        public string Get(int count)
        {
            if (Values != null)
            {
                Values.Clear();
                GC.Collect();
            }

            sw.Start();



            for(int i = 0; i < count; i++)
            {
                Values.Add(new Movie());
            }

            sw.Stop();
            var value = sw.Elapsed;
            var elapsedmsg = value.TotalMilliseconds > 1000 ? value.TotalSeconds + " s"
                            : value.TotalMilliseconds >= 1 ? value.TotalMilliseconds + " ms"
                            : value.TotalMilliseconds < 1 && value.TotalMilliseconds >= 0.001 ? value.TotalMicroseconds + " us"
                            : value.TotalMilliseconds < 0.001 ? value.TotalNanoseconds + " ns" : "";



            sw.Reset();
            return 
                $"Elapsed time: {elapsedmsg}\n" +
                $"Total items: {Values.Count}";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
