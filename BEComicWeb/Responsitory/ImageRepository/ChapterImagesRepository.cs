using BEComicWeb.Data;
using BEComicWeb.Interface.ImageInterface;
using BEComicWeb.Model.ImageModel;

namespace BEComicWeb.Responsitory.ImageRepository
{
    public class ChapterImagesRepository :  IChapterImagesRepository
    {
        AppDbContext _dbContext = new();
        public List<string> DeleteChapterImages(string chapter_id)
        {
            var res = _dbContext.ChapterImagesDb.Where(e => e.Chapter.Id == chapter_id).ToList();
            if (res != null)
            {
                _dbContext.ChapterImagesDb.RemoveRange(res);
                _dbContext.SaveChanges();
            }

            return res.Select(e => e.ImagePath).ToList();
        }

        public List<string> GetChapterImages(string chapter_id)
        {
            var res = _dbContext.ChapterImagesDb.Where(e => e.Chapter.Id == chapter_id).Select(e => e.ImagePath).ToList();
            return res;
        }

        public List<string> UpdateChapterImages(string chapter_id)
        {
            var res = _dbContext.ChapterImagesDb.Where(e => e.Chapter.Id == chapter_id).ToList();
            if (res != null) 
            {
                _dbContext.ChapterImagesDb.RemoveRange(res);
                _dbContext.SaveChanges();
            }
            
            return res.Select(e => e.ImagePath).ToList();
        }

        public ChapterImages AddChapterImage(ChapterImages ChapterImage)
        {
            _dbContext.ChapterImagesDb.Add(ChapterImage);
            _dbContext.SaveChanges();
            return ChapterImage;
        }
    }
}
