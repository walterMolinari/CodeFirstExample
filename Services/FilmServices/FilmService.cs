using FilmsMinimalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FilmsMinimalAPI.Services.FilmServices
{
    public class FilmService : IFilmService
    {
        
        public async Task<IResult> Create(FilmContext context, Film film)
        {
            context.Films.Add(film);
            await context.SaveChangesAsync();
            return TypedResults.Created($"/Film/{film.ID}",film);
        }

        public async Task<IResult> Delete(FilmContext context, int id)
        {
            if (await context.Films.FindAsync(id) is Film film)
            {
                context.Films.Remove(film);
                await context.SaveChangesAsync();
                return TypedResults.Ok(film);
            }
            return TypedResults.NotFound();
        }

        public async Task<IResult> GetAll(FilmContext context)
        {
            return TypedResults.Ok(await context.Films.ToArrayAsync());
        }

        public async Task<IResult> GetById(FilmContext context, int id)
        {
            return await context.Films.FindAsync(id)
                is Film film
                ? TypedResults.Ok(film)
                : TypedResults.NotFound();
        }

        public async Task<IResult> Update(FilmContext context, int id, Film filmInput)
        {
            var search = await context.Films.FindAsync(id);
            if (search is null) return TypedResults.NotFound();

            search.Title = filmInput.Title;
            search.Description = filmInput.Description;
            search.Year = filmInput.Year;
            search.Photo_url = filmInput.Photo_url;

            await context.SaveChangesAsync();
            return TypedResults.NoContent();
        }
    }
}
