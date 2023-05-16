using BEComicWeb.Data;
using BEComicWeb.Interface.ImageInterface;
using BEComicWeb.Model.ImageModel;
using Microsoft.EntityFrameworkCore;

namespace BEComicWeb.Responsitory.ImageRepository
{
    public class ChapterImagesRepository : IChapterImagesRepository
    {
        AppDbContext _dbContext = new();
        public List<ChapterImages> DeleteChapterImages(string chapter_id)
        {
            var res = _dbContext.ChapterImagesDb.Where(e => e.ChapterId == chapter_id).ToList();
            if (res != null)
            {
                _dbContext.ChapterImagesDb.RemoveRange(res);
                _dbContext.SaveChanges();
            }

            return res;
        }

        public List<ChapterImages> GetChapterImages(string chapter_id)
        {
            var res = _dbContext.ChapterImagesDb.Where(e => e.ChapterId == chapter_id).ToList();
            return res;
        }

        public async Task<List<ChapterImages>> UpdateChapterImages(string chapterId, List<ChapterImages> chapterImages)
        {
            var existingChapterImages = await _dbContext.ChapterImagesDb
                .Where(ci => ci.ChapterId == chapterId)
                .ToListAsync();

            foreach (var ci in chapterImages)
            {
                // check if the chapter image already exists
                var existingCi = existingChapterImages.FirstOrDefault(eci => eci.Id == ci.Id);
                if (existingCi != null)
                {
                    // update the order of the existing chapter image
                    existingCi.Order = ci.Order;
                }
                else
                {
                    // add a new chapter image
                    _dbContext.ChapterImagesDb.Add(ci);
                }
            }

            int maxOrder = chapterImages.Max(ci => ci.Order);
            var res = _dbContext.ChapterImagesDb.Where(ci => ci.ChapterId == chapterId && ci.Order > maxOrder).ToList();
            if (res != null)
            {
                _dbContext.ChapterImagesDb.RemoveRange(res);
                await _dbContext.SaveChangesAsync();
            }

            return chapterImages;
        }


        public ChapterImages AddChapterImage(ChapterImages ChapterImage)
        {
            _dbContext.ChapterImagesDb.Add(ChapterImage);
            _dbContext.SaveChanges();
            return ChapterImage;
        }
    }
}
