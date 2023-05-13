using BEComicWeb.Data;
using BEComicWeb.Interface.ImageInterface;
using BEComicWeb.Model.ImageModel;

namespace BEComicWeb.Responsitory.ImageRepository
{
    public class ChapterImagesRepository :  IChapterImagesRepository
    {
        AppDbContext _dbContext = new();
        public List<ChapterImages> DeleteChapterImages(string chapter_id)
        {
            var res = _dbContext.ChapterImagesDb.Where(e => e.Chapter.Id == chapter_id).ToList();
            if (res != null)
            {
                _dbContext.ChapterImagesDb.RemoveRange(res);
                _dbContext.SaveChanges();
            }

            return res;
        }

        public List<ChapterImages> GetChapterImages(string chapter_id)
        {
            var res = _dbContext.ChapterImagesDb.Where(e => e.Chapter.Id == chapter_id).ToList();
            return res;
        }

        public List<ChapterImages> UpdateChapterImages(string chapter_id)
        {
            var res = _dbContext.ChapterImagesDb.Where(e => e.Chapter.Id == chapter_id).ToList();
            if (res != null) 
            {
                _dbContext.ChapterImagesDb.RemoveRange(res);
                _dbContext.SaveChanges();
            }
            
            return res;
        }

        public ChapterImages AddChapterImage(ChapterImages ChapterImage)
        {
            _dbContext.ChapterImagesDb.Add(ChapterImage);
            _dbContext.SaveChanges();
            return ChapterImage;
        }
    }
}
