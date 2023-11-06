using LightweightToDoLesson11.Models;

namespace LightweightToDoLesson11.Services.Interfaces
{
    public interface IPostsServicese
    {
        PostModele Create(PostModele model);
        PostModele Update(PostModele model);
        PostModele Get(int id);
        List<PostModele> Get();
        void Delete(int id);
    }
}
