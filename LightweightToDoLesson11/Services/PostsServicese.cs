using LightweightToDoLesson11.Data;
using LightweightToDoLesson11.Models;
using LightweightToDoLesson11.Services.Interfaces;

namespace LightweightToDoLesson11.Services
{
    public class PostsServicese : IPostsServicese
    {
        private MyDataContexte _dataContexte;
        public PostsServicese(MyDataContexte dateContexte)
        {
            _dataContexte = dateContexte;
        }
        public PostModele Create(PostModele model)
        {
            var lastPost = _dataContexte.Posts.LastOrDefault();    
            int newId = lastPost is null ? 1 : lastPost.Id +1;

            model.Id = newId;
            _dataContexte.Posts.Add(model);

            return model;   
        }

        public void Delete(int id)
        {
            var modelToDelete = _dataContexte.Posts.FirstOrDefault(x => x.Id == id);
            _dataContexte.Posts.Remove(modelToDelete);
        }

        public PostModele Get(int id)
        {
            return _dataContexte.Posts.FirstOrDefault(x => x.Id == id);
        }

        public List<PostModele> Get()
        {

            return _dataContexte.Posts;
        }

        public PostModele Update(PostModele model)
        {
            var modelToUpdate = _dataContexte.Posts.FirstOrDefault(x => x.Id == model.Id);
            modelToUpdate.Header = model.Header;
            modelToUpdate.Text = model.Text;

            return modelToUpdate;
        }
    }
}
