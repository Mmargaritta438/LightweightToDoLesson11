using LightweightToDoLesson11.Models;

namespace LightweightToDoLesson11.Data
{
    public class MyDataContexte
    {
        public List<PostModele> Posts { get; set; } 

        public MyDataContexte() 
        {
            Posts = new List<PostModele>(); 
        }
    }
}
