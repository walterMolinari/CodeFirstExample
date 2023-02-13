using FilmsMinimalAPI.Model;

namespace FilmsMinimalAPI.Services;

public interface IFilmService
{
    public Task<IResult> GetAll(FilmContext context);
    public Task<IResult> GetById(FilmContext context, int id);
    public Task<IResult> Create(FilmContext context,Film film);
    public Task<IResult> Update(FilmContext context, int id, Film filmImput);
    public Task<IResult> Delete(FilmContext context, int id);

}
